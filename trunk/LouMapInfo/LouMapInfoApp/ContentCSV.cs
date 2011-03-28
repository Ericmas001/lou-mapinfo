using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Reports.core;
using EricUtility.Windows.Forms;
using EricUtility;
using System.Threading;
using LouMapInfo.CSV;
using System.Diagnostics;

namespace LouMapInfoApp
{
    public partial class ContentCSV : UserControl
    {
        ReportCSV m_Report; 
        string m_Filename;
        public ContentCSV(ReportCSV r, string filename)
        {
            m_Report = r;
            m_Filename = filename;
            InitializeComponent();
            CustomTabControl tctl = new CustomTabControl();
            tctl.Controls.Add(this.tpageReport);
            tctl.Controls.Add(this.tpageBBCode);
            //tctl.Controls.Add(this.tabPage1);
            tctl.DisplayStyle = EricUtility.Windows.Forms.TabStyle.Chrome;
            // 
            tctl.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            tctl.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            tctl.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            tctl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            tctl.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.White;
            tctl.DisplayStyleProvider.FocusTrack = false;
            tctl.DisplayStyleProvider.HotTrack = true;
            tctl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tctl.DisplayStyleProvider.Opacity = 1F;
            tctl.DisplayStyleProvider.Overlap = 16;
            tctl.DisplayStyleProvider.Padding = new System.Drawing.Point(10, 5);
            tctl.DisplayStyleProvider.Radius = 16;
            tctl.DisplayStyleProvider.ShowTabCloser = false;
            tctl.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            tctl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            tctl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            tctl.Dock = System.Windows.Forms.DockStyle.Fill;
            tctl.HotTrack = true;
            tctl.Location = new System.Drawing.Point(0, 0);
            tctl.Name = "tctl";
            tctl.SelectedIndex = 0;
            tctl.Size = new System.Drawing.Size(707, 468);
            tctl.TabIndex = 0;
            tctl.Alignment = TabAlignment.Bottom;
            pnlContent.Controls.Remove(customTabControl1);
            pnlContent.Controls.Add(tctl);
            txtBBCode.Text = r.RawFile();
        }

        private void tpageReport_SizeChanged(object sender, EventArgs e)
        {
            btnOpenCSV.Location = new Point((Width / 2) - (btnOpenCSV.Width / 2), (Height / 2) - (btnOpenCSV.Height / 2));
        }

        private void btnCopyAllBBCode_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenCSV_Click(object sender, EventArgs e)
        {
            Process.Start(m_Filename);
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
