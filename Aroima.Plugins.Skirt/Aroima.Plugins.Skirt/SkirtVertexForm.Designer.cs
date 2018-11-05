namespace Aroima.Plugins.Skirt
{
    partial class SkirtVertexForm
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
            System.Windows.Forms.Label weight1Label;
            System.Windows.Forms.Label weight2Label;
            System.Windows.Forms.Label weight3Label;
            System.Windows.Forms.Label weight4Label;
            System.Windows.Forms.Label bone1Label;
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listVertex = new System.Windows.Forms.ListView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bone1ComboBox = new System.Windows.Forms.ComboBox();
            this.weight4TextBox = new System.Windows.Forms.TextBox();
            this.weight3TextBox = new System.Windows.Forms.TextBox();
            this.weight2TextBox = new System.Windows.Forms.TextBox();
            this.weight1TextBox = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bone2ComboBox = new System.Windows.Forms.ComboBox();
            this.bone3ComboBox = new System.Windows.Forms.ComboBox();
            this.bone4ComboBox = new System.Windows.Forms.ComboBox();
            weight1Label = new System.Windows.Forms.Label();
            weight2Label = new System.Windows.Forms.Label();
            weight3Label = new System.Windows.Forms.Label();
            weight4Label = new System.Windows.Forms.Label();
            bone1Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // weight1Label
            // 
            weight1Label.AutoSize = true;
            weight1Label.Location = new System.Drawing.Point(236, 66);
            weight1Label.Name = "weight1Label";
            weight1Label.Size = new System.Drawing.Size(47, 12);
            weight1Label.TabIndex = 0;
            weight1Label.Text = "Weight1:";
            // 
            // weight2Label
            // 
            weight2Label.AutoSize = true;
            weight2Label.Location = new System.Drawing.Point(236, 91);
            weight2Label.Name = "weight2Label";
            weight2Label.Size = new System.Drawing.Size(47, 12);
            weight2Label.TabIndex = 2;
            weight2Label.Text = "Weight2:";
            // 
            // weight3Label
            // 
            weight3Label.AutoSize = true;
            weight3Label.Location = new System.Drawing.Point(236, 116);
            weight3Label.Name = "weight3Label";
            weight3Label.Size = new System.Drawing.Size(47, 12);
            weight3Label.TabIndex = 4;
            weight3Label.Text = "Weight3:";
            // 
            // weight4Label
            // 
            weight4Label.AutoSize = true;
            weight4Label.Location = new System.Drawing.Point(236, 141);
            weight4Label.Name = "weight4Label";
            weight4Label.Size = new System.Drawing.Size(47, 12);
            weight4Label.TabIndex = 6;
            weight4Label.Text = "Weight4:";
            // 
            // bone1Label
            // 
            bone1Label.AutoSize = true;
            bone1Label.Location = new System.Drawing.Point(32, 63);
            bone1Label.Name = "bone1Label";
            bone1Label.Size = new System.Drawing.Size(39, 12);
            bone1Label.TabIndex = 8;
            bone1Label.Text = "Bone1:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listVertex);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bone4ComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.bone3ComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.bone2ComboBox);
            this.splitContainer1.Panel2.Controls.Add(bone1Label);
            this.splitContainer1.Panel2.Controls.Add(this.bone1ComboBox);
            this.splitContainer1.Panel2.Controls.Add(weight4Label);
            this.splitContainer1.Panel2.Controls.Add(this.weight4TextBox);
            this.splitContainer1.Panel2.Controls.Add(weight3Label);
            this.splitContainer1.Panel2.Controls.Add(this.weight3TextBox);
            this.splitContainer1.Panel2.Controls.Add(weight2Label);
            this.splitContainer1.Panel2.Controls.Add(this.weight2TextBox);
            this.splitContainer1.Panel2.Controls.Add(weight1Label);
            this.splitContainer1.Panel2.Controls.Add(this.weight1TextBox);
            this.splitContainer1.Size = new System.Drawing.Size(800, 425);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // listVertex
            // 
            this.listVertex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listVertex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVertex.FullRowSelect = true;
            this.listVertex.GridLines = true;
            this.listVertex.HideSelection = false;
            this.listVertex.Location = new System.Drawing.Point(4, 4);
            this.listVertex.MultiSelect = false;
            this.listVertex.Name = "listVertex";
            this.listVertex.Size = new System.Drawing.Size(258, 417);
            this.listVertex.TabIndex = 1;
            this.listVertex.UseCompatibleStateImageBehavior = false;
            this.listVertex.View = System.Windows.Forms.View.Details;
            this.listVertex.SelectedIndexChanged += new System.EventHandler(this.listVertex_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(258, 417);
            this.dataGridView1.TabIndex = 0;
            // 
            // bone1ComboBox
            // 
            this.bone1ComboBox.FormattingEnabled = true;
            this.bone1ComboBox.Location = new System.Drawing.Point(77, 60);
            this.bone1ComboBox.Name = "bone1ComboBox";
            this.bone1ComboBox.Size = new System.Drawing.Size(121, 20);
            this.bone1ComboBox.TabIndex = 9;
            // 
            // weight4TextBox
            // 
            this.weight4TextBox.Location = new System.Drawing.Point(289, 138);
            this.weight4TextBox.Name = "weight4TextBox";
            this.weight4TextBox.Size = new System.Drawing.Size(63, 19);
            this.weight4TextBox.TabIndex = 7;
            this.weight4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // weight3TextBox
            // 
            this.weight3TextBox.Location = new System.Drawing.Point(289, 113);
            this.weight3TextBox.Name = "weight3TextBox";
            this.weight3TextBox.Size = new System.Drawing.Size(63, 19);
            this.weight3TextBox.TabIndex = 5;
            this.weight3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // weight2TextBox
            // 
            this.weight2TextBox.Location = new System.Drawing.Point(289, 88);
            this.weight2TextBox.Name = "weight2TextBox";
            this.weight2TextBox.Size = new System.Drawing.Size(63, 19);
            this.weight2TextBox.TabIndex = 3;
            this.weight2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // weight1TextBox
            // 
            this.weight1TextBox.Location = new System.Drawing.Point(289, 63);
            this.weight1TextBox.Name = "weight1TextBox";
            this.weight1TextBox.Size = new System.Drawing.Size(63, 19);
            this.weight1TextBox.TabIndex = 1;
            this.weight1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "X";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Y";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Z";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bone2ComboBox
            // 
            this.bone2ComboBox.FormattingEnabled = true;
            this.bone2ComboBox.Location = new System.Drawing.Point(77, 87);
            this.bone2ComboBox.Name = "bone2ComboBox";
            this.bone2ComboBox.Size = new System.Drawing.Size(121, 20);
            this.bone2ComboBox.TabIndex = 10;
            // 
            // bone3ComboBox
            // 
            this.bone3ComboBox.FormattingEnabled = true;
            this.bone3ComboBox.Location = new System.Drawing.Point(77, 112);
            this.bone3ComboBox.Name = "bone3ComboBox";
            this.bone3ComboBox.Size = new System.Drawing.Size(121, 20);
            this.bone3ComboBox.TabIndex = 11;
            // 
            // bone4ComboBox
            // 
            this.bone4ComboBox.FormattingEnabled = true;
            this.bone4ComboBox.Location = new System.Drawing.Point(77, 138);
            this.bone4ComboBox.Name = "bone4ComboBox";
            this.bone4ComboBox.Size = new System.Drawing.Size(121, 20);
            this.bone4ComboBox.TabIndex = 12;
            // 
            // SkirtVertexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SkirtVertexForm";
            this.Text = "SkirtVertexForm";
            this.Load += new System.EventHandler(this.SkirtVertexForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox bone1ComboBox;
        private System.Windows.Forms.TextBox weight4TextBox;
        private System.Windows.Forms.TextBox weight3TextBox;
        private System.Windows.Forms.TextBox weight2TextBox;
        private System.Windows.Forms.TextBox weight1TextBox;
        private System.Windows.Forms.ListView listVertex;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox bone4ComboBox;
        private System.Windows.Forms.ComboBox bone3ComboBox;
        private System.Windows.Forms.ComboBox bone2ComboBox;
    }
}