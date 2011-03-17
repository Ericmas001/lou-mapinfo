using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.OfficialLOU.Items;
using LouMapInfo.OfficialLOU;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUShrineCastlesReport : LoUReportInfo
    {
        private LoUWorldInfo world;
        private LoUPt location;
        public LoUShrineCastlesReport(LoUWorldInfo w, LoUPt l)
            : base(OldLoUCityType.CastlePalace)
        {
            this.world = w;
            this.location = l;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            title = new TextReportItem("Castles surrounding" + location, true);
            LoUContinentInfo cont = world.Continent(location.Continent);
            Dictionary<int, List<LoUCityInfo>> cities = new Dictionary<int, List<LoUCityInfo>>();
            List<LoUCityInfo> alls = new List<LoUCityInfo>();
            for (int i = 1; i <= 20; ++i)
            {
                cities.Add(i, new List<LoUCityInfo>());
            }
            foreach (LoUAllianceInfo a in cont.Alliances)
            {
                foreach (LoUPlayerInfo p in a.Players())
                {
                    foreach (LoUCityInfo c in p.Cities(OldLoUCityType.CastlePalace, cont.Id))
                    {
                        int d = Math.Abs(c.Location.X - location.X) + Math.Abs(c.Location.Y - location.Y);
                        if (d <= 20)
                        {
                            cities[d].Add(c);
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
