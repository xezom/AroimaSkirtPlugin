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
            var list = new List<BodySettings>();
            list.Add(new BodySettings());
            list.Add(new BodySettings());
            using (var dlg = new BodySettingsDialog()
            {
                BodySettingsList = list
            })
            {
                dlg.ShowDialog();
            }
        }
    }
}
