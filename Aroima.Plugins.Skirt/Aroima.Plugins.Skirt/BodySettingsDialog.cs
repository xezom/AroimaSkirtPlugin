using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PEPlugin.Pmd;
using PEPlugin.Pmx;

namespace Aroima.Plugins.Skirt
{
    /// <summary>
    /// 剛体設定画面
    /// </summary>
    public partial class BodySettingsDialog : Form
    {
        CheckBox[] chkPassGroup;

        ViewModel<BodySettings> vm = new ViewModel<BodySettings>();
        

        /// <summary>
        /// ViewModel
        /// </summary>
        public ViewModel<BodySettings> Vm { get => vm; set => vm = value; }
        

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BodySettingsDialog()
        {
            InitializeComponent();

            chkPassGroup = new CheckBox[]
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
                checkBox5,
                checkBox6,
                checkBox7,
                checkBox8,
                checkBox9,
                checkBox10,
                checkBox11,
                checkBox12,
                checkBox13,
                checkBox14,
                checkBox15,
                checkBox16
            };




            vm.SelectionChanged += Vm_SelectionChanged;
            vm.ModelUpdated += Vm_ModelUpdated;
            vm.ModelModified += Vm_ModelModified;

            vm.Add(validateMode);
            vm.Add(validateBoxKind);
            vm.Add(t => t.Mass = Validators.GetFloatGTEZ(textMass, "質量"));
            vm.Add(t => t.PositionDamping = Validators.GetFloatGTEZ(textPositionDamping, "移動減衰"));
            vm.Add(t => t.RotationDamping = Validators.GetFloatGTEZ(textRotationDamping, "回転減衰"));
            vm.Add(t => t.Restriction = Validators.GetFloatGTEZ(textRestriction, "反発力"));
            vm.Add(t => t.Friction = Validators.GetFloatGTEZ(textFriction, "摩擦力"));
            vm.Add(validateGroup);
            vm.Add(validatePassGroup);
           
        }

        /// <summary>
        /// 状態の変化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vm_ModelModified(object sender, EventArgs e)
        {
            tbCommit.Enabled = vm.Modified;
            tbCancel.Enabled = vm.Modified;
        }

        /// <summary>
        /// 画面初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BodySettingsDialog_Load(object sender, EventArgs e)
        {
            
                listBodySettings.Items.Clear();
                if (vm.DataSource == null)
                    return;

                foreach (var s in vm.DataSource)
                {
                    listBodySettings.Items.Add(s);
                }
                listBodySettings.SelectedIndex = 0;
            
        }

        /// <summary>
        /// 一覧から選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBodySettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = listBodySettings.SelectedIndex;
            BodySettings obj = (BodySettings)listBodySettings.SelectedItem;

            int r = vm.SelectionChanging(selected, obj);
            if (r != selected)
                listBodySettings.SelectedIndex = r;
        }

        /// <summary>
        /// 選択されたのを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vm_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                vm.Setup = true;
                var settings = vm.Seleced;
                switch (settings.Mode)
                {
                    case BodyMode.Static:
                        rbStatic.Checked = true;
                        break;
                    case BodyMode.Dynamic:
                        rbDynamic.Checked = true;
                        break;
                    case BodyMode.DynamicWithBone:
                        rbDynamicWithBone.Checked = true;
                        break;
                }
                switch (settings.BoxKind)
                {
                    case BodyBoxKind.Sphere:
                        rbSphere.Checked = true;
                        textSize1.Text = settings.BoxSize.X.ToString();

                        break;
                    case BodyBoxKind.Box:
                        rbBox.Checked = true;
                        textSize1.Text = settings.BoxSize.X.ToString();
                        textSize2.Text = settings.BoxSize.Y.ToString();
                        textSize3.Text = settings.BoxSize.Z.ToString();
                        break;
                    case BodyBoxKind.Capsule:
                        rbCapsule.Checked = true;
                        textSize1.Text = settings.BoxSize.X.ToString();
                        textSize2.Text = settings.BoxSize.Y.ToString();

                        break;
                }
                textMass.Text = settings.Mass.ToString();
                textPositionDamping.Text = settings.PositionDamping.ToString();
                textRotationDamping.Text = settings.RotationDamping.ToString();
                textRestriction.Text = settings.Restriction.ToString();
                textFriction.Text = settings.Friction.ToString();

                cmbGroup.SelectedIndex = settings.Group;

                var list = new List<string>();
                for (int i = 0; i < BodySettings.GROUP_SIZE; i++)
                {
                    chkPassGroup[i].Checked = settings.PassGroup[i] == 1;
                    if (chkPassGroup[i].Checked)
                        list.Add((i + 1).ToString());
                }
                textPassGroup.Text = String.Join(",", list.ToArray());
            }
            finally
            {
                vm.Setup = false;
            }
        }

        /// <summary>
        /// 画面の変更結果を反映する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vm_ModelUpdated(object sender, ModelUpdatedEventArgs<BodySettings> e)
        {
            vm.Seleced.Assign(e.Src);

        }

        #region 入力検証

        /// <summary>
        /// 
        /// </summary>
        /// <param name="temp"></param>
        private void validateMode(BodySettings temp)
        {
            if (rbStatic.Checked)
                temp.Mode = BodyMode.Static;
            else if (rbDynamic.Checked)
                temp.Mode = BodyMode.Dynamic;
            else
                temp.Mode = BodyMode.DynamicWithBone;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="temp"></param>
        private void validateBoxKind(BodySettings temp)
        {
            if (rbSphere.Checked)
            {
                temp.BoxKind = BodyBoxKind.Sphere;
                temp.BoxSize.X = Validators.GetFloatGTEZ(textSize1, labelSize1.Text);
            }
            else if (rbBox.Checked)
            {
                temp.BoxKind = BodyBoxKind.Box;
                temp.BoxSize.X = Validators.GetFloatGTEZ(textSize1, labelSize1.Text);
                temp.BoxSize.Y = Validators.GetFloatGTEZ(textSize2, labelSize2.Text);
                temp.BoxSize.Z = Validators.GetFloatGTEZ(textSize3, labelSize3.Text);
            }
            else
            {
                temp.BoxKind = BodyBoxKind.Capsule;
                temp.BoxSize.X = Validators.GetFloatGTEZ(textSize1, labelSize1.Text);
                temp.BoxSize.Y = Validators.GetFloatGTEZ(textSize2, labelSize2.Text);
            }
        }
        private void validateGroup(BodySettings t)
        {
            if (cmbGroup.SelectedIndex == -1)
                throw new ValidationException("グループを選択してください", cmbGroup);
            t.Group = cmbGroup.SelectedIndex;
        }
        private void validatePassGroup(BodySettings t)
        {
            for (int i = 0; i < BodySettings.GROUP_SIZE; i++)
            {
                t.PassGroup[i] = chkPassGroup[i].Checked ? 1 : 0;
            }
        }

        #endregion

        #region 画面変更

        private void rbSphere_CheckedChanged(object sender, EventArgs e)
        {
            selectBoxKind();
        }
        private void rbBox_CheckedChanged(object sender, EventArgs e)
        {
            selectBoxKind();
        }
        private void rbCapsule_CheckedChanged(object sender, EventArgs e)
        {
            selectBoxKind();
        }
        private void selectBoxKind()
        {
            if (rbSphere.Checked)
            {
                labelSize1.Visible = true;
                labelSize1.Text = "半径";
                textSize2.Visible = true;

                labelSize2.Visible = false;
                textSize2.Visible = false;

                labelSize3.Visible = false;
                textSize3.Visible = false;
            }
            else if (rbBox.Checked)
            {
                labelSize1.Text = "幅";
                labelSize2.Text = "高さ";
                labelSize3.Text = "奥行";

                labelSize1.Visible = true;
                textSize2.Visible = true;

                labelSize2.Visible = true;
                textSize2.Visible = true;

                labelSize3.Visible = true;
                textSize3.Visible = true;
            }
            else if (rbCapsule.Checked)
            {
                labelSize1.Text = "半径";
                labelSize2.Text = "高さ";

                labelSize1.Visible = true;
                textSize2.Visible = true;

                labelSize2.Visible = true;
                textSize2.Visible = true;

                labelSize3.Visible = false;
                textSize3.Visible = false;
            }

            vm.Modified = true;
        }

        /// <summary>
        /// 非衝突グループ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var list = new List<string>();
            for (int i = 0; i < BodySettings.GROUP_SIZE; i++)
            {
                if (chkPassGroup[i].Checked)
                    list.Add((i + 1).ToString());
            }
            textPassGroup.Text = String.Join(",", list.ToArray());
            vm.Modified = true;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            Vm.Modified = true;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vm.Modified = true;
        }

        private void rbStatic_CheckedChanged(object sender, EventArgs e)
        {
            Vm.Modified = true;
        }

        #endregion

        #region ツールボタン

        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCommit_Click(object sender, EventArgs e)
        {
            vm.Commit();
        }

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCancel_Click(object sender, EventArgs e)
        {
            vm.Cancel();
        }

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        /// <summary>
        /// 画面を閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BodySettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vm.Modified &&
                MessageBox.Show("変更されているけど閉じていい?", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;

        }
    }
}
