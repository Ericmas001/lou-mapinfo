using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.OfficialLOU;
using System.Threading;
using LouMapInfo.Layout;
using EricUtility.Windows.Forms;

namespace LouMapInfoApp.Tools
{
    public partial class ContentLayout : UserControl
    {
        bool water = true;
        private Point mouse = new Point(-1, -1);
        private Point coords = new Point(-1, -1);
        int x0 = 64;
        int y0 = 26;
        int dx = 34;
        int dy = 21;
        bool validClick = false;
        private bool m_Loaded = false;
        private  Dictionary<BuildingType, Bitmap> m_DONOTUSE_Buildings = new Dictionary<BuildingType, Bitmap>();
        private  List<LayoutEntry> m_DONOTUSE_Layout = new List<LayoutEntry>();
        private  LayoutEntry[,] m_CoordLayout = new LayoutEntry[20, 20];
        public  Dictionary<BuildingType, Bitmap> Buildings
        {
            get
            {
                if (!m_Loaded)
                    LoadAll();
                return m_DONOTUSE_Buildings;
            }
        }
        public  List<LayoutEntry> CityLayout
        {
            get
            {
                if (!m_Loaded)
                    LoadAll();
                return m_DONOTUSE_Layout;
            }
        }
        private Dictionary<ResourceType, int> m_Production = new Dictionary<ResourceType, int>();
        private Dictionary<ResourceType, int> m_Storage = new Dictionary<ResourceType, int>();
        private int m_Hidden;
        private int m_Carts;
        private int m_Ships;
        private int m_BuildingCount;
        private int m_ConsSpeed;
        private int m_ArmySize;
        public void LoadAll()
        {
            m_Loaded = true;
            m_DONOTUSE_Buildings.Add(BuildingType.None, new Bitmap(1, 1));//Destroy", '0', '-'));
            m_DONOTUSE_Buildings.Add(BuildingType.ResWood, Properties.Resources.pl_res_forest);//Wood", 'A', '.'));
            m_DONOTUSE_Buildings.Add(BuildingType.ResStone, Properties.Resources.pl_res_stone);//Stone", 'B', ':'));
            m_DONOTUSE_Buildings.Add(BuildingType.ResIron, Properties.Resources.pl_res_iron);//Iron", 'C', ','));
            m_DONOTUSE_Buildings.Add(BuildingType.ResFood, Properties.Resources.pl_res_lake);//Food", 'D', ';'));
            m_DONOTUSE_Buildings.Add(BuildingType.WoodcutterOld, Properties.Resources.pl_building_hut_old);//Woodcutter's hut (old)", 'F', 'W'));
            m_DONOTUSE_Buildings.Add(BuildingType.QuarryOld, Properties.Resources.pl_building_stone_quarry_old);//Quarry (old)", 'G', 'Q'));
            m_DONOTUSE_Buildings.Add(BuildingType.IronMineOld, Properties.Resources.pl_building_mine_old);//Iron Mine (old)", 'H', 'I'));
            m_DONOTUSE_Buildings.Add(BuildingType.FarmOld, Properties.Resources.pl_building_farm_old);//Farm (old)", 'I', 'F'));
            m_DONOTUSE_Buildings.Add(BuildingType.Woodcutter, Properties.Resources.pl_building_hut);//Woodcutter's hut", '2', '2'));
            m_DONOTUSE_Buildings.Add(BuildingType.Quarry, Properties.Resources.pl_building_stone_quarry);//Quarry", '3', '3'));
            m_DONOTUSE_Buildings.Add(BuildingType.IronMine, Properties.Resources.pl_building_mine);//Iron Mine", '4', '4'));
            m_DONOTUSE_Buildings.Add(BuildingType.Farm, Properties.Resources.pl_building_farm);//Farm", '5', '2'));
            m_DONOTUSE_Buildings.Add(BuildingType.Sawmill, Properties.Resources.pl_building_lumber_mill);//Sawmill", 'K', 'L'));
            m_DONOTUSE_Buildings.Add(BuildingType.Stonemasson, Properties.Resources.pl_building_stonecutter);//Stonemasson", 'L', 'A'));
            m_DONOTUSE_Buildings.Add(BuildingType.Foundry, Properties.Resources.pl_building_iron_furnace);//Foundry", 'M', 'D'));
            m_DONOTUSE_Buildings.Add(BuildingType.Mill, Properties.Resources.pl_building_mill);//Mill", 'N', 'M'));
            m_DONOTUSE_Buildings.Add(BuildingType.Warehouse, Properties.Resources.pl_building_storage);//Warehouse", 'Z', 'S'));
            m_DONOTUSE_Buildings.Add(BuildingType.Cottage, Properties.Resources.pl_building_cottage);//Cottage", 'O', 'C'));
            m_DONOTUSE_Buildings.Add(BuildingType.Hideout, Properties.Resources.pl_building_hideout);//Hideout", '1', 'H'));
            m_DONOTUSE_Buildings.Add(BuildingType.Marketplace, Properties.Resources.pl_building_market_place);//Marketplm_DONOTUSE_Buildings.Add(ace", 'J', 'P'));
            m_DONOTUSE_Buildings.Add(BuildingType.Townhouse, Properties.Resources.pl_building_townhouse);//Townhouse", 'E', 'U'));
            m_DONOTUSE_Buildings.Add(BuildingType.Barracks, Properties.Resources.pl_building_barracks);//Barracks", 'P', 'B'));
            m_DONOTUSE_Buildings.Add(BuildingType.CityGuardHouse, Properties.Resources.pl_building_cityguard_house);//CityGuardHouse", 'S', 'K'));
            m_DONOTUSE_Buildings.Add(BuildingType.TrainingGround, Properties.Resources.pl_building_casern);//Training Ground", 'Q', 'G'));
            m_DONOTUSE_Buildings.Add(BuildingType.Stable, Properties.Resources.pl_building_stables);//Stable", 'U', 'E'));
            m_DONOTUSE_Buildings.Add(BuildingType.MoonglowTower, Properties.Resources.pl_building_mage_tower);//Moonglow Tower", 'R', 'J'));
            m_DONOTUSE_Buildings.Add(BuildingType.TrinsicTemple, Properties.Resources.pl_building_temple);//Trinsic Temple", 'W', 'Z'));
            m_DONOTUSE_Buildings.Add(BuildingType.Workshop, Properties.Resources.pl_building_weapon_factory);//Workshop", 'V', 'Y'));
            m_DONOTUSE_Buildings.Add(BuildingType.Harbor, Properties.Resources.pl_building_harbour);//Harbor", 'T', 'R'));
            m_DONOTUSE_Buildings.Add(BuildingType.Shipyard, Properties.Resources.pl_building_shipyard);//Shipyard", 'Y', 'V'));
            m_DONOTUSE_Buildings.Add(BuildingType.Castle, Properties.Resources.pl_building_stronghold);//Castle", 'X', 'X'));
            m_DONOTUSE_Buildings.Add(BuildingType.FarmLand, Properties.Resources.pl_res_farmland);//Farm Land", ' ', ' '));

            Point[][] lines = new Point[][]{
                new Point[]{ new Point(2,8), new Point(10,16)},
                new Point[]{ new Point(1,8), new Point(10,17)},
                new Point[]{ new Point(0,8), new Point(10,18)},
                new Point[]{ new Point(0,8), new Point(10,18)},
                new Point[]{ new Point(0,5), new Point(13,18)},
                new Point[]{ new Point(0,4), new Point(7,11), new Point(14,18)},
                new Point[]{ new Point(0,3), new Point(6,12), new Point(15,18)},
                new Point[]{ new Point(0,3), new Point(5,13), new Point(15,18)},
                new Point[]{ new Point(0,3), new Point(5,13), new Point(15,18)},
                new Point[]{ new Point(5,13)},
                new Point[]{ new Point(0,3), new Point(5,13), new Point(15,18)},
                new Point[]{ new Point(0,3), new Point(5,13), new Point(15,18)},
                new Point[]{ new Point(0,3), new Point(6,12), new Point(15,18)},
                new Point[]{ new Point(0,4), new Point(7,11), new Point(14,18)},
                new Point[]{ new Point(0,5), new Point(13,18)},
                new Point[]{ new Point(0,8), new Point(10,18)},
                new Point[]{ new Point(0,8), new Point(10,18)},
                new Point[]{ new Point(1,8), new Point(10,17)},
                new Point[]{ new Point(2,8), new Point(10,16)},
            };
            for (int y = 0; y < lines.Length; ++y)
                foreach (Point p in lines[y])
                    for (int x = p.X; x <= p.Y; ++x)
                    {
                        LayoutEntry le = new LayoutEntry(x, y, BuildingType.None);
                        le.RefreshResourceProduction += new ResourceTypeHandler(le_RefreshResourceProduction);
                        le.RefreshResourceStorage += new EmptyHandler(le_RefreshResourceStorage);
                        le.RefreshResourceHidden += new EmptyHandler(le_RefreshResourceHidden);
                        le.RefreshTransport += new EmptyHandler(le_RefreshTransport);
                        le.RefreshBuildingCount += new EmptyHandler(le_RefreshBuildingCount);
                        le.RefreshConsSpeed += new EmptyHandler(le_RefreshConsSpeed);
                        le.RefreshArmySize += new EmptyHandler(le_RefreshArmySize);
                        m_DONOTUSE_Layout.Add(le);
                        if (x != 9 || y != 9)
                            m_CoordLayout[x, y] = le;
                    }
            foreach (LayoutEntry le in CityLayout)
                for (int xi = -1; xi <= 1; ++xi)
                    for (int yi = -1; yi <= 1; ++yi)
                        if (xi != 0 || yi != 0)
                            if (le.X + xi >= 0 && le.X + xi < 20 && le.Y + yi >= 0 && le.Y + yi < 20 && m_CoordLayout[le.X + xi, le.Y + yi] != null)
                                le.AddNeighbor(m_CoordLayout[le.X + xi, le.Y + yi]);
        }

        void le_RefreshArmySize()
        {
            int multi = 1;
            int total = 0;
            foreach (LayoutEntry le in CityLayout)
            {
                total += le.ArmySize;
                if (le.Info == BuildingType.Castle)
                    multi = 4;
            }
            m_ArmySize = total * multi;
            RefreshCounters();
        }

        void le_RefreshConsSpeed()
        {
            int total = 100;
            foreach (LayoutEntry le in CityLayout)
                total += le.ConsSpeed;
            m_ConsSpeed = total;
            RefreshCounters();
        }

        void le_RefreshBuildingCount()
        {
            int total = 0;
            foreach (LayoutEntry le in CityLayout)
                total += le.BuildingCount;
            m_BuildingCount = total;
            RefreshCounters();
        }

        void le_RefreshTransport()
        {
            int totalC = 0;
            int totalS = 0;
            foreach (LayoutEntry le in CityLayout)
            {
                totalC += le.Carts;
                totalS += le.Ships;
            }
            m_Carts = totalC;
            m_Ships = totalS;
            RefreshCounters();
        }

        void le_RefreshResourceHidden()
        {
            int total = 0;
            foreach (LayoutEntry le in CityLayout)
                total += le.Hidden;
            m_Hidden = total;
            RefreshCounters();
        }

        void le_RefreshResourceStorage()
        {
            int totalW = 175000;
            int totalS = 175000;
            int totalI = 175000;
            int totalF = 175000;
            foreach (LayoutEntry le in CityLayout)
            {
                totalW += le.Storage(ResourceType.Wood);
                totalS += le.Storage(ResourceType.Stone);
                totalI += le.Storage(ResourceType.Iroon);
                totalF += le.Storage(ResourceType.Food);
            }
            m_Storage[ResourceType.Wood] = totalW;
            m_Storage[ResourceType.Stone] = totalS;
            m_Storage[ResourceType.Iroon] = totalI;
            m_Storage[ResourceType.Food] = totalF;
            RefreshCounters();
        }

        void le_RefreshResourceProduction(ResourceType res)
        {
            int total = 0;
            foreach (LayoutEntry le in CityLayout)
                total += le.Production(res);
            if (res == ResourceType.Wood)
                total += 300;
            m_Production[res] = total; 
            RefreshCounters();
        }


        private BuildingType m_CurBuilding = BuildingType.None;
        private ToolStripButton m_CurButton = null;
        private void RefreshCounters()
        {
            lblGold.Text = m_Production[ResourceType.Gold].ToString("N0") + "/h";
            lblWood.Text = m_Production[ResourceType.Wood].ToString("N0") + "/h";
            lblStone.Text = m_Production[ResourceType.Stone].ToString("N0") + "/h";
            lblIron.Text = m_Production[ResourceType.Iroon].ToString("N0") + "/h";
            lblFood.Text = m_Production[ResourceType.Food].ToString("N0") + "/h";
            lblTotalRes.Text = (m_Production[ResourceType.Wood] + m_Production[ResourceType.Stone] + m_Production[ResourceType.Iroon] + m_Production[ResourceType.Food]).ToString("N0") + "/h";
            lblStorWood.Text = m_Storage[ResourceType.Wood].ToString("N0");
            lblStorStone.Text = m_Storage[ResourceType.Stone].ToString("N0");
            lblStorIron.Text = m_Storage[ResourceType.Iroon].ToString("N0");
            lblStorFood.Text = m_Storage[ResourceType.Food].ToString("N0");
            lblStorHidden.Text = m_Hidden.ToString("N0");
            lblNbCarts.Text = m_Carts.ToString("N0") + " (" + (m_Carts * 1000).ToString("N0") + ")";
            lblNbShips.Text = m_Ships.ToString("N0") + " (" + (m_Ships * 10000).ToString("N0") + ")";
            lblBuildingsLeft.Text = "" + (100 - m_BuildingCount);
            if (m_BuildingCount > 100)
                lblBuildingsLeft.ForeColor = Color.Red;
            else
                lblBuildingsLeft.ForeColor = Color.Black;
            lblConsSpeed.Text = m_ConsSpeed.ToString("N0") + "%";
            lblArmySize.Text = m_ArmySize.ToString("N0");
        }
        private void ResetCounters()
        {
            m_Production.Clear();
            m_Production.Add(ResourceType.Gold, 0);
            m_Production.Add(ResourceType.Wood, 300);
            m_Production.Add(ResourceType.Stone, 0);
            m_Production.Add(ResourceType.Iroon, 0);
            m_Production.Add(ResourceType.Food, 0);
            m_Storage.Clear();
            m_Storage.Add(ResourceType.Wood, 175000);
            m_Storage.Add(ResourceType.Stone, 175000);
            m_Storage.Add(ResourceType.Iroon, 175000);
            m_Storage.Add(ResourceType.Food, 175000);
            m_Hidden = 0;
            m_Carts = 0;
            m_Ships = 0;
            m_BuildingCount = 100;
            m_ConsSpeed = 100;

        }
        public ContentLayout()
        {
            ResetCounters();
            InitializeComponent();
            m_CurButton = btnDestroy;
            btnDestroy.BackColor = SystemColors.Highlight;
            CreateNew(true);
            RefreshCounters();
            tabControl1.SelectedTab = tbImport;
            
            ImageList list = new ImageList();
            tabControl1.ImageList = list;
            list.Images.Add(Properties.Resources.icon_build_slots);
            list.Images.Add(Properties.Resources.icon_recruit_slots);
            tbCityInfo.ImageIndex = 0;
            tbCityMilitary.ImageIndex = 1;
        }
        private void pbCity_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int mousex = coords.X;
            int mousey = coords.Y;
            if (validClick)
                    g.DrawImage(Properties.Resources.pl_decal_select_building, x0 + (mousex * dx), y0 + 15 + (mousey * dy), 48, 48);
            
            foreach (LayoutEntry l in CityLayout)
            {
                if (l.X == 9 && l.Y == 9)
                    g.DrawImage(Properties.Resources.pl_building_townhall, x0 + (9 * dx), y0 + (9 * dy), 48, 48);
                else
                    g.DrawImage(Buildings[l.Info], x0 + (l.X * dx), y0 + (l.Y * dy), 48, 48);
            }
        }
        public void ChooseTool(ToolStripButton btn, BuildingType type)
        {
            if (m_CurButton != null)
                m_CurButton.BackColor = Color.White;
            m_CurButton = btn;
            m_CurButton.BackColor = SystemColors.Highlight;
            m_CurBuilding = type;
            pbCity.Invalidate();
        }
        private void btnTree_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.ResWood);
        }

        private void btnStone_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.ResStone);
        }

        private void btnIron_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.ResIron);
        }

        private void btnWater_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.ResFood);
        }

        private void btnHideout_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Hideout);
        }

        private void btnOldWoodcutter_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.WoodcutterOld);
        }

        private void btnOldQuarry_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.QuarryOld);
        }

        private void btnOldIronMine_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.IronMineOld);
        }

        private void btnOldFarm_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.FarmOld);
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.None);
        }

        private void btnWoodcutter_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Woodcutter);
        }

        private void btnQuarry_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Quarry);
        }

        private void btnIronMine_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.IronMine);
        }

        private void btnFarm_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Farm);
        }

        private void btnCottage_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Cottage);
        }

        private void btnMarket_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Marketplace);
        }

        private void btnBarrack_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Barracks);
        }

        private void btnTrainingGround_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.TrainingGround);
        }

        private void btnMoonglowTower_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.MoonglowTower);
        }

        private void btnWorkshop_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Workshop);
        }

        private void btnHarbor_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Harbor);
        }

        private void btnSawmill_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Sawmill);
        }

        private void btnStonemasson_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Stonemasson);
        }

        private void btnFoundry_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Foundry);
        }

        private void btnMill_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Mill);
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Warehouse);
        }

        private void btnTownhouse_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Townhouse);
        }

        private void btnCityGuardHouse_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.CityGuardHouse);
        }

        private void btnStable_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Stable);
        }

        private void btnTrinsicTemple_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.TrinsicTemple);
        }

        private void btnCastle_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Castle);
        }

        private void btnShipyard_Click(object sender, EventArgs e)
        {
            ChooseTool((ToolStripButton)sender, BuildingType.Shipyard);
        }
        public void verifyValid()
        {
            validClick = false;
            int mousex = coords.X;
            int mousey = coords.Y;
            if (mousex >= 0 && mousex < 20 && mousey >= 0 && mousey < 20 && m_CoordLayout[mousex, mousey] != null)
            {
                if (!water && (m_CurBuilding == BuildingType.Harbor || m_CurBuilding == BuildingType.Shipyard))
                    return;
                if (water)
                {
                    bool waterSpot = false;
                    foreach (Point p in new Point[] { new Point(15, 14), new Point(16, 14), new Point(14, 15), new Point(17, 15), new Point(14, 16), new Point(18, 16), new Point(15, 17), new Point(16, 18) })
                        if (p.X == mousex && p.Y == mousey)
                        {
                            waterSpot = true;
                            if (m_CurBuilding != BuildingType.None && m_CurBuilding != BuildingType.Harbor && m_CurBuilding != BuildingType.Shipyard)
                                return;
                        }
                    if (!waterSpot && (m_CurBuilding == BuildingType.Harbor || m_CurBuilding == BuildingType.Shipyard))
                        return;
                    foreach (Point p in new Point[] { new Point(15, 15), new Point(16, 15), new Point(15, 16), new Point(16, 16), new Point(17, 16), new Point(16, 17), new Point(17, 17)})
                        if (p.X == mousex && p.Y == mousey)
                            return;
                }



                if (m_CurBuilding == m_CoordLayout[mousex, mousey].Info)
                    return;

                validClick = true;
            }
        }
        private void pbCity_MouseMove(object sender, MouseEventArgs e)
        {

            mouse = e.Location;
            Point nc = new Point((mouse.X - x0 - 3) / dx, (mouse.Y - y0 - 13) / dy);
            if (nc.X != coords.X || nc.Y != coords.Y)
            {
                coords = nc;
                verifyValid();
                pbCity.Invalidate();
            }
        }
        public void CreateNew(bool w)
        {
            ResetCounters();
            water = w;
            if (water)
                pbCity.BackgroundImage = Properties.Resources.pl_town_bg_water;
            else
                pbCity.BackgroundImage = Properties.Resources.pl_town_bg;
            btnShipyard.Enabled = water;
            btnHarbor.Enabled = water;

            foreach (LayoutEntry le in CityLayout)
            {
                le.Water = water;
                le.Info = BuildingType.None;
            }
        }
        public void Import(string patente)
        {
            if (patente.Contains("ShareString"))
            {
                CreateNew(patente.Contains("];"));
                string s = patente.Substring(patente.IndexOf('#')).Replace("#", "").Replace("T", "-").Replace("_", "-").Replace("[/ShareString]", "");
                for (int i = 0; i < s.Length; ++i)
                {
                    int j = i;
                    if (water)
                    {
                        if (i >= 242)
                            j += 2;
                        if (i >= 258)
                            j += 3;
                        if (i >= 272)
                            j += 2;
                    }
                    CityLayout[j].Info = BuildingInfo.ByLetterShareString[s[i]].BType;
                }
            }
            else if (patente.Contains("lou-fcp.co.uk"))
            {
                string s = patente.Substring(patente.IndexOf('=') + 1);
                CreateNew(s[0] == 'W');
                for (int i = 0; i < s.Length - 1; ++i)
                {
                    CityLayout[i].Info = BuildingInfo.ByLetterFlashPlanner[s[i + 1]].BType;
                }
            }
            else
                throw (new NotImplementedException());
        }

        private void pbCity_MouseClick(object sender, MouseEventArgs e)
        {
            bool demo = m_CurBuilding == BuildingType.None || e.Button == System.Windows.Forms.MouseButtons.Right;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int mousex = coords.X;
                int mousey = coords.Y;
                if (mousex >= 0 && mousex < 20 && mousey >= 0 && mousey < 20 && m_CoordLayout[mousex, mousey] != null)
                {
                    m_CoordLayout[mousex, mousey].Info = BuildingType.None;
                }
            }
            else if (validClick && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    int mousex = coords.X;
                    int mousey = coords.Y;
                    if (mousex >= 0 && mousex < 20 && mousey >= 0 && mousey < 20 && m_CoordLayout[mousex, mousey] != null)
                    {
                        m_CoordLayout[mousex, mousey].Info = m_CurBuilding;
                    }
            }
                verifyValid();
                pbCity.Invalidate();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtImport.Text))
            {
                try
                {
                    Import(txtImport.Text);
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
            CreateNew(false);
            RefreshCounters();
            tabControl1.SelectedIndex = 0;
        }

        private void btnCreateWater_Click(object sender, EventArgs e)
        {
            CreateNew(true);
            RefreshCounters();
            tabControl1.SelectedIndex = 0;
        }
    }
}
