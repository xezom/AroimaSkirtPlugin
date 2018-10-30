namespace Aroima.Plugins.Skirt
{
    partial class JointSettingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JointSettingDialog));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listJointSettings = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textSpringConstRotZ = new System.Windows.Forms.TextBox();
            this.textSpringConstRotY = new System.Windows.Forms.TextBox();
            this.textSpringConstRotX = new System.Windows.Forms.TextBox();
            this.textSpringConstMoveZ = new System.Windows.Forms.TextBox();
            this.textSpringConstMoveY = new System.Windows.Forms.TextBox();
            this.textSpringConstMoveX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textLimitAngHZ = new System.Windows.Forms.TextBox();
            this.textLimitAngLZ = new System.Windows.Forms.TextBox();
            this.textLimitAngHY = new System.Windows.Forms.TextBox();
            this.textLimitAngLY = new System.Windows.Forms.TextBox();
            this.textLimitAngHX = new System.Windows.Forms.TextBox();
            this.textLimitAngLX = new System.Windows.Forms.TextBox();
            this.textLimitMoveHZ = new System.Windows.Forms.TextBox();
            this.textLimitMoveLZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textLimitMoveHY = new System.Windows.Forms.TextBox();
            this.textLimitMoveLY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textLimitMoveHX = new System.Windows.Forms.TextBox();
            this.textLimitMoveLX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listJointSettings);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 425);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // listJointSettings
            // 
            this.listJointSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listJointSettings.FormattingEnabled = true;
            this.listJointSettings.ItemHeight = 12;
            this.listJointSettings.Location = new System.Drawing.Point(4, 4);
            this.listJointSettings.Name = "listJointSettings";
            this.listJointSettings.Size = new System.Drawing.Size(258, 417);
            this.listJointSettings.TabIndex = 0;
            this.listJointSettings.SelectedIndexChanged += new System.EventHandler(this.listJointSettings_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textSpringConstRotZ);
            this.groupBox2.Controls.Add(this.textSpringConstRotY);
            this.groupBox2.Controls.Add(this.textSpringConstRotX);
            this.groupBox2.Controls.Add(this.textSpringConstMoveZ);
            this.groupBox2.Controls.Add(this.textSpringConstMoveY);
            this.groupBox2.Controls.Add(this.textSpringConstMoveX);
            this.groupBox2.Location = new System.Drawing.Point(16, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ばね";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "回転";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "移動";
            // 
            // textSpringConstRotZ
            // 
            this.textSpringConstRotZ.Location = new System.Drawing.Point(179, 60);
            this.textSpringConstRotZ.Name = "textSpringConstRotZ";
            this.textSpringConstRotZ.Size = new System.Drawing.Size(61, 19);
            this.textSpringConstRotZ.TabIndex = 5;
            this.textSpringConstRotZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSpringConstRotZ.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textSpringConstRotY
            // 
            this.textSpringConstRotY.Location = new System.Drawing.Point(112, 60);
            this.textSpringConstRotY.Name = "textSpringConstRotY";
            this.textSpringConstRotY.Size = new System.Drawing.Size(61, 19);
            this.textSpringConstRotY.TabIndex = 4;
            this.textSpringConstRotY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSpringConstRotY.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textSpringConstRotX
            // 
            this.textSpringConstRotX.Location = new System.Drawing.Point(45, 60);
            this.textSpringConstRotX.Name = "textSpringConstRotX";
            this.textSpringConstRotX.Size = new System.Drawing.Size(61, 19);
            this.textSpringConstRotX.TabIndex = 3;
            this.textSpringConstRotX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSpringConstRotX.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textSpringConstMoveZ
            // 
            this.textSpringConstMoveZ.Location = new System.Drawing.Point(179, 32);
            this.textSpringConstMoveZ.Name = "textSpringConstMoveZ";
            this.textSpringConstMoveZ.Size = new System.Drawing.Size(61, 19);
            this.textSpringConstMoveZ.TabIndex = 2;
            this.textSpringConstMoveZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSpringConstMoveZ.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textSpringConstMoveY
            // 
            this.textSpringConstMoveY.Location = new System.Drawing.Point(112, 32);
            this.textSpringConstMoveY.Name = "textSpringConstMoveY";
            this.textSpringConstMoveY.Size = new System.Drawing.Size(61, 19);
            this.textSpringConstMoveY.TabIndex = 1;
            this.textSpringConstMoveY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSpringConstMoveY.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textSpringConstMoveX
            // 
            this.textSpringConstMoveX.Location = new System.Drawing.Point(45, 32);
            this.textSpringConstMoveX.Name = "textSpringConstMoveX";
            this.textSpringConstMoveX.Size = new System.Drawing.Size(61, 19);
            this.textSpringConstMoveX.TabIndex = 0;
            this.textSpringConstMoveX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSpringConstMoveX.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textLimitAngHZ);
            this.groupBox1.Controls.Add(this.textLimitAngLZ);
            this.groupBox1.Controls.Add(this.textLimitAngHY);
            this.groupBox1.Controls.Add(this.textLimitAngLY);
            this.groupBox1.Controls.Add(this.textLimitAngHX);
            this.groupBox1.Controls.Add(this.textLimitAngLX);
            this.groupBox1.Controls.Add(this.textLimitMoveHZ);
            this.groupBox1.Controls.Add(this.textLimitMoveLZ);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textLimitMoveHY);
            this.groupBox1.Controls.Add(this.textLimitMoveLY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textLimitMoveHX);
            this.groupBox1.Controls.Add(this.textLimitMoveLX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "制限";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "回転";
            // 
            // textLimitAngHZ
            // 
            this.textLimitAngHZ.Location = new System.Drawing.Point(371, 62);
            this.textLimitAngHZ.Name = "textLimitAngHZ";
            this.textLimitAngHZ.Size = new System.Drawing.Size(45, 19);
            this.textLimitAngHZ.TabIndex = 15;
            this.textLimitAngHZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitAngHZ.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitAngLZ
            // 
            this.textLimitAngLZ.Location = new System.Drawing.Point(305, 62);
            this.textLimitAngLZ.Name = "textLimitAngLZ";
            this.textLimitAngLZ.Size = new System.Drawing.Size(45, 19);
            this.textLimitAngLZ.TabIndex = 14;
            this.textLimitAngLZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitAngLZ.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitAngHY
            // 
            this.textLimitAngHY.Location = new System.Drawing.Point(240, 62);
            this.textLimitAngHY.Name = "textLimitAngHY";
            this.textLimitAngHY.Size = new System.Drawing.Size(45, 19);
            this.textLimitAngHY.TabIndex = 13;
            this.textLimitAngHY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitAngHY.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitAngLY
            // 
            this.textLimitAngLY.Location = new System.Drawing.Point(175, 62);
            this.textLimitAngLY.Name = "textLimitAngLY";
            this.textLimitAngLY.Size = new System.Drawing.Size(45, 19);
            this.textLimitAngLY.TabIndex = 12;
            this.textLimitAngLY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitAngLY.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitAngHX
            // 
            this.textLimitAngHX.Location = new System.Drawing.Point(110, 62);
            this.textLimitAngHX.Name = "textLimitAngHX";
            this.textLimitAngHX.Size = new System.Drawing.Size(45, 19);
            this.textLimitAngHX.TabIndex = 11;
            this.textLimitAngHX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitAngHX.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitAngLX
            // 
            this.textLimitAngLX.Location = new System.Drawing.Point(45, 62);
            this.textLimitAngLX.Name = "textLimitAngLX";
            this.textLimitAngLX.Size = new System.Drawing.Size(45, 19);
            this.textLimitAngLX.TabIndex = 10;
            this.textLimitAngLX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitAngLX.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitMoveHZ
            // 
            this.textLimitMoveHZ.Location = new System.Drawing.Point(370, 38);
            this.textLimitMoveHZ.Name = "textLimitMoveHZ";
            this.textLimitMoveHZ.Size = new System.Drawing.Size(45, 19);
            this.textLimitMoveHZ.TabIndex = 9;
            this.textLimitMoveHZ.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitMoveLZ
            // 
            this.textLimitMoveLZ.Location = new System.Drawing.Point(305, 37);
            this.textLimitMoveLZ.Name = "textLimitMoveLZ";
            this.textLimitMoveLZ.Size = new System.Drawing.Size(45, 19);
            this.textLimitMoveLZ.TabIndex = 8;
            this.textLimitMoveLZ.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // textLimitMoveHY
            // 
            this.textLimitMoveHY.Location = new System.Drawing.Point(240, 37);
            this.textLimitMoveHY.Name = "textLimitMoveHY";
            this.textLimitMoveHY.Size = new System.Drawing.Size(45, 19);
            this.textLimitMoveHY.TabIndex = 6;
            this.textLimitMoveHY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitMoveHY.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitMoveLY
            // 
            this.textLimitMoveLY.Location = new System.Drawing.Point(175, 37);
            this.textLimitMoveLY.Name = "textLimitMoveLY";
            this.textLimitMoveLY.Size = new System.Drawing.Size(45, 19);
            this.textLimitMoveLY.TabIndex = 5;
            this.textLimitMoveLY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitMoveLY.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "X";
            // 
            // textLimitMoveHX
            // 
            this.textLimitMoveHX.Location = new System.Drawing.Point(110, 37);
            this.textLimitMoveHX.Name = "textLimitMoveHX";
            this.textLimitMoveHX.Size = new System.Drawing.Size(45, 19);
            this.textLimitMoveHX.TabIndex = 2;
            this.textLimitMoveHX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitMoveHX.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textLimitMoveLX
            // 
            this.textLimitMoveLX.Location = new System.Drawing.Point(45, 37);
            this.textLimitMoveLX.Name = "textLimitMoveLX";
            this.textLimitMoveLX.Size = new System.Drawing.Size(45, 19);
            this.textLimitMoveLX.TabIndex = 1;
            this.textLimitMoveLX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textLimitMoveLX.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "移動";
            // 
            // JointSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "JointSettingDialog";
            this.Text = "JointSettingDialog";
            this.Load += new System.EventHandler(this.JointSettingDialog_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listJointSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textLimitMoveHY;
        private System.Windows.Forms.TextBox textLimitMoveLY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLimitMoveHX;
        private System.Windows.Forms.TextBox textLimitMoveLX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textSpringConstRotZ;
        private System.Windows.Forms.TextBox textSpringConstRotY;
        private System.Windows.Forms.TextBox textSpringConstRotX;
        private System.Windows.Forms.TextBox textSpringConstMoveZ;
        private System.Windows.Forms.TextBox textSpringConstMoveY;
        private System.Windows.Forms.TextBox textSpringConstMoveX;
        private System.Windows.Forms.TextBox textLimitAngHZ;
        private System.Windows.Forms.TextBox textLimitAngLZ;
        private System.Windows.Forms.TextBox textLimitAngHY;
        private System.Windows.Forms.TextBox textLimitAngLY;
        private System.Windows.Forms.TextBox textLimitAngHX;
        private System.Windows.Forms.TextBox textLimitAngLX;
        private System.Windows.Forms.TextBox textLimitMoveHZ;
        private System.Windows.Forms.TextBox textLimitMoveLZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}