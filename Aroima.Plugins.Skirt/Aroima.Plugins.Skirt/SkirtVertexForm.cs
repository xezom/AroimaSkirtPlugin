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
    public partial class SkirtVertexForm : Form
    {
        ViewModel<Vertex> vm = new ViewModel<Vertex>();

        public SkirtVertexForm()
        {
            InitializeComponent();

            vm.SelectionChanged += Vm_SelectionChanged;
        }

        public ViewModel<Vertex> Vm { get => vm; set => vm = value; }

        private void SkirtVertexForm_Load(object sender, EventArgs e)
        {

            foreach (var v in Vm.DataSource)
            {
                var item = new ListViewItem(v.Id.ToString());
                item.SubItems.Add(v.X.ToString());
                item.SubItems.Add(v.Y.ToString());
                item.SubItems.Add(v.Z.ToString());
                item.Tag = v;

                listVertex.Items.Add(item);
            }

            listVertex.Items[0].Selected = true;
        }

        private void Vm_SelectionChanged(object sender, EventArgs e)
        {
            var v = Vm.Seleced;

            bone1ComboBox.Text = v.Bone1;
            bone2ComboBox.Text = v.Bone2;
            bone3ComboBox.Text = v.Bone3;
            bone4ComboBox.Text = v.Bone4;

            weight1TextBox.Text = v.Weight1.ToString();
            weight2TextBox.Text = v.Weight2.ToString();
            weight3TextBox.Text = v.Weight3.ToString();
            weight4TextBox.Text = v.Weight4.ToString();
        }

        private void listVertex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listVertex.SelectedIndices.Count == 0)
                return;
            int selected = listVertex.SelectedIndices[0];
            Vertex obj = (Vertex)listVertex.SelectedItems[0].Tag;
            
            int r = vm.SelectionChanging(selected, obj);
            if (r != selected)
                listVertex.Items[r].Selected = true;
        }
    }
}
