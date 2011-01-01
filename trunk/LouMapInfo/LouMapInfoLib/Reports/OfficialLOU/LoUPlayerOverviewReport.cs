using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.Entities;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Entities;
using LouMapInfo.Reports.OfficialLOU.Items;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUPlayerOverviewReport : LoUReportInfo
    {
        private LoUPlayerInfo player;
        public LoUPlayerOverviewReport(LoUPlayerInfo p, LoUCityType type)
            : base(type)
        {
            player = p;
            generateReport();
        }

        protected override int depth
        {
            get { return 3; }
        }
        public override void generateReport()
        {
            title = new LoUPlayerInfoReportItem(player, true);
            subtitle = new TextReportItem(LoUReportUtility.SayCityType(LoUType), true);

            foreach (int ic in player.ActiveContinents)
            {
                ReportItem r = new ContinentScoreReportItem(ic, player.CScore(ic), true, false);

                //First castles
                if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                {
                    LoUCityInfo[] cities = player.Cities(LoUCityType.CastlePalace, ic);
                    ReportItem r3 = new LoUCityTypeReportItem(cities.Length, LoUCityType.Castle, true);
                    Array.Sort(cities);
                    Array.Reverse(cities);
                    foreach (LoUCityInfo c in cities)
                        r3.Items.Add(new LoUCityInfoReportItem(c, true));
                    r.Items.Add(r3);
                }

                //Then non-castled cities
                if (m_Type == CityCastleType.Both || m_Type == CityCastleType.City)
                {
                    LoUCityInfo[] cities = player.Cities(LoUCityType.City, ic);
                    ReportItem r3 = new LoUCityTypeReportItem(cities.Length, LoUCityType.City, true);
                    Array.Sort(cities);
                    Array.Reverse(cities);
                    foreach (LoUCityInfo c in cities)
                        r3.Items.Add(new LoUCityInfoReportItem(c, true));
                    r.Items.Add(r3);
                }
                root.Add(r);

            }
        }
    }
}
