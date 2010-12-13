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
using EricUtility;

namespace LouMapInfoApp
{
    public partial class ReportForm : Form
    {
        ReportInfo report;
        int depth;
        public ReportForm(ReportInfo r, int d)
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
            Text = StringUtility.RemoveBBCodeTags(r.Title);
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
            btnBBCodeB.Checked = Properties.Settings.Default.bbCode_b;
            btnBBCodeI.Checked = Properties.Settings.Default.bbCode_i;
            btnBBCodeU.Checked = Properties.Settings.Default.bbCode_u;
            btnBBCodeS.Checked = Properties.Settings.Default.bbCode_s;
            btnBBCodeUrl.Checked = Properties.Settings.Default.bbCode_url;
            btnBBCodeCity.Checked = Properties.Settings.Default.bbCode_city;
            btnBBCodePlayer.Checked = Properties.Settings.Default.bbCode_player;
            btnBBCodeAlliance.Checked = Properties.Settings.Default.bbCode_alliance;
            r.BBCodeDisplay["b"] = btnBBCodeB.Checked;
            r.BBCodeDisplay["i"] = btnBBCodeI.Checked;
            r.BBCodeDisplay["u"] = btnBBCodeS.Checked;
            r.BBCodeDisplay["s"] = btnBBCodeU.Checked;
            r.BBCodeDisplay["url"] = btnBBCodeUrl.Checked;
            r.BBCodeDisplay["city"] = btnBBCodeCity.Checked;
            r.BBCodeDisplay["player"] = btnBBCodePlayer.Checked;
            r.BBCodeDisplay["alliance"] = btnBBCodeAlliance.Checked;
            ReportOption ro = (ReportOption)Properties.Settings.Default.reportOptions;
            btnDisplayOptionsAllianceScore.Checked = (ro & ReportOption.AllianceScore) != 0;
            btnDisplayOptionsCityCount.Checked = (ro & ReportOption.CityCount) != 0;
            btnDisplayOptionsCityName.Checked = (ro & ReportOption.CityName) != 0;
            btnDisplayOptionsCityScore.Checked = (ro & ReportOption.CityScore) != 0;
            btnDisplayOptionsPlayerCount.Checked = (ro & ReportOption.PlayerCount) != 0;
            btnDisplayOptionsPlayerScore.Checked = (ro & ReportOption.PlayerScore) != 0;
            btnDisplayOptionsAllianceRank.Checked = (ro & ReportOption.AllianceRank) != 0;
            report.SetOption(ro, true);
            txtBBCode.Text = report.BBCode(depth);
            reportBrowser.DocumentText = report.Report(depth);
        }
        private void btnBBCode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            btn.Checked = !btn.Checked;
            string b = btn.Name.Replace("btnBBCode", "").ToLower();
            report.BBCodeDisplay[b] = btn.Checked;
            Properties.Settings.Default["bbcode_" + b] = btn.Checked;
            Properties.Settings.Default.Save();
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

        private void btnDisplayOptions_ButtonClick(object sender, EventArgs e)
        {
            btnDisplayOptions.ShowDropDown();
        }

        private void btnDisplayOptionsAllianceScore_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsAllianceScore.Checked = !btnDisplayOptionsAllianceScore.Checked;
            report.SetOption(ReportOption.AllianceScore, btnDisplayOptionsAllianceScore.Checked);
            if (sender != null)
            {
                Properties.Settings.Default.reportOptions = (int)report.Options;
                Properties.Settings.Default.Save();
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnDisplayOptionsPlayerScore_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsPlayerScore.Checked = !btnDisplayOptionsPlayerScore.Checked;
            report.SetOption(ReportOption.PlayerScore, btnDisplayOptionsPlayerScore.Checked);
            if (sender != null)
            {
                Properties.Settings.Default.reportOptions = (int)report.Options;
                Properties.Settings.Default.Save();
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnDisplayOptionsPlayerCount_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsPlayerCount.Checked = !btnDisplayOptionsPlayerCount.Checked;
            report.SetOption(ReportOption.PlayerCount, btnDisplayOptionsPlayerCount.Checked);
            if (sender != null)
            {
                Properties.Settings.Default.reportOptions = (int)report.Options;
                Properties.Settings.Default.Save();
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnDisplayOptionsCityName_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsCityName.Checked = !btnDisplayOptionsCityName.Checked;
            report.SetOption(ReportOption.CityName, btnDisplayOptionsCityName.Checked);
            if (sender != null)
            {
                Properties.Settings.Default.reportOptions = (int)report.Options;
                Properties.Settings.Default.Save();
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnDisplayOptionsCityScore_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsCityScore.Checked = !btnDisplayOptionsCityScore.Checked;
            report.SetOption(ReportOption.CityScore, btnDisplayOptionsCityScore.Checked);
            if (sender != null)
            {
                Properties.Settings.Default.reportOptions = (int)report.Options;
                Properties.Settings.Default.Save();
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnDisplayOptionsCityCount_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsCityCount.Checked = !btnDisplayOptionsCityCount.Checked;
            report.SetOption(ReportOption.CityCount, btnDisplayOptionsCityCount.Checked);
            if (sender != null)
            {
                Properties.Settings.Default.reportOptions = (int)report.Options; 
                Properties.Settings.Default.Save();
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }

        private void btnDisplayOptionsAllianceRank_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsAllianceRank.Checked = !btnDisplayOptionsAllianceRank.Checked;
            report.SetOption(ReportOption.AllianceRank, btnDisplayOptionsAllianceRank.Checked);
            if (sender != null)
            {
                Properties.Settings.Default.reportOptions = (int)report.Options;
                Properties.Settings.Default.Save();
                txtBBCode.Text = report.BBCode(depth);
                reportBrowser.DocumentText = report.Report(depth);
            }
        }
    }
}
