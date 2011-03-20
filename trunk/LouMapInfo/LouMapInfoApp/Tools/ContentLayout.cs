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

namespace LouMapInfoApp.Tools
{
    public partial class ContentLayout : UserControl
    {
        private static bool m_Loaded = false;
        private static Dictionary<BuildingType, Bitmap> m_DONOTUSE_Buildings = new Dictionary<BuildingType,Bitmap>();
        public static Dictionary<BuildingType, Bitmap> Buildings
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return m_DONOTUSE_Buildings;
            }
        }
        public static void Load()
        {
            m_Loaded = true;
            m_DONOTUSE_Buildings.Add(BuildingType.None, new Bitmap(1,1));//Destroy", '0', '-'));
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
        }


        private BuildingType m_CurBuilding = BuildingType.None;
        private ToolStripButton m_CurButton = null;
        public ContentLayout()
        {
            InitializeComponent();
        }
        private void pbCity_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x0 = 64;
            int y0 = 26;
            int dx = 34;
            int dy = 21;
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
                new Point[]{ new Point(5,8), new Point(10,13)},
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
            {
                if (y == 9)
                    g.DrawImage(Properties.Resources.pl_building_townhall, x0 + (9 * dx), y0 + (y * dy), 48, 48);
                foreach (Point p in lines[y])
                    for (int x = p.X; x <= p.Y; ++x)
                        g.DrawImage(Buildings[m_CurBuilding], x0 + (x * dx), y0 + (y * dy), 48, 48);
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
    }
}
