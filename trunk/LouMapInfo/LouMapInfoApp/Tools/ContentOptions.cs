using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LouMapInfoApp.Tools
{
    public partial class ContentOptions : UserControl
    {
        bool started = false;
        public ContentOptions()
        {
            InitializeComponent();
            if (Properties.Settings.Default.liveRememberPass)
                rdxConnectionRememberAll.Checked = true;
            else if (Properties.Settings.Default.liveRememberMail)
                rdxConnectionRememberMail.Checked = true;
            else
                rdxConnectionDontRemember.Checked = true;

            if (Properties.Settings.Default.showDetail)
                rdxDetailDetailed.Checked = true;
            else
                rdxDetailSummary.Checked = true;

            chkDisplayAllianceRank.Checked = Properties.Settings.Default.dispAllianceRank;
            chkDisplayAllianceScore.Checked = Properties.Settings.Default.dispAllianceScore;
            chkDisplayCityCount.Checked = Properties.Settings.Default.dispCityCount;
            chkDisplayCityName.Checked = Properties.Settings.Default.dispCityName;
            chkDisplayCityScore.Checked = Properties.Settings.Default.dispCityScore;
            chkDisplayPlayerCount.Checked = Properties.Settings.Default.dispPlayerCount;
            chkDisplayPlayerScore.Checked = Properties.Settings.Default.dispPlayerScore;
            chkDisplayPalaceLevel.Checked = Properties.Settings.Default.dispPalaceLevel;
            chkDisplayPalaceVirtue.Checked = Properties.Settings.Default.dispPalaceVirtue;

            chkBBCodeAlliance.Checked = Properties.Settings.Default.bbCode_alliance;
            chkBBCodeB.Checked = Properties.Settings.Default.bbCode_b;
            chkBBCodeCity.Checked = Properties.Settings.Default.bbCode_city;
            chkBBCodeI.Checked = Properties.Settings.Default.bbCode_i;
            chkBBCodePlayer.Checked = Properties.Settings.Default.bbCode_player;
            chkBBCodeS.Checked = Properties.Settings.Default.bbCode_s;
            chkBBCodeU.Checked = Properties.Settings.Default.bbCode_u;
            chkBBCodeUrl.Checked = Properties.Settings.Default.bbCode_url;

            chkFilterLand.Checked = Properties.Settings.Default.filtLand;
            chkFilterNoAlliance.Checked = Properties.Settings.Default.filtNoAlliance;
            chkFilterNoCities.Checked = Properties.Settings.Default.filtNoCities;
            chkFilterTypeCastles.Checked = Properties.Settings.Default.filtCastles;
            chkFilterTypeCities.Checked = Properties.Settings.Default.filtCities;
            chkFilterTypePalaces.Checked = Properties.Settings.Default.filtPalaces;
            chkFilterWater.Checked = Properties.Settings.Default.filtWater;

            chkGroupAlliance.Checked = Properties.Settings.Default.groupAlliance;
            chkGroupBordering.Checked = Properties.Settings.Default.groupBordering;
            chkGroupCityType.Checked = Properties.Settings.Default.groupCityType;
            chkGroupContinent.Checked = Properties.Settings.Default.groupContinent;
            chkGroupDistance.Checked = Properties.Settings.Default.groupDistance;
            chkGroupPalaceLvl.Checked = Properties.Settings.Default.groupPalaceLvl;
            chkGroupPlayer.Checked = Properties.Settings.Default.groupPlayer;
            chkGroupVirtueType.Checked = Properties.Settings.Default.groupVirtueType;

            started = true;
        }

        private void GeneralUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((Control)sender).Text);
        }

        private void MailUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:" + ((Control)sender).Text);
        }

        private void rdxConnectionDontRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.liveRememberMail = false;
                Properties.Settings.Default.liveRememberPass = false;
                Properties.Settings.Default.liveUsername = "";
                Properties.Settings.Default.livePassword = "";
                Properties.Settings.Default.Save();
            }
        }

        private void rdxConnectionRememberMail_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.liveRememberMail = true;
                Properties.Settings.Default.liveRememberPass = false;
                Properties.Settings.Default.livePassword = "";
                Properties.Settings.Default.Save();
            }
        }

        private void rdxConnectionRememberAll_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.liveRememberMail = true;
                Properties.Settings.Default.liveRememberPass = true;
                Properties.Settings.Default.Save();
            }
        }

        private void rdxDetailSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.showDetail = false;
                Properties.Settings.Default.Save();
            }
        }

        private void rdxDetailDetailed_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.showDetail = true;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayCityCount_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispCityCount = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayCityScore_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispCityScore = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayCityName_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispCityName = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayPlayerCount_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispPlayerCount = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayPlayerScore_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispPlayerScore = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayAllianceScore_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispAllianceScore = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayAllianceRank_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispAllianceRank = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkFilterTypeCities_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.filtCities = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkFilterTypeCastles_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.filtCastles = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkFilterTypePalaces_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.filtPalaces = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkFilterLand_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.filtLand = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkFilterWater_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.filtWater = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkFilterNoAlliance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.filtNoAlliance = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkFilterNoCities_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.filtNoCities = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodeB_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_b = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodeU_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_u = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodeI_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_i = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodeS_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_s = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodeUrl_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_url = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodeCity_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_city = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodePlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_player = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkBBCodeAlliance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.bbCode_alliance = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayPalaceLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispPalaceLevel = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkDisplayPalaceVirtue_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.dispPalaceVirtue = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupContinent_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupContinent = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupAlliance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupAlliance = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupPlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupPlayer = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupDistance = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupPalaceLvl_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupPalaceLvl = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupCityType_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupCityType = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupVirtueType_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupVirtueType = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkGroupBordering_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.groupBordering = ((CheckBox)sender).Checked;
                Properties.Settings.Default.Save();
            }
        }
    }
}
