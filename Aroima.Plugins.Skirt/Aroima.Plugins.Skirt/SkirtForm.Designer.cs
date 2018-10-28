namespace Aroima.Plugins.Skirt
{
    partial class SkirtForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("root");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkirtForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBone = new System.Windows.Forms.TabPage();
            this.btnSetBodyAngle = new System.Windows.Forms.Button();
            this.textBody = new System.Windows.Forms.TextBox();
            this.btnAddBody = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textToBone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textParentName = new System.Windows.Forms.TextBox();
            this.chkBone = new System.Windows.Forms.CheckBox();
            this.textBoneName = new System.Windows.Forms.TextBox();
            this.btnGetPosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoneList = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCreateModel = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveAllComponent = new System.Windows.Forms.ToolStripButton();
            this.textPosX = new System.Windows.Forms.TextBox();
            this.textPosY = new System.Windows.Forms.TextBox();
            this.textPosZ = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageBone.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1733, 826);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1733, 900);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(81, 35);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 32);
            this.toolStripLabel1.Text = "State";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainTreeView);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.splitContainer1.Size = new System.Drawing.Size(1733, 826);
            this.splitContainer1.SplitterDistance = 576;
            this.splitContainer1.SplitterWidth = 9;
            this.splitContainer1.TabIndex = 0;
            // 
            // mainTreeView
            // 
            this.mainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTreeView.HideSelection = false;
            this.mainTreeView.Location = new System.Drawing.Point(9, 8);
            this.mainTreeView.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.mainTreeView.Name = "mainTreeView";
            treeNode1.Name = "rootNode";
            treeNode1.Text = "root";
            this.mainTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.mainTreeView.Size = new System.Drawing.Size(558, 810);
            this.mainTreeView.TabIndex = 0;
            this.mainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainTreeView_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBone);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(9, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1130, 810);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageBone
            // 
            this.tabPageBone.Controls.Add(this.linkLabel1);
            this.tabPageBone.Controls.Add(this.textPosZ);
            this.tabPageBone.Controls.Add(this.textPosY);
            this.tabPageBone.Controls.Add(this.textPosX);
            this.tabPageBone.Controls.Add(this.btnSetBodyAngle);
            this.tabPageBone.Controls.Add(this.textBody);
            this.tabPageBone.Controls.Add(this.btnAddBody);
            this.tabPageBone.Controls.Add(this.label4);
            this.tabPageBone.Controls.Add(this.textToBone);
            this.tabPageBone.Controls.Add(this.label3);
            this.tabPageBone.Controls.Add(this.textParentName);
            this.tabPageBone.Controls.Add(this.chkBone);
            this.tabPageBone.Controls.Add(this.textBoneName);
            this.tabPageBone.Controls.Add(this.btnGetPosition);
            this.tabPageBone.Controls.Add(this.label1);
            this.tabPageBone.Location = new System.Drawing.Point(8, 39);
            this.tabPageBone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPageBone.Name = "tabPageBone";
            this.tabPageBone.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPageBone.Size = new System.Drawing.Size(1114, 763);
            this.tabPageBone.TabIndex = 0;
            this.tabPageBone.Text = "ボーン";
            this.tabPageBone.UseVisualStyleBackColor = true;
            // 
            // btnSetBodyAngle
            // 
            this.btnSetBodyAngle.Location = new System.Drawing.Point(611, 292);
            this.btnSetBodyAngle.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSetBodyAngle.Name = "btnSetBodyAngle";
            this.btnSetBodyAngle.Size = new System.Drawing.Size(236, 48);
            this.btnSetBodyAngle.TabIndex = 10;
            this.btnSetBodyAngle.Text = "Set Body Angle";
            this.btnSetBodyAngle.UseVisualStyleBackColor = true;
            this.btnSetBodyAngle.Click += new System.EventHandler(this.btnSetBodyAngle_Click);
            // 
            // textBody
            // 
            this.textBody.Location = new System.Drawing.Point(169, 298);
            this.textBody.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBody.Name = "textBody";
            this.textBody.Size = new System.Drawing.Size(212, 31);
            this.textBody.TabIndex = 9;
            // 
            // btnAddBody
            // 
            this.btnAddBody.Location = new System.Drawing.Point(436, 294);
            this.btnAddBody.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAddBody.Name = "btnAddBody";
            this.btnAddBody.Size = new System.Drawing.Size(163, 46);
            this.btnAddBody.TabIndex = 8;
            this.btnAddBody.Text = "Add Body";
            this.btnAddBody.UseVisualStyleBackColor = true;
            this.btnAddBody.Click += new System.EventHandler(this.btnAddBody_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "相対ボーン";
            // 
            // textToBone
            // 
            this.textToBone.Location = new System.Drawing.Point(169, 218);
            this.textToBone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textToBone.Name = "textToBone";
            this.textToBone.ReadOnly = true;
            this.textToBone.Size = new System.Drawing.Size(212, 31);
            this.textToBone.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "親ボーン";
            // 
            // textParentName
            // 
            this.textParentName.Location = new System.Drawing.Point(169, 168);
            this.textParentName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textParentName.Name = "textParentName";
            this.textParentName.ReadOnly = true;
            this.textParentName.Size = new System.Drawing.Size(212, 31);
            this.textParentName.TabIndex = 4;
            // 
            // chkBone
            // 
            this.chkBone.AutoSize = true;
            this.chkBone.Enabled = false;
            this.chkBone.Location = new System.Drawing.Point(186, 118);
            this.chkBone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.chkBone.Name = "chkBone";
            this.chkBone.Size = new System.Drawing.Size(148, 28);
            this.chkBone.TabIndex = 3;
            this.chkBone.Text = "ボーン設定";
            this.chkBone.UseVisualStyleBackColor = true;
            // 
            // textBoneName
            // 
            this.textBoneName.Location = new System.Drawing.Point(169, 58);
            this.textBoneName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoneName.Name = "textBoneName";
            this.textBoneName.Size = new System.Drawing.Size(212, 31);
            this.textBoneName.TabIndex = 1;
            // 
            // btnGetPosition
            // 
            this.btnGetPosition.Location = new System.Drawing.Point(436, 54);
            this.btnGetPosition.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnGetPosition.Name = "btnGetPosition";
            this.btnGetPosition.Size = new System.Drawing.Size(163, 46);
            this.btnGetPosition.TabIndex = 2;
            this.btnGetPosition.Text = "Get Vertex";
            this.btnGetPosition.UseVisualStyleBackColor = true;
            this.btnGetPosition.Click += new System.EventHandler(this.btnGetPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ボーン";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cmbBoneList);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Size = new System.Drawing.Size(1115, 689);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "親ボーン";
            // 
            // cmbBoneList
            // 
            this.cmbBoneList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoneList.FormattingEnabled = true;
            this.cmbBoneList.Location = new System.Drawing.Point(154, 38);
            this.cmbBoneList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cmbBoneList.Name = "cmbBoneList";
            this.cmbBoneList.Size = new System.Drawing.Size(320, 32);
            this.cmbBoneList.TabIndex = 0;
            this.cmbBoneList.SelectedIndexChanged += new System.EventHandler(this.cmbBoneList_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreateModel,
            this.tsbRemoveAllComponent});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(84, 39);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbCreateModel
            // 
            this.tsbCreateModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateModel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateModel.Image")));
            this.tsbCreateModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateModel.Name = "tsbCreateModel";
            this.tsbCreateModel.Size = new System.Drawing.Size(36, 36);
            this.tsbCreateModel.Text = "Create Model";
            this.tsbCreateModel.Click += new System.EventHandler(this.tsbCreateModel_Click);
            // 
            // tsbRemoveAllComponent
            // 
            this.tsbRemoveAllComponent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveAllComponent.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveAllComponent.Image")));
            this.tsbRemoveAllComponent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveAllComponent.Name = "tsbRemoveAllComponent";
            this.tsbRemoveAllComponent.Size = new System.Drawing.Size(36, 36);
            this.tsbRemoveAllComponent.Text = "RemoveAllComponent";
            // 
            // textPosX
            // 
            this.textPosX.Location = new System.Drawing.Point(445, 118);
            this.textPosX.Name = "textPosX";
            this.textPosX.Size = new System.Drawing.Size(154, 31);
            this.textPosX.TabIndex = 11;
            // 
            // textPosY
            // 
            this.textPosY.Location = new System.Drawing.Point(611, 118);
            this.textPosY.Name = "textPosY";
            this.textPosY.Size = new System.Drawing.Size(156, 31);
            this.textPosY.TabIndex = 12;
            // 
            // textPosZ
            // 
            this.textPosZ.Location = new System.Drawing.Point(785, 118);
            this.textPosZ.Name = "textPosZ";
            this.textPosZ.Size = new System.Drawing.Size(100, 31);
            this.textPosZ.TabIndex = 13;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(491, 171);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(58, 24);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "位置";
            // 
            // SkirtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 900);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "SkirtForm";
            this.Text = "SkirtForm";
            this.Load += new System.EventHandler(this.SkirtForm_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageBone.ResumeLayout(false);
            this.tabPageBone.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCreateModel;
        private System.Windows.Forms.Button btnGetPosition;
        private System.Windows.Forms.TextBox textBoneName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBone;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoneList;
        private System.Windows.Forms.CheckBox chkBone;
        private System.Windows.Forms.TextBox textParentName;
        private System.Windows.Forms.TextBox textToBone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBody;
        private System.Windows.Forms.Button btnAddBody;
        private System.Windows.Forms.ToolStripButton tsbRemoveAllComponent;
        private System.Windows.Forms.Button btnSetBodyAngle;
        private System.Windows.Forms.TextBox textPosY;
        private System.Windows.Forms.TextBox textPosX;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textPosZ;
    }
}