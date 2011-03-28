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
        public ContinentPicker()
        {
            InitializeComponent();
        }

        private void toolStripButton47_Click(object sender, EventArgs e)
        {
            continent = int.Parse(((ToolStripButton)sender).Text);
            Close();
        }

        private void btnReportsLvl1_Click(object sender, EventArgs e)
        {

        }

        private void btnReportsLvl2_Click(object sender, EventArgs e)
        {

        }

        private void btnReportsLvl3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptions_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptionsCityCount_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptionsCityScore_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptionsCityName_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptionsPlayerCount_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptionsPlayerScore_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptionsAllianceScore_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayOptionsAllianceRank_Click(object sender, EventArgs e)
        {

        }
    }
}
