using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Layout;
using System.Drawing;

namespace LouMapInfo.Layout
{
    public delegate void ResourceTypeHandler(ResourceType res);
    public delegate void BuildingTypeHandler(BuildingType res);
    public delegate void EmptyHandler();
    public class LayoutEntry
    {
        public event ResourceTypeHandler RefreshResourceProduction = delegate { };
        public event BuildingTypeHandler RefreshRecruitmentSpeed = delegate { };
        public event EmptyHandler RefreshResourceStorage = delegate { };
        public event EmptyHandler RefreshResourceHidden = delegate { };
        public event EmptyHandler RefreshTransport = delegate { };
        public event EmptyHandler RefreshBuildingCount = delegate { };
        public event EmptyHandler RefreshConsSpeed = delegate { };
        public event EmptyHandler RefreshArmySize = delegate { };
        private static readonly Point[] InvalidOnWater = new Point[] { new Point(15, 14), new Point(16, 14), new Point(14, 15), new Point(17, 15), new Point(14, 16), new Point(18, 16), new Point(15, 17), new Point(16, 18), new Point(15, 15), new Point(16, 15), new Point(15, 16), new Point(16, 16), new Point(17, 16), new Point(16, 17), new Point(17, 17) };
        private static readonly Point[] SuperInvalidOnWater = new Point[] { new Point(15, 15), new Point(16, 15), new Point(15, 16), new Point(16, 16), new Point(17, 16), new Point(16, 17), new Point(17, 17) };
        
        private int m_X;

        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }
        private int m_Y;

        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }
        private BuildingType m_Info;

        public BuildingType Info
        {
            get { return m_Info; }
            set
            {
                if (m_X == 9 && m_Y == 9)
                    m_Info = BuildingType.None;
                else if (m_Info != value)
                {
                    BuildingType old = m_Info;
                    m_Info = value;
                    if (old == BuildingType.Farm || old == BuildingType.FarmOld)
                    {
                        foreach (LayoutEntry le in Neighbors)
                            if (le.Info == BuildingType.FarmLand)
                                le.Info = BuildingType.None;
                    }
                    if (m_Info == BuildingType.Farm || m_Info == BuildingType.FarmOld)
                    {
                        foreach (LayoutEntry le in Neighbors)
                            if (le.Info == BuildingType.None)
                                le.Info = BuildingType.FarmLand;
                    }
                    if( m_Info == BuildingType.None )
                        foreach (LayoutEntry le in Neighbors)
                            if (le.Info == BuildingType.Farm || le.Info == BuildingType.FarmOld)
                                m_Info = BuildingType.FarmLand;
                    Refresh(BuildingInfo.ByType[old].HelpingNeighbors || BuildingInfo.ByType[m_Info].HelpingNeighbors, old,m_Info);
                }
            }
        }
        private bool m_Water;

        public bool Water
        {
            get { return m_Water; }
            set { m_Water = value; }
        }
        private List<LayoutEntry> m_Neighbors = new List<LayoutEntry>();

        private Dictionary<ResourceType, int> m_Production = new Dictionary<ResourceType, int>();
        private Dictionary<BuildingType, int> m_Recruitment = new Dictionary<BuildingType, int>();
        private Dictionary<ResourceType, int> m_Storage = new Dictionary<ResourceType, int>();
        private int m_Hidden = 0;
        private int m_Carts = 0;
        private int m_Ships = 0;
        private int m_BuildingCount = 0;
        private int m_ConsSpeed = 0;
        private int m_ArmySize = 0;

        public int ArmySize
        {
            get { return m_ArmySize; }
            set { m_ArmySize = value; }
        }

        public int ConsSpeed
        {
            get { return m_ConsSpeed; }
            set { m_ConsSpeed = value; }
        }

        public int BuildingCount
        {
            get { return m_BuildingCount; }
            set { m_BuildingCount = value; }
        }

        public int Carts
        {
            get { return m_Carts; }
            set { m_Carts = value; }
        }

        public int Ships
        {
            get { return m_Ships; }
            set { m_Ships = value; }
        }

        public int Hidden
        {
            get { return m_Hidden; }
            set { m_Hidden = value; }
        }
        public LayoutEntry(int x, int y, BuildingType type)
        {
            Reset(BuildingType.None);
            m_X = x;
            m_Y = y;
            if (x == 9 && y == 9)
                m_Info = BuildingType.None;
            else
                m_Info = type;
        }
        public int Production(ResourceType res)
        {
            return m_Production[res];
        }
        public int Storage(ResourceType res)
        {
            return m_Storage[res];
        }
        public int Recruitment(BuildingType type)
        {
            return m_Recruitment[type];
        }
        public void AddNeighbor(LayoutEntry n)
        {
            if (n != null && (n.X != 9 || n.Y != 9))
                m_Neighbors.Add(n);
        }
        public LayoutEntry[] Neighbors
        {
            get
            {

                if (!m_Water)
                {
                    LayoutEntry[] resLand = new LayoutEntry[m_Neighbors.Count];
                    m_Neighbors.CopyTo(resLand);
                    return resLand;
                }
                List<LayoutEntry> resl = new List<LayoutEntry>();
                foreach (LayoutEntry le in m_Neighbors)
                {
                    bool ok = true;
                    foreach (Point p in InvalidOnWater)
                        ok = ok && (p.X != le.X || p.Y != le.Y);
                    if (ok)
                        resl.Add(le);
                }
                LayoutEntry[] res = new LayoutEntry[resl.Count];
                resl.CopyTo(res);
                return res;
            }
        }
        public LayoutEntry[] NeighborsWithWater
        {
            get
            {

                if (!m_Water)
                {
                    LayoutEntry[] resLand = new LayoutEntry[m_Neighbors.Count];
                    m_Neighbors.CopyTo(resLand);
                    return resLand;
                }
                List<LayoutEntry> resl = new List<LayoutEntry>();
                foreach (LayoutEntry le in m_Neighbors)
                {
                    bool ok = true;
                    foreach (Point p in SuperInvalidOnWater)
                        ok = ok && (p.X != le.X || p.Y != le.Y);
                    if (ok)
                        resl.Add(le);
                }
                LayoutEntry[] res = new LayoutEntry[resl.Count];
                resl.CopyTo(res);
                return res;
            }
        }
        public void Reset(BuildingType b)
        {
            m_Production.Clear();
            m_Production.Add(ResourceType.None, 0);
            m_Production.Add(ResourceType.Gold, 0);
            m_Production.Add(ResourceType.Wood, 0);
            m_Production.Add(ResourceType.Stone, 0);
            m_Production.Add(ResourceType.Iron, 0);
            m_Production.Add(ResourceType.Food, 0);
            m_Storage.Clear();
            m_Storage.Add(ResourceType.None, 0);
            m_Storage.Add(ResourceType.Gold, 0);
            m_Storage.Add(ResourceType.Wood, 0);
            m_Storage.Add(ResourceType.Stone, 0);
            m_Storage.Add(ResourceType.Iron, 0);
            m_Storage.Add(ResourceType.Food, 0);
            m_Recruitment.Clear();
            m_Recruitment.Add(BuildingType.CityGuardHouse, 0);
            m_Recruitment.Add(BuildingType.TrainingGround, 0);
            m_Recruitment.Add(BuildingType.Stable, 0);
            m_Recruitment.Add(BuildingType.MoonglowTower, 0);
            m_Recruitment.Add(BuildingType.TrinsicTemple, 0);
            m_Recruitment.Add(BuildingType.Workshop, 0);
            m_Recruitment.Add(BuildingType.Shipyard, 0);
            m_Hidden = 0;
            m_Carts = 0;
            m_Ships = 0;
            m_BuildingCount = 0;
            m_ConsSpeed = 0;
            m_ArmySize = 0;

            if (BuildingInfo.ByType[b].ResourceProduced != ResourceType.None)
                RefreshResourceProduction(BuildingInfo.ByType[b].ResourceProduced);

            if (b == BuildingType.Warehouse)
                RefreshResourceStorage();

            if (b == BuildingType.Hideout)
                RefreshResourceHidden();

            if (b == BuildingType.Marketplace || b == BuildingType.Harbor)
                RefreshTransport();

            if (b == BuildingType.Cottage)
                RefreshConsSpeed();

            if (b == BuildingType.Barracks || b == BuildingType.Castle)
                RefreshArmySize();

            if (m_Recruitment.ContainsKey(b))
                RefreshRecruitmentSpeed(b);

            RefreshBuildingCount();
        }
        public void Refresh(bool alsoNeighbors)
        {
            Refresh(alsoNeighbors, m_Info, m_Info);
        }
        public void Refresh(bool alsoNeighbors, BuildingType oldb, BuildingType newb)
        {
            if (alsoNeighbors)
                foreach (LayoutEntry le in NeighborsWithWater)
                    le.Refresh(false);
            Reset(oldb);
            if (m_Info == BuildingType.Barracks)
            {
                m_ArmySize = 1000;
                RefreshArmySize();
            }
            else if (m_Info == BuildingType.Castle)
                RefreshArmySize();
            else if (m_Recruitment.ContainsKey(m_Info))
            {
                int numB = 0;
                if (m_Info != BuildingType.CityGuardHouse)
                {
                    foreach (LayoutEntry le in NeighborsWithWater)
                        if (le.m_Info == BuildingType.Barracks)
                            numB++;
                }
                int speed = 150 + (numB * 25);
                m_Recruitment[m_Info] = speed;
                RefreshRecruitmentSpeed(m_Info);
            }
            else if (m_Info == BuildingType.Cottage)
            {
                m_ConsSpeed = 100;
                RefreshConsSpeed();
            }
            else if (m_Info == BuildingType.Harbor)
            {
                m_Ships = 30;
                RefreshTransport();
            }
            else if (m_Info == BuildingType.Marketplace)
            {
                m_Carts = 200;
                RefreshTransport();
            }
            else if (m_Info == BuildingType.Hideout)
            {
                int numW = 0;
                foreach (LayoutEntry le in NeighborsWithWater)
                    if (le.m_Info == BuildingType.ResWood)
                        numW++;
                m_Hidden = 150 * (100 + numW * 25);
                RefreshResourceHidden();
            }
            else if (m_Info == BuildingType.Warehouse)
            {
                int numW = 0;
                int numS = 0;
                int numI = 0;
                int numF = 0;
                foreach (LayoutEntry le in NeighborsWithWater)
                    if (le.m_Info == BuildingType.Sawmill)
                        numW++;
                    else if (le.m_Info == BuildingType.Stonemasson)
                        numS++;
                    else if (le.m_Info == BuildingType.Foundry)
                        numI++;
                    else if (le.m_Info == BuildingType.Mill)
                        numF++;
                m_Storage[ResourceType.Wood] = 2000 * (100 + numW * 200);
                m_Storage[ResourceType.Stone] = 2000 * (100 + numS * 200);
                m_Storage[ResourceType.Iron] = 2000 * (100 + numI * 200);
                m_Storage[ResourceType.Food] = 2000 * (100 + numF * 200);
                RefreshResourceStorage();
            }
            else if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Gold)
            {
                int numH = 0;
                int numMP = 0;
                foreach (LayoutEntry le in NeighborsWithWater)
                    if (le.m_Info == BuildingType.Harbor)
                        numH++;
                    else if (le.m_Info == BuildingType.Marketplace)
                        numMP++;
                m_Production[ResourceType.Gold] = 400 + (80 * numMP) + (200 * numH);
                RefreshResourceProduction(ResourceType.Gold);
            }
            else if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Wood)
            {
                int numR = 0;
                int numC = 0;
                bool hasB = false;
                foreach (LayoutEntry le in NeighborsWithWater)
                    if (le.m_Info == BuildingType.ResWood)
                        numR++;
                    else if (le.m_Info == BuildingType.Cottage)
                        numC++;
                    else if (le.m_Info == BuildingType.Sawmill)
                        hasB = true;
                if (m_Info == BuildingType.Woodcutter)
                {
                    int basic = 300;
                    int resBonus = numR > 0 ? 110 + (40 * numR) : 100;
                    int step1 = basic * resBonus;
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = step1 * (100 + 30 * numC);
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    int step3 = hasB ? step2 * 175 : step2 * 100;
                    step3 = step3 % 100 != 0 ? step3 / 100 + 1 : step3 / 100;
                    m_Production[ResourceType.Wood] = step3;
                }
                else
                {
                    int basic = 300;
                    int step1 = basic * (100 + numR * 25 + numC * 50);
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = hasB ? step1 * 175 : step1 * 100;
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    m_Production[ResourceType.Wood] = step2;
                }
                RefreshResourceProduction(ResourceType.Wood);
            }
            else if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Stone)
            {
                int numR = 0;
                int numC = 0;
                bool hasB = false;
                foreach (LayoutEntry le in NeighborsWithWater)
                    if (le.m_Info == BuildingType.ResStone)
                        numR++;
                    else if (le.m_Info == BuildingType.Cottage)
                        numC++;
                    else if (le.m_Info == BuildingType.Stonemasson)
                        hasB = true;
                if (m_Info == BuildingType.Quarry)
                {
                    int basic = 300;
                    int resBonus = numR > 0 ? 110 + (40 * numR) : 100;
                    int step1 = basic * resBonus;
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = step1 * (100 + 30 * numC);
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    int step3 = hasB ? step2 * 175 : step2 * 100;
                    step3 = step3 % 100 != 0 ? step3 / 100 + 1 : step3 / 100;
                    m_Production[ResourceType.Stone] = step3;
                }
                else
                {
                    int basic = 300;
                    int step1 = basic * (100 + numR * 25 + numC * 50);
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = hasB ? step1 * 175 : step1 * 100;
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    m_Production[ResourceType.Stone] = step2;
                }
                RefreshResourceProduction(ResourceType.Stone);
            }
            else if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Iron)
            {
                int numR = 0;
                int numC = 0;
                bool hasB = false;
                foreach (LayoutEntry le in NeighborsWithWater)
                    if (le.m_Info == BuildingType.ResIron)
                        numR++;
                    else if (le.m_Info == BuildingType.Cottage)
                        numC++;
                    else if (le.m_Info == BuildingType.Foundry)
                        hasB = true;
                if (m_Info == BuildingType.IronMine)
                {
                    int basic = 300;
                    int resBonus = numR > 0 ? 110 + (40 * numR) : 100;
                    int step1 = basic * resBonus;
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = step1 * (100 + 30 * numC);
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    int step3 = hasB ? step2 * 175 : step2 * 100;
                    step3 = step3 % 100 != 0 ? step3 / 100 + 1 : step3 / 100;
                    m_Production[ResourceType.Iron] = step3;
                }
                else
                {
                    int basic = 300;
                    int step1 = basic * (100 + numR * 25 + numC * 50);
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = hasB ? step1 * 175 : step1 * 100;
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    m_Production[ResourceType.Iron] = step2;
                }
                RefreshResourceProduction(ResourceType.Iron);
            }
            else if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Food)
            {
                int numR = 0;
                int numC = 0;
                int numL = 0;
                bool hasB = false;
                foreach (LayoutEntry le in NeighborsWithWater)
                    if (le.m_Info == BuildingType.ResFood)
                        numR++;
                    else if (le.m_Info == BuildingType.Cottage)
                        numC++;
                    else if (le.m_Info == BuildingType.FarmLand)
                        numL++;
                    else if (le.m_Info == BuildingType.Mill)
                        hasB = true;
                if (m_Info == BuildingType.Farm)
                {
                    int basic = 300;
                    int resBonus = numL > 0 ? 110 + (40 * numL) : 100;
                    int step1 = basic * resBonus;
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = step1 * (100 + 30 * numC);
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    int step3 = step2 * (100 + 50 * numR);
                    step3 = step3 % 100 != 0 ? step3 / 100 + 1 : step3 / 100;
                    int step4 = hasB ? step3 * 175 : step3 * 100;
                    step4 = step4 % 100 != 0 ? step4 / 100 + 1 : step4 / 100;
                    m_Production[ResourceType.Food] = step4;
                }
                else
                {
                    int basic = 400;
                    int resBonus = 100 + (25 * numL) + (50 * numC);
                    int step1 = basic * resBonus;
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = step1 * (100 + 50 * numR);
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    int step3 = hasB ? step2 * 175 : step2 * 100;
                    step3 = step3 % 100 != 0 ? step3 / 100 + 1 : step3 / 100;
                    m_Production[ResourceType.Food] = step3;
                }
                RefreshResourceProduction(ResourceType.Food);
            }
            if (m_Info == BuildingType.None || m_Info == BuildingType.ResWood || m_Info == BuildingType.ResStone || m_Info == BuildingType.ResIron || m_Info == BuildingType.ResFood || m_Info == BuildingType.FarmLand)
                m_BuildingCount = 0;
            else
                m_BuildingCount = 1;
            RefreshBuildingCount();
        }
        public int Usefulness
        {
            get
            {
                switch (m_Info)
                {
                    case BuildingType.None: return -1;
                    case BuildingType.ResWood:  //Resource Wood (Trees)", 'A', '.', true, ResourceType.None, 901));
                    case BuildingType.ResStone:  //Resource Stone", 'B', ':', true, ResourceType.None, 900));
                    case BuildingType.ResIron:  //Resource Iron", 'C', ',', true, ResourceType.None, 902));
                    case BuildingType.ResFood:  //Resource Food (Lakes)", 'D', ';', true, ResourceType.None, 903));
                    case BuildingType.WoodcutterOld:  //Woodcutter's hut (old)", 'F', 'W', false,ResourceType.Wood, 401));
                    case BuildingType.QuarryOld:  //Quarry (old)", 'G', 'Q', false,ResourceType.Stone, 402));
                    case BuildingType.IronMineOld:  //Iron Mine (old)", 'H', 'I', false,ResourceType.Iron, 406));
                    case BuildingType.FarmOld:  //Farm (old)", 'I', 'F', false,ResourceType.Food, 403));
                    case BuildingType.Woodcutter:  //Woodcutter's hut", '2', '2', false,ResourceType.Wood, 447));
                    case BuildingType.Quarry:  //Quarry", '3', '3', false,ResourceType.Stone, 448));
                    case BuildingType.IronMine:  //Iron Mine", '4', '4', false,ResourceType.Iron, 449));
                    case BuildingType.Farm:  //Farm", '5', '1', false,ResourceType.Food, 450));
                    case BuildingType.Sawmill:  //Sawmill", 'K', 'L', true, ResourceType.None, 407));
                    case BuildingType.Stonemasson:  //Stonemasson", 'L', 'A', true, ResourceType.None, 410));
                    case BuildingType.Foundry:  //Foundry", 'M', 'D', true, ResourceType.None, 411));
                    case BuildingType.Mill:  //Mill", 'N', 'M', true, ResourceType.None, 408));
                    case BuildingType.Warehouse:  //Warehouse", 'Z', 'S', false, ResourceType.None, 420));
                    case BuildingType.Cottage:  //Cottage", 'O', 'C', true, ResourceType.None, 404));
                    case BuildingType.Hideout:  //Hideout", '1', 'H', false, ResourceType.None, 409));
                    case BuildingType.Marketplace:  //Marketplace", 'J', 'P', true, ResourceType.None, 405));
                    case BuildingType.Townhouse:  //Townhouse", 'E', 'U', false, ResourceType.Gold, 413));
                    case BuildingType.Barracks:  //Barracks", 'P', 'B', true, ResourceType.None, 414));
                    case BuildingType.CityGuardHouse: return 150;
                    case BuildingType.TrainingGround:  //Training Ground", 'Q', 'G', false, ResourceType.None, 416));
                    case BuildingType.Stable:  //Stable", 'U', 'E', false, ResourceType.None, 417));
                    case BuildingType.MoonglowTower:  //Moonglow Tower", 'R', 'J', false, ResourceType.None, 436));
                    case BuildingType.TrinsicTemple:  //Trinsic Temple", 'W', 'Z', false, ResourceType.None, 437));
                    case BuildingType.Workshop:  //Workshop", 'V', 'Y', false, ResourceType.None,418));
                    case BuildingType.Harbor:  //Harbor", 'T', 'R', true, ResourceType.None,422));
                    case BuildingType.Shipyard:  //Shipyard", 'Y', 'V', false, ResourceType.None,419));
                    case BuildingType.Castle: return int.MaxValue;
                    case BuildingType.FarmLand: return -1;
                }
                return 0;
            }
        }
    }
}
