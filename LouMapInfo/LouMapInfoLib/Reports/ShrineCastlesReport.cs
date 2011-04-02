using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo;
using LouMapInfo.Entities.Filter;

namespace LouMapInfo.Reports
{
    public class ShrineCastlesReport : ReportInfo
    {
        private WorldInfo world;
        private Pt location;
        public ShrineCastlesReport(WorldInfo w, Pt l)
            : base()
        {
            this.world = w;
            this.location = l;
            m_Filters.Add(FilterType.BorderingLand, true);
            m_Filters.Add(FilterType.BorderingWater, true);
            m_Filters.Add(FilterType.NoAlliance, true);
            m_Filters.Add(FilterType.TypeCastle, true);
            m_Filters.Add(FilterType.TypePalace, true);
            m_Filters.Add(FilterType.TypeCity, true);
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            title = new TextReportItem("Cities surrounding" + location, true);
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            ContinentInfo cont = world.Continent(location.Continent);
            Dictionary<int, List<CityInfo>> cities = new Dictionary<int, List<CityInfo>>();
            List<CityInfo> alls = new List<CityInfo>();
            for (int i = 1; i <= 20; ++i)
            {
                cities.Add(i, new List<CityInfo>());
            }
            foreach (AllianceInfo a in cont.Alliances)
            {
                foreach (PlayerInfo p in a.Players())
                {
                    foreach (CityInfo c in p.Cities(cont.Id, FilterType.TypePalace, FilterType.TypeCastle, FilterType.BorderingLand, FilterType.BorderingWater))
                    {
                        double d = Math.Sqrt(Math.Pow(c.Location.X - location.X, 2.0) + Math.Pow(c.Location.Y - location.Y, 2.0));
                        //int d = Math.Abs() + Math.Abs(c.Location.Y - location.Y);
                        int dist = (int)(0.9999999 + d);
                        if (dist <= 20)
                        {
                            cities[dist].Add(c);
                            alls.Add(c);
                        }
                    }
                }
            }
            foreach (int d in cities.Keys)
            {
                if (cities[d].Count > 0)
                {
                    ReportItem r = new TextReportItem(d + " tiles distance", true);
                    CityInfo[] all = new CityInfo[cities[d].Count];
                    cities[d].CopyTo(all, 0);
                    Array.Sort(all);
                    Array.Reverse(all);
                    foreach (CityInfo c in all)
                        r.Items.Add(new DetailedCityInfoReportItem(c, true, true, true, false));
                    root.Add(r);
                }
            }
            if (alls.Count > 0)
            {
                ReportItem r = new TextReportItem("All <= 20 distance", true);
                CityInfo[] all = new CityInfo[alls.Count];
                alls.CopyTo(all, 0);
                Array.Sort(all);
                Array.Reverse(all);
                foreach (CityInfo c in all)
                    r.Items.Add(new DetailedCityInfoReportItem(c, true, true, true, false));
                root.Add(r);
            }
        }
    }
}
