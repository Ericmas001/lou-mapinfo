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
using LouMapInfo.Entities;


namespace LouMapInfoApp
{
    public partial class ContentReport : UserControl
    {
        ReportInfo report;
        public ContentReport(ReportInfo r)
        {
            report = r;
            InitializeComponent();

            r.ShowDetail = Properties.Settings.Default.showDetail;
            btnReportDetailed.BackColor = r.ShowDetail ? SystemColors.Highlight : Color.White;
            btnReportSummary.BackColor = !r.ShowDetail ? SystemColors.Highlight : Color.White;

            btnGroupAlliance.Visible = r.hasGrouping(GroupingType.Alliance);
            btnGroupBorderingType.Visible = r.hasGrouping(GroupingType.Bordering);
            btnGroupCityType.Visible = r.hasGrouping(GroupingType.CityType);
            btnGroupContinent.Visible = r.hasGrouping(GroupingType.Continent);
            btnGroupDistance.Visible = r.hasGrouping(GroupingType.Distance);
            btnGroupPalaceLvl.Visible = r.hasGrouping(GroupingType.PalaceLevel);
            btnGroupPlayer.Visible = r.hasGrouping(GroupingType.Player);
            btnGroupVirtueType.Visible = r.hasGrouping(GroupingType.VirtueType);

            report.SetGrouping(GroupingType.Alliance, btnGroupAlliance.Checked = Properties.Settings.Default.groupAlliance);
            report.SetGrouping(GroupingType.Bordering, btnGroupBorderingType.Checked = Properties.Settings.Default.groupBordering);
            report.SetGrouping(GroupingType.CityType, btnGroupCityType.Checked = Properties.Settings.Default.groupCityType);
            report.SetGrouping(GroupingType.Continent, btnGroupContinent.Checked = Properties.Settings.Default.groupContinent);
            report.SetGrouping(GroupingType.Distance, btnGroupDistance.Checked = Properties.Settings.Default.groupDistance);
            report.SetGrouping(GroupingType.PalaceLevel, btnGroupPalaceLvl.Checked = Properties.Settings.Default.groupPalaceLvl);
            report.SetGrouping(GroupingType.Player, btnGroupPlayer.Checked = Properties.Settings.Default.groupPlayer);
            report.SetGrouping(GroupingType.VirtueType, btnGroupVirtueType.Checked = Properties.Settings.Default.groupVirtueType);
            
            btnFilterCastle.Visible = r.hasFilter(FilterType.TypeCastle);
            btnFilterCity.Visible = r.hasFilter(FilterType.TypeCity);
            btnFilterPalace.Visible = r.hasFilter(FilterType.TypePalace);
            sepFilter1.Visible = r.hasType0Filter() &&( r.hasType1Filter() || r.hasType2Filter() || r.hasType3Filter());
            
            btnFilterLand.Visible = r.hasFilter(FilterType.BorderingLand);
            btnFilterWater.Visible = r.hasFilter(FilterType.BorderingWater);
            sepFilter2.Visible = r.hasType1Filter() && (r.hasType2Filter() || r.hasType3Filter());

            btnFilterNoCities.Visible = r.hasFilter(FilterType.NoCities);
            sepFilter3.Visible = r.hasType2Filter() && r.hasType3Filter();

            btnFilterNoAlliance.Visible = r.hasFilter(FilterType.NoAlliance);

            report.SetFilter(FilterType.TypeCastle,btnFilterCastle.Checked = Properties.Settings.Default.filtCastles);
            report.SetFilter(FilterType.TypeCity, btnFilterCity.Checked = Properties.Settings.Default.filtCities);
            report.SetFilter(FilterType.TypePalace, btnFilterPalace.Checked = Properties.Settings.Default.filtPalaces);
            report.SetFilter(FilterType.BorderingLand, btnFilterLand.Checked = Properties.Settings.Default.filtLand);
            report.SetFilter(FilterType.BorderingWater, btnFilterWater.Checked = Properties.Settings.Default.filtWater);
            report.SetFilter(FilterType.NoCities, btnFilterNoCities.Checked = Properties.Settings.Default.filtNoCities);
            report.SetFilter(FilterType.NoAlliance, btnFilterNoAlliance.Checked = Properties.Settings.Default.filtNoAlliance);

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
            Text = StringUtility.RemoveBBCodeTags(r.Title);
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
            report.SetOption(ReportOption.AllianceScore,btnDisplayOptionsAllianceScore.Checked = Properties.Settings.Default.dispAllianceScore);
            report.SetOption(ReportOption.CityCount,btnDisplayOptionsCityCount.Checked = Properties.Settings.Default.dispCityCount);
            report.SetOption(ReportOption.CityName,btnDisplayOptionsCityName.Checked = Properties.Settings.Default.dispCityName);
            report.SetOption(ReportOption.CityScore,btnDisplayOptionsCityScore.Checked = Properties.Settings.Default.dispCityScore);
            report.SetOption(ReportOption.PlayerCount, btnDisplayOptionsPlayerCount.Checked = Properties.Settings.Default.dispPlayerCount);
            report.SetOption(ReportOption.PlayerScore, btnDisplayOptionsPlayerScore.Checked = Properties.Settings.Default.dispPlayerScore);
            report.SetOption(ReportOption.AllianceRank, btnDisplayOptionsAllianceRank.Checked = Properties.Settings.Default.dispAllianceRank);
            report.SetOption(ReportOption.PalaceLevel, btnDisplayOptionsPalaceLevel.Checked = Properties.Settings.Default.dispPalaceLevel);
            report.SetOption(ReportOption.PalaceVirtue, btnDisplayOptionsPalaceVirtue.Checked = Properties.Settings.Default.dispPalaceVirtue);
            
            RefreshReport();
        }
        private void RefreshReport()
        {
            btnDisplayOptions.Enabled = false;
            pnlContent.Enabled = false;
            RefreshReportAsync();
            //new Thread(new ThreadStart(RefreshReportAsync)).Start();
        }
        private void RefreshReportAsync()
        {
            string r = report.Report();
            string b = report.BBCode();
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
            btnDisplayOptions.Enabled = true;
            pnlContent.Enabled = true;
            webKitBrowser1.DocumentText = r;
            //reportBrowser.DocumentText = r;
        }
        private void btnBBCode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            btn.Checked = !btn.Checked;
            string b = btn.Name.Replace("btnBBCode", "").ToLower();
            report.BBCodeDisplay[b] = btn.Checked;
            //Properties.Settings.Default["bbcode_" + b] = btn.Checked;
            //Properties.Settings.Default.Save();
            txtBBCode.Text = report.BBCode();
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
                //Properties.Settings.Default.dispAllianceScore = btnDisplayOptionsAllianceScore.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }
        }

        private void btnDisplayOptionsPlayerScore_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsPlayerScore.Checked = !btnDisplayOptionsPlayerScore.Checked;
            report.SetOption(ReportOption.PlayerScore, btnDisplayOptionsPlayerScore.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispPlayerScore = btnDisplayOptionsPlayerScore.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }
        }

        private void btnDisplayOptionsPlayerCount_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsPlayerCount.Checked = !btnDisplayOptionsPlayerCount.Checked;
            report.SetOption(ReportOption.PlayerCount, btnDisplayOptionsPlayerCount.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispPlayerCount = btnDisplayOptionsPlayerCount.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }
        }

        private void btnDisplayOptionsPalaceLevel_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsPalaceLevel.Checked = !btnDisplayOptionsPalaceLevel.Checked;
            report.SetOption(ReportOption.PalaceLevel, btnDisplayOptionsPalaceLevel.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispCityName = btnDisplayOptionsCityName.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }

        }

        private void btnDisplayOptionsPalaceVirtue_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsPalaceVirtue.Checked = !btnDisplayOptionsPalaceVirtue.Checked;
            report.SetOption(ReportOption.PalaceVirtue, btnDisplayOptionsPalaceVirtue.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispCityName = btnDisplayOptionsCityName.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }

        }

        private void btnDisplayOptionsCityName_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsCityName.Checked = !btnDisplayOptionsCityName.Checked;
            report.SetOption(ReportOption.CityName, btnDisplayOptionsCityName.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispCityName = btnDisplayOptionsCityName.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }
        }

        private void btnDisplayOptionsCityScore_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsCityScore.Checked = !btnDisplayOptionsCityScore.Checked;
            report.SetOption(ReportOption.CityScore, btnDisplayOptionsCityScore.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispCityScore = btnDisplayOptionsCityScore.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }
        }

        private void btnDisplayOptionsCityCount_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsCityCount.Checked = !btnDisplayOptionsCityCount.Checked;
            report.SetOption(ReportOption.CityCount, btnDisplayOptionsCityCount.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispCityCount = btnDisplayOptionsCityCount.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }
        }

        private void btnDisplayOptionsAllianceRank_Click(object sender, EventArgs e)
        {
            btnDisplayOptionsAllianceRank.Checked = !btnDisplayOptionsAllianceRank.Checked;
            report.SetOption(ReportOption.AllianceRank, btnDisplayOptionsAllianceRank.Checked);
            if (sender != null)
            {
                //Properties.Settings.Default.dispAllianceRank = btnDisplayOptionsAllianceRank.Checked;
                //Properties.Settings.Default.Save();
                RefreshReport();
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new ReportForm(report).Show();
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

        private void btnFilterCity_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FilterEnabled(FilterType.TypeCity);
            if (newVal || report.FilterEnabled(FilterType.TypeCastle) || report.FilterEnabled(FilterType.TypePalace))
            {
                report.SetFilter(FilterType.TypeCity,newVal);
                btnFilterCity.Checked = newVal;
                RefreshReport();
            }
        }

        private void btnFilterCastle_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FilterEnabled(FilterType.TypeCastle);
            if (newVal || report.FilterEnabled(FilterType.TypeCity) || report.FilterEnabled(FilterType.TypePalace))
            {
                report.SetFilter(FilterType.TypeCastle, newVal);
                btnFilterCastle.Checked = newVal;
                RefreshReport();
            }
        }

        private void btnFilterPalace_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FilterEnabled(FilterType.TypePalace);
            if (newVal || report.FilterEnabled(FilterType.TypeCastle) || report.FilterEnabled(FilterType.TypeCity))
            {
                report.SetFilter(FilterType.TypePalace, newVal);
                btnFilterPalace.Checked = newVal;
                RefreshReport();
            }
        }

        private void btnFilterLand_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FilterEnabled(FilterType.BorderingLand);
            if (newVal || report.FilterEnabled(FilterType.BorderingWater))
            {
                report.SetFilter(FilterType.BorderingLand, newVal);
                btnFilterLand.Checked = newVal;
                RefreshReport();
            }

        }

        private void btnFilterWater_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FilterEnabled(FilterType.BorderingWater);
            if (newVal || report.FilterEnabled(FilterType.BorderingLand))
            {
                report.SetFilter(FilterType.BorderingWater, newVal);
                btnFilterWater.Checked = newVal;
                RefreshReport();
            }

        }

        private void btnFilterNoCities_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FilterEnabled(FilterType.NoCities);
            report.SetFilter(FilterType.NoCities, newVal);
            btnFilterNoCities.Checked = newVal;
            RefreshReport();
        }

        private void btnFilterNoAlliance_Click(object sender, EventArgs e)
        {
            bool newVal = !report.FilterEnabled(FilterType.NoAlliance);
            report.SetFilter(FilterType.NoAlliance, newVal);
            btnFilterNoAlliance.Checked = newVal;
            RefreshReport();
        }

        private void btnReportDetailed_Click(object sender, EventArgs e)
        {
            if (!report.ShowDetail)
            {
                report.ShowDetail = true;
                btnReportDetailed.BackColor = SystemColors.Highlight;
                btnReportSummary.BackColor = Color.White;
                RefreshReport();
            }
        }

        private void btnReportSummary_Click(object sender, EventArgs e)
        {
            if (report.ShowDetail)
            {
                report.ShowDetail = false;
                btnReportSummary.BackColor = SystemColors.Highlight;
                btnReportDetailed.BackColor = Color.White;
                RefreshReport();
            }
        }

        private void btnGroupContinent_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.Continent);
            report.SetGrouping(GroupingType.Continent, newVal);
            btnGroupContinent.Checked = newVal;
            RefreshReport();
        }

        private void btnGroupAlliance_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.Alliance);
            report.SetGrouping(GroupingType.Alliance, newVal);
            btnGroupAlliance.Checked = newVal;
            RefreshReport();
        }

        private void btnGroupPlayer_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.Player);
            report.SetGrouping(GroupingType.Player, newVal);
            btnGroupPlayer.Checked = newVal;
            RefreshReport();
        }

        private void btnGroupDistance_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.Distance);
            report.SetGrouping(GroupingType.Distance, newVal);
            btnGroupDistance.Checked = newVal;
            RefreshReport();
        }

        private void btnGroupPalaceLvl_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.PalaceLevel);
            report.SetGrouping(GroupingType.PalaceLevel, newVal);
            btnGroupPalaceLvl.Checked = newVal;
            RefreshReport();
        }

        private void btnGroupCityType_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.CityType);
            report.SetGrouping(GroupingType.CityType, newVal);
            btnGroupCityType.Checked = newVal;
            RefreshReport();
        }

        private void btnGroupVirtueType_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.VirtueType);
            report.SetGrouping(GroupingType.VirtueType, newVal);
            btnGroupVirtueType.Checked = newVal;
            RefreshReport();
        }

        private void btnBorderingType_Click(object sender, EventArgs e)
        {
            bool newVal = !report.GroupingEnabled(GroupingType.Bordering);
            report.SetGrouping(GroupingType.Bordering, newVal);
            btnGroupBorderingType.Checked = newVal;
            RefreshReport();
        }
    }
}
