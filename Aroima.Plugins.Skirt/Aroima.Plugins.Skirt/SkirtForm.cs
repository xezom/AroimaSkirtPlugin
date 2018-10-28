using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PEPlugin;
using PEPlugin.Form;
using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using PEPlugin.View;
using PEPlugin.Vmd;
using PEPlugin.Vme;

namespace Aroima.Plugins.Skirt
{
    public partial class SkirtForm : Form
    {
        SkirtModel model = new SkirtModel();
        SkirtBone bone = null;
        SkirtPlugin plugin = null;
        

        internal SkirtPlugin Plugin { get => plugin; set => plugin = value; }

        public SkirtForm()
        {
            InitializeComponent();
        }

        private void SkirtForm_Load(object sender, EventArgs e)
        {
            foreach (var bone in plugin.PMX.Bone)
                cmbBoneList.Items.Add(bone.Name);
        }

        private void ShowSkirtModel()
        {
            var rootNode = mainTreeView.Nodes[0];
            rootNode.Nodes.Clear();
            rootNode.Text = "Parent: " + model.ParentBoneName;

            cmbBoneList.SelectedIndex = -1;
            for (int i = 0; i < plugin.PMX.Bone.Count; i++)
                if (plugin.PMX.Bone[i].Name == model.ParentBoneName)
                {
                    cmbBoneList.SelectedIndex = i;
                    break;
                }


            foreach (var column in model.ColumnList)
            {
                var columnNode = new TreeNode(column.Name)
                {
                    Tag = column
                };
                rootNode.Nodes.Add(columnNode);
                foreach (var bone in column.BoneList)
                {
                    var boneNode = new TreeNode(bone.Name)
                    {
                        Tag = bone
                    };
                    columnNode.Nodes.Add(boneNode);
                }
            }
            rootNode.Expand();
        }

        private void tsbCreateModel_Click(object sender, EventArgs e)
        {
            var builder = new SkirtModelBuilder();
            model = builder.Build(16, 4);

            ShowSkirtModel();
        }

        private void btnGetPosition_Click(object sender, EventArgs e)
        {
            var idx = plugin.PmxView.GetSelectedVertexIndices();
            if ( idx ==null || idx.Length == 0)
            {
                MessageBox.Show("頂点を選択してください");
                return;
            }
            if (bone == null)
            {
                MessageBox.Show("ボーンを選択してください");
                return;
            }
            if (bone.Pos == 0 && model.ParentBone == null)
            {
                MessageBox.Show("親ボーンを選択してください");
                return;
            }


            var v = plugin.PMX.Vertex[idx[0]];
            if (bone.Bone == null)
            {
                bone.CreateBone(v);
                plugin.PMX.Bone.Add(bone.Bone);
            }
            else
            {
                bone.Vertex = v;
                bone.Bone.Position = v.Position;
            }
            ShowBone(bone);

            
            plugin.UpdateView();

            //mainTreeView.SelectedNode = mainTreeView.SelectedNode.NextNode;
        }

        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                bone = null;
                return;
            }
            if (e.Node.Level == 2)
            {
                tabControl1.SelectedTab = tabPageBone;
                bone = (SkirtBone)e.Node.Tag;
                ShowBone(bone);
            }
            else if ( e.Node.Level == 0)
            {
                tabControl1.SelectedTab = tabPage2;
            }
            
        }
        private void ShowBone(SkirtBone bone)
        {
            tabControl1.SelectedTab = tabPageBone;
            
            if (bone == null)
                return;
            textBoneName.Text = bone.Name;
            chkBone.Checked = bone.Bone != null;



            if (bone.Bone != null && bone.Bone.Parent != null)
                textParentName.Text = bone.Bone.Parent.Name;
            else
                textParentName.Text = "";
            if (bone.Bone != null && bone.Bone.ToBone != null)
                textToBone.Text = bone.Bone.ToBone.Name;
            else
                textToBone.Text = "";

            if ( bone.Bone != null )
            {
                textPosX.Text = bone.Bone.Position.X.ToString();
                textPosY.Text = bone.Bone.Position.Y.ToString();
            }
            

        }

        private void cmbBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoneList.SelectedIndex == -1)
                return;

            var rootBone = plugin.PMX.Bone[cmbBoneList.SelectedIndex];
            model.ParentBoneName = rootBone.Name;
            model.ParentBone = rootBone;
            
        }

        private void btnAddBody_Click(object sender, EventArgs e)
        {
            if (bone == null)
                return;

            var body = bone.AddBone();
            plugin.PMX.Body.Add(body);

            textBody.Text = body.Name;

            plugin.UpdateView();
        }

        private void btnSetBodyAngle_Click(object sender, EventArgs e)
        {
            if (bone == null)
                return;

            bone.SetBodyAngle();


            plugin.UpdateView();
        }
    }
}
