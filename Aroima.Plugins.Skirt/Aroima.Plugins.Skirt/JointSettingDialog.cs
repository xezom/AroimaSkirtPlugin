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
    public partial class JointSettingDialog : Form
    {
        ViewModel<JointSettings> vm = new ViewModel<JointSettings>();

        #region プロパティ

        public ViewModel<JointSettings> Vm { get => vm; set => vm = value; }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public JointSettingDialog()
        {
            InitializeComponent();

            Func<float, bool> rangeCheck = (r) => r >= -180 && r <= 180;

            vm.ModelUpdated += Vm_ModelUpdated;
            vm.ModelModified += Vm_ModelModified;
            vm.SelectionChanged += Vm_SelectionChanged;

            vm.Add(t => t.Limit_MoveLow.X = Validators.GetFloat(textLimitMoveLX, "移動制限 X下限"));
            vm.Add(t => t.Limit_MoveHigh.X = Validators.GetFloat(textLimitMoveHX, "移動制限 X上限"));
            vm.Add(t => t.Limit_MoveLow.Y = Validators.GetFloat(textLimitMoveLY, "移動制限 Y下限"));
            vm.Add(t => t.Limit_MoveHigh.Y = Validators.GetFloat(textLimitMoveHY, "移動制限 Y上限"));
            vm.Add(t => t.Limit_MoveLow.Z = Validators.GetFloat(textLimitMoveLZ, "移動制限 Z下限"));
            vm.Add(t => t.Limit_MoveHigh.Z = Validators.GetFloat(textLimitMoveHZ, "移動制限 Z上限"));

            vm.Add(t => t.Limit_AngleLow.X = Validators.GetFloat(textLimitAngLX, "角度制限 X下限", rangeCheck));
            vm.Add(t => t.Limit_AngleHigh.X = Validators.GetFloat(textLimitAngHX, "角度制限 X上限", rangeCheck));
            vm.Add(t => t.Limit_AngleLow.Y = Validators.GetFloat(textLimitAngLY, "角度制限 Y下限", rangeCheck));
            vm.Add(t => t.Limit_AngleHigh.Y = Validators.GetFloat(textLimitAngHY, "角度制限 Y上限", rangeCheck));
            vm.Add(t => t.Limit_AngleLow.Z = Validators.GetFloat(textLimitAngLZ, "角度制限 Z下限", rangeCheck));
            vm.Add(t => t.Limit_AngleHigh.Z = Validators.GetFloat(textLimitAngHZ, "角度制限 Z上限", rangeCheck));

            vm.Add(t => t.SpringConst_Move.X = Validators.GetFloat(textSpringConstMoveX, "ばね移動X"));
            vm.Add(t => t.SpringConst_Move.Y = Validators.GetFloat(textSpringConstMoveY, "ばね移動Y"));
            vm.Add(t => t.SpringConst_Move.Z = Validators.GetFloat(textSpringConstMoveZ, "ばね移動Z"));

            vm.Add(t => t.SpringConst_Rotate.X = Validators.GetFloat(textSpringConstRotX, "ばね回転X"));
            vm.Add(t => t.SpringConst_Rotate.Y = Validators.GetFloat(textSpringConstRotY, "ばね回転Y"));
            vm.Add(t => t.SpringConst_Rotate.Z = Validators.GetFloat(textSpringConstRotZ, "ばね回転Z"));
        }

        /// <summary>
        /// 画面初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JointSettingDialog_Load(object sender, EventArgs e)
        {
            listJointSettings.Items.Clear();
            if (vm.DataSource == null)
                return;
            foreach (var js in vm.DataSource)
                listJointSettings.Items.Add(js);

            listJointSettings.SelectedIndex = 0;
        }

        /// <summary>
        /// 選択変更
        /// 表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vm_SelectionChanged(object sender, EventArgs e)
        {
            var settings = vm.Seleced;


            textLimitMoveHX.Text = settings.Limit_MoveHigh.X.ToString();
            textLimitMoveHY.Text = settings.Limit_MoveHigh.Y.ToString();
            textLimitMoveHZ.Text = settings.Limit_MoveHigh.Z.ToString();

            textLimitMoveLX.Text = settings.Limit_MoveLow.X.ToString();
            textLimitMoveLY.Text = settings.Limit_MoveLow.Y.ToString();
            textLimitMoveLZ.Text = settings.Limit_MoveLow.Z.ToString();

            textLimitAngLX.Text = settings.Limit_AngleLow.X.ToAngle().ToString();
            textLimitAngLY.Text = settings.Limit_AngleLow.Y.ToAngle().ToString();
            textLimitAngLZ.Text = settings.Limit_AngleLow.Z.ToAngle().ToString();

            textLimitAngHX.Text = settings.Limit_AngleHigh.X.ToAngle().ToString();
            textLimitAngHY.Text = settings.Limit_AngleHigh.Y.ToAngle().ToString();
            textLimitAngHZ.Text = settings.Limit_AngleHigh.Z.ToAngle().ToString();


            textSpringConstMoveX.Text = settings.SpringConst_Move.X.ToString();
            textSpringConstMoveY.Text = settings.SpringConst_Move.Y.ToString();
            textSpringConstMoveZ.Text = settings.SpringConst_Move.Z.ToString();

            textSpringConstRotX.Text = settings.SpringConst_Rotate.X.ToString();
            textSpringConstRotY.Text = settings.SpringConst_Rotate.Y.ToString();
            textSpringConstRotZ.Text = settings.SpringConst_Rotate.Z.ToString();
        }

        /// <summary>
        /// 変更発生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vm_ModelModified(object sender, EventArgs e)
        {
            tbCommit.Enabled = vm.Modified;
            tbCancel.Enabled = vm.Modified;
        }

        /// <summary>
        /// 変更確定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vm_ModelUpdated(object sender, ModelUpdatedEventArgs<JointSettings> e)
        {
            var t = e.Src;
            var settings = vm.Seleced;

            settings.Limit_MoveLow.X = t.Limit_MoveLow.X;
            settings.Limit_MoveLow.Y = t.Limit_MoveLow.Y;
            settings.Limit_MoveLow.Z = t.Limit_MoveLow.Z;

            settings.Limit_MoveHigh.X = t.Limit_MoveHigh.X;
            settings.Limit_MoveHigh.Y = t.Limit_MoveHigh.Y;
            settings.Limit_MoveHigh.Z = t.Limit_MoveHigh.Z;

            settings.Limit_AngleLow.X = FuncUtil.toRad(t.Limit_AngleLow.X);
            settings.Limit_AngleLow.Y = FuncUtil.toRad(t.Limit_AngleLow.Y);
            settings.Limit_AngleLow.Z = FuncUtil.toRad(t.Limit_AngleLow.Z);


            settings.Limit_AngleHigh.X = FuncUtil.toRad(t.Limit_AngleHigh.X);
            settings.Limit_AngleHigh.Y = FuncUtil.toRad(t.Limit_AngleHigh.Y);
            settings.Limit_AngleHigh.Z = FuncUtil.toRad(t.Limit_AngleHigh.Z);

            settings.SpringConst_Move.X = t.SpringConst_Move.X;
            settings.SpringConst_Move.Y = t.SpringConst_Move.Y;
            settings.SpringConst_Move.Z = t.SpringConst_Move.Z;


            settings.SpringConst_Rotate.X = t.SpringConst_Rotate.X;
            settings.SpringConst_Rotate.Y = t.SpringConst_Rotate.Y;
            settings.SpringConst_Rotate.Z = t.SpringConst_Rotate.Z;
        }

        /// <summary>
        /// 選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listJointSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = listJointSettings.SelectedIndex;
            var obj = (JointSettings)listJointSettings.SelectedItem;
            int idx = vm.SelectionChanging(selected, obj);
            if (idx != selected)
                listJointSettings.SelectedIndex = idx;
        }

        
        /// <summary>
        /// テキストボックス変更発生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_TextChanged(object sender, EventArgs e)
        {
            vm.Modified = true;
        }

        /// <summary>
        /// 閉じる時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JointSettingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vm.Modified && MessageBox.Show("変更されているけど閉じていい?", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            e.Cancel = true;
        }

        #region ツールボタン

        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCancel_Click(object sender, EventArgs e)
        {
            vm.Cancel();
        }

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCommit_Click(object sender, EventArgs e)
        {
            vm.Commit();
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
    }
}
