using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LouMapInfo.Layout;

namespace LouMapInfoApp
{
    public class LayoutPictureBox : PictureBox
    {
        public event EmptyHandler CounterRefreshed = delegate { };
        public event BuildingTypeHandler BuildingChanged = delegate { };
        private Point mouse = new Point(-1, -1);
        private Point coords = new Point(-1, -1);
        int x0 = 64;
        int y0 = 26;
        int dx = 34;
        int dy = 21;
        bool validClick = false;
        private bool m_Loaded = false;
        private Dictionary<BuildingType, Bitmap> m_DONOTUSE_Buildings = new Dictionary<BuildingType, Bitmap>();
        private CompleteLayout m_Layout;

        public int Hidden
        {
            get { return m_Layout.Hidden; }
        }

        public Dictionary<ResourceType, int> Production
        {
            get { return m_Layout.Production; }
        }

        public Dictionary<ResourceType, int> Storage
        {
            get { return m_Layout.Storage; }
        }

        public Dictionary<BuildingType, int> Recruitment
        {
            get { return m_Layout.Recruitment; }
        }

        public int Carts
        {
            get { return m_Layout.Carts; }
        }

        public int Ships
        {
            get { return m_Layout.Ships; }
        }

        public int BuildingCount
        {
            get { return m_Layout.BuildingCount; }
        }

        public int ConsSpeed
        {
            get { return m_Layout.ConsSpeed; }
        }

        public int ArmySize
        {
            get { return m_Layout.ArmySize; }
        }


        public bool Water
        {
            get { return m_Layout.Water; }
            set { m_Layout.Water = value; }
        }
        private Dictionary<BuildingType, Bitmap> Buildings
        {
            get
            {
                if (!m_Loaded)
                    LoadAll();
                return m_DONOTUSE_Buildings;
            }
        }



        public LayoutPictureBox()
        {
            m_Layout = new CompleteLayout();
            m_Layout.MapChanged += new EmptyHandler(m_Layout_MapChanged);
            m_Layout.CounterRefreshed += new EmptyHandler(m_Layout_CounterRefreshed);
            m_Layout.BuildingChanged += new BuildingTypeHandler(m_Layout_BuildingChanged);
        }

        void m_Layout_BuildingChanged(BuildingType res)
        {
            OnMouseMove(new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, mouse.X, mouse.Y, 0));
            Invalidate();
            BuildingChanged(res);
        }

        void m_Layout_CounterRefreshed()
        {
            CounterRefreshed();
        }

        void m_Layout_MapChanged()
        {
            if (m_Layout.Water)
                BackgroundImage = Properties.Resources.pl_town_bg_water;
            else
                BackgroundImage = Properties.Resources.pl_town_bg;
        }
        



        private void LoadAll()
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
        }
        public void verifyValid()
        {
            validClick = false;
            int mousex = coords.X;
            int mousey = coords.Y;
            if (mousex >= 0 && mousex < 20 && mousey >= 0 && mousey < 20 && m_Layout.CoordLayout[mousex, mousey] != null)
            {
                if (!m_Layout.Water && (m_Layout.CurBuilding == BuildingType.Harbor || m_Layout.CurBuilding == BuildingType.Shipyard))
                    return;
                if (m_Layout.Water)
                {
                    bool waterSpot = false;
                    foreach (Point p in new Point[] { new Point(15, 14), new Point(16, 14), new Point(14, 15), new Point(17, 15), new Point(14, 16), new Point(18, 16), new Point(15, 17), new Point(16, 18) })
                        if (p.X == mousex && p.Y == mousey)
                        {
                            waterSpot = true;
                            if (m_Layout.CurBuilding != BuildingType.None && m_Layout.CurBuilding != BuildingType.Harbor && m_Layout.CurBuilding != BuildingType.Shipyard)
                                return;
                        }
                    if (!waterSpot && (m_Layout.CurBuilding == BuildingType.Harbor || m_Layout.CurBuilding == BuildingType.Shipyard))
                        return;
                    foreach (Point p in new Point[] { new Point(15, 15), new Point(16, 15), new Point(15, 16), new Point(16, 16), new Point(17, 16), new Point(16, 17), new Point(17, 17) })
                        if (p.X == mousex && p.Y == mousey)
                            return;
                }



                if (m_Layout.CurBuilding == m_Layout.CoordLayout[mousex, mousey].Info)
                    return;

                validClick = true;
            }
        }
        public void CreateNew(bool w)
        {
            m_Layout.CreateNew(w);
        }
        public void Import(string patente)
        {
            m_Layout.Import(patente);
        }
        public void ChooseTool(BuildingType res)
        {
            m_Layout.ChooseTool(res);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            int mousex = coords.X;
            int mousey = coords.Y;
            if (validClick)
                g.DrawImage(Properties.Resources.pl_decal_select_building, x0 + (mousex * dx), y0 + 15 + (mousey * dy), 48, 48);

            foreach (LayoutEntry l in m_Layout.CityLayout)
            {
                if (l.X == 9 && l.Y == 9)
                    g.DrawImage(Properties.Resources.pl_building_townhall, x0 + (9 * dx), y0 + (9 * dy), 48, 48);
                else
                    g.DrawImage(Buildings[l.Info], x0 + (l.X * dx), y0 + (l.Y * dy), 48, 48);
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mouse = e.Location;
            Point nc = new Point((mouse.X - x0 - 3) / dx, (mouse.Y - y0 - 13) / dy);
            if (nc.X != coords.X || nc.Y != coords.Y)
            {
                coords = nc;
                verifyValid();
                Invalidate();
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            bool demo = m_Layout.CurBuilding == BuildingType.None || e.Button == System.Windows.Forms.MouseButtons.Right;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int mousex = coords.X;
                int mousey = coords.Y;
                if (mousex >= 0 && mousex < 20 && mousey >= 0 && mousey < 20 && m_Layout.CoordLayout[mousex, mousey] != null)
                {
                    m_Layout.CoordLayout[mousex, mousey].Info = BuildingType.None;
                }
            }
            else if (validClick && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int mousex = coords.X;
                int mousey = coords.Y;
                if (mousex >= 0 && mousex < 20 && mousey >= 0 && mousey < 20 && m_Layout.CoordLayout[mousex, mousey] != null)
                {
                    m_Layout.CoordLayout[mousex, mousey].Info = m_Layout.CurBuilding;
                }
            }
            verifyValid();
            Invalidate();
        }

        public void FireOnKeyDown(KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.W: m_Layout.ChooseTool(BuildingType.Woodcutter); break;
                case Keys.P: m_Layout.ChooseTool(BuildingType.Marketplace); break;
                case Keys.V: m_Layout.ChooseTool(BuildingType.Shipyard); break;
                case Keys.J: m_Layout.ChooseTool(BuildingType.MoonglowTower); break;

                case Keys.Q: m_Layout.ChooseTool(BuildingType.Quarry); break;
                case Keys.L: m_Layout.ChooseTool(BuildingType.Sawmill); break;
                case Keys.K: m_Layout.ChooseTool(BuildingType.CityGuardHouse); break;
                case Keys.Z: m_Layout.ChooseTool(BuildingType.TrinsicTemple); break;

                case Keys.I: m_Layout.ChooseTool(BuildingType.IronMine); break;
                case Keys.A: m_Layout.ChooseTool(BuildingType.Stonemasson); break;
                case Keys.B: m_Layout.ChooseTool(BuildingType.Barracks); break;
                case Keys.D1: m_Layout.ChooseTool(BuildingType.ResWood); break;

                case Keys.F: m_Layout.ChooseTool(BuildingType.Farm); break;
                case Keys.D: m_Layout.ChooseTool(BuildingType.Foundry); break;
                case Keys.G: m_Layout.ChooseTool(BuildingType.TrainingGround); break;
                case Keys.D2: m_Layout.ChooseTool(BuildingType.ResStone); break;

                case Keys.C: m_Layout.ChooseTool(BuildingType.Cottage); break;
                case Keys.M: m_Layout.ChooseTool(BuildingType.Mill); break;
                case Keys.E: m_Layout.ChooseTool(BuildingType.Stable); break;
                case Keys.D3: m_Layout.ChooseTool(BuildingType.ResIron); break;

                case Keys.S: m_Layout.ChooseTool(BuildingType.Warehouse); break;
                case Keys.T: m_Layout.ChooseTool(BuildingType.Townhouse); break;
                case Keys.U: m_Layout.ChooseTool(BuildingType.Townhouse); break;
                case Keys.Y: m_Layout.ChooseTool(BuildingType.Workshop); break;
                case Keys.D4: m_Layout.ChooseTool(BuildingType.ResFood); break;

                case Keys.H: m_Layout.ChooseTool(BuildingType.Hideout); break;
                case Keys.R: m_Layout.ChooseTool(BuildingType.Harbor); break;
                case Keys.X: m_Layout.ChooseTool(BuildingType.Castle); break;
                case Keys.D0: m_Layout.ChooseTool(BuildingType.None); break;

                case Keys.D5: m_Layout.ChooseTool(BuildingType.WoodcutterOld); break;
                case Keys.D6: m_Layout.ChooseTool(BuildingType.QuarryOld); break;
                case Keys.D7: m_Layout.ChooseTool(BuildingType.IronMineOld); break;
                case Keys.D8: m_Layout.ChooseTool(BuildingType.FarmOld); break;

            }
        }

        public string GenerateFlashCityPlanner()
        {
            return m_Layout.GenerateFlashCityPlanner();
        }

        public string GenerateShareString()
        {
            return m_Layout.GenerateShareString();
        }
    }
}
