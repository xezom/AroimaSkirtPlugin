using Aroima.Plugins.Skirt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aroima.Plugins.FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bb = new BodySettingsBuilder();
            var list = new List<BodySettings>();
            for (int i = 0; i < 4; i++)
                list.Add(bb.Build(i, 4));
            

            using (var dlg = new BodySettingsDialog())
            {
                dlg.Vm.DataSource = list;
                dlg.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var builder = new VJointSettingsBuilder();
            var list = new List<JointSettings>();
            for (int i = 0; i < 4; i++)
                list.Add(builder.Build(i, 4));

            using (var dlg = new JointSettingDialog())
            {
                dlg.Vm.DataSource = list;
                dlg.ShowDialog();
            }
        }
    }
}
