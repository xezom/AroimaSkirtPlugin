namespace Aroima.Plugins.Skirt
{
    partial class NewModelDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.ndLayerNum = new System.Windows.Forms.NumericUpDown();
            this.ndColumnNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.CmbParentName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ndLayerNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndColumnNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "階層数";
            // 
            // ndLayerNum
            // 
            this.ndLayerNum.Location = new System.Drawing.Point(70, 42);
            this.ndLayerNum.Name = "ndLayerNum";
            this.ndLayerNum.Size = new System.Drawing.Size(43, 19);
            this.ndLayerNum.TabIndex = 2;
            this.ndLayerNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ndLayerNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ndColumnNum
            // 
            this.ndColumnNum.Location = new System.Drawing.Point(70, 72);
            this.ndColumnNum.Name = "ndColumnNum";
            this.ndColumnNum.Size = new System.Drawing.Size(43, 19);
            this.ndColumnNum.TabIndex = 3;
            this.ndColumnNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ndColumnNum.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "列数";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(70, 111);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(151, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CmbParentName
            // 
            this.CmbParentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbParentName.FormattingEnabled = true;
            this.CmbParentName.Location = new System.Drawing.Point(70, 12);
            this.CmbParentName.Name = "CmbParentName";
            this.CmbParentName.Size = new System.Drawing.Size(121, 20);
            this.CmbParentName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "親ボーン";
            // 
            // NewModelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 143);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbParentName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ndColumnNum);
            this.Controls.Add(this.ndLayerNum);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewModelDialog";
            this.Text = "モデル作成";
            this.Load += new System.EventHandler(this.NewModelDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ndLayerNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndColumnNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ndLayerNum;
        private System.Windows.Forms.NumericUpDown ndColumnNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox CmbParentName;
        private System.Windows.Forms.Label label3;
    }
}