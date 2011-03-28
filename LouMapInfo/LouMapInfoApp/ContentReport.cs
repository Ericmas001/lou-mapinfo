﻿using System;
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
using LouMapInfo.Entities;
using LouMapInfo.Reports.Features;

namespace LouMapInfoApp
{
    public partial class ContentReport : UserControl
    {
        ReportInfo report;
        int depth;
        public ContentReport(ReportInfo r, int d)
        {
            InitializeComponent();

            btnFeatureCastle.Visible = r.hasFeature(ReportFeatureType.TypeCastle);
            btnFeatureCity.Visible = r.hasFeature(ReportFeatureType.TypeCity);
            btnFeaturePalace.Visible = r.hasFeature(ReportFeatureType.TypePalace);
            sepFeature1.Visible = r.hasType0Feature() &&( r.hasType1Feature() || r.hasType2Feature() || r.hasType3Feature());
            
            btnFeatureLand.Visible = r.hasFeature(ReportFeatureType.BorderingLand);
            btnFeatureWater.Visible = r.hasFeature(ReportFeatureType.BorderingWater);
            sepFeature2.Visible = r.hasType1Feature() && (r.hasType2Feature() || r.hasType3Feature());

            btnFeatureNoCities.Visible = r.hasFeature(ReportFeatureType.NoCities);
            sepFeature3.Visible = r.hasType2Feature() && r.hasType3Feature();

            btnFeatureNoAlliance.Visible = r.hasFeature(ReportFeatureType.NoAlliance);

            btnFeatureCastle.Checked = r.FeatureEnabled(ReportFeatureType.TypeCastle);
            btnFeatureCity.Checked = r.FeatureEnabled(ReportFeatureType.TypeCity);
            btnFeaturePalace.Checked = r.FeatureEnabled(ReportFeatureType.TypePalace);
            btnFeatureLand.Checked = r.FeatureEnabled(ReportFeatureType.BorderingLand);
            btnFeatureWater.Checked = r.FeatureEnabled(ReportFeatureType.BorderingWater);
            btnFeatureNoCities.Checked = r.FeatureEnabled(ReportFeatureType.NoCities);
            btnFeatureNoAlliance.Checked = r.FeatureEnabled(ReportFeatureType.NoAlliance);
            



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
            switch (d)
            {
                case 1: btnReportsLvl1_Click(null, new EventArgs()); break;
                case 2: btnReportsLvl2_Click(null, new EventArgs()); break;
                case 3: case 4: btnReportsLvl3_Click(null, new EventArgs()); break;
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
            RefreshReport();
        }
        private void RefreshReport()
        {
            btnReportsLvl.Enabled = false;
            btnDisplayOptions.Enabled = false;
            pnlContent.Enabled = false;
            RefreshReportAsync();
            //new Thread(new ThreadStart(RefreshReportAsync)).Start();
        }
        private void RefreshReportAsync()
        {
            string r = report.Report(depth);
            string b = report.BBCode(depth);
            RefreshReport(r, b);
        }
        private delegate void ReportsHandler(string r, string b);
        private void RefreshReport(string r, string b)
        {
            if (InvokeRequired)
            {
                Invoke(new ReportsHandler(RefreshReport), r, b);
                return;
            }
            txtBBCode.Text = b;
            btnReportsLvl.Enabled = true;
            btnDisplayOptions.Enabled = true;
            pnlContent.Enabled = true;
            reportBrowser.DocumentText = r;
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
            Properties.Settings.Default.lastWDetailLvl = 1;
            Properties.Settings.Default.Save();
            txtBBCode.Text = report.BBCode(depth);
            btnReportsLvl.Text = btnReportsLvl1.Text;
            btnReportsLvl1.Checked = true;
            btnReportsLvl2.Checked = false;
            btnReportsLvl3.Checked = false;
            RefreshReport();
        }

        private void btnReportsLvl2_Click(object sender, EventArgs e)
        {
            depth = 2;
            Properties.Settings.Default.lastWDetailLvl = 2;
            Properties.Settings.Default.Save();
            btnReportsLvl.Text = btnReportsLvl2.Text;
            btnReportsLvl1.Checked = false;
            btnReportsLvl2.Checked = true;
            btnReportsLvl3.Checked = false;
            if (sender != null)
            {
                RefreshReport();
            }
        }

        private void btnReportsLvl3_Click(object sender, EventArgs e)
        {
            depth = 4;
            Properties.Settings.Default.lastWDetailLvl = 4;
            Properties.Settings.Default.Save();
            btnReportsLvl.Text = btnReportsLvl3.Text;
            btnReportsLvl1.Checked = false;
            btnReportsLvl2.Checked = false;
            btnReportsLvl3.Checked = true;
            if (sender != null)
            {
                RefreshReport();
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
                RefreshReport();
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
                RefreshReport();
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
                RefreshReport();
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
                RefreshReport();
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
                RefreshReport();
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
                RefreshReport();
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
                RefreshReport();
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new ReportForm(report, depth).Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshReport();
        }
        private bool already = false;
        private void reportBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!already)
            {
                already = true;
                RefreshReport();
            }
        }

        private void btnFeatureCity_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FeatureEnabled(ReportFeatureType.TypeCity);
            if (newVal || report.FeatureEnabled(ReportFeatureType.TypeCastle) || report.FeatureEnabled(ReportFeatureType.TypePalace))
            {
                report.SetFeature(ReportFeatureType.TypeCity,newVal);
                btnFeatureCity.Checked = newVal;
                RefreshReport();
            }
        }

        private void btnFeatureCastle_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FeatureEnabled(ReportFeatureType.TypeCastle);
            if (newVal || report.FeatureEnabled(ReportFeatureType.TypeCity) || report.FeatureEnabled(ReportFeatureType.TypePalace))
            {
                report.SetFeature(ReportFeatureType.TypeCastle, newVal);
                btnFeatureCastle.Checked = newVal;
                RefreshReport();
            }
        }

        private void btnFeaturePalace_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FeatureEnabled(ReportFeatureType.TypePalace);
            if (newVal || report.FeatureEnabled(ReportFeatureType.TypeCastle) || report.FeatureEnabled(ReportFeatureType.TypeCity))
            {
                report.SetFeature(ReportFeatureType.TypePalace, newVal);
                btnFeaturePalace.Checked = newVal;
                RefreshReport();
            }
        }

        private void btnFeatureLand_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FeatureEnabled(ReportFeatureType.BorderingLand);
            if (newVal || report.FeatureEnabled(ReportFeatureType.BorderingWater))
            {
                report.SetFeature(ReportFeatureType.BorderingLand, newVal);
                btnFeatureLand.Checked = newVal;
                RefreshReport();
            }

        }

        private void btnFeatureWater_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FeatureEnabled(ReportFeatureType.BorderingWater);
            if (newVal || report.FeatureEnabled(ReportFeatureType.BorderingLand))
            {
                report.SetFeature(ReportFeatureType.BorderingWater, newVal);
                btnFeatureWater.Checked = newVal;
                RefreshReport();
            }

        }

        private void btnFeatureNoCities_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FeatureEnabled(ReportFeatureType.NoCities);
            report.SetFeature(ReportFeatureType.NoCities, newVal);
            btnFeatureNoCities.Checked = newVal;
            RefreshReport();
        }

        private void btnFeatureNoAlliance_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FeatureEnabled(ReportFeatureType.NoAlliance);
            report.SetFeature(ReportFeatureType.NoAlliance, newVal);
            btnFeatureNoAlliance.Checked = newVal;
            RefreshReport();
        }
    }
}
