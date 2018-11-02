namespace Aroima.Plugins.Skirt
{
    partial class BodySettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodySettingsDialog));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCommit = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.textSize1 = new System.Windows.Forms.TextBox();
            this.labelSize1 = new System.Windows.Forms.Label();
            this.rbSphere = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCapsule = new System.Windows.Forms.RadioButton();
            this.rbBox = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDynamicWithBone = new System.Windows.Forms.RadioButton();
            this.rbDynamic = new System.Windows.Forms.RadioButton();
            this.rbStatic = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBodySettings = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textPassGroup = new System.Windows.Forms.TextBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textFriction = new System.Windows.Forms.TextBox();
            this.textRestriction = new System.Windows.Forms.TextBox();
            this.textRotationDamping = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textPositionDamping = new System.Windows.Forms.TextBox();
            this.textMass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textSize3 = new System.Windows.Forms.TextBox();
            this.labelSize3 = new System.Windows.Forms.Label();
            this.textSize2 = new System.Windows.Forms.TextBox();
            this.labelSize2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCommit,
            this.tsbCancel,
            this.tsbUpdate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1519, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCommit
            // 
            this.tsbCommit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCommit.Image = ((System.Drawing.Image)(resources.GetObject("tsbCommit.Image")));
            this.tsbCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCommit.Name = "tsbCommit";
            this.tsbCommit.Size = new System.Drawing.Size(36, 36);
            this.tsbCommit.Text = "確定";
            this.tsbCommit.Click += new System.EventHandler(this.tsbCommit_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(36, 36);
            this.tsbCancel.Text = "取り消し";
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(36, 36);
            this.tsbUpdate.Text = "繁栄";
            // 
            // textSize1
            // 
            this.textSize1.Location = new System.Drawing.Point(128, 36);
            this.textSize1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textSize1.Name = "textSize1";
            this.textSize1.Size = new System.Drawing.Size(154, 31);
            this.textSize1.TabIndex = 0;
            this.textSize1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSize1.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // labelSize1
            // 
            this.labelSize1.AutoSize = true;
            this.labelSize1.Location = new System.Drawing.Point(39, 40);
            this.labelSize1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSize1.Name = "labelSize1";
            this.labelSize1.Size = new System.Drawing.Size(67, 24);
            this.labelSize1.TabIndex = 1;
            this.labelSize1.Text = "label1";
            this.labelSize1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rbSphere
            // 
            this.rbSphere.AutoSize = true;
            this.rbSphere.Location = new System.Drawing.Point(20, 36);
            this.rbSphere.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbSphere.Name = "rbSphere";
            this.rbSphere.Size = new System.Drawing.Size(65, 28);
            this.rbSphere.TabIndex = 2;
            this.rbSphere.TabStop = true;
            this.rbSphere.Text = "球";
            this.rbSphere.UseVisualStyleBackColor = true;
            this.rbSphere.CheckedChanged += new System.EventHandler(this.rbSphere_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCapsule);
            this.groupBox1.Controls.Add(this.rbBox);
            this.groupBox1.Controls.Add(this.rbSphere);
            this.groupBox1.Location = new System.Drawing.Point(26, 134);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Size = new System.Drawing.Size(364, 92);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "形状";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbCapsule
            // 
            this.rbCapsule.AutoSize = true;
            this.rbCapsule.Location = new System.Drawing.Point(197, 36);
            this.rbCapsule.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbCapsule.Name = "rbCapsule";
            this.rbCapsule.Size = new System.Drawing.Size(116, 28);
            this.rbCapsule.TabIndex = 4;
            this.rbCapsule.TabStop = true;
            this.rbCapsule.Text = "カプセル";
            this.rbCapsule.UseVisualStyleBackColor = true;
            this.rbCapsule.CheckedChanged += new System.EventHandler(this.rbCapsule_CheckedChanged);
            // 
            // rbBox
            // 
            this.rbBox.AutoSize = true;
            this.rbBox.Location = new System.Drawing.Point(108, 36);
            this.rbBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbBox.Name = "rbBox";
            this.rbBox.Size = new System.Drawing.Size(65, 28);
            this.rbBox.TabIndex = 3;
            this.rbBox.TabStop = true;
            this.rbBox.Text = "箱";
            this.rbBox.UseVisualStyleBackColor = true;
            this.rbBox.CheckedChanged += new System.EventHandler(this.rbBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbDynamicWithBone);
            this.groupBox2.Controls.Add(this.rbDynamic);
            this.groupBox2.Controls.Add(this.rbStatic);
            this.groupBox2.Location = new System.Drawing.Point(26, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Size = new System.Drawing.Size(953, 92);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "剛体タイプ";
            // 
            // rbDynamicWithBone
            // 
            this.rbDynamicWithBone.AutoSize = true;
            this.rbDynamicWithBone.Location = new System.Drawing.Point(358, 36);
            this.rbDynamicWithBone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbDynamicWithBone.Name = "rbDynamicWithBone";
            this.rbDynamicWithBone.Size = new System.Drawing.Size(168, 28);
            this.rbDynamicWithBone.TabIndex = 2;
            this.rbDynamicWithBone.TabStop = true;
            this.rbDynamicWithBone.Text = "radioButton1";
            this.rbDynamicWithBone.UseVisualStyleBackColor = true;
            // 
            // rbDynamic
            // 
            this.rbDynamic.AutoSize = true;
            this.rbDynamic.Location = new System.Drawing.Point(191, 36);
            this.rbDynamic.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbDynamic.Name = "rbDynamic";
            this.rbDynamic.Size = new System.Drawing.Size(137, 28);
            this.rbDynamic.TabIndex = 1;
            this.rbDynamic.TabStop = true;
            this.rbDynamic.Text = "物理演算";
            this.rbDynamic.UseVisualStyleBackColor = true;
            // 
            // rbStatic
            // 
            this.rbStatic.AutoSize = true;
            this.rbStatic.Location = new System.Drawing.Point(13, 36);
            this.rbStatic.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbStatic.Name = "rbStatic";
            this.rbStatic.Size = new System.Drawing.Size(147, 28);
            this.rbStatic.TabIndex = 0;
            this.rbStatic.TabStop = true;
            this.rbStatic.Text = "ボーン追従";
            this.rbStatic.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBodySettings);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.cmbGroup);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1519, 775);
            this.splitContainer1.SplitterDistance = 504;
            this.splitContainer1.SplitterWidth = 9;
            this.splitContainer1.TabIndex = 2;
            // 
            // listBodySettings
            // 
            this.listBodySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBodySettings.FormattingEnabled = true;
            this.listBodySettings.ItemHeight = 24;
            this.listBodySettings.Location = new System.Drawing.Point(9, 8);
            this.listBodySettings.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.listBodySettings.Name = "listBodySettings";
            this.listBodySettings.Size = new System.Drawing.Size(486, 759);
            this.listBodySettings.TabIndex = 0;
            this.listBodySettings.SelectedIndexChanged += new System.EventHandler(this.listBodySettings_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textPassGroup);
            this.groupBox5.Controls.Add(this.checkBox16);
            this.groupBox5.Controls.Add(this.checkBox15);
            this.groupBox5.Controls.Add(this.checkBox14);
            this.groupBox5.Controls.Add(this.checkBox13);
            this.groupBox5.Controls.Add(this.checkBox12);
            this.groupBox5.Controls.Add(this.checkBox11);
            this.groupBox5.Controls.Add(this.checkBox10);
            this.groupBox5.Controls.Add(this.checkBox9);
            this.groupBox5.Controls.Add(this.checkBox8);
            this.groupBox5.Controls.Add(this.checkBox7);
            this.groupBox5.Controls.Add(this.checkBox6);
            this.groupBox5.Controls.Add(this.checkBox5);
            this.groupBox5.Controls.Add(this.checkBox4);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Location = new System.Drawing.Point(26, 556);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox5.Size = new System.Drawing.Size(953, 184);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "非衝突グループ";
            // 
            // textPassGroup
            // 
            this.textPassGroup.Location = new System.Drawing.Point(28, 124);
            this.textPassGroup.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textPassGroup.Name = "textPassGroup";
            this.textPassGroup.ReadOnly = true;
            this.textPassGroup.Size = new System.Drawing.Size(684, 31);
            this.textPassGroup.TabIndex = 16;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.checkBox16.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox16.Location = new System.Drawing.Point(672, 36);
            this.checkBox16.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(38, 55);
            this.checkBox16.TabIndex = 15;
            this.checkBox16.Text = "16";
            this.checkBox16.UseVisualStyleBackColor = false;
            this.checkBox16.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(84)))));
            this.checkBox15.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox15.Location = new System.Drawing.Point(628, 36);
            this.checkBox15.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(38, 55);
            this.checkBox15.TabIndex = 14;
            this.checkBox15.Text = "15";
            this.checkBox15.UseVisualStyleBackColor = false;
            this.checkBox15.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.BackColor = System.Drawing.Color.Magenta;
            this.checkBox14.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox14.Location = new System.Drawing.Point(585, 36);
            this.checkBox14.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(38, 55);
            this.checkBox14.TabIndex = 13;
            this.checkBox14.Text = "14";
            this.checkBox14.UseVisualStyleBackColor = false;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.checkBox13.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox13.Location = new System.Drawing.Point(542, 36);
            this.checkBox13.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(38, 55);
            this.checkBox13.TabIndex = 12;
            this.checkBox13.Text = "13";
            this.checkBox13.UseVisualStyleBackColor = false;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.checkBox12.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox12.Location = new System.Drawing.Point(498, 36);
            this.checkBox12.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(38, 55);
            this.checkBox12.TabIndex = 11;
            this.checkBox12.Text = "12";
            this.checkBox12.UseVisualStyleBackColor = false;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.BackColor = System.Drawing.Color.Cyan;
            this.checkBox11.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox11.Location = new System.Drawing.Point(455, 36);
            this.checkBox11.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(38, 55);
            this.checkBox11.TabIndex = 10;
            this.checkBox11.Text = "11";
            this.checkBox11.UseVisualStyleBackColor = false;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(85)))));
            this.checkBox10.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox10.Location = new System.Drawing.Point(412, 36);
            this.checkBox10.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(38, 55);
            this.checkBox10.TabIndex = 9;
            this.checkBox10.Text = "10";
            this.checkBox10.UseVisualStyleBackColor = false;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.BackColor = System.Drawing.Color.Yellow;
            this.checkBox9.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox9.Location = new System.Drawing.Point(368, 36);
            this.checkBox9.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(28, 55);
            this.checkBox9.TabIndex = 8;
            this.checkBox9.Text = "9";
            this.checkBox9.UseVisualStyleBackColor = false;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.checkBox8.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox8.Location = new System.Drawing.Point(325, 36);
            this.checkBox8.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(28, 55);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Text = "8";
            this.checkBox8.UseVisualStyleBackColor = false;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.checkBox7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox7.Location = new System.Drawing.Point(282, 36);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(28, 55);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Text = "7";
            this.checkBox7.UseVisualStyleBackColor = false;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.checkBox6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox6.Location = new System.Drawing.Point(238, 36);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(28, 55);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "6";
            this.checkBox6.UseVisualStyleBackColor = false;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox5.Location = new System.Drawing.Point(195, 36);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(28, 55);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "5";
            this.checkBox5.UseVisualStyleBackColor = false;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Aquamarine;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox4.Location = new System.Drawing.Point(152, 36);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(28, 55);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(127)))));
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox3.Location = new System.Drawing.Point(108, 36);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(28, 55);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "3";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(127)))));
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox2.Location = new System.Drawing.Point(65, 36);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(28, 55);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(127)))));
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Location = new System.Drawing.Point(22, 36);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(28, 55);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "1";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 512);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "グループ";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cmbGroup.Location = new System.Drawing.Point(154, 504);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(97, 32);
            this.cmbGroup.TabIndex = 7;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textFriction);
            this.groupBox4.Controls.Add(this.textRestriction);
            this.groupBox4.Controls.Add(this.textRotationDamping);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textPositionDamping);
            this.groupBox4.Controls.Add(this.textMass);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(26, 342);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox4.Size = new System.Drawing.Size(953, 150);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "物理演算パラメータ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "摩擦力";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "反発力";
            // 
            // textFriction
            // 
            this.textFriction.Location = new System.Drawing.Point(449, 98);
            this.textFriction.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textFriction.Name = "textFriction";
            this.textFriction.Size = new System.Drawing.Size(154, 31);
            this.textFriction.TabIndex = 7;
            this.textFriction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textFriction.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textRestriction
            // 
            this.textRestriction.Location = new System.Drawing.Point(128, 98);
            this.textRestriction.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textRestriction.Name = "textRestriction";
            this.textRestriction.Size = new System.Drawing.Size(154, 31);
            this.textRestriction.TabIndex = 6;
            this.textRestriction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textRestriction.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textRotationDamping
            // 
            this.textRotationDamping.Location = new System.Drawing.Point(765, 48);
            this.textRotationDamping.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textRotationDamping.Name = "textRotationDamping";
            this.textRotationDamping.Size = new System.Drawing.Size(154, 31);
            this.textRotationDamping.TabIndex = 5;
            this.textRotationDamping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textRotationDamping.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(637, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "回転減衰";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "移動減衰";
            // 
            // textPositionDamping
            // 
            this.textPositionDamping.Location = new System.Drawing.Point(449, 48);
            this.textPositionDamping.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textPositionDamping.Name = "textPositionDamping";
            this.textPositionDamping.Size = new System.Drawing.Size(154, 31);
            this.textPositionDamping.TabIndex = 2;
            this.textPositionDamping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPositionDamping.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // textMass
            // 
            this.textMass.Location = new System.Drawing.Point(128, 48);
            this.textMass.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textMass.Name = "textMass";
            this.textMass.Size = new System.Drawing.Size(154, 31);
            this.textMass.TabIndex = 1;
            this.textMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textMass.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "質量";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textSize3);
            this.groupBox3.Controls.Add(this.labelSize3);
            this.groupBox3.Controls.Add(this.textSize2);
            this.groupBox3.Controls.Add(this.labelSize2);
            this.groupBox3.Controls.Add(this.textSize1);
            this.groupBox3.Controls.Add(this.labelSize1);
            this.groupBox3.Location = new System.Drawing.Point(26, 238);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Size = new System.Drawing.Size(873, 92);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "サイズ";
            // 
            // textSize3
            // 
            this.textSize3.Location = new System.Drawing.Point(691, 36);
            this.textSize3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textSize3.Name = "textSize3";
            this.textSize3.Size = new System.Drawing.Size(154, 31);
            this.textSize3.TabIndex = 5;
            this.textSize3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSize3.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // labelSize3
            // 
            this.labelSize3.AutoSize = true;
            this.labelSize3.Location = new System.Drawing.Point(602, 42);
            this.labelSize3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSize3.Name = "labelSize3";
            this.labelSize3.Size = new System.Drawing.Size(67, 24);
            this.labelSize3.TabIndex = 4;
            this.labelSize3.Text = "label1";
            this.labelSize3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textSize2
            // 
            this.textSize2.Location = new System.Drawing.Point(410, 36);
            this.textSize2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textSize2.Name = "textSize2";
            this.textSize2.Size = new System.Drawing.Size(154, 31);
            this.textSize2.TabIndex = 3;
            this.textSize2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSize2.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // labelSize2
            // 
            this.labelSize2.AutoSize = true;
            this.labelSize2.Location = new System.Drawing.Point(321, 42);
            this.labelSize2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelSize2.Name = "labelSize2";
            this.labelSize2.Size = new System.Drawing.Size(67, 24);
            this.labelSize2.TabIndex = 2;
            this.labelSize2.Text = "label1";
            this.labelSize2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BodySettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 814);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "BodySettingsDialog";
            this.Text = "BodySettingsDialog";
            this.Load += new System.EventHandler(this.BodySettingsDialog_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbStatic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCapsule;
        private System.Windows.Forms.RadioButton rbBox;
        private System.Windows.Forms.RadioButton rbSphere;
        private System.Windows.Forms.Label labelSize1;
        private System.Windows.Forms.TextBox textSize1;
        private System.Windows.Forms.RadioButton rbDynamic;
        private System.Windows.Forms.RadioButton rbDynamicWithBone;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textSize2;
        private System.Windows.Forms.Label labelSize2;
        private System.Windows.Forms.TextBox textSize3;
        private System.Windows.Forms.Label labelSize3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textMass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPositionDamping;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textFriction;
        private System.Windows.Forms.TextBox textRestriction;
        private System.Windows.Forms.TextBox textRotationDamping;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.TextBox textPassGroup;
        private System.Windows.Forms.ListBox listBodySettings;
        private System.Windows.Forms.ToolStripButton tsbCommit;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
    }
}