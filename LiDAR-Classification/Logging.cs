using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiDAR_Classification
{
    class Logging
    {
        public static void Write(TextBox textBox, string content)
        {
            textBox.Text += string.Format(
                "[{0}] - {1}\r\n", DateTime.Now.ToLongTimeString(), content);
        }

        public static void Write(TextBox textBox, string content, HeightObject[] array)
        {
            string array_text = "[";
            foreach (var item in array) array_text += item.Value + ", ";
            array_text += "]";
            textBox.Text += string.Format(
                "[{0}] - {1} {2}\r\n", DateTime.Now.ToLongTimeString(), content, array_text);
        }
    }
}
