using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

using log4net;
using log4net.Appender;
using log4net.Config;

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
        private static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        SkirtModel model = new SkirtModel();
        SkirtColumn column = null;
        SkirtNode node = null;
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

            var asm = Assembly.GetExecutingAssembly();
            var dirName = System.IO.Path.GetDirectoryName(asm.Location);

            XmlConfigurator.Configure(new System.IO.FileInfo(dirName + "\\log4net.config"));
            LOG.Debug("assembly location: " + dirName);
        }

        private void SkirtForm_Load(object sender, EventArgs e)
        {
            LOG.Info("loading form...");
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

            // 親ノードの選択
            var t = plugin.PMX.Bone.Select((b, i) => new { Bone = b, Index = i })
                .FirstOrDefault(n => n.Bone.Name == model.ParentBoneName);
            cmbBoneList.SelectedIndex = t != null ? t.Index : -1;

            // ツリーノードの生成
            model.ColumnList.ForEach(column =>
            {
                var columnNode = new TreeNode(column.Name)
                {
                    Tag = column
                };
                rootNode.Nodes.Add(columnNode);
                column.NodeList.ForEach(node =>
                {
                    var nodeNode = new TreeNode(node.Name)
                    {
                        Tag = node
                    };
                    columnNode.Nodes.Add(nodeNode);
                });
            });
            rootNode.Expand();
        }


        
        /// <summary>
        /// 一覧から選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var prevNode = node;
            if (e.Node == null)
            {
                node = null;
            }
            else
            {
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
                        node = (SkirtNode)e.Node.Tag;
                        column = node.Column;
                        ShowColumn(column);
                        ShowNode(node);
                        break;
                }
            }
            setToolButtons();

            // ボーンを画面上で選択
            if (plugin != null && node != null &&  node != prevNode && node.Bone != null)
            {
                var s = plugin.PMX.Bone
                    .Select((b, i) => new { Bone = b, Index = i })
                    .FirstOrDefault(n => n.Bone == node.Bone);
                if (s.Index != -1)
                {
                    plugin.FormConnector.SelectedBoneIndex = s.Index;
                    plugin.Connect.View.PMDView.UpdateView();
                }
            }
        }

        /// <summary>
        /// 列パネルの表示
        /// </summary>
        /// <param name="column"></param>
        private void ShowColumn(SkirtColumn column)
        {
            
            textColumnName.Text = column.Name;
        }

        /// <summary>
        /// ボーンパネルの表示
        /// </summary>
        /// <param name="node"></param>
        private void ShowNode(SkirtNode node)
        {
            foreach (Control control in tabPageBone.Controls)
            {
                control.Enabled = node != null;
            }
            
            if (node == null)
                return;

            // 名前
            textBoneName.Text = node.Name;

            // 位置
            textPosX.Text = node.Position.X.ToString();
            textPosY.Text = node.Position.Y.ToString();
            textPosZ.Text = node.Position.Z.ToString();

            // 法線
            textNormalX.Text = node.Normal.X.ToString();
            textNormalY.Text = node.Normal.Y.ToString();
            textNormalZ.Text = node.Normal.Z.ToString();





            if (node.Bone != null && node.Bone.Parent != null)
                textParentName.Text = node.Bone.Parent.Name;
            else
                textParentName.Text = "";
            if (node.Bone != null && node.Bone.ToBone != null)
            {
                textToBone.Text = node.Bone.ToBone.Name;
                textToBonePosX.Text = node.Bone.ToBone.Position.X.ToString();
                textToBonePosY.Text = node.Bone.ToBone.Position.Y.ToString();
                textToBonePosZ.Text = node.Bone.ToBone.Position.Z.ToString();
            }
            else
            {
                textToBone.Text = "";

                textToBonePosX.Text = "";
                textToBonePosY.Text = "";
                textToBonePosZ.Text = "";
            }
            
            if ( node.Body != null )
            {
                textBody.Text = node.Body.Name;
                textAngleX.Text = node.Body.Rotation.X.ToString();
                textAngleY.Text = node.Body.Rotation.Y.ToString();
                textAngleZ.Text = node.Body.Rotation.Z.ToString();
            }
            else
            {
                textBody.Text = "";
                textAngleX.Text = "";
                textAngleY.Text = "";
                textAngleZ.Text = "";
            }

            if (node.V_Joint != null)
                textVJoint.Text = node.V_Joint.Name;
            else
                textVJoint.Text = "";

            if (node.H_joint != null)
                textHJoint.Text = node.H_joint.Name;
            else
                textHJoint.Text = "";

        }

        /// <summary>
        /// 頂点選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetPosition_Click(object sender, EventArgs e)
        {
            
            if (node == null)
            {
                MessageBox.Show("ノードを選択してください");
                return;
            }
            if (node.Row == 0 && model.ParentBone == null)
            {
                MessageBox.Show("親ノードを選択してください");
                return;
            }
            var idx = plugin.PmxView.GetSelectedVertexIndices();
            if (idx == null || idx.Length == 0)
            {
                MessageBox.Show("頂点を選択してください");
                return;
            }
            // 選択頂点一覧の取得
            var vertexList = idx.Select(i => plugin.PMX.Vertex[i]).ToList();


            using (var dlg = new VertexDialog()
            {
                VertexList = vertexList,
                StartPosition = FormStartPosition.CenterParent
            })
            {
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;

                bool vertexOnly = dlg.VertexOnly;

                var v = dlg.SelectedVertex;
                if (node.Bone == null)
                {
                    node.CreateBone(v);

                    plugin.PMX.Bone.Add(node.Bone);
                }
                else
                {
                    node.Vertex = v;
                    if (!vertexOnly)
                    {
                        node.Bone.Position = v.Position;
                        node.Position = v.Position;
                        if (node.Body != null)
                            node.Body.Position = v.Position;
                    }
                }
                ShowNode(node);

                // 頂点選択
                var foundVertex = plugin.PMX.Vertex.Select((x, i) => new { Vertex = x, Index = i })
                    .FirstOrDefault(p => p.Vertex == v);
                if (foundVertex != null)
                    plugin.FormConnector.SelectedVertexIndex = foundVertex.Index;



                plugin.UpdateView();

                // ボーン選択
                var foundBone = plugin.PMX.Bone.Select((b, i) => new { Bone = b, Index = i })
                    .FirstOrDefault(p => p.Bone == node.Bone);
                if (foundBone != null)
                {
                    plugin.FormConnector.SelectedBoneIndex = foundBone.Index;
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
        /// スカートモデルの新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateModel_Click(object sender, EventArgs e)
        {
            var boneNameList = new List<string>();
            foreach (var item in cmbBoneList.Items)
                boneNameList.Add(item.ToString());
            // ダイアログの表示
            using (var dlg = new NewModelDialog() {
                StartPosition = FormStartPosition.CenterParent,
                BoneNameList = boneNameList
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                // スカートモデルの新規生成
                model = builder.Build(dlg.ColumnNum, dlg.LayerNum);
                model.ParentBoneName = dlg.ParentBoneName;
                model.ParentBone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == dlg.ParentBoneName);
                //plugin.FormConnector.SelectedBoneIndex =

                ShowSkirtModel();
            }
        }

        /// <summary>
        /// モデルの読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miImport_Click(object sender, EventArgs e)
        {
            // スカートボーンをスキャン
            // 列数と階層数を得る
            int imax = 0;
            int jmax = 0;
            var r = new Regex(@"スカート_(?<j>\d+)_(?<i>\d+)");
            foreach ( var match in plugin.PMX.Bone.Select(b => r.Match(b.Name))
                .Where(m => m.Success))
            {
                var j = int.Parse(match.Groups["j"].Value);
                var i = int.Parse(match.Groups["i"].Value);
                if (i + 1 > imax)
                    imax = i + 1;
                if (j + 1 > jmax)
                    jmax = j + 1;
            }
                

            if (imax == 0 || jmax == 0)
            {
                MessageBox.Show("スカートボーンは見つかりませんでした");
                return;
            }
            
            
            model = builder.Build(imax, jmax);
            var p = plugin.PMX.Bone.FirstOrDefault(b => b.Name == "スカート_0_0");
            if (p != null)
            {
                model.ParentBoneName = p.Name;
                model.ParentBone = p;
            }
            if (MessageBox.Show("パラメータファイルを読み込みますか?",
                "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            }

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
                DefaultExt = "xml", Filter = "XML(*.xml)|*.xml"
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
                LOG.Debug("loading file: " + dlg.FileName + " ...");

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

                if (dlg.RemoveBone)
                {
                    LOG.Info("Removing all bones...");
                    plugin.RemoveAllSkirtBone();
                    foreach (var col in model.ColumnList)
                        foreach (var node in col.NodeList)
                            if (node.Bone != null)
                                node.Bone = null;
                }
                if (dlg.RemoveBody)
                {
                    LOG.Info("Removing all bodys...");
                    plugin.RemoveAllSkirtBody();
                    foreach(var col in model.ColumnList)
                        foreach (var node in col.NodeList)
                        if (node.Body != null)
                            node.Body = null;

                }
                if (dlg.RemoveJoint)
                {
                    LOG.Info("Removing all joints...");
                    plugin.RemoveAllSkirtJoint();
                    foreach (var col in model.ColumnList)
                        foreach (var node in col.NodeList)
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
        /// 剛体再生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateBodySettings_Click(object sender, EventArgs e)
        {
            model.ColumnList.ForEach(c => c.CreatedBody());
            plugin.UpdateView();
        }
        /// <summary>
        /// 縦Joint作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateVJoint_Click(object sender, EventArgs e)
        {
            model.ColumnList.ForEach(col => col.CreateVJoint());
            plugin.UpdateView();

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
                        foreach (var node in col.NodeList)
                            if (node.H_joint == joint)
                                node.H_joint = null;
                }
                plugin.UpdateView();
            }
            bool closed = chkClosedLoop.Checked;
            for (int i = 0; i < model.ColumnList.Count; i++)
            {
                if (i == model.ColumnList.Count - 1)
                {
                    if ( closed )
                        model.ColumnList[i].CreateHJoint();
                }
                else
                {
                    model.ColumnList[i].CreateHJoint();
                }
            }
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

                            var bone = col.NodeList[i];
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
                            var bone = col.NodeList[i];
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
                        var bone = col.NodeList[i];
                        bone.UpdateVJointSetting(js);
                    }
                }
                plugin.UpdateView();
            }
        }

        #endregion

        class Distance : IComparable<Distance>
        {
            public SkirtNode Bone;
            public float Length;

            public int CompareTo(Distance other)
            {
                return Length.CompareTo(other.Length);
            }
        }


     
        /// <summary>
        /// ウエィトを塗る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    foreach (var b in col.NodeList)
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
                foreach ( var b in col.NodeList )
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
            var treeNode = mainTreeView.SelectedNode;
            if (treeNode == null)
                return;

            switch (treeNode.Level)
            {
                case 2:
                    if ( node.Row == model.LayerCount - 1 
                        && node.Column.Pos == model.ColumnList.Count - 1 )
                    {
                        tbNext.Enabled = false;
                    }
                    else
                    {
                        tbNext.Enabled = true;
                    }
                    if (node.Row == 0 && node.Column.Pos == 0)
                        tbPrev.Enabled = false;
                    else
                        tbPrev.Enabled = true;
                    tbUp.Enabled = true;
                    tbDown.Enabled = false;

                    break;
            }
        }


        private void tbPrev_Click(object sender, EventArgs e)
        {
            var treeNode = mainTreeView.SelectedNode;
            if (treeNode == null)
                return;
            if (treeNode.Level == 2)
            {
                if ( treeNode.PrevNode != null )
                {
                    mainTreeView.SelectedNode = treeNode.PrevNode;
                }
                else if ( treeNode.Parent.PrevNode != null && treeNode.Parent.PrevNode.Nodes.Count > 0)
                {
                    mainTreeView.SelectedNode = treeNode.Parent.PrevNode.Nodes[treeNode.Parent.PrevNode.Nodes.Count - 1];
                    treeNode.Parent.Collapse();
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


        private void btnSort_Click(object sender, EventArgs e)
        {
            SortBones();
            SortBodies();
            SortJoints();
            plugin.UpdateView();

        }

        private void SortBones()
        {
            var temp = plugin.PMX.Bone.Where(b => b.Name.StartsWith("スカート_")).ToList();

            temp.ForEach(b => plugin.PMX.Bone.Remove(b));
            temp.Sort((a, b) => a.Name.CompareTo(b.Name));
            temp.ForEach(b => plugin.PMX.Bone.Add(b));
        }

        private void SortBodies()
        {
            var temp = plugin.PMX.Body.Where(b => b.Name.StartsWith("スカート_")).ToList();
            temp.ForEach(b => plugin.PMX.Body.Remove(b));
            temp.Sort((a, b) => a.Name.CompareTo(b.Name));
            temp.ForEach(b => plugin.PMX.Body.Add(b));
        }

        private void SortJoints()
        {
            var temp = plugin.PMX.Joint.Where(
                b => b.Name.StartsWith("スカート_") || b.Name.StartsWith("横スカート_")
                ).ToList();
            temp.ForEach(b => plugin.PMX.Joint.Remove(b));
            temp.Sort((a, b) => a.Name.CompareTo(b.Name));
            temp.ForEach(b => plugin.PMX.Joint.Add(b));
        }


    }

    
}
