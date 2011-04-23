using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo;


namespace LouMapInfo.Reports
{
    public class BattlePalaceReport : ReportInfo
    {
        private WorldInfo world;
        private BattleType type;
        public BattlePalaceReport(WorldInfo w, BattleType b)
            : base()
        {
            this.world = w;
            this.type = b;
            m_Filters.Add(FilterType.BorderingLand, true);
            m_Filters.Add(FilterType.BorderingWater, true);

            m_Grouping.Add(GroupingType.VirtueType, true);

            m_LockedGroups = 1;
            LoadIfNeeded();
        }


        class PalaceComp : IComparer<CityInfo>
        {
            public PalaceComp()
            {
            }
            #region IComparer<LoUPlayerInfo> Members

            public int Compare(CityInfo x, CityInfo y)
            {
                int xScore = (x.PalaceLvl * 1000000) + x.Score;
                int yScore = (y.PalaceLvl * 1000000) + y.Score;
                return xScore.CompareTo(yScore);
            }

            #endregion
        }
        protected override void OnLoad()
        {
            bool el = FilterEnabled(FilterType.BorderingLand);
            bool ew = FilterEnabled(FilterType.BorderingWater);
            switch (type)
            {
                case BattleType.HighestLevel: title = new TextReportItem(false, "Highest Level Battle"); break;
                default: return;
            }
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            Dictionary<VirtueType, Dictionary<string, CityInfo>> palaces = new Dictionary<VirtueType, Dictionary<string, CityInfo>>();
            foreach (VirtueType v in Enum.GetValues(typeof(VirtueType)))
            {
                palaces.Add(v, new Dictionary<string, CityInfo>());
                string[] players = world.PalacesOwnersByVirtue(v);
                foreach (string p in players)
                {
                    PlayerInfo pl = world.Player(p);
                    pl.LoadIfNeeded();

                    CityInfo[] cities;
                    if( !el)
                        cities =pl.Cities(FilterType.TypePalace, FilterType.BorderingWater);
                    else if (!ew)
                        cities = pl.Cities(FilterType.TypePalace, FilterType.BorderingLand);
                    else
                        cities = pl.Cities(FilterType.TypePalace, FilterType.BorderingLand, FilterType.BorderingWater);

                    foreach (CityInfo city in cities)
                    {
                        city.LoadIfNeeded();
                        if (v == VirtueType.None || city.VirtueType == v)
                        {
                            if (!palaces[v].ContainsKey(pl.Alliance.Name))
                                palaces[v].Add(pl.Alliance.Name, city);
                            else if (city.PalaceLvl > palaces[v][pl.Alliance.Name].PalaceLvl || (city.PalaceLvl == palaces[v][pl.Alliance.Name].PalaceLvl && city.Score > palaces[v][pl.Alliance.Name].Score))
                                palaces[v][pl.Alliance.Name] = city;
                        }
                    }
                }
            }
            if (GroupingEnabled(GroupingType.VirtueType))
            {
                foreach (VirtueType v in Enum.GetValues(typeof(VirtueType)))
                {
                    if (v != VirtueType.None && palaces[v].Count > 0)
                    {
                        ReportItem r = new TextReportItem(false, v + " Palaces");

                        CityInfo[] cities = new CityInfo[palaces[v].Count];
                        int count = 0;
                        foreach (string a in palaces[v].Keys)
                            cities[count++] = palaces[v][a];
                        Array.Sort(cities, new PalaceComp());
                        Array.Reverse(cities);
                        int rank = 1;
                        foreach (CityInfo p in cities)
                        {
                            ReportItem r2 = new AllianceInfoReportItem(false, p.Player.Alliance, rank++);
                            r2.Items.Add(new DetailedPalaceInfoReportItem(true, p, true, false, true, true, false));
                            r.Items.Add(r2);
                        }
                        root.Add(r);
                    }
                }
            }
            else
            {
                if (palaces[VirtueType.None].Count > 0)
                {
                    //ReportItem r = new TextReportItem(false, v + " Palaces");

                    CityInfo[] cities = new CityInfo[palaces[VirtueType.None].Count];
                    int count = 0;
                    foreach (string a in palaces[VirtueType.None].Keys)
                        cities[count++] = palaces[VirtueType.None][a];
                    Array.Sort(cities, new PalaceComp());
                    Array.Reverse(cities);
                    int rank = 1;
                    foreach (CityInfo p in cities)
                    {
                        ReportItem r2 = new AllianceInfoReportItem(false, p.Player.Alliance, rank++);
                        r2.Items.Add(new DetailedPalaceInfoReportItem(true, p, true, false, true, true, false));
                        root.Add(r2);
                    }
                }
            }
        }
    }
}
