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
    public partial class NewModelDialog : Form
    {
        int layerNum = 4;
        int columnNum = 16;
        List<string> boneNameList = new List<string>();
        string parentBoneName;

        public NewModelDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 階層数
        /// </summary>
        public int LayerNum { get => layerNum; set => layerNum = value; }

        /// <summary>
        /// 列数
        /// </summary>
        public int ColumnNum { get => columnNum; set => columnNum = value; }
        public List<string> BoneNameList { get => boneNameList; set => boneNameList = value; }
        public string ParentBoneName { get => parentBoneName; set => parentBoneName = value; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            layerNum = (int)ndLayerNum.Value;
            columnNum = (int)ndColumnNum.Value;
            parentBoneName = (string)CmbParentName.SelectedItem;
            
        }

        private void NewModelDialog_Load(object sender, EventArgs e)
        {
            CmbParentName.Items.AddRange(boneNameList.ToArray());
            CmbParentName.SelectedIndex = 0;
            for ( int i = 0; i < boneNameList.Count; i++)
                if ( boneNameList[i] == "下半身")
                {
                    CmbParentName.SelectedIndex = i;
                    break;
                }
        }
    }
}
