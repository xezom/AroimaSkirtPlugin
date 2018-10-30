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
    public partial class BodySettingsDialog : Form
    {
        BodySettings settings;
        bool modified = false;

        CheckBox[] chkPassGroup = new CheckBox[16];

        List<Action<BodySettings>> validators = new List<Action<BodySettings>>();
        List<BodySettings> bodySettingsList;
        int current = -1;

        public List<BodySettings> BodySettingsList { get => bodySettingsList; set => bodySettingsList = value; }

        public BodySettingsDialog()
        {
            InitializeComponent();

            chkPassGroup[0] = checkBox1;
            chkPassGroup[1] = checkBox2;
            chkPassGroup[2] = checkBox3;
            chkPassGroup[3] = checkBox4;
            chkPassGroup[4] = checkBox5;
            chkPassGroup[5] = checkBox6;
            chkPassGroup[6] = checkBox7;
            chkPassGroup[7] = checkBox8;
            chkPassGroup[8] = checkBox9;
            chkPassGroup[9] = checkBox10;
            chkPassGroup[10] = checkBox11;
            chkPassGroup[11] = checkBox12;
            chkPassGroup[12] = checkBox13;
            chkPassGroup[13] = checkBox14;
            chkPassGroup[14] = checkBox15;
            chkPassGroup[15] = checkBox16;

            validators.Add(validateMode);
            validators.Add(validateBoxKind);
            validators.Add(t =>
                t.Mass = Validators.GetFloatGTEZ(textMass, "質量"));
            validators.Add(t =>
                t.PositionDamping = Validators.GetFloatGTEZ(textPositionDamping, "移動減衰"));
            validators.Add(t =>
                t.RotationDamping = Validators.GetFloatGTEZ(textRotationDamping, "回転減衰"));
            validators.Add(t =>
                t.Restriction = Validators.GetFloatGTEZ(textRestriction, "反発力"));
            validators.Add(t =>
                t.Friction = Validators.GetFloatGTEZ(textFriction, "摩擦力"));
            validators.Add(validateGroup);
            validators.Add(validatePassGroup);
        }

        private void BodySettingsDialog_Load(object sender, EventArgs e)
        {
            foreach ( var s in BodySettingsList )
            {
                listBodySettings.Items.Add(s);
            }
            listBodySettings.SelectedIndex = 0;

            UpdateView();

            modified = false;
        }

        private void listBodySettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = listBodySettings.SelectedIndex;
            if ( selected == current )
            {

            }
            else
            {
                if ( modified )
                {
                    if ( UpdateData() )
                    {
                        current = selected;
                        settings = (BodySettings)listBodySettings.Items[selected];
                        UpdateView();
                        modified = false;
                    }
                    else
                    {
                        listBodySettings.SelectedIndex = current;
                    }
                }
                else
                {
                    current = selected;
                    settings = (BodySettings)listBodySettings.Items[selected];
                    UpdateView();
                    modified = false;
                }
            }
        }

        private void UpdateView()
        {
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
            for (int i = 0; i < 16; i++)
            {
                chkPassGroup[i].Checked = settings.PassGroup[i] == 1;
                if (chkPassGroup[i].Checked)
                    list.Add((i + 1).ToString());
            }
            textPassGroup.Text = String.Join(",", list.ToArray());
        }

        private bool UpdateData()
        {
            var t = new BodySettings();
            try
            {
                foreach (var validator in validators)
                    validator(t);
            }
            catch (ValidationException e)
            {
                MessageBox.Show(e.Message);
                e.TargetControl.Focus();
                if ( e.TargetControl is TextBox)
                {
                    // TODO
                }
                return false;
            }
            settings.BoxKind = t.BoxKind;
            settings.Mode = t.Mode;
            settings.BoxSize.X = t.BoxSize.X;
            settings.BoxSize.Y = t.BoxSize.Y;
            settings.BoxSize.Z = t.BoxSize.Z;
            settings.Mass = t.Mass;
            settings.PositionDamping = t.PositionDamping;
            settings.RotationDamping = t.RotationDamping;
            settings.Restriction = t.Restriction;
            settings.Friction = t.Friction;
            settings.Group = t.Group;
            for (int i = 0; i < 16; i++)
                settings.PassGroup[i] = t.PassGroup[i];


            return true;
        }

        private void validateMode(BodySettings temp)
        {
            if (rbStatic.Checked)
                temp.Mode = BodyMode.Static;
            else if (rbDynamic.Checked)
                temp.Mode = BodyMode.Dynamic;
            else
                temp.Mode = BodyMode.DynamicWithBone;
        }
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
            for (int i = 0; i < 16; i++)
            {
                t.PassGroup[i] = chkPassGroup[i].Checked ? 1 : 0;
            }
        }
        


            private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

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

            modified = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var list = new List<string>();
            for (int i = 0; i < 16; i++)
            {
                if (chkPassGroup[i].Checked)
                    list.Add((i + 1).ToString());
            }
            textPassGroup.Text = String.Join(",", list.ToArray());
            modified = true;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            modified = true;
        }


    }

    public class ValidationException : Exception
    {
        Control control_;

        public ValidationException(string message, Control control):base(message)
        {
            this.control_ = control;
        }

        public Control TargetControl { get => control_; set => control_ = value; }
    }

     
}
