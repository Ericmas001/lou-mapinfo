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
            if (UserOptions.Current.liveRememberPass)
                rdxConnectionRememberAll.Checked = true;
            else if (UserOptions.Current.liveRememberMail)
                rdxConnectionRememberMail.Checked = true;
            else
                rdxConnectionDontRemember.Checked = true;

            if (UserOptions.Current.showDetail)
                rdxDetailDetailed.Checked = true;
            else
                rdxDetailSummary.Checked = true;

            chkDisplayAllianceRank.Checked = UserOptions.Current.dispAllianceRank;
            chkDisplayAllianceScore.Checked = UserOptions.Current.dispAllianceScore;
            chkDisplayCityCount.Checked = UserOptions.Current.dispCityCount;
            chkDisplayCityName.Checked = UserOptions.Current.dispCityName;
            chkDisplayCityScore.Checked = UserOptions.Current.dispCityScore;
            chkDisplayPlayerCount.Checked = UserOptions.Current.dispPlayerCount;
            chkDisplayPlayerScore.Checked = UserOptions.Current.dispPlayerScore;
            chkDisplayPalaceLevel.Checked = UserOptions.Current.dispPalaceLevel;
            chkDisplayPalaceVirtue.Checked = UserOptions.Current.dispPalaceVirtue;

            chkBBCodeAlliance.Checked = UserOptions.Current.bbCode_alliance;
            chkBBCodeB.Checked = UserOptions.Current.bbCode_b;
            chkBBCodeCity.Checked = UserOptions.Current.bbCode_city;
            chkBBCodeI.Checked = UserOptions.Current.bbCode_i;
            chkBBCodePlayer.Checked = UserOptions.Current.bbCode_player;
            chkBBCodeS.Checked = UserOptions.Current.bbCode_s;
            chkBBCodeU.Checked = UserOptions.Current.bbCode_u;
            chkBBCodeUrl.Checked = UserOptions.Current.bbCode_url;

            chkFilterLand.Checked = UserOptions.Current.filtLand;
            chkFilterNoAlliance.Checked = UserOptions.Current.filtNoAlliance;
            chkFilterNoCities.Checked = UserOptions.Current.filtNoCities;
            chkFilterTypeCastles.Checked = UserOptions.Current.filtCastles;
            chkFilterTypeCities.Checked = UserOptions.Current.filtCities;
            chkFilterTypePalaces.Checked = UserOptions.Current.filtPalaces;
            chkFilterWater.Checked = UserOptions.Current.filtWater;

            chkGroupAlliance.Checked = UserOptions.Current.groupAlliance;
            chkGroupBordering.Checked = UserOptions.Current.groupBordering;
            chkGroupCityType.Checked = UserOptions.Current.groupCityType;
            chkGroupContinent.Checked = UserOptions.Current.groupContinent;
            chkGroupDistance.Checked = UserOptions.Current.groupDistance;
            chkGroupPalaceLvl.Checked = UserOptions.Current.groupPalaceLvl;
            chkGroupPlayer.Checked = UserOptions.Current.groupPlayer;
            chkGroupVirtueType.Checked = UserOptions.Current.groupVirtueType;

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
                UserOptions.Current.liveRememberMail = false;
                UserOptions.Current.liveRememberPass = false;
                UserOptions.Current.liveUsername = "";
                UserOptions.Current.livePassword = "";
                UserOptions.Current.Save();
            }
        }

        private void rdxConnectionRememberMail_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.liveRememberMail = true;
                UserOptions.Current.liveRememberPass = false;
                UserOptions.Current.livePassword = "";
                UserOptions.Current.Save();
            }
        }

        private void rdxConnectionRememberAll_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.liveRememberMail = true;
                UserOptions.Current.liveRememberPass = true;
                UserOptions.Current.Save();
            }
        }

        private void rdxDetailSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.showDetail = false;
                UserOptions.Current.Save();
            }
        }

        private void rdxDetailDetailed_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.showDetail = true;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayCityCount_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispCityCount = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayCityScore_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispCityScore = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayCityName_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispCityName = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayPlayerCount_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispPlayerCount = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayPlayerScore_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispPlayerScore = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayAllianceScore_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispAllianceScore = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayAllianceRank_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispAllianceRank = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkFilterTypeCities_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.filtCities = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkFilterTypeCastles_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.filtCastles = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkFilterTypePalaces_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.filtPalaces = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkFilterLand_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.filtLand = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkFilterWater_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.filtWater = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkFilterNoAlliance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.filtNoAlliance = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkFilterNoCities_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.filtNoCities = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodeB_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_b = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodeU_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_u = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodeI_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_i = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodeS_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_s = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodeUrl_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_url = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodeCity_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_city = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodePlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_player = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkBBCodeAlliance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.bbCode_alliance = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayPalaceLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispPalaceLevel = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkDisplayPalaceVirtue_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.dispPalaceVirtue = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupContinent_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupContinent = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupAlliance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupAlliance = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupPlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupPlayer = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupDistance = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupPalaceLvl_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupPalaceLvl = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupCityType_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupCityType = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupVirtueType_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupVirtueType = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }

        private void chkGroupBordering_CheckedChanged(object sender, EventArgs e)
        {
            if (started)
            {
                UserOptions.Current.groupBordering = ((CheckBox)sender).Checked;
                UserOptions.Current.Save();
            }
        }
    }
}
