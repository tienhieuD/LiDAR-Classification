namespace LiDAR_Classification
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btn_input = new System.Windows.Forms.Button();
            this.btn_output = new System.Windows.Forms.Button();
            this.txt_input_path = new System.Windows.Forms.TextBox();
            this.txt_output_path = new System.Windows.Forms.TextBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.cbx_action = new System.Windows.Forms.ComboBox();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            this.lb_choose_action = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_cls = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_input
            // 
            this.btn_input.Location = new System.Drawing.Point(12, 40);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(75, 23);
            this.btn_input.TabIndex = 0;
            this.btn_input.Text = "&Input";
            this.btn_input.UseVisualStyleBackColor = true;
            this.btn_input.Click += new System.EventHandler(this.btn_input_Click);
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(12, 71);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(75, 23);
            this.btn_output.TabIndex = 1;
            this.btn_output.Text = "&Output";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // txt_input_path
            // 
            this.txt_input_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_input_path.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_input_path.Location = new System.Drawing.Point(95, 40);
            this.txt_input_path.Multiline = true;
            this.txt_input_path.Name = "txt_input_path";
            this.txt_input_path.ReadOnly = true;
            this.txt_input_path.Size = new System.Drawing.Size(348, 23);
            this.txt_input_path.TabIndex = 2;
            // 
            // txt_output_path
            // 
            this.txt_output_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output_path.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_output_path.Location = new System.Drawing.Point(95, 71);
            this.txt_output_path.Multiline = true;
            this.txt_output_path.Name = "txt_output_path";
            this.txt_output_path.ReadOnly = true;
            this.txt_output_path.Size = new System.Drawing.Size(348, 23);
            this.txt_output_path.TabIndex = 3;
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_log.BackColor = System.Drawing.Color.Black;
            this.txt_log.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_log.Location = new System.Drawing.Point(12, 100);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_log.Size = new System.Drawing.Size(429, 226);
            this.txt_log.TabIndex = 4;
            // 
            // cbx_action
            // 
            this.cbx_action.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_action.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_action.FormattingEnabled = true;
            this.cbx_action.Items.AddRange(new object[] {
            "0. View file",
            "1. MCC-LiDAR Classification",
            "2. K-Mean Classification"});
            this.cbx_action.Location = new System.Drawing.Point(93, 11);
            this.cbx_action.Name = "cbx_action";
            this.cbx_action.Size = new System.Drawing.Size(170, 23);
            this.cbx_action.TabIndex = 5;
            this.cbx_action.SelectedIndexChanged += new System.EventHandler(this.cbx_action_SelectedIndexChanged);
            // 
            // btn_setting
            // 
            this.btn_setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_setting.Location = new System.Drawing.Point(366, 11);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 23);
            this.btn_setting.TabIndex = 6;
            this.btn_setting.Text = "&Setting";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_apply
            // 
            this.btn_apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_apply.Location = new System.Drawing.Point(269, 11);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(91, 23);
            this.btn_apply.TabIndex = 7;
            this.btn_apply.Text = "&Run";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // lb_choose_action
            // 
            this.lb_choose_action.AutoSize = true;
            this.lb_choose_action.Location = new System.Drawing.Point(43, 15);
            this.lb_choose_action.Name = "lb_choose_action";
            this.lb_choose_action.Size = new System.Drawing.Size(40, 13);
            this.lb_choose_action.TabIndex = 8;
            this.lb_choose_action.Text = "Action";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(447, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 344);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "How to use?";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(217, 317);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // btn_cls
            // 
            this.btn_cls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cls.Location = new System.Drawing.Point(354, 332);
            this.btn_cls.Name = "btn_cls";
            this.btn_cls.Size = new System.Drawing.Size(87, 23);
            this.btn_cls.TabIndex = 10;
            this.btn_cls.Text = "&Clear log";
            this.btn_cls.UseVisualStyleBackColor = true;
            this.btn_cls.Click += new System.EventHandler(this.btn_cls_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 367);
            this.Controls.Add(this.btn_cls);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_choose_action);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.cbx_action);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.txt_output_path);
            this.Controls.Add(this.txt_input_path);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.btn_input);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiDAR Classification";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_input;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.TextBox txt_input_path;
        private System.Windows.Forms.TextBox txt_output_path;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.ComboBox cbx_action;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Label lb_choose_action;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_cls;
    }
}

