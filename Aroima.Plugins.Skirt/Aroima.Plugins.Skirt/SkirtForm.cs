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
        SkirtColumn column = null;
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

        /// <summary>
        /// 画面表示
        /// </summary>
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
            model = builder.Build(plugin, 16, 4);

            ShowSkirtModel();
        }

        private void btnGetPosition_Click(object sender, EventArgs e)
        {
            var idx = plugin.PmxView.GetSelectedVertexIndices();
            if (idx == null || idx.Length == 0)
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
            List<IPXVertex> vertexList = new List<IPXVertex>();
            foreach (var ind in idx)
                vertexList.Add(plugin.PMX.Vertex[ind]);

            using (var dlg = new VertexDialog()
            {
                VertexList = vertexList
            })
            {
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;



                var v = dlg.SelectedVertex;
                if (bone.Bone == null)
                {
                    bone.CreateBone(v);
                    plugin.PMX.Bone.Add(bone.Bone);
                }
                else
                {
                    bone.Vertex = v;
                    bone.Bone.Position = v.Position;
                    if (bone.Body != null)
                        bone.Body.Position = v.Position;
                }
                ShowBone(bone);


                plugin.UpdateView();


                //mainTreeView.SelectedNode = mainTreeView.SelectedNode.NextNode;
            }
        }

        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                bone = null;
                return;
            }
            switch (e.Node.Level)
            {
                case 0:
                    tabControl1.SelectedTab = tabPageModel;
                    break;
                case 1:
                    tabControl1.SelectedTab = tabPageColumn;
                    column = (SkirtColumn)e.Node.Tag;
                    ShowColumn(column);
                    break;
                case 2:
                    tabControl1.SelectedTab = tabPageBone;
                    bone = (SkirtBone)e.Node.Tag;
                    ShowBone(bone);
                    break;
            }
           
        }

        private void ShowColumn(SkirtColumn column)
        {
            textColumnName.Text = column.Name;
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
            {
                textToBone.Text = bone.Bone.ToBone.Name;
                textToBonePosX.Text = bone.Bone.ToBone.Position.X.ToString();
                textToBonePosY.Text = bone.Bone.ToBone.Position.Y.ToString();
                textToBonePosZ.Text = bone.Bone.ToBone.Position.Z.ToString();
            }
            else
            {
                textToBone.Text = "";

                textToBonePosX.Text = "";
                textToBonePosY.Text = "";
                textToBonePosZ.Text = "";
            }
            if (bone.Bone != null)
            {
                textPosX.Text = bone.Bone.Position.X.ToString();
                textPosY.Text = bone.Bone.Position.Y.ToString();
                textPosZ.Text = bone.Bone.Position.Z.ToString();
            }
            else
            {
                textPosX.Text = "";
                textPosY.Text = "";
                textPosZ.Text = "";
            }
            if ( bone.Vertex != null )
            {
                textNormalX.Text = bone.Vertex.Normal.X.ToString();
                textNormalY.Text = bone.Vertex.Normal.Y.ToString();
                textNormalZ.Text = bone.Vertex.Normal.Z.ToString();
            }
            else
            {
                textNormalX.Text = "";
                textNormalY.Text = "";
                textNormalZ.Text = "";
            }
           
            if ( bone.Body != null )
            {
                textBody.Text = bone.Body.Name;
            }
            else
            {
                textBody.Text = "";
            }
            if (bone.RotaionMatrix != null)
            {
                textM11.Text = bone.RotaionMatrix.M11.ToString();
                textM12.Text = bone.RotaionMatrix.M12.ToString();
                textM13.Text = bone.RotaionMatrix.M13.ToString();
                textM21.Text = bone.RotaionMatrix.M21.ToString();
                textM22.Text = bone.RotaionMatrix.M22.ToString();
                textM23.Text = bone.RotaionMatrix.M23.ToString();
                textM31.Text = bone.RotaionMatrix.M31.ToString();
                textM32.Text = bone.RotaionMatrix.M32.ToString();
                textM33.Text = bone.RotaionMatrix.M33.ToString();
            }
            else
            {
                textM11.Text = "";
                textM12.Text = "";
                textM13.Text = "";
                textM21.Text = "";
                textM22.Text = "";
                textM23.Text = "";
                textM31.Text = "";
                textM32.Text = "";
                textM33.Text = "";
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

        /// <summary>
        /// 剛体を新規生成してボーンの追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBody_Click(object sender, EventArgs e)
        {
            if (bone == null)
                return;

            var body = bone.AddBody();
            plugin.PMX.Body.Add(body);

            ShowBone(bone);

            plugin.UpdateView();
        }

        private void btnSetBodyAngle_Click(object sender, EventArgs e)
        {
            if (bone == null)
                return;

            bone.SetBodyAngle();

            ShowBone(bone);

            plugin.UpdateView();
        }

        private void linkBonePos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var text = textPosX.Text + "," + textPosY.Text + "," + textPosZ.Text;
            Clipboard.SetText(text);
        }

        private void linkNormal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var text = textNormalX.Text + "," + textNormalY.Text + "," + textNormalZ.Text;
            Clipboard.SetText(text);
        }

        private void linkToBonePos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var text = textToBonePosX.Text + "," + textToBonePosY.Text + "," + textToBonePosZ.Text;
            Clipboard.SetText(text);
        }

        private void btnAddJoint_Click(object sender, EventArgs e)
        {
            if (bone == null)
                return;

            var joint = bone.AddJoint();
            plugin.PMX.Joint.Add(joint);

            //ShowBone(bone);

            plugin.UpdateView();
        }

        private void tsbRemoveAllComponent_Click(object sender, EventArgs e)
        {
            using (var dlg = new RemoveDialog())
            {
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                if (!dlg.RemoveBone && !dlg.RemoveBody && !dlg.RemoveJoint)
                    return;

                if (MessageBox.Show("スカート関連のコンポーネントを全削除します", "重要", MessageBoxButtons.OKCancel)
                        == DialogResult.No)
                    return;

                if (dlg.RemoveJoint)
                    plugin.RemoveAllSkirtJoint();
                if (dlg.RemoveBody)
                    plugin.RemoveAllSkirtBody();
                if (dlg.RemoveBone)
                    plugin.RemoveAllSkirtBone();

                plugin.UpdateView();
            }
        }

        private void tsbCreateBodyAndJoint_Click(object sender, EventArgs e)
        {
            model.CreatBody();
            plugin.UpdateView();
        }

        private void btnCreateBody_Click(object sender, EventArgs e)
        {
            if (column == null)
                return;

            column.CreatedBody();
            plugin.UpdateView();
        }

        private void btnCreateJoint_Click(object sender, EventArgs e)
        {
            if (column == null)
                return;

            column.CreatedJoint();
            plugin.UpdateView();
        }
    }
}
