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

        bool water = true;
        private Point mouse = new Point(-1, -1);
        private Point coords = new Point(-1, -1);
        int x0 = 64;
        int y0 = 26;
        int dx = 34;
        int dy = 21;
        bool validClick = false;
        private bool m_Loaded = false;
        private Dictionary<BuildingType, Bitmap> m_DONOTUSE_Buildings = new Dictionary<BuildingType, Bitmap>();
        private List<LayoutEntry> m_DONOTUSE_Layout = new List<LayoutEntry>();
        private LayoutEntry[,] m_CoordLayout = new LayoutEntry[20, 20];
        private Dictionary<ResourceType, int> m_Production = new Dictionary<ResourceType, int>();
        private Dictionary<ResourceType, int> m_Storage = new Dictionary<ResourceType, int>();
        private Dictionary<BuildingType, int> m_Recruitment = new Dictionary<BuildingType, int>();
        private int m_Hidden;
        private int m_Carts;
        private int m_Ships;
        private int m_BuildingCount;
        private int m_ConsSpeed;
        private int m_ArmySize;
        private BuildingType m_CurBuilding = BuildingType.None;

        public int Hidden
        {
            get { return m_Hidden; }
        }

        public Dictionary<ResourceType, int> Production
        {
            get { return m_Production; }
        }

        public Dictionary<ResourceType, int> Storage
        {
            get { return m_Storage; }
        }

        public Dictionary<BuildingType, int> Recruitment
        {
            get { return m_Recruitment; }
        }

        public int Carts
        {
            get { return m_Carts; }
        }

        public int Ships
        {
            get { return m_Ships; }
        }

        public int BuildingCount
        {
            get { return m_BuildingCount; }
        }

        public int ConsSpeed
        {
            get { return m_ConsSpeed; }
        }

        public int ArmySize
        {
            get { return m_ArmySize; }
        }


        public bool Water
        {
            get { return water; }
            set
            {
                water = value;

                if (water)
                    BackgroundImage = Properties.Resources.pl_town_bg_water;
                else
                    BackgroundImage = Properties.Resources.pl_town_bg;
            }
        }
        public BuildingType CurBuilding
        {
            get { return m_CurBuilding; }
            set { ChooseTool(value); }
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
        private List<LayoutEntry> CityLayout
        {
            get
            {
                if (!m_Loaded)
                    LoadAll();
                return m_DONOTUSE_Layout;
            }
        }



        public LayoutPictureBox()
        {
            ResetCounters();

            m_CurBuilding = BuildingType.None;
            CreateNew(true);
            RefreshCounters();
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
                        le.RefreshResourceStorage += new LouMapInfo.Layout.EmptyHandler(le_RefreshResourceStorage);
                        le.RefreshResourceHidden += new LouMapInfo.Layout.EmptyHandler(le_RefreshResourceHidden);
                        le.RefreshTransport += new LouMapInfo.Layout.EmptyHandler(le_RefreshTransport);
                        le.RefreshBuildingCount += new LouMapInfo.Layout.EmptyHandler(le_RefreshBuildingCount);
                        le.RefreshConsSpeed += new LouMapInfo.Layout.EmptyHandler(le_RefreshConsSpeed);
                        le.RefreshArmySize += new LouMapInfo.Layout.EmptyHandler(le_RefreshArmySize);
                        le.RefreshRecruitmentSpeed += new BuildingTypeHandler(le_RefreshRecruitmentSpeed);
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

        void le_RefreshRecruitmentSpeed(BuildingType type)
        {
            int total = 100;
            foreach (LayoutEntry le in CityLayout)
                total += le.Recruitment(type);
            m_Recruitment[type] = total;
            RefreshCounters();
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
        private void RefreshCounters()
        {
            CounterRefreshed();
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
            m_Recruitment.Clear();
            m_Recruitment.Add(BuildingType.CityGuardHouse, 100);
            m_Recruitment.Add(BuildingType.TrainingGround, 100);
            m_Recruitment.Add(BuildingType.Stable, 100);
            m_Recruitment.Add(BuildingType.MoonglowTower, 100);
            m_Recruitment.Add(BuildingType.TrinsicTemple, 100);
            m_Recruitment.Add(BuildingType.Workshop, 100);
            m_Recruitment.Add(BuildingType.Shipyard, 100);
            m_Hidden = 0;
            m_Carts = 0;
            m_Ships = 0;
            m_BuildingCount = 100;
            m_ConsSpeed = 100;

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
                    foreach (Point p in new Point[] { new Point(15, 15), new Point(16, 15), new Point(15, 16), new Point(16, 16), new Point(17, 16), new Point(16, 17), new Point(17, 17) })
                        if (p.X == mousex && p.Y == mousey)
                            return;
                }



                if (m_CurBuilding == m_CoordLayout[mousex, mousey].Info)
                    return;

                validClick = true;
            }
        }
        public void CreateNew(bool w)
        {
            ResetCounters();
            Water = w;

            foreach (LayoutEntry le in CityLayout)
            {
                le.Water = water;
                le.Info = BuildingType.None;
            }
            RefreshCounters();
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
            RefreshCounters();
        }
        public void ChooseTool(BuildingType type)
        {
            m_CurBuilding = type;
            OnMouseMove(new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, mouse.X, mouse.Y, 0));
            Invalidate();
            BuildingChanged(type);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
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
                case Keys.W: ChooseTool(BuildingType.Woodcutter); break;
                case Keys.P: ChooseTool(BuildingType.Marketplace); break;
                case Keys.V: ChooseTool(BuildingType.Shipyard); break;
                case Keys.J: ChooseTool(BuildingType.MoonglowTower); break;

                case Keys.Q: ChooseTool(BuildingType.Quarry); break;
                case Keys.L: ChooseTool(BuildingType.Sawmill); break;
                case Keys.K: ChooseTool(BuildingType.CityGuardHouse); break;
                case Keys.Z: ChooseTool(BuildingType.TrinsicTemple); break;

                case Keys.I: ChooseTool(BuildingType.IronMine); break;
                case Keys.A: ChooseTool(BuildingType.Stonemasson); break;
                case Keys.B: ChooseTool(BuildingType.Barracks); break;
                case Keys.D1: ChooseTool(BuildingType.ResWood); break;

                case Keys.F: ChooseTool(BuildingType.Farm); break;
                case Keys.D: ChooseTool(BuildingType.Foundry); break;
                case Keys.G: ChooseTool(BuildingType.TrainingGround); break;
                case Keys.D2: ChooseTool(BuildingType.ResStone); break;

                case Keys.C: ChooseTool(BuildingType.Cottage); break;
                case Keys.M: ChooseTool(BuildingType.Mill); break;
                case Keys.E: ChooseTool(BuildingType.Stable); break;
                case Keys.D3: ChooseTool(BuildingType.ResIron); break;

                case Keys.S: ChooseTool(BuildingType.Warehouse); break;
                case Keys.T: ChooseTool(BuildingType.Townhouse); break;
                case Keys.U: ChooseTool(BuildingType.Townhouse); break;
                case Keys.Y: ChooseTool(BuildingType.Workshop); break;
                case Keys.D4: ChooseTool(BuildingType.ResFood); break;

                case Keys.H: ChooseTool(BuildingType.Hideout); break;
                case Keys.R: ChooseTool(BuildingType.Harbor); break;
                case Keys.X: ChooseTool(BuildingType.Castle); break;
                case Keys.D0: ChooseTool(BuildingType.None); break;

                case Keys.D5: ChooseTool(BuildingType.WoodcutterOld); break;
                case Keys.D6: ChooseTool(BuildingType.QuarryOld); break;
                case Keys.D7: ChooseTool(BuildingType.IronMineOld); break;
                case Keys.D8: ChooseTool(BuildingType.FarmOld); break;

            }
        }

        public string GenerateFlashCityPlanner()
        {
            string basic = "http://www.lou-fcp.co.uk/map.php?map=";
            char t = water ? 'W' : 'L';
            string layout = "";
            foreach (LayoutEntry le in CityLayout)
            {
                BuildingType b = le.Info;
                if (le.Info == BuildingType.FarmLand)
                    b = BuildingType.None;
                layout += BuildingInfo.ByType[b].LetterFlashPlanner;
            }
            return basic + t + layout;
        }

        public string GenerateShareString()
        {
            const string basicW = "[ShareString.1.3];########################-------#-------#####--------#--------###---------#---------##---------#---------##------#######------##-----##-----##-----##----##-------##----##----#---------#----##----#---------#----#######----T----#######----#---------#----##----#---------#----##----##-------##----##-----##-----##-----##------#######--__--##---------#----_##_-##---------#----_###_###--------#-----_#######-------#------_########################[/ShareString]";
            const string basicL = "[ShareString.1.3]:########################-------#-------#####--------#--------###---------#---------##---------#---------##------#######------##-----##-----##-----##----##-------##----##----#---------#----##----#---------#----#######----T----#######----#---------#----##----#---------#----##----##-------##----##-----##-----##-----##------#######------##---------#---------##---------#---------###--------#--------#####-------#-------########################[/ShareString]";
            bool started = false;
            int ri = 0;
            string s = "";
            List<LayoutEntry> layout = CityLayout;
            for (int i = 0; i < basicL.Length; ++i)
            {
                if (!started)
                {
                    if (basicL[i] == '#')
                        started = true;
                    s += water ? basicW[i] : basicL[i];
                }
                else
                {
                    if (water && basicL[i] == '-' && basicW[i] == '#')
                    {
                        ri++;
                        s += basicW[i];
                    }
                    else if (basicL[i] == '-')
                    {
                        LayoutEntry le = layout[ri++];
                        BuildingType b = le.Info;
                        if (le.Info == BuildingType.FarmLand)
                            b = BuildingType.None;
                        if (water && b == BuildingType.None && basicW[i] == '_')
                            s += basicW[i];
                        else
                            s += BuildingInfo.ByType[b].LetterShareString;
                    }
                    else if (basicL[i] == 'T')
                    {
                        ri++;
                        s += basicL[i];
                    }
                    else
                        s += basicL[i];
                }
            }
            return s;
        }
    }
}
