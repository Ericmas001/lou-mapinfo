using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LouMapInfo.Entities;
using EricUtility.Networking.JSON;
using LouMapInfo;

namespace LouMapInfo.Layout
{
    public class CompleteLayout
    {
        public event EmptyHandler CounterRefreshed = delegate { };
        public event EmptyHandler MapChanged = delegate { };
        public event BuildingTypeHandler BuildingChanged = delegate { };
        bool water = true;
        private bool m_Loaded = false;
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
                MapChanged();
            }
        }
        public BuildingType CurBuilding
        {
            get { return m_CurBuilding; }
            set { ChooseTool(value); }
        }
        public List<LayoutEntry> CityLayout
        {
            get
            {
                if (!m_Loaded)
                    LoadAll();
                return m_DONOTUSE_Layout;
            }
        }

        public LayoutEntry[,] CoordLayout
        {
            get
            {
                if (!m_Loaded)
                    LoadAll(); 
                return m_CoordLayout;
            }
            set { m_CoordLayout = value; }
        }



        public CompleteLayout()
        {
            ResetCounters();

            m_CurBuilding = BuildingType.None;
            CreateNew(true);
            RefreshCounters();
        }


        public CompleteLayout(string s) : this()
        {
            Import(s);
        }




        private void LoadAll()
        {
            m_Loaded = true;

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
                totalI += le.Storage(ResourceType.Iron);
                totalF += le.Storage(ResourceType.Food);
            }
            m_Storage[ResourceType.Wood] = totalW;
            m_Storage[ResourceType.Stone] = totalS;
            m_Storage[ResourceType.Iron] = totalI;
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
            m_Production.Add(ResourceType.Iron, 0);
            m_Production.Add(ResourceType.Food, 0);
            m_Storage.Clear();
            m_Storage.Add(ResourceType.Wood, 175000);
            m_Storage.Add(ResourceType.Stone, 175000);
            m_Storage.Add(ResourceType.Iron, 175000);
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
            m_BuildingCount = 0;
            m_ConsSpeed = 100;

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
            BuildingChanged(type);
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

        public static CompleteLayout GetLayoutFromCity(CityInfo city)
        {
            JsonArrayCollection jac = EndPoint.GetCityLayout(city.Player.Alliance.World.Url, city.Player.Alliance.World.Session.SessionID, city.Id);
            string s = "http://www.lou-fcp.co.uk/map.php?map=";
            s += city.Bordering == BorderingType.Water ? "W" : "L";
            foreach (JsonObjectCollection joc in jac)
            {
                int t = (int)((JsonNumericValue)joc["t"]).Value;
                if (t == 4)
                {
                    int v = (int)((JsonNumericValue)joc["v"]).Value;
                    if (v != 12 && v <= 50 && (v < 27 || v > 30))
                    {
                        BuildingInfo bi = BuildingInfo.ByOfficialID[400 +v];
                        s += bi.LetterFlashPlanner;
                    }
                    else if (v == 12 || (v >= 27 && v <= 30) || v <= 100)
                    {
                        BuildingInfo bi = BuildingInfo.ByOfficialID[501];
                        s += bi.LetterFlashPlanner;
                    }
                }
                else if (t == 5)
                {
                    int b = (int)((JsonNumericValue)joc["b"]).Value;
                    if (b == 1)
                    {
                        BuildingInfo bi = BuildingInfo.ByOfficialID[501];
                        s += bi.LetterFlashPlanner;
                    }
                }
                else if (t == 9)
                {
                    int r = (int)((JsonNumericValue)joc["r"]).Value;
                        BuildingInfo bi = BuildingInfo.ByOfficialID[900+r];
                        s += bi.LetterFlashPlanner;
                }
            }
            if (city.Bordering == BorderingType.Water)
            {
                s = s.Insert(279, "00");
                s = s.Insert(297, "000");
                s = s.Insert(315, "00");
            }
            return new CompleteLayout(s);
        }
    }
}
