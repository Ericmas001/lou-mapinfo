using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LouMapInfoApp.V4
{
    public partial class ContinentPicker : Form
    {
        int continent = -1;
        public int Continent { get { return continent; } }
        public ContinentPicker()
        {
            InitializeComponent();
        }

        private void toolStripButton47_Click(object sender, EventArgs e)
        {
            continent = int.Parse(((ToolStripButton)sender).Text);
            Close();
        }
    }
}
