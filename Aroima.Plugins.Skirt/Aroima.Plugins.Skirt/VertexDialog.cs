using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aroima.Plugins.Skirt
{
    public partial class VertexDialog : Form
    {
        List<IPXVertex> vertexList = null;
        IPXVertex selectedVertex;
        bool vertexOnly = false;

        public VertexDialog()
        {
            InitializeComponent();
        }

        public List<IPXVertex> VertexList { get => vertexList; set => vertexList = value; }
        public IPXVertex SelectedVertex { get => selectedVertex; set => selectedVertex = value; }
        public bool VertexOnly { get => vertexOnly; set => vertexOnly = value; }

        private void VertexDialog_Load(object sender, EventArgs e)
        {
            foreach ( var v in vertexList)
            {
                listVertex.Items.Add(v.Position.X.ToString() + ", " + v.Position.Y.ToString() + ", " + v.Position.Z.ToString());
                
            }
            listVertex.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ( listVertex.SelectedIndex == -1)
            {
                MessageBox.Show("選択してください");
                return;
            }
            selectedVertex = vertexList[listVertex.SelectedIndex];
        }

        private void listVertex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listVertex.SelectedIndex == -1)
            {
                textPosX.Text = "";
                textPosY.Text = "";
                textPosZ.Text = "";
                textNormalX.Text = "";
                textNormalY.Text = "";
                textNormalZ.Text = "";
            }
            else
            {
                selectedVertex = vertexList[listVertex.SelectedIndex];
                textPosX.Text = selectedVertex.Position.X.ToString();
                textPosY.Text = selectedVertex.Position.Y.ToString();
                textPosZ.Text = selectedVertex.Position.Z.ToString();
                textNormalX.Text = selectedVertex.Normal.X.ToString();
                textNormalY.Text = selectedVertex.Normal.Y.ToString();
                textNormalZ.Text = selectedVertex.Normal.Z.ToString();
            }
        }

        private void chkVertexOnly_CheckedChanged(object sender, EventArgs e)
        {
            vertexOnly = chkVertexOnly.Checked;
        }
    }
}
