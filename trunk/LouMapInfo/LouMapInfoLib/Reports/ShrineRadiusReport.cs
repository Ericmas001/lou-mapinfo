using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo;


namespace LouMapInfo.Reports
{
    public class ShrineRadiusReport : ReportInfo
    {
        private WorldInfo world;
        private Pt location;
        public ShrineRadiusReport(WorldInfo w, Pt l)
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

        protected override void OnLoad()
        {
            title = new TextReportItem(false, "Cities surrounding" + location);
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            ContinentInfo cont = world.Continent(location.Continent);
            Dictionary<int, Dictionary<CityInfo,double>> cities = new Dictionary<int, Dictionary<CityInfo,double>>();
            Dictionary<CityInfo, double> alls = new Dictionary<CityInfo, double>();
            Filters fs = new Filters();
            foreach (FilterType f in m_Filters.Keys)
            {
                if (hasFilter(f) && FilterEnabled(f))
                    fs.AllFilters.Add(f);
            }
            for (int i = 1; i <= 20; ++i)
            {
                cities.Add(i, new Dictionary<CityInfo,double>());
            }
            foreach (AllianceInfo a in cont.Alliances)
            {
                if (a.Name != "" || FilterEnabled(FilterType.NoAlliance))
                {
                    foreach (PlayerInfo p in a.Players())
                    {
                        foreach (CityInfo c in p.Cities(fs, cont.Id))
                        {
                            double d = Math.Sqrt(Math.Pow(c.Location.X - location.X, 2.0) + Math.Pow(c.Location.Y - location.Y, 2.0));
                            //int d = Math.Abs() + Math.Abs(c.Location.Y - location.Y);
                            int dist = (int)(0.9999999 + d);
                            if (dist > 0 && dist <= 20)
                            {
                                if (c.TypeCity == CityType.Palace)
                                    c.LoadIfNeeded();
                                cities[dist].Add(c, c.Score / (d + 2));
                                alls.Add(c, c.Score / (d + 2));
                            }
                        }
                    }
                }
            }
            foreach (int d in cities.Keys)
            {
                if (cities[d].Count > 0)
                {
                    ReportItem r = new TextReportItem(false, d + " tiles distance");
                    CityInfo[] all = new CityInfo[cities[d].Count];
                    cities[d].Keys.CopyTo(all,0);
                    Array.Sort(all);
                    Array.Reverse(all);
                    foreach (CityInfo c in all)
                        r.Items.Add(new MultiLineReportItem(true,
                            new DetailedCityInfoReportItem(true, c, true, true, false),
                            new EnlightmentScoreReportItem(true, c.TypeCity, c.Bordering, c.VirtueType, (int)cities[d][c])
                            ));
                    root.Add(r);
                }
            }
            if (alls.Count > 0)
            {
                ReportItem r = new TextReportItem(false,"All <= 20 distance");
                CityInfo[] all = new CityInfo[alls.Count];
                alls.Keys.CopyTo(all, 0);
                Array.Sort(all);
                Array.Reverse(all);
                foreach (CityInfo c in all)
                    r.Items.Add(new MultiLineReportItem(true,
                        new DetailedCityInfoReportItem(true, c, true, true, false),
                        new EnlightmentScoreReportItem(true, c.TypeCity, c.Bordering, c.VirtueType, (int)alls[c])
                        ));
                root.Add(r);
            }
        }
    }
}
