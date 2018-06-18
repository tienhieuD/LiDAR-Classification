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
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
            this.txt_space.Text = Properties.Settings.Default["spacing"].ToString();
            this.txt_threshold.Text = Properties.Settings.Default["threshold"].ToString();
            this.txt_cluster.Text = Properties.Settings.Default["cluster"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["spacing"] = this.txt_space.Text;
            Properties.Settings.Default["threshold"] = this.txt_threshold.Text;
            Properties.Settings.Default["cluster"] = this.txt_cluster.Text;
            Properties.Settings.Default.Save();
            this.Dispose();
        }
    }
}
