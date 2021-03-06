﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports;
using System.Threading;
using LouMapInfo.Layout;
using EricUtility.Windows.Forms;
using System.Diagnostics;
using EricUtility.Networking.Gathering;
using EricUtility;

namespace LouMapInfoApp.Tools
{
    public partial class ContentLayout : UserControl
    {

        private bool m_Loaded = false;
        private Dictionary<ToolStripButton, BuildingType> m_DONOTUSE_ButtonToBuilding = new Dictionary<ToolStripButton, BuildingType>();
        private Dictionary<BuildingType, ToolStripButton> m_DONOTUSE_BuildingToButton = new Dictionary<BuildingType, ToolStripButton>();
        private ToolStripButton m_CurButton = null;

        public Dictionary<ToolStripButton, BuildingType> ButtonToBuilding
        {
            get
            {
                if (!m_Loaded)
                    LoadAll();
                return m_DONOTUSE_ButtonToBuilding;
            }
        }
        public Dictionary<BuildingType, ToolStripButton> BuildingToButton
        {
            get
            {
                if (!m_Loaded)
                    LoadAll();
                return m_DONOTUSE_BuildingToButton;
            }
        }
        public ContentLayout()
        {
            InitializeComponent();

            nudAPUseSlots.Value = UserOptions.Current.apUseSlots;
            nudAPCottages.Value = UserOptions.Current.apNumCottages;
            txtAPPlacement.Text = UserOptions.Current.apPlacementSchedule;
            chkAPBuildOnlyOnOpen.Checked = UserOptions.Current.apBuildOnlyOnOpen;
            chkAPClearBuildings.Checked = UserOptions.Current.apClearBuildings;
            chkAPKeepExtraNodes.Checked = UserOptions.Current.apKeepExtraResNodes;

            pbCity.ChooseTool(BuildingType.None);
            pbCity.CreateNew(true);
            tabControl1.SelectedTab = tbCityInfo;

            ImageList list = new ImageList();
            tabControl1.ImageList = list;
            list.Images.Add(Properties.Resources.icon_build_slots);
            list.Images.Add(Properties.Resources.icon_recruit_slots);
            tbCityInfo.ImageIndex = 0;
            tbCityMilitary.ImageIndex = 1;

            foreach (BuildingType bt in BuildingInfo.ByType.Keys)
                if (bt != BuildingType.None && bt != BuildingType.FarmLand)
                {
                    lstUtilDestroyAll.Items.Add(BuildingInfo.ByType[bt]);
                    lstUtilReplaceAll1.Items.Add(BuildingInfo.ByType[bt]);
                    lstUtilReplaceAll2.Items.Add(BuildingInfo.ByType[bt]);
                    lstUtilDestroyWeak.Items.Add(BuildingInfo.ByType[bt]);
                    if (bt != BuildingType.ResFood && bt != BuildingType.ResIron && bt != BuildingType.ResStone && bt != BuildingType.ResWood)
                    {
                        lstUtilPlaceSome.Items.Add(BuildingInfo.ByType[bt]);
                    }
                }
            lstUtilDestroyAll.SelectedIndex = 0;
            lstUtilReplaceAll1.SelectedIndex = 0;
            lstUtilReplaceAll2.SelectedIndex = 0;
            lstUtilPlaceSome.SelectedIndex = 0;
            lstUtilDestroyWeak.SelectedIndex = 0;
        }





        public void LoadAll()
        {
            m_Loaded = true;

            m_DONOTUSE_BuildingToButton.Add(BuildingType.None, btnDestroy);//Destroy", '0', '-'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.ResWood, btnTree);//Wood", 'A', '.'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.ResStone, btnStone);//Stone", 'B', ':'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.ResIron, btnIron);//Iron", 'C', ','));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.ResFood, btnWater);//Food", 'D', ';'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.WoodcutterOld, btnOldWoodcutter);//Woodcutter's hut (old)", 'F', 'W'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.QuarryOld, btnOldQuarry);//Quarry (old)", 'G', 'Q'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.IronMineOld, btnOldIronMine);//Iron Mine (old)", 'H', 'I'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.FarmOld, btnOldFarm);//Farm (old)", 'I', 'F'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Woodcutter, btnWoodcutter);//Woodcutter's hut", '2', '2'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Quarry, btnQuarry);//Quarry", '3', '3'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.IronMine, btnIronMine);//Iron Mine", '4', '4'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Farm, btnFarm);//Farm", '5', '2'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Sawmill, btnSawmill);//Sawmill", 'K', 'L'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Stonemasson, btnStonemasson);//Stonemasson", 'L', 'A'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Foundry, btnFoundry);//Foundry", 'M', 'D'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Mill, btnMill);//Mill", 'N', 'M'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Warehouse, btnWarehouse);//Warehouse", 'Z', 'S'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Cottage, btnCottage);//Cottage", 'O', 'C'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Hideout, btnHideout);//Hideout", '1', 'H'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Marketplace, btnMarket);//Marketplm_DONOTUSE_Buildings.Add(ace", 'J', 'P'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Townhouse, btnTownhouse);//Townhouse", 'E', 'U'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Barracks, btnBarrack);//Barracks", 'P', 'B'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.CityGuardHouse, btnCityGuardHouse);//CityGuardHouse", 'S', 'K'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.TrainingGround, btnTrainingGround);//Training Ground", 'Q', 'G'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Stable, btnStable);//Stable", 'U', 'E'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.MoonglowTower, btnMoonglowTower);//Moonglow Tower", 'R', 'J'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.TrinsicTemple, btnTrinsicTemple);//Trinsic Temple", 'W', 'Z'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Workshop, btnWorkshop);//Workshop", 'V', 'Y'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Harbor, btnHarbor);//Harbor", 'T', 'R'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Shipyard, btnShipyard);//Shipyard", 'Y', 'V'));
            m_DONOTUSE_BuildingToButton.Add(BuildingType.Castle, btnCastle);//Castle", 'X', 'X'));

            foreach (BuildingType bt in m_DONOTUSE_BuildingToButton.Keys)
                m_DONOTUSE_ButtonToBuilding.Add(m_DONOTUSE_BuildingToButton[bt], bt);
        }
        private void RefreshCounters()
        {
            lblGold.Text = pbCity.Production[ResourceType.Gold].ToString("N0") + "/h";
            lblWood.Text = pbCity.Production[ResourceType.Wood].ToString("N0") + "/h";
            lblStone.Text = pbCity.Production[ResourceType.Stone].ToString("N0") + "/h";
            lblIron.Text = pbCity.Production[ResourceType.Iron].ToString("N0") + "/h";
            lblFood.Text = pbCity.Production[ResourceType.Food].ToString("N0") + "/h";
            lblTotalRes.Text = (pbCity.Production[ResourceType.Wood] + pbCity.Production[ResourceType.Stone] + pbCity.Production[ResourceType.Iron] + pbCity.Production[ResourceType.Food]).ToString("N0") + "/h";
            lblStorWood.Text = pbCity.Storage[ResourceType.Wood].ToString("N0");
            lblStorStone.Text = pbCity.Storage[ResourceType.Stone].ToString("N0");
            lblStorIron.Text = pbCity.Storage[ResourceType.Iron].ToString("N0");
            lblStorFood.Text = pbCity.Storage[ResourceType.Food].ToString("N0");
            lblStorHidden.Text = pbCity.Hidden.ToString("N0");
            lblNbCarts.Text = pbCity.Carts.ToString("N0") + " (" + (pbCity.Carts * 1000).ToString("N0") + ")";
            lblNbShips.Text = pbCity.Ships.ToString("N0") + " (" + (pbCity.Ships * 10000).ToString("N0") + ")";
            lblBuildingsLeft.Text = "" + (100 - pbCity.BuildingCount);
            if (pbCity.BuildingCount > 100)
                lblBuildingsLeft.ForeColor = Color.Red;
            else
                lblBuildingsLeft.ForeColor = Color.Black;
            lblConsSpeed.Text = pbCity.ConsSpeed.ToString("N0") + "%";
            lblArmySize.Text = pbCity.ArmySize.ToString("N0");
            lblArmySize2.Text = pbCity.ArmySize.ToString("N0");
            lblCityGuard.Text = pbCity.Recruitment[BuildingType.CityGuardHouse].ToString("N0") + "%";
            lblTrainingGround.Text = pbCity.Recruitment[BuildingType.TrainingGround].ToString("N0") + "%";
            lblStable.Text = pbCity.Recruitment[BuildingType.Stable].ToString("N0") + "%";
            lblTrinsic.Text = pbCity.Recruitment[BuildingType.TrinsicTemple].ToString("N0") + "%";
            lblMoonglow.Text = pbCity.Recruitment[BuildingType.MoonglowTower].ToString("N0") + "%";
            lblWorkShop.Text = pbCity.Recruitment[BuildingType.Workshop].ToString("N0") + "%";
            lblShipyard.Text = pbCity.Recruitment[BuildingType.Shipyard].ToString("N0") + "%";
        }
        private void btnBuilding_Click(object sender, EventArgs e)
        {
            pbCity.ChooseTool(ButtonToBuilding[(ToolStripButton)sender]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtImport.Text))
            {
                try
                {
                    pbCity.Import(txtImport.Text);
                    txtImport.Text = "";
                    tabControl1.SelectedIndex = 0;
                }
                catch
                {
                }
            }
        }

        private void btnCreateLand_Click(object sender, EventArgs e)
        {
            pbCity.CreateNew(false);
            tabControl1.SelectedIndex = 0;
        }

        private void btnCreateWater_Click(object sender, EventArgs e)
        {
            pbCity.CreateNew(true);
            tabControl1.SelectedIndex = 0;
        }

        public void ContentLayout_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtImport.Focused && !txtAPPlacement.Focused && !nudAPCottages.Focused && !nudAPUseSlots.Focused)
            {
                pbCity.FireOnKeyDown(e);
            }
        }

        private void btnCopyFCP_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pbCity.GenerateFlashCityPlanner());
        }

        private void btnCopySS_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pbCity.GenerateShareString());
        }

        private void btnAutoPlanCity_Click(object sender, EventArgs e)
        {
            statePictureBox1.Etat = StatePictureBoxStates.Waiting;
            Enabled = false;
            string args = "";
            args += " use_slots=" + (int)nudAPUseSlots.Value;
            args += " num_cottages=" + (int)nudAPCottages.Value;
            args += " keep_extra_res_nodes=" + (chkAPKeepExtraNodes.Checked ? "1" : "0");
            args += " build_on_nrs=" + (chkAPBuildOnlyOnOpen.Checked ? "0" : "1");
            args += " also_clear_castle=0";
            args += " clear_buildings=" + (chkAPClearBuildings.Checked ? "1" : "0");
            if (!String.IsNullOrEmpty(txtAPPlacement.Text))
            {
                args += " placement_schedule=" + txtAPPlacement.Text;
            }
            string postArgs = "content=" + pbCity.GenerateFlashCityPlanner() + args;
            new Thread(new ParameterizedThreadStart(CallAutoPlanner)).Start(postArgs);

        }
        private void CallAutoPlanner(object o)
        {
            string postArgs = o as string;
            string askURL = "http://2.latest.loof78.appspot.com/lou_city/calc";
            string s = GatheringUtility.GetPageSource(askURL, postArgs);
            if (s.Contains("error:"))
            {
                EndAutoPlannerBadly(StringUtility.RemoveHTMLTags(s.Substring(s.IndexOf("error:"))));
            }
            else
            {
                int u = s.LastIndexOf("http://www.lou-fcp.co.uk/map.php?map=");
                string url = s.Substring(u, s.IndexOf("</a>") - u);
                EndAutoPlanner(url);
            }
        }
        private void EndAutoPlanner(string res)
        {
            if (InvokeRequired)
            {
                Invoke(new StringHandler(EndAutoPlanner), res);
                return;
            }

            UserOptions.Current.apUseSlots = (int)nudAPUseSlots.Value;
            UserOptions.Current.apNumCottages = (int)nudAPCottages.Value;
            UserOptions.Current.apPlacementSchedule = txtAPPlacement.Text;
            UserOptions.Current.apBuildOnlyOnOpen = chkAPBuildOnlyOnOpen.Checked;
            UserOptions.Current.apClearBuildings = chkAPClearBuildings.Checked;
            UserOptions.Current.apKeepExtraResNodes = chkAPKeepExtraNodes.Checked;
            UserOptions.Current.Save();

            pbCity.Import(res);
            tabControl1.SelectedTab = tbCityInfo;
            statePictureBox1.Etat = StatePictureBoxStates.None;
            Enabled = true;
        }
        private void EndAutoPlannerBadly(string res)
        {
            if (InvokeRequired)
            {
                Invoke(new StringHandler(EndAutoPlannerBadly), res);
                return;
            }
            MessageBox.Show(res);
            statePictureBox1.Etat = StatePictureBoxStates.None;
            Enabled = true;
        }
        private void btnHelpAutoPlanner_Click(object sender, EventArgs e)
        {
            MessageBox.Show("control the # of slots used (default 72) and best-effort cottages placed (default 0). the cottages are included in use_slots, so use_slots better be > than num_cottages -- generally at least 3x greater. \n\n list of options in the form option=default\nuse_slots=72\nnum_cottages=0\nkeep_extra_res_nodes=0\nplacement_schedule=WSI (format: [WSIF]+(,[WSIF]+)* -- commas seperate the res set to use for each wave. if more waves are needed to place all res buildings than there are res sets in placement_schedule, placement_schedule will be repeated as needed. the order of letters within each per-wave res set does not matter. duplicate letters within a wave have no effect. e.g. for one wave, 'WWWF' has the same meaning as 'FW': place food or wood on that wave. )\nclear_buildings=1\nalso_clear_castle=0\nbuild_on_nrs=1");
        }

        private void pbCity_BuildingChanged(BuildingType res)
        {
            if (m_CurButton != null)
                m_CurButton.BackColor = Color.White;
            m_CurButton = BuildingToButton[res];
            m_CurButton.BackColor = SystemColors.Highlight;
        }

        private void pbCity_CounterRefreshed()
        {
            RefreshCounters();
        }

        public void Import(CompleteLayout l)
        {
            pbCity.Import(l);
        }

        public void Import(string s)
        {
            pbCity.Import(s);
        }
        public string GenerateFlashCityPlanner()
        {
            return pbCity.GenerateFlashCityPlanner();
        }

        private void btnCopyFCPShort_Click(object sender, EventArgs e)
        {
            string s = GatheringUtility.GetPageSource(pbCity.GenerateFlashCityPlanner().Replace("map.php", "bitly.php"));
            int iU = s.IndexOf("http://bit.ly/");
            int iUf = s.IndexOf('<', iU);
            Clipboard.SetText(s.Substring(iU, iUf - iU));
        }

        private void btnOpenFCP_Click(object sender, EventArgs e)
        {
            Process.Start(pbCity.GenerateFlashCityPlanner());
        }

        private void btnUtilDestroyAll_Click(object sender, EventArgs e)
        {
            if (lstUtilDestroyAll.SelectedItem is BuildingInfo)
            {
                BuildingInfo b = lstUtilDestroyAll.SelectedItem as BuildingInfo;
                foreach (LayoutEntry le in pbCity.City.CityLayout)
                {
                    if (b.BType == le.Info)
                        le.Info = BuildingType.None;
                }
            }
            else
            {
                if (lstUtilDestroyAll.SelectedIndex == 0 || lstUtilDestroyAll.SelectedIndex == 1)
                {
                    List<BuildingType> excluded = new List<BuildingType>(new BuildingType[] { BuildingType.FarmLand, BuildingType.None, BuildingType.ResFood, BuildingType.ResIron, BuildingType.ResStone, BuildingType.ResWood });
                    foreach (LayoutEntry le in pbCity.City.CityLayout)
                    {
                        if (!excluded.Contains(le.Info))
                            le.Info = BuildingType.None;
                    }
                }
                if (lstUtilDestroyAll.SelectedIndex == 0 || lstUtilDestroyAll.SelectedIndex == 2)
                {
                    List<BuildingType> included = new List<BuildingType>(new BuildingType[] { BuildingType.ResFood, BuildingType.ResIron, BuildingType.ResStone, BuildingType.ResWood });
                    foreach (LayoutEntry le in pbCity.City.CityLayout)
                    {
                        if (included.Contains(le.Info))
                            le.Info = BuildingType.None;
                    }
                }
            }
            pbCity.Invalidate();
        }

        private void btnUtilReplaceAll_Click(object sender, EventArgs e)
        {
            BuildingInfo b1 = lstUtilReplaceAll1.SelectedItem as BuildingInfo;
            BuildingInfo b2 = lstUtilReplaceAll2.SelectedItem as BuildingInfo;
            if (b1.BType == b2.BType)
                return;
            bool b1OnWater = (b1.BType == BuildingType.Shipyard || b1.BType == BuildingType.Harbor);
            bool b2OnWater = (b2.BType == BuildingType.Shipyard || b2.BType == BuildingType.Harbor);

            if (b1OnWater != b2OnWater)
                return;

            foreach (LayoutEntry le in pbCity.City.CityLayout)
            {
                if (b1.BType == le.Info)
                    le.Info = b2.BType;
            }
            pbCity.Invalidate();
        }

        private void btnUtilPlaceSome_Click(object sender, EventArgs e)
        {
            BuildingInfo b = lstUtilPlaceSome.SelectedItem as BuildingInfo;
            int count = (int)nudUtilPlaceSome.Value;
            int used = 0;
            foreach (LayoutEntry le in pbCity.City.CityLayout)
            {
                if (used >= count)
                    return;
                if (le.Info == BuildingType.None)
                {
                    le.Info = b.BType;
                    used++;
                }
            }
            pbCity.Invalidate();
        }

        private void btnUtilDestroyWeak_Click(object sender, EventArgs e)
        {
            int total = (int)nudUtilDestroyWeak.Value;
            for (int i = 0; i < total; ++i)
            {
                LayoutEntry weak = null;
                if (lstUtilDestroyAll.SelectedItem is BuildingInfo)
                {
                    BuildingInfo b = lstUtilDestroyAll.SelectedItem as BuildingInfo;
                    foreach (LayoutEntry le in pbCity.City.CityLayout)
                    {
                        if (b.BType == le.Info && (weak == null || weak.Usefulness > le.Usefulness))
                            weak = le;
                    }
                }
                else
                {
                    if (lstUtilDestroyWeak.SelectedIndex == 0)
                    {
                        // all buildings
                        List<BuildingType> excluded = new List<BuildingType>(new BuildingType[] { BuildingType.FarmLand, BuildingType.None, BuildingType.ResFood, BuildingType.ResIron, BuildingType.ResStone, BuildingType.ResWood });
                        foreach (LayoutEntry le in pbCity.City.CityLayout)
                        {
                            if (!excluded.Contains(le.Info) && (weak == null || weak.Usefulness > le.Usefulness))
                                weak = le;
                        }

                    }
                    else if (lstUtilDestroyWeak.SelectedIndex == 1)
                    {
                        // Res Building
                        List<BuildingType> included = new List<BuildingType>(new BuildingType[] { BuildingType.Cottage, BuildingType.Farm, BuildingType.FarmOld, BuildingType.Woodcutter, BuildingType.WoodcutterOld, BuildingType.IronMine, BuildingType.IronMineOld, BuildingType.Quarry, BuildingType.QuarryOld, BuildingType.Mill, BuildingType.Sawmill, BuildingType.Stonemasson, BuildingType.Foundry });
                        foreach (LayoutEntry le in pbCity.City.CityLayout)
                        {
                            if (included.Contains(le.Info) && (weak == null || weak.Usefulness > le.Usefulness))
                                weak = le;
                        }
                    }
                    else if (lstUtilDestroyWeak.SelectedIndex == 2)
                    {
                        // Gold Building
                        List<BuildingType> included = new List<BuildingType>(new BuildingType[] { BuildingType.Townhouse, BuildingType.Marketplace, BuildingType.Harbor });
                        foreach (LayoutEntry le in pbCity.City.CityLayout)
                        {
                            if (included.Contains(le.Info) && (weak == null || weak.Usefulness > le.Usefulness))
                                weak = le;
                        }
                    }
                    else if (lstUtilDestroyWeak.SelectedIndex == 3)
                    {
                        // War Building
                        List<BuildingType> included = new List<BuildingType>(new BuildingType[] { BuildingType.Barracks, BuildingType.TrainingGround, BuildingType.Stable, BuildingType.TrinsicTemple, BuildingType.CityGuardHouse, BuildingType.MoonglowTower, BuildingType.Workshop, BuildingType.Shipyard});
                        foreach (LayoutEntry le in pbCity.City.CityLayout)
                        {
                            if (included.Contains(le.Info) && (weak == null || weak.Usefulness > le.Usefulness))
                                weak = le;
                        }
                    }
                }
                if (weak != null)
                    weak.Info = BuildingType.None;
            }
            pbCity.Invalidate();
        }
    }
}
