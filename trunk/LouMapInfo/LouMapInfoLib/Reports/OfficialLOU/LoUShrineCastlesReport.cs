using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.OfficialLOU.Items;
using LouMapInfo.OfficialLOU;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUShrineCastlesReport : ReportInfo
    {
        private LoUWorldInfo world;
        private LoUPt location;
        private bool includeNoAlliance;
        public LoUShrineCastlesReport(LoUWorldInfo w, LoUPt l, bool noAlliance)
            : base(LoUCityType.Castle, LoUCityType.Palace)
        {
            this.world = w;
            this.location = l;
            includeNoAlliance = noAlliance;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            title = new TextReportItem("Castles surrounding" + location, true);
            subtitle = new TextReportItem((includeNoAlliance ? "Including " : "Excluding ") + "players without an alliance",true);
            LoUContinentInfo cont = world.Continent(location.Continent);
            Dictionary<int, List<LoUCityInfo>> cities = new Dictionary<int, List<LoUCityInfo>>();
            List<LoUCityInfo> alls = new List<LoUCityInfo>();
            for (int i = 1; i <= 20; ++i)
            {
                cities.Add(i, new List<LoUCityInfo>());
            }
            foreach (LoUAllianceInfo a in cont.Alliances)
            {
                if (includeNoAlliance || a.Name != "")
                {
                    foreach (LoUPlayerInfo p in a.Players())
                    {
                        foreach (LoUCityInfo c in p.Cities(cont.Id, ReportFeatureType.TypePalace, ReportFeatureType.BorderingLand, ReportFeatureType.BorderingWater))
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
            }
            foreach (int d in cities.Keys)
            {
                if (cities[d].Count > 0)
                {
                    ReportItem r = new TextReportItem(d + " tiles distance", true);
                    LoUCityInfo[] all = new LoUCityInfo[cities[d].Count];
                    cities[d].CopyTo(all, 0);
                    Array.Sort(all);
                    Array.Reverse(all);
                    foreach (LoUCityInfo c in all)
                        r.Items.Add(new LoUDetailedCityInfoReportItem(c, true, true, true, false));
                    root.Add(r);
                }
            }
            if (alls.Count > 0)
            {
                ReportItem r = new TextReportItem("All <= 20 distance", true);
                LoUCityInfo[] all = new LoUCityInfo[alls.Count];
                alls.CopyTo(all, 0);
                Array.Sort(all);
                Array.Reverse(all);
                foreach (LoUCityInfo c in all)
                    r.Items.Add(new LoUDetailedCityInfoReportItem(c, true, true, true, false));
                root.Add(r);
            }
        }
    }
}
