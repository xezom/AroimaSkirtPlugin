using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            rootNode.Text =  model.ParentBoneName;

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
            if (bone.Row == 0 && model.ParentBone == null)
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
                    bone.Position = v.Position;
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
                    column = bone.Column;
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

        /// <summary>
        /// 親ボーン設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoneList.SelectedIndex == -1)
                return;

            var rootBone = plugin.PMX.Bone[cmbBoneList.SelectedIndex];
            model.ParentBoneName = rootBone.Name;
            model.ParentBone = rootBone;

            var rootNode = mainTreeView.Nodes[0];
            rootNode.Text = rootBone.Name;


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

            bone.AddBody();
            ShowBone(bone);
            plugin.UpdateView();
        }

        private void btnSetBodyAngle_Click(object sender, EventArgs e)
        {
            if (bone == null)
                return;

            bone.SetBodyRotation();
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

            bone.AddVJoint();
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

        /// <summary>
        /// 列方向に剛体を生成する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateBody_Click(object sender, EventArgs e)
        {
            if (column == null)
            {
                MessageBox.Show("no column selected.");
                return;
            }
            column.CreatedBody();
            plugin.UpdateView();
        }

        private void btnCreateJoint_Click(object sender, EventArgs e)
        {
            if (column == null)
                return;

            column.CreateVJoint();
            plugin.UpdateView();
        }

        private void tsbBodySettings_Click(object sender, EventArgs e)
        {

        }

        private void tbJointSettingsV_Click(object sender, EventArgs e)
        {
            using (var dlg = new JointSettingDialog()
            {
                SettingsList = model.V_jointSettingList
            })
            {
                dlg.ShowDialog();
            }
        }

        private void btnVJointSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateHJoint_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void miCreateModel_Click(object sender, EventArgs e)
        {
            var builder = new SkirtModelBuilder();
            model = builder.Build(plugin, 16, 4);

            ShowSkirtModel();
        }

        /// <summary>
        /// モデルをファイルに保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miSave_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog()
            {
                DefaultExt = "xml",
                Filter = "XML(*.xml)|*.xml"
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var serializer = new XmlSerializer(typeof(SkirtModel));
                    using (var stream = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8))
                    {
                        serializer.Serialize(stream, model);
                    }
                }
            }
        }

        /// <summary>
        /// ファイルからモデルを読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miLoad_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog()
            {
                DefaultExt = "xml",
                Filter = "XML(*.xml)|*.xml"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                // 読み込み
                loadFromToFile(dlg.FileName);
                // 表示
                ShowSkirtModel();
            }
        }

        /// <summary>
        /// ファイルからモデルを読み込む
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        private void loadFromToFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(SkirtModel));
            using (var stream = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                model = (SkirtModel)serializer.Deserialize(stream);
            }
            // 関連付ける
            foreach (var col in model.ColumnList)
            {
                foreach (var b in col.BoneList)
                {
                    b.Bone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == b.Name);
                    b.Body = plugin.PMX.Body.FirstOrDefault(x => x.Name == b.Name);
                    b.V_Joint = plugin.PMX.Joint.FirstOrDefault(x => x.Name == b.Name);
                }
            }
        }

        private void miCreateVJoint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 横Joint作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateHJoint_Click(object sender, EventArgs e)
        {
            foreach (var col in model.ColumnList)
                col.CreateHJoint();
            plugin.UpdateView();
        }

        /// <summary>
        /// 縦Joint設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miVJointSettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new JointSettingDialog()
            {
                SettingsList = model.V_jointSettingList
            })
            {
                dlg.ShowDialog();
                foreach (var col in model.ColumnList)
                {
                    for (int i = 0; i < model.LayerCount - 1; i++)
                    {
                        var js = model.V_jointSettingList[i];
                        var bone = col.BoneList[i];
                        bone.UpdateVJointSetting(js);
                    }
                }
                plugin.UpdateView();
            }
        }

        private void miHJointSettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new JointSettingDialog()
            {
                SettingsList = model.H_jointSettingList
            })
            {
                dlg.ShowDialog();
                foreach (var col in model.ColumnList)
                {
                    for (int i = 0; i < model.LayerCount; i++)
                    {
                        var js = model.H_jointSettingList[i];
                        var bone = col.BoneList[i];
                        bone.UpdateVJointSetting(js);
                    }
                }
                plugin.UpdateView();
            }
        }

        private void miBodySettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new BodySettingsDialog()
            {
                BodySettingsList = model.BodySettingList
            })
            {
                dlg.ShowDialog();


                foreach (var col in model.ColumnList)
                {
                    for (int i = 0; i < model.LayerCount; i++)
                    {
                        var bs = model.BodySettingList[i];

                        var bone = col.BoneList[i];
                        bone.UpdateBodySetting(bs);
                    }
                }
                plugin.UpdateView();

            }
        }
    }
}
