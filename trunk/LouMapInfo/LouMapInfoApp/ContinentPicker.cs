using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LouMapInfoApp
{
    public partial class ContinentPicker : Form
    {
        int continent = -1;
        public int Continent { get { return continent; } }
        public ContinentPicker(int x, int y)
        {
            InitializeComponent();
            Size = new Size(8 + (23 * x), 23 + (25 * y));
            for (int i = x-1; i >= 0; --i)
            {
                ToolStrip tb = new ToolStrip();
                tb.GripStyle = ToolStripGripStyle.Hidden;
                tb.BackColor = Color.White;
                Controls.Add(tb);
                for (int j = 0; j < y; ++j)
                {
                    ToolStripButton btn = new ToolStripButton("" + i + j);
                    btn.Click += new EventHandler(ContinentPicked);
                    tb.Items.Add(btn);
                }
            }
        }

        private void ContinentPicked(object sender, EventArgs e)
        {
            continent = int.Parse(((ToolStripButton)sender).Text);
            Close();
        }
    }
}
