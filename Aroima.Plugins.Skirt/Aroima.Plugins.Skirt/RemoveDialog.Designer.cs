namespace Aroima.Plugins.Skirt
{
    partial class RemoveDialog
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
            this.chkBone = new System.Windows.Forms.CheckBox();
            this.chkBody = new System.Windows.Forms.CheckBox();
            this.chkJoint = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkBone
            // 
            this.chkBone.AutoSize = true;
            this.chkBone.Location = new System.Drawing.Point(26, 21);
            this.chkBone.Name = "chkBone";
            this.chkBone.Size = new System.Drawing.Size(53, 16);
            this.chkBone.TabIndex = 0;
            this.chkBone.Text = "ボーン";
            this.chkBone.UseVisualStyleBackColor = true;
            // 
            // chkBody
            // 
            this.chkBody.AutoSize = true;
            this.chkBody.Checked = true;
            this.chkBody.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBody.Location = new System.Drawing.Point(85, 21);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(48, 16);
            this.chkBody.TabIndex = 1;
            this.chkBody.Text = "剛体";
            this.chkBody.UseVisualStyleBackColor = true;
            // 
            // chkJoint
            // 
            this.chkJoint.AutoSize = true;
            this.chkJoint.Checked = true;
            this.chkJoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJoint.Location = new System.Drawing.Point(139, 21);
            this.chkJoint.Name = "chkJoint";
            this.chkJoint.Size = new System.Drawing.Size(50, 16);
            this.chkJoint.TabIndex = 2;
            this.chkJoint.Text = "Joint";
            this.chkJoint.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(58, 62);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(139, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RemoveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 101);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkJoint);
            this.Controls.Add(this.chkBody);
            this.Controls.Add(this.chkBone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveDialog";
            this.Text = "スカート要素の削除";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBone;
        private System.Windows.Forms.CheckBox chkBody;
        private System.Windows.Forms.CheckBox chkJoint;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}