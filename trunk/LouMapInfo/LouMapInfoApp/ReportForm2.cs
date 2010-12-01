using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Reports.core;
using EricUtility.Windows.Forms;
using LouMapInfo.Entities;

namespace LouMapInfoApp
{
    public partial class ReportForm2 : Form
    {
        ReportInfo report;
        int depth;
        public ReportForm2(ReportInfo r, int d)
        {
            InitializeComponent();
            CustomTabControl tctl = new CustomTabControl();
            tctl.Controls.Add(this.tpageReport);
            tctl.Controls.Add(this.tpageBBCode);
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
            report = r;
            depth = d;
            Text = r.Title;
            switch (r.Type)
            {
                case LouMapInfo.Entities.CityCastleType.Both: btnBoth_Click(null, new EventArgs()); break;
                case LouMapInfo.Entities.CityCastleType.City: btnCities_Click(null, new EventArgs()); break;
                case LouMapInfo.Entities.CityCastleType.Castle: btnCastles_Click(null, new EventArgs()); break;
            }
            switch (d)
            {
                case 1: btnReportsLvl1_Click(null, new EventArgs()); break;
                case 2: btnReportsLvl2_Click(null, new EventArgs()); break;
                case 3: btnReportsLvl3_Click(null, new EventArgs()); break;
            }
            txtBBCode.Text = report.BBCode(depth);
            reportBrowser.DocumentText = report.Report(depth);
        }
        private void btnBBCode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            btn.Checked = !btn.Checked;
            string b = btn.Name.Replace("btnBBCode", "").ToLower();
            report.BBCodeDisplay[b] = btn.Checked;
            txtBBCode.Text = report.BBCode(depth);
        }

        private void txtBBCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                txtBBCode.SelectAll();
        }

        private void btnBBCodeDisplay_ButtonClick(object sender, EventArgs e)
        {
            btnBBCodeDisplay.ShowDropDown();
        }

        private void btnCopyAllBBCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBCode.Text);
        }

        private void btnReportsLvl_ButtonClick(object sender, EventArgs e)
        {
            btnReportsLvl.ShowDropDown();
        }

        private void btnReportsLvl1_Click(object sender, EventArgs e)
        {
            depth = 1;
            btnReportsLvl.Text = btnReportsLvl1.Text;
            btnReportsLvl1.Checked = true;
            btnReportsLvl2.Checked = false;
            btnReportsLvl3.Checked = false;
            txtBBCode.Text = report.BBCode(depth);
            reportBrowser.DocumentText = report.Report(depth);
        }

        private void btnReportsLvl2_Click(object sender, EventArgs e)
        {
            depth = 2;
            btnReportsLvl.Text = btnReportsLvl2.Text;
            btnReportsLvl1.Checked = false;
            btnReportsLvl2.Checked = true;
            btnReportsLvl3.Checked = false;
            if (sender != null)
            {
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnReportsLvl3_Click(object sender, EventArgs e)
        {
            depth = 3;
            btnReportsLvl.Text = btnReportsLvl3.Text;
            btnReportsLvl1.Checked = false;
            btnReportsLvl2.Checked = false;
            btnReportsLvl3.Checked = true;
            if (sender != null)
            {
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }
        private void btnCityType_ButtonClick(object sender, EventArgs e)
        {
            btnCityType.ShowDropDown();
        }

        private void btnBoth_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnBoth.Text;
            btnBoth.Checked = true;
            btnCities.Checked = false;
            btnCastles.Checked = false;
            report.Type = CityCastleType.Both;
            if (sender != null)
            {
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnCastles_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnCastles.Text;
            btnBoth.Checked = false;
            btnCities.Checked = false;
            btnCastles.Checked = true;
            report.Type = CityCastleType.Castle;
            if (sender != null)
            {
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnCities_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnCities.Text;
            btnBoth.Checked = false;
            btnCities.Checked = true;
            btnCastles.Checked = false;
            report.Type = CityCastleType.City;
            if (sender != null)
            {
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }
    }
}
