namespace Aroima.Plugins.Skirt
{
    partial class VertexDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textNormalZ = new System.Windows.Forms.TextBox();
            this.textNormalY = new System.Windows.Forms.TextBox();
            this.textNormalX = new System.Windows.Forms.TextBox();
            this.textPosZ = new System.Windows.Forms.TextBox();
            this.textPosY = new System.Windows.Forms.TextBox();
            this.textPosX = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listVertex = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textNormalZ);
            this.panel1.Controls.Add(this.textNormalY);
            this.panel1.Controls.Add(this.textNormalX);
            this.panel1.Controls.Add(this.textPosZ);
            this.panel1.Controls.Add(this.textPosY);
            this.panel1.Controls.Add(this.textPosX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 67);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "法線";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "位置";
            // 
            // textNormalZ
            // 
            this.textNormalZ.Location = new System.Drawing.Point(240, 37);
            this.textNormalZ.Name = "textNormalZ";
            this.textNormalZ.Size = new System.Drawing.Size(81, 19);
            this.textNormalZ.TabIndex = 5;
            this.textNormalZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textNormalY
            // 
            this.textNormalY.Location = new System.Drawing.Point(154, 37);
            this.textNormalY.Name = "textNormalY";
            this.textNormalY.Size = new System.Drawing.Size(80, 19);
            this.textNormalY.TabIndex = 4;
            this.textNormalY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textNormalX
            // 
            this.textNormalX.Location = new System.Drawing.Point(68, 37);
            this.textNormalX.Name = "textNormalX";
            this.textNormalX.Size = new System.Drawing.Size(80, 19);
            this.textNormalX.TabIndex = 3;
            this.textNormalX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textPosZ
            // 
            this.textPosZ.Location = new System.Drawing.Point(241, 12);
            this.textPosZ.Name = "textPosZ";
            this.textPosZ.Size = new System.Drawing.Size(80, 19);
            this.textPosZ.TabIndex = 2;
            this.textPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textPosY
            // 
            this.textPosY.Location = new System.Drawing.Point(154, 12);
            this.textPosY.Name = "textPosY";
            this.textPosY.Size = new System.Drawing.Size(80, 19);
            this.textPosY.TabIndex = 1;
            this.textPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textPosX
            // 
            this.textPosX.Location = new System.Drawing.Point(68, 12);
            this.textPosX.Name = "textPosX";
            this.textPosX.Size = new System.Drawing.Size(80, 19);
            this.textPosX.TabIndex = 0;
            this.textPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 41);
            this.panel2.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(166, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listVertex);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 67);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(334, 150);
            this.panel3.TabIndex = 2;
            // 
            // listVertex
            // 
            this.listVertex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVertex.FormattingEnabled = true;
            this.listVertex.ItemHeight = 12;
            this.listVertex.Location = new System.Drawing.Point(4, 4);
            this.listVertex.Name = "listVertex";
            this.listVertex.Size = new System.Drawing.Size(326, 142);
            this.listVertex.TabIndex = 0;
            this.listVertex.SelectedIndexChanged += new System.EventHandler(this.listVertex_SelectedIndexChanged);
            // 
            // VertexDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 258);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VertexDialog";
            this.Text = "VertexDialog";
            this.Load += new System.EventHandler(this.VertexDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNormalZ;
        private System.Windows.Forms.TextBox textNormalY;
        private System.Windows.Forms.TextBox textNormalX;
        private System.Windows.Forms.TextBox textPosZ;
        private System.Windows.Forms.TextBox textPosY;
        private System.Windows.Forms.TextBox textPosX;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox listVertex;
        private System.Windows.Forms.Button btnOK;
    }
}