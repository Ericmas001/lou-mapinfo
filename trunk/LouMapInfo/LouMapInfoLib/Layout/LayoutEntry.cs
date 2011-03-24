using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Layout;
using System.Drawing;

namespace LouMapInfo.Layout
{
    public delegate void ResourceTypeHandler(ResourceType res);
    public class LayoutEntry
    {
        public event ResourceTypeHandler RefreshResourceProduction = delegate { };
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
            int val = 0;
            if (res == ResourceType.None)
                foreach (ResourceType t in m_Production.Keys)
                    val += m_Production[t];
            else
                val = m_Production[res];
            return val;
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
            m_Production.Add(ResourceType.Gold, 0);
            m_Production.Add(ResourceType.Wood, 0);
            m_Production.Add(ResourceType.Stone, 0);
            m_Production.Add(ResourceType.Iroon, 0);
            m_Production.Add(ResourceType.Food, 0);

            if (BuildingInfo.ByType[b].ResourceProduced != ResourceType.None)
                RefreshResourceProduction(BuildingInfo.ByType[b].ResourceProduced);
        }
        public void Refresh(bool alsoNeighbors)
        {
            Refresh(alsoNeighbors, m_Info, m_Info);
        }
        public void Refresh(bool alsoNeighbors, BuildingType oldb, BuildingType newb)
        {
            if (alsoNeighbors)
                foreach (LayoutEntry le in Neighbors)
                    le.Refresh(false);
            Reset(oldb);
            if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Gold)
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
            else if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Iroon)
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
                    m_Production[ResourceType.Iroon] = step3;
                }
                else
                {
                    int basic = 300;
                    int step1 = basic * (100 + numR * 25 + numC * 50);
                    step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                    int step2 = hasB ? step1 * 175 : step1 * 100;
                    step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                    m_Production[ResourceType.Iroon] = step2;
                }
                RefreshResourceProduction(ResourceType.Iroon);
            }
            else if (BuildingInfo.ByType[m_Info].ResourceProduced == ResourceType.Food)
            {
                /* int numR = 0;
                 int numC = 0;
                 bool hasB = false;
                 foreach (LayoutEntry le in NeighborsWithWater)
                     if (le.m_Info == BuildingType.ResFood)
                         numR++;
                     else if (le.m_Info == BuildingType.Cottage)
                         numC++;
                     else if (le.m_Info == BuildingType.Mill)
                         hasB = true;
                 if (m_Info == BuildingType.Farm)
                 {
                     int basic = 300;
                     int resBonus = numR > 0 ? 110 + (40 * numR) : 100;
                     int step1 = basic * resBonus;
                     step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                     int step2 = step1 * (100 + 30 * numC);
                     step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                     int step3 = hasB ? step2 * 175 : step2 * 100;
                     step3 = step3 % 100 != 0 ? step3 / 100 + 1 : step3 / 100;
                     m_Production[ResourceType.Food] = step3;
                 }
                 else
                 {
                     int basic = 300;
                     int step1 = basic * (100 + numR * 25 + numC * 50);
                     step1 = step1 % 100 != 0 ? step1 / 100 + 1 : step1 / 100;
                     int step2 = hasB ? step1 * 175 : step1 * 100;
                     step2 = step2 % 100 != 0 ? step2 / 100 + 1 : step2 / 100;
                     m_Production[ResourceType.Food] = step2;
                 }
                 RefreshResourceProduction(ResourceType.Food);*/
            }
        }
    }
}
