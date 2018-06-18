using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiDAR_Classification
{
    class Feature
    {
        public static string MCCLIDAR_PATH = string.Format(@"{0}\MCC-LIDAR\bin", Application.StartupPath);
        public static string LASTOOL_PATH = string.Format(@"{0}\LAStools\bin", Application.StartupPath);

        internal static void Kmean(string input_path, string output_path, TextBox log)
        {
            // Khởi tạo
            int number_of_cluster = int.Parse(GetSettingParams("cluster"));

            Logging.Write(log, "*** K-Mean Algorithm ***");
            Logging.Write(log, string.Format("number_of_cluster: {0}", number_of_cluster));
            Logging.Write(log, string.Format("input_path: {0}", input_path));
            Logging.Write(log, string.Format("output_path: {0}", output_path));

            HeightObject[] height_object = GetHeightObjectFromFile(input_path);

            Logging.Write(log, string.Format("height_object_length: {0}", height_object.Length));

            // Khởi tạo ngâu nhiên các trọng tâm;
            HeightObject[] centroid_object = GetRandomCentroid(height_object, number_of_cluster);
            HeightObject[] init_centroid_object = centroid_object;

            Logging.Write(log, "init_centroid_object: ", init_centroid_object);

            centroid_object = KmeanAlgorithm(height_object, centroid_object, log);

            Logging.Write(log, "new_centroid_object: ", centroid_object);

            // Lưu vào file thông tin
            // - Đường dẫn lưu
            // - Trọng tâm khởi tạo
            // - Trọng tâm tính được
            // - Danh sách các điểm Nhãn 2 và Cụm
            SaveFile(input_path, output_path,
                init_centroid_object,
                centroid_object,
                height_object);
        }

        private static void SaveFile(
            string input_path,
            string output_path, 
            HeightObject[] init_centroid_object, 
            HeightObject[] centroid_object, 
            HeightObject[] height_object)
        {
            string las2txt_file = input_path.Substring(0, (input_path.Length - 3)) + "txt";
            List<string> output_lines = new List<string>();
            StreamWriter csv_file = new StreamWriter(output_path);

            // Đọc file text 
            FileStream fs = File.Open(las2txt_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BufferedStream bs = new BufferedStream(fs);
            StreamReader sr = new StreamReader(bs);
            string line;
            long i = 0;
            while ((line = sr.ReadLine()) != null) {
                var line_split = line.Split(' ');
                if (line_split[3] == "2") {
                    output_lines.Add(
                        string.Format("{0} {1}", line, height_object[i].Cluster));
                    i++;
                }
            }

            // Lưu file csv
            // Tâm khởi tạo
            string str_init_center = "";
            string label = "";
            int l = 0;
            foreach (var item in init_centroid_object) {
                str_init_center += item.Value + ",";
                label += l + ",";
                l++;
            }
            str_init_center = str_init_center.Substring(0, str_init_center.Length - 1);
            csv_file.WriteLine("init centroid");
            csv_file.WriteLine("cluster label," + label);
            csv_file.WriteLine(string.Format("{0} values,", centroid_object.Length) + str_init_center);

            // Tâm kết quả
            string str_result_center = "";
            foreach (var item in centroid_object)
                str_result_center += item.Value + ",";
            str_result_center = str_result_center.Substring(0, str_result_center.Length - 1);
            csv_file.WriteLine("result centroid");
            csv_file.WriteLine("cluster label," + label);
            csv_file.WriteLine(string.Format("{0} values,", centroid_object.Length) + str_result_center);

            // Danh sách điểm và cụm
            csv_file.WriteLine("point and cluster");
            csv_file.WriteLine("x,y,z,mcc,cluster label");
            foreach (var out_line in output_lines)
                csv_file.WriteLine(out_line.Replace(" ",","));

            Process.Start(output_path);   
        }


        private static HeightObject[] KmeanAlgorithm(HeightObject[] height_object, 
                                           HeightObject[] centroid_object, TextBox log)
        {
            // Khởi tạo trọng tâm mới là rỗng
            HeightObject[] new_cent_object = new HeightObject[centroid_object.Length];

            // Với mỗi điểm tính trọng tâm gần nó nhất và gán cụm
            foreach (var ho in height_object)
                ho.Cluster = GetNearestCluster(ho, centroid_object);

            // Tính lại trọng tâm
            for (int i = 0; i < centroid_object.Length; i++)
                new_cent_object[i] = CalulateNewCentroid(i, height_object);
            //Logging.Write(log, "process: ", new_cent_object);

            // Nếu trọng tâm chưa trùng nhau, tiếp tục tính trọng tâm
            // Không thì thôi
            if (!EqualsCentroid(centroid_object, new_cent_object))
                return KmeanAlgorithm(height_object, new_cent_object, log);
            else
                return new_cent_object;
        }

        internal static void Mcc(string input_path, string output_path, TextBox log)
        {
            string cmd = "cmd.exe";
            string spacing = GetSettingParams("spacing");
            string threshold = GetSettingParams("threshold");
            string args = string.Format(
                "/k \"{0}\\set_path.bat & mcc-lidar -s {3} -t {4} {1} {2}\"", 
                MCCLIDAR_PATH, input_path, output_path, spacing, threshold);
            Process.Start(cmd, args);
        }

        internal static void LasView(string input_path, TextBox log)
        {
            string lasview = LASTOOL_PATH + "\\lasview.exe";
            string args = string.Format("-i {0}", input_path);
            Process.Start(lasview, args).WaitForExit();
        }

        internal static string Las2txt(string input_path)
        {
            string las2txt = LASTOOL_PATH + "\\las2txt.exe";
            string args = string.Format("-i \"{0}\" -parse xyzc", input_path);
            Process.Start(las2txt, args).WaitForExit();
            return input_path.Substring(0, (input_path.Length - 3)) + "txt";
        }

        private static string GetSettingParams(string key)
        {
            return Properties.Settings.Default[key].ToString();
        }

        private static HeightObject[] GetHeightObjectFromFile(string input_path)
        {
            // Lấy ra độ cao của những điểm được gán nhãn là 2
            // Khai báo
            var las2txt_file = Las2txt(input_path);
            var heightObjects = new List<HeightObject>();

            // Đọc file
            FileStream fs = File.Open(las2txt_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BufferedStream bs = new BufferedStream(fs);
            StreamReader sr = new StreamReader(bs);
            string line;
            while ((line = sr.ReadLine()) != null) {
                var line_split = line.Split(' ');
                if (line_split[3] == "2") {
                    var height = float.Parse(line_split[2]);
                    var Object = new HeightObject(height);
                    heightObjects.Add(Object);
                }
            }
            return heightObjects.ToArray();
        }

        private static HeightObject[] GetRandomCentroid(HeightObject[] height_object, int number_of_cluster)
        {
            HeightObject[] centroid = new HeightObject[number_of_cluster];
            Random random = new Random();
            int random_value = random.Next(1, height_object.Length / (number_of_cluster + 1) - 1);

            for (int i = 0; i < number_of_cluster; i++)
                centroid[i] = height_object[i * random_value + random_value];

            return centroid;
        }

        private static int GetNearestCluster(HeightObject ho, HeightObject[] centroid_object)
        {
            var min_index = 0;
            for (int i = 1; i < centroid_object.Length; i++)
                if (ho.GetDistance(centroid_object[i]) < ho.GetDistance(centroid_object[min_index]))
                    min_index = i;
            return min_index;
        }

        private static HeightObject CalulateNewCentroid(int cluster, HeightObject[] height_object)
        {
            double sum = 0.0;
            int count = 0;
            for (int i = 0; i < height_object.Length; i++) {
                if (height_object[i].Cluster == cluster) {
                    sum += height_object[i].Value;
                    count++;
                }
            }
            return new HeightObject((float)(sum/count), cluster);
        }

        private static bool EqualsCentroid(HeightObject[] centroid_object, HeightObject[] new_cent_object)
        {
            for (int i = 0; i < centroid_object.Length; i++)
                if (centroid_object[i].Value != new_cent_object[i].Value)
                    return false;
            return true;
        }
    }
}
