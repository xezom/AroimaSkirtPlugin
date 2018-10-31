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



        /// <summary>
        /// コンストラクタ
        /// </summary>
        public JointSettingDialog()
        {
            InitializeComponent();

            Func<float, bool> rangeCheck = (r) => r >= -180 && r <= 180;

            validators.Add(t => t.Limit_MoveLow.X = Validators.GetFloat(textLimitMoveLX, "移動制限 X下限"));
            validators.Add(t => t.Limit_MoveHigh.X = Validators.GetFloat(textLimitMoveHX, "移動制限 X上限"));
            validators.Add(t => t.Limit_MoveLow.Y = Validators.GetFloat(textLimitMoveLY, "移動制限 Y下限"));
            validators.Add(t => t.Limit_MoveHigh.Y = Validators.GetFloat(textLimitMoveHY, "移動制限 Y上限"));
            validators.Add(t => t.Limit_MoveLow.Z = Validators.GetFloat(textLimitMoveLZ, "移動制限 Z下限"));
            validators.Add(t => t.Limit_MoveHigh.Z = Validators.GetFloat(textLimitMoveHZ, "移動制限 Z上限"));

            validators.Add(t => t.Limit_AngleLow.X = Validators.GetFloat(textLimitAngLX, "角度制限 X下限", rangeCheck));
            validators.Add(t => t.Limit_AngleHigh.X = Validators.GetFloat(textLimitAngHX, "角度制限 X上限", rangeCheck));
            validators.Add(t => t.Limit_AngleLow.Y = Validators.GetFloat(textLimitAngLY, "角度制限 Y下限", rangeCheck));
            validators.Add(t => t.Limit_AngleHigh.Y = Validators.GetFloat(textLimitAngHY, "角度制限 Y上限", rangeCheck));
            validators.Add(t => t.Limit_AngleLow.Z = Validators.GetFloat(textLimitAngLZ, "角度制限 Z下限", rangeCheck));
            validators.Add(t => t.Limit_AngleHigh.Z = Validators.GetFloat(textLimitAngHZ, "角度制限 Z上限", rangeCheck));

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

        public void UpdateView()
        {
            Func<float, float> toAngle = x => x / (float)Math.PI * 180;

            textLimitMoveHX.Text = settings.Limit_MoveHigh.X.ToString();
            textLimitMoveHY.Text = settings.Limit_MoveHigh.Y.ToString();
            textLimitMoveHZ.Text = settings.Limit_MoveHigh.Z.ToString();

            textLimitMoveLX.Text = settings.Limit_MoveLow.X.ToString();
            textLimitMoveLY.Text = settings.Limit_MoveLow.Y.ToString();
            textLimitMoveLZ.Text = settings.Limit_MoveLow.Z.ToString();

            textLimitAngLX.Text = toAngle(settings.Limit_AngleLow.X).ToString();
            textLimitAngLY.Text = toAngle(settings.Limit_AngleLow.Y).ToString();
            textLimitAngLZ.Text = toAngle(settings.Limit_AngleLow.Z).ToString();

            textLimitAngHX.Text = toAngle(settings.Limit_AngleHigh.X).ToString();
            textLimitAngHY.Text = toAngle(settings.Limit_AngleHigh.Y).ToString();
            textLimitAngHZ.Text = toAngle(settings.Limit_AngleHigh.Z).ToString();


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
                        listJointSettings.SelectedIndex = current;
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
                if ( e.TargetControl is TextBox )
                {
                    ((TextBox)e.TargetControl).SelectAll();

                }

                return false;
            }
            Func<float, float> toRad = x => x / 180f * (float)Math.PI;

            settings.Limit_MoveLow.X = t.Limit_MoveLow.X;
            settings.Limit_MoveLow.Y = t.Limit_MoveLow.Y;
            settings.Limit_MoveLow.Z = t.Limit_MoveLow.Z;

            settings.Limit_MoveHigh.X = t.Limit_MoveHigh.X;
            settings.Limit_MoveHigh.Y = t.Limit_MoveHigh.Y;
            settings.Limit_MoveHigh.Z = t.Limit_MoveHigh.Z;

            settings.Limit_AngleLow.X = toRad(t.Limit_AngleLow.X);
            settings.Limit_AngleLow.Y = toRad(t.Limit_AngleLow.Y);
            settings.Limit_AngleLow.Z = toRad(t.Limit_AngleLow.Z);


            settings.Limit_AngleHigh.X = toRad(t.Limit_AngleHigh.X);
            settings.Limit_AngleHigh.Y = toRad(t.Limit_AngleHigh.Y);
            settings.Limit_AngleHigh.Z = toRad(t.Limit_AngleHigh.Z);

            settings.SpringConst_Move.X = t.SpringConst_Move.X;
            settings.SpringConst_Move.Y = t.SpringConst_Move.Y;
            settings.SpringConst_Move.Z = t.SpringConst_Move.Z;


            settings.SpringConst_Rotate.X = t.SpringConst_Rotate.X;
            settings.SpringConst_Rotate.Y = t.SpringConst_Rotate.Y;
            settings.SpringConst_Rotate.Z = t.SpringConst_Rotate.Z;


            return true;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private void JointSettingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified)
            {
                if (!UpdateData())
                    e.Cancel = true;
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (modified)
            {
                UpdateView();
                modified = false;
            }
        }
    }
    /*
    class ViewModel
    {
        int currentIndex;
        bool modified;
        JointSettings settings;
        JointSettingDialog form;
        List<Action<JointSettings>> validators = new List<Action<JointSettings>>();

        public bool Modified { get => modified; set => modified = value; }
        public int CurrentIndex { get => currentIndex; set => currentIndex = value; }
        public List<Action<JointSettings>> Validators { get => validators;  }

        public ViewModel(JointSettingDialog form)
        {
            this.form = form;

        }
  

        public int SetSelected(int selected)
        {
            if (currentIndex != selected)
            {
                if (modified)
                {
                    if (!UpdateData())
                    {
                        return  selected;
                    }
                    else
                    {
                        settings = (JointSettings)listJointSettings.Items[selected];
                        currentIndex = selected;
                        form.UpdateView();
                        modified = false;
                    }
                }
                else
                {
                    settings = (JointSettings)listJointSettings.Items[selected];
                    currentIndex = selected;
                    form.UpdateView();
                    modified = false;
                }
            }
        }

        public void AddValidator(Action<JointSettings> validator)
        {

            validators.Add(validator);
        }

        public bool UpdateData()
        {
            var t = new JointSettings();
            try
            {
                foreach (var v in Validators)
                    v(t);
            }
            catch (ValidationException e)
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
    }*/
}
