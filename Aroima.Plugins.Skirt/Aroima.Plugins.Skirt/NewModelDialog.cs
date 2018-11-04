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

        private void ndLayerNum_ValueChanged(object sender, EventArgs e)
        {
            layerNum = (int)ndLayerNum.Value;
            columnNum = (int)ndColumnNum.Value;
        }
    }
}
