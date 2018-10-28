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
    public partial class RemoveDialog : Form
    {
        public RemoveDialog()
        {
            InitializeComponent();
        }

        bool removeBone = false;
        bool removeBody = false;
        bool removeJoint = false;

        public bool RemoveBone { get => removeBone; set => removeBone = value; }
        public bool RemoveBody { get => removeBody; set => removeBody = value; }
        public bool RemoveJoint { get => removeJoint; set => removeJoint = value; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            removeBone = chkBone.Checked;
            removeBody = chkBody.Checked;
            removeJoint = chkJoint.Checked;
        }
    }
}
