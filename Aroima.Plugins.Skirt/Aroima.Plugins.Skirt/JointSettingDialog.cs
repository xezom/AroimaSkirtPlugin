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
        List<Action<JointSettings>> validators = new List<Action<JointSettings>>();
        List<JointSettings> settingsList;
        bool modified = false;
        int current = -1;
        JointSettings settings;


        public JointSettingDialog()
        {
            InitializeComponent();

            validators.Add(t => t.Limit_MoveLow.X = Validators.GetFloat(textLimitMoveLX, "移動制限 X下限"));
            validators.Add(t => t.Limit_MoveHigh.X = Validators.GetFloat(textLimitMoveHX, "移動制限 X上限"));
            validators.Add(t => t.Limit_MoveLow.Y = Validators.GetFloat(textLimitMoveLY, "移動制限 Y下限"));
            validators.Add(t => t.Limit_MoveHigh.Y = Validators.GetFloat(textLimitMoveHY, "移動制限 Y上限"));
            validators.Add(t => t.Limit_MoveLow.Z = Validators.GetFloat(textLimitMoveLZ, "移動制限 Z下限"));
            validators.Add(t => t.Limit_MoveHigh.Z = Validators.GetFloat(textLimitMoveHZ, "移動制限 Z上限"));

            validators.Add(t => t.Limit_AngleLow.X = Validators.GetFloat(textLimitAngLX, "移動制限 X下限"));
            validators.Add(t => t.Limit_AngleHigh.X = Validators.GetFloat(textLimitMoveHX, "移動制限 X上限"));
            validators.Add(t => t.Limit_AngleLow.Y = Validators.GetFloat(textLimitAngLY, "移動制限 Y下限"));
            validators.Add(t => t.Limit_AngleHigh.Y = Validators.GetFloat(textLimitMoveHY, "移動制限 Y上限"));
            validators.Add(t => t.Limit_AngleLow.Z = Validators.GetFloat(textLimitAngLZ, "移動制限 Z下限"));
            validators.Add(t => t.Limit_AngleHigh.Z = Validators.GetFloat(textLimitMoveHZ, "移動制限 Z上限"));

            validators.Add(t => t.SpringConst_Move.X = Validators.GetFloat(textSpringConstMoveX, "ばね移動X"));
            validators.Add(t => t.SpringConst_Move.Y = Validators.GetFloat(textSpringConstMoveY, "ばね移動Y"));
            validators.Add(t => t.SpringConst_Move.Z = Validators.GetFloat(textSpringConstMoveZ, "ばね移動Z"));

            validators.Add(t => t.SpringConst_Rotate.X = Validators.GetFloat(textSpringConstRotX, "ばね回転X"));
            validators.Add(t => t.SpringConst_Rotate.Y = Validators.GetFloat(textSpringConstRotY, "ばね回転Y"));
            validators.Add(t => t.SpringConst_Rotate.Z = Validators.GetFloat(textSpringConstRotZ, "ばね回転Z"));
        }


        public List<JointSettings> SettingsList { get => settingsList; set => settingsList = value; }

        private void JointSettingDialog_Load(object sender, EventArgs e)
        {
            foreach (var js in settingsList)
                listJointSettings.Items.Add(js);
            if (settingsList.Count > 0)
                listJointSettings.SelectedIndex = 0;

            UpdateView();
            modified = false;
        }

        private void UpdateView()
        {


            textLimitMoveHX.Text = settings.Limit_MoveHigh.X.ToString();
            textLimitMoveHY.Text = settings.Limit_MoveHigh.Y.ToString();
            textLimitMoveHZ.Text = settings.Limit_MoveHigh.Z.ToString();

            textLimitMoveLX.Text = settings.Limit_MoveLow.X.ToString();
            textLimitMoveLY.Text = settings.Limit_MoveLow.Y.ToString();
            textLimitMoveLZ.Text = settings.Limit_MoveLow.Z.ToString();

            textSpringConstMoveX.Text = settings.SpringConst_Move.X.ToString();
            textSpringConstMoveY.Text = settings.SpringConst_Move.Y.ToString();
            textSpringConstMoveZ.Text = settings.SpringConst_Move.Z.ToString();

            textSpringConstRotX.Text = settings.SpringConst_Rotate.X.ToString();
            textSpringConstRotY.Text = settings.SpringConst_Rotate.Y.ToString();
            textSpringConstRotZ.Text = settings.SpringConst_Rotate.Z.ToString();
        }

        private void listJointSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = listJointSettings.SelectedIndex;
            if ( current != selected)
            {
                if ( modified )
                {
                    if (!UpdateData())
                    {
                        listJointSettings.SelectedIndex = selected;
                    }
                    else
                    {
                        settings = (JointSettings)listJointSettings.Items[selected];
                        current = selected;
                        UpdateView();
                        modified = false;
                    }
                }
                else
                {
                    settings = (JointSettings)listJointSettings.Items[selected];
                    current = selected;
                    UpdateView();
                    modified = false;
                }
            }
        }

        private bool UpdateData()
        {
            var t = new JointSettings();
            try
            {
                foreach (var v in validators)
                    v(t);
            }
            catch ( ValidationException e)
            {
                MessageBox.Show(e.Message);
                e.TargetControl.Focus();
                return false;
            }
            settings.Limit_MoveLow = t.Limit_MoveLow;
            settings.Limit_MoveHigh = t.Limit_MoveHigh;
            settings.Limit_AngleLow = t.Limit_AngleLow;
            settings.Limit_AngleHigh = t.Limit_AngleHigh;
            settings.SpringConst_Move = t.SpringConst_Move;
            settings.SpringConst_Rotate = t.SpringConst_Rotate;
            return true;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            modified = true;
        }
    }
}
