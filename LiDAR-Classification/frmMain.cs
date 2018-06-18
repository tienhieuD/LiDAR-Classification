using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiDAR_Classification
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Text = string.Format("Lidar Classification ({0})", DateTime.Today.ToString("dd.MM.yyyy"));
            this.cbx_action.DropDownStyle = ComboBoxStyle.DropDownList;
            if (this.cbx_action.Items.Count > 0) this.cbx_action.SelectedIndex = 0;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Do nothing.
        }

        private void btn_input_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "LAS Files (*.las)|*.las|All Files (*.*)|*.*";
            if (open_file.ShowDialog() == DialogResult.OK)
                txt_input_path.Text = open_file.FileName;
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file = new SaveFileDialog();
            save_file.Filter = cbx_action.SelectedIndex == 1 ?
                "LAS Files (*.las)|*.las|All Files (*.*)|*.*" :
                "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*" ;
            if (save_file.ShowDialog() == DialogResult.OK)
                txt_output_path.Text = save_file.FileName;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_input_path.Text))
            {
                MessageBox.Show("Input file is empty!", "ERROR INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (cbx_action.SelectedIndex)
            {
                case 0:
                    Feature.LasView(txt_input_path.Text, txt_log);
                    break;
                case 1:
                    if (string.IsNullOrWhiteSpace(txt_output_path.Text)) {
                        MessageBox.Show("Output file is empty!", "ERROR OUTPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    Feature.Mcc(txt_input_path.Text, txt_output_path.Text, txt_log);
                    break;
                case 2:
                    if (string.IsNullOrWhiteSpace(txt_output_path.Text)) {
                        MessageBox.Show("Output file is empty!", "ERROR OUTPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    Feature.Kmean(txt_input_path.Text, txt_output_path.Text, txt_log);
                    break;
                default:
                    break;
            }
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            frmSetting setting = new frmSetting();
            setting.ShowDialog();
        }

        private void cbx_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Do nothing
        }

        private void btn_cls_Click(object sender, EventArgs e)
        {
            this.txt_log.Clear();
        }
    }
}
