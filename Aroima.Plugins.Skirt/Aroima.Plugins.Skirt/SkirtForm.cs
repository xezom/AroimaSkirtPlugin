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
        SkirtModelBuilder builder;


        public SkirtPlugin Plugin
        {
            get => plugin;
            set
            {
                plugin = value;
                builder = new SkirtModelBuilder(value); 
            }
        }
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
                    ShowColumn(column);
                    ShowBone(bone);
                    break;
            }
            setToolButtons();


            if (plugin != null && bone != null &&  bone.Bone != null)
            {
                int id = -1;
                for (int i = 0; i < plugin.PMX.Bone.Count; i++)
                {
                    if (plugin.PMX.Bone[i] == bone.Bone)
                    {
                        id = i;
                        break;
                    }
                }
                if (id != -1)
                {
                    plugin.FormConnector.SelectedBoneIndex = id;
                    plugin.Connect.View.PMDView.UpdateView();
                }
            }
        }

        private void ShowColumn(SkirtColumn column)
        {
            textColumnName.Text = column.Name;
        }
        private void ShowBone(SkirtBone bone)
        {
            
            if (bone == null)
                return;
            // 名前
            textBoneName.Text = bone.Name;

            // 位置
            textPosX.Text = bone.Position.X.ToString();
            textPosY.Text = bone.Position.Y.ToString();
            textPosZ.Text = bone.Position.Z.ToString();

            // 法線
            textNormalX.Text = bone.Normal.X.ToString();
            textNormalY.Text = bone.Normal.Y.ToString();
            textNormalZ.Text = bone.Normal.Z.ToString();





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

            if (bone.V_Joint != null)
                textVJoint.Text = bone.V_Joint.Name;
            else
                textVJoint.Text = "";

            if (bone.H_joint != null)
                textHJoint.Text = bone.H_joint.Name;
            else
                textHJoint.Text = "";

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
                VertexList = vertexList,
                StartPosition = FormStartPosition.CenterParent
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


                int id = -1;
                for ( int i = 0; i < plugin.PMX.Vertex.Count; i++)
                    if ( plugin.PMX.Vertex[i] == v)
                    {
                        id = i;
                        break;
                    }
                if (id != -1)
                {
                    plugin.FormConnector.SelectedVertexIndex = id;
                }
                
                plugin.UpdateView();


                id = -1;
                for (int i = 0; i < plugin.PMX.Bone.Count; i++)
                    if (plugin.PMX.Bone[i] == bone)
                    {
                        id = i;
                        break;
                    }
                if (id != -1)
                {
                    plugin.FormConnector.SelectedBoneIndex = id;
                    //plugin.Connect.View.PMDView.UpdateView();
                    plugin.Connect.View.PMDView.UpdateView();
                }
                
                
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
            {
                MessageBox.Show("no column selected.");
                return;
            }

            column.CreateVJoint();
            plugin.UpdateView();
        }



        #region メニュー

        /// <summary>
        /// モデルの新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateModel_Click(object sender, EventArgs e)
        {
            var boneNameList = new List<string>();
            foreach (var item in cmbBoneList.Items)
                boneNameList.Add(item.ToString());
            using (var dlg = new NewModelDialog() {
                StartPosition = FormStartPosition.CenterParent,
                BoneNameList = boneNameList
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                model = builder.Build(dlg.ColumnNum, dlg.LayerNum);
                model.ParentBoneName = dlg.ParentBoneName;
                model.ParentBone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == dlg.ParentBoneName);
                //plugin.FormConnector.SelectedBoneIndex =

                ShowSkirtModel();
            }
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
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                model.SaveToFile(dlg.FileName);
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
                model = builder.LoadFromFile(dlg.FileName);
                // 表示
                ShowSkirtModel();
            }
        }

        

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miRemoveComponents_Click(object sender, EventArgs e)
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
                {
                    plugin.RemoveAllSkirtJoint();

                    foreach (var col in model.ColumnList)
                        foreach (var node in col.BoneList)
                            if (node.Bone != null)
                                node.Bone = null;
                }
                if (dlg.RemoveBody)
                {
                    plugin.RemoveAllSkirtBody();
                    foreach(var col in model.ColumnList)
                        foreach (var node in col.BoneList)
                        if (node.Body != null)
                            node.Body = null;

                }
                if (dlg.RemoveBone)
                {
                    plugin.RemoveAllSkirtBone();
                    foreach (var col in model.ColumnList)
                        foreach (var node in col.BoneList)
                        {
                            if (node.H_joint != null)
                                node.H_joint = null;
                            if (node.V_Joint != null)
                                node.V_Joint = null;
                        }
                }
                plugin.UpdateView();
            }
        }

        /// <summary>
        /// 横Joint作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateHJoint_Click(object sender, EventArgs e)
        {
            var q = plugin.PMX.Joint.Where(x => x.Name.StartsWith("横スカート_"));
            var count = q.Count();
            if (count > 0)
            {
                if (MessageBox.Show("横Jointが既に存在しています。削除しますか?", "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                // 削除
                foreach ( var joint in q)
                {
                    plugin.PMX.Joint.Remove(joint);

                    foreach (var col in model.ColumnList)
                        foreach (var node in col.BoneList)
                            if (node.H_joint == joint)
                                node.H_joint = null;
                }
                plugin.UpdateView();
            }
            foreach (var col in model.ColumnList)
                col.CreateHJoint();
            plugin.UpdateView();
        }

        /// <summary>
        /// 縦Joint作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateVJoint_Click(object sender, EventArgs e)
        {
            foreach (var col in model.ColumnList)
                col.CreateVJoint();
            plugin.UpdateView();

        }


        /// <summary>
        /// 剛体設定画面の表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miBodySettings_Click(object sender, EventArgs e)
        {
            // 画面表示
            using (var dlg = new BodySettingsDialog())
            {
                dlg.Vm.DataSource = model.BodySettingList;
                dlg.ShowDialog();

                // 更新
                bool updated = false;
                foreach (var col in model.ColumnList)
                {
                    for (int i = 0; i < model.LayerCount; i++)
                    {
                        if (dlg.Vm.ModifedList[i])
                        {
                            var bs = model.BodySettingList[i];

                            var bone = col.BoneList[i];
                            bone.UpdateBodySetting(bs);

                            updated = true;
                        }
                    }
                }
                if (updated)
                {
                    plugin.UpdateView();

                    plugin.UpdatePMX();
                    model.Clear();
                    model.UpdatePlugin();

                    System.GC.Collect();
                }
            }
        }

        /// <summary>
        /// 縦Joint設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miVJointSettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new JointSettingDialog())
            {
                dlg.Vm.DataSource = model.V_jointSettingList;
                dlg.ShowDialog();

                foreach (var col in model.ColumnList)
                {
                    for (int i = 0; i < model.LayerCount - 1; i++)
                    {
                        if (dlg.Vm.ModifedList[i])
                        {
                            var js = model.V_jointSettingList[i];
                            var bone = col.BoneList[i];
                            bone.UpdateVJointSetting(js);
                        }
                    }
                }
                plugin.UpdateView();
                System.GC.Collect();               
            }
        }
        /// <summary>
        /// 横Joint設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miHJointSettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new JointSettingDialog())
            {
                dlg.Vm.DataSource = model.H_jointSettingList;
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

        #endregion

        class Distance : IComparable<Distance>
        {
            public SkirtBone Bone;
            public float Length;

            public int CompareTo(Distance other)
            {
                return Length.CompareTo(other.Length);
            }
        }


     

        private void btnPaintWeight_Click(object sender, EventArgs e)
        {

            float p = float.Parse(textP.Text);
            float wt1 = float.Parse(textWt1.Text);
            float wt2 = float.Parse(textWt2.Text);

            foreach (var i in model.SelectedVertex)
            {
                var v1 = plugin.PMX.Vertex[i];

                var list = new List<Distance>();

                foreach (var col in model.ColumnList)
                {
                    foreach (var b in col.BoneList)
                    {
                        list.Add(new Distance()
                        {
                            Bone = b,
                            Length = (v1.Position - b.Position).Length()
                        });
                    }
                }
                list.Sort();

                Func<float, float> f = x => (float)Math.Pow(p, x);
                float w1 = f(list[0].Length);
                float w2 = f(list[1].Length);
                float w3 = f(list[2].Length);
                float w4 = f(list[3].Length);

                float a2 = list[1].Length / list[0].Length;
                float a3 = list[2].Length / list[0].Length;
                float a4 = list[3].Length / list[0].Length;


                if (w4 / w1 > wt1)
                {
                    // BDEF3
                    v1.Bone1 = list[0].Bone.Bone;
                    v1.Bone2 = list[1].Bone.Bone;
                    v1.Bone3 = list[2].Bone.Bone;
                    v1.Bone4 = list[3].Bone.Bone;

                    v1.Weight1 = w1 / (w1 + w2 + w3 + w4);
                    v1.Weight2 = w2 / (w1 + w2 + w3 + w4);
                    v1.Weight3 = w3 / (w1 + w2 + w3 + w4);
                    v1.Weight4 = w4 / (w1 + w2 + w3 + w4);
                }
                if (w3 / w1 > wt1)
                {
                    // BDEF3
                    v1.Bone1 = list[0].Bone.Bone;
                    v1.Bone2 = list[1].Bone.Bone;
                    v1.Bone3 = list[2].Bone.Bone;
                    v1.Bone4 = null;

                    v1.Weight1 = w1 / (w1 + w2 + w3);
                    v1.Weight2 = w2 / (w1 + w2 + w3);
                    v1.Weight3 = w3 / (w1 + w2 + w3);
                    v1.Weight4 = 0;
                }
                else if ( w2 / w1 > wt2)
                {
                    // BDEF2
                    v1.Bone1 = list[0].Bone.Bone;
                    v1.Bone2 = list[1].Bone.Bone;
                    v1.Bone3 = null;
                    v1.Bone4 = null;

                    v1.Weight1 = w1 / (w1 + w2);
                    v1.Weight2 = w2 / (w1 + w2);
                    v1.Weight3 = 0;
                    v1.Weight4 = 0;
                }
                else
                { 
                    // BDEF1
                    v1.Bone1 = list[0].Bone.Bone;
                    v1.Bone2 = null;
                    v1.Bone3 = null;
                    v1.Bone4 = null;
                    v1.Weight1 = 1f;
                    v1.Weight2 = 0;
                    v1.Weight3 = 0;
                    v1.Weight4 = 0;
                }

            }
            plugin.UpdateView();

        }

        private void btnGetVertex_Click(object sender, EventArgs e)
        {
            model.SelectedVertex = plugin.PmxView.GetSelectedVertexIndices().ToList();

            textVertexNum.Text = model.SelectedVertex.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> bones = new List<int>();
            foreach ( var col in model.ColumnList )
                foreach ( var b in col.BoneList )
                    if ( b.Bone != null )
                    {
                        for (int i = 0; i < plugin.PMX.Bone.Count; i++)
                            if ( plugin.PMX.Bone[i] == b.Bone)
                            {
                                bones.Add(i);
                                break;
                            }
                    }

            plugin.PmxView.SetSelectedBoneIndices(bones.ToArray());
            //plugin.Connect.View.PMDView.UpdateView();
            plugin.Connect.View.PmxView.UpdateView();
        }

        private void btnSelectVertex_Click(object sender, EventArgs e)
        {
            plugin.PmxView.SetSelectedVertexIndices(model.SelectedVertex.ToArray());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<Vertex> vList = new List<Vertex>();

            foreach ( int idx in model.SelectedVertex)
            {

                var v = plugin.PMX.Vertex[idx];

                vList.Add(new Vertex()
                {
                    Id = idx,
                    X = v.Position.X,
                    Y = v.Position.Y,
                    Z = v.Position.Z,
                    Bone1 = v.Bone1 != null ? v.Bone1.Name : "",
                    Weight1 = v.Weight1,
                    Bone2 = v.Bone2 != null ? v.Bone2.Name : "",
                    Weight2 = v.Weight2,
                    Bone3 = v.Bone3 != null ? v.Bone3.Name : "",
                    Weight3 = v.Weight3,
                    Bone4 = v.Bone4 != null ? v.Bone4.Name : "",
                    Weight4 = v.Weight4

                });
            }
            using (var form = new SkirtVertexForm())
            {
                form.Vm.DataSource = vList;
                form.ShowDialog();
            }
        }

        private void mainTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if (selected && unfocused)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void setToolButtons()
        {

        }
        private void tbPrev_Click(object sender, EventArgs e)
        {
            var node = mainTreeView.SelectedNode;
            if (node == null)
                return;
            if (node.Level == 2)
            {
                if ( node.PrevNode != null )
                {
                    mainTreeView.SelectedNode = node.PrevNode;
                }
                else if ( node.Parent.PrevNode != null && node.Parent.PrevNode.Nodes.Count > 0)
                {
                    mainTreeView.SelectedNode = node.Parent.PrevNode.Nodes[node.Parent.PrevNode.Nodes.Count - 1];
                    node.Parent.Collapse();
                }
            }
        }
        private void tbNext_Click(object sender, EventArgs e)
        {
            var node = mainTreeView.SelectedNode;
            if (node == null)
                return;
            if (node.Level == 2)
            {
                if (node.NextNode != null)
                    mainTreeView.SelectedNode = node.NextNode;
                else
                {
                    if (node.Parent.NextNode != null && node.Parent.NextNode.Nodes.Count > 0)
                    {
                        mainTreeView.SelectedNode = node.Parent.NextNode.Nodes[0];
                        node.Parent.Collapse();
                    }
                }
            }


    
        }

        private void tbUp_Click(object sender, EventArgs e)
        {
            var node = mainTreeView.SelectedNode;
            if (node == null)
                return;
            if (node.Parent != null)
                mainTreeView.SelectedNode = node.Parent;
        }

        private void tbDown_Click(object sender, EventArgs e)
        {
            var node = mainTreeView.SelectedNode;
            if (node == null)
                return;
            if (node.Nodes.Count > 0)
            {
                node.Expand();
                mainTreeView.SelectedNode = node.Nodes[0];
            }
        }
    }

    
}
