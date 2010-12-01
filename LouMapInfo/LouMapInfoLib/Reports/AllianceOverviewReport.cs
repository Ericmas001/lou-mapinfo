using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.Entities;

namespace LouMapInfo.Reports
{
    public class AllianceOverviewReport : ReportInfo
    {
        private String alliance;
        private WorldInfo world;
        public AllianceOverviewReport(WorldInfo w, String name, CityCastleType type)
            : base(type)
        {
            this.alliance = name;
            this.world = w;
            generateReport();
        }

        protected override int depth
        {
            get { return 3; }
        }
        public override void generateReport()
        {
            AllianceReportRoot info = getAlliance();

            CityCastleType type = m_Type;
            title = new AllianceInfoReportItem(new AllianceInfo(-1, info.AName, info.AScore, null),-1,true);
            if (type == CityCastleType.Castle)
                subtitle = new TextReportItem("Castled Cities only", true);
            else if (type == CityCastleType.City)
                subtitle = new TextReportItem("Non-Castled Cities only", true);

            foreach (int ic in info.Continents.Keys)
            {
                AllianceReportEntry a = info.Continents[ic];
                ReportItem r = new MultiLineReportItem(false,
                    new ContinentScoreReportItem(ic,a.AScore,false,false),
                    new PlayerCountReportItem(a.Players.Count,CityCastleType.Both,false));

                foreach (PlayerReportEntry e in a.Players)
                {
                    ReportItem r2 = new PlayerInfoReportItem(new PlayerInfo(-1, e.PName, e.PScore, null), false);

                    if (type == CityCastleType.Both || type == CityCastleType.City)
                    {
                        ReportItem r3 = new CityTypeReportItem(e.Cities.Count, CityCastleType.City, true);
                        CityInfo[] cities = new CityInfo[e.Cities.Count];
                        e.Cities.CopyTo(cities, 0);
                        Array.Sort(cities);
                        Array.Reverse(cities);
                        foreach (CityInfo c in cities)
                            r3.Items.Add(new CityInfoReportItem(c, true));
                        r2.Items.Add(r3);
                    }

                    if (type == CityCastleType.Both || type == CityCastleType.Castle)
                    {
                        ReportItem r3 = new CityTypeReportItem(e.Castles.Count, CityCastleType.Castle, true);
                        CityInfo[] cities = new CityInfo[e.Castles.Count];
                        e.Castles.CopyTo(cities, 0);
                        Array.Sort(cities);
                        Array.Reverse(cities);
                        foreach (CityInfo c in cities)
                            r3.Items.Add(new CityInfoReportItem(c, true));
                        r2.Items.Add(r3);
                    }

                    r.Items.Add(r2);
                }


                root.Add(r);
            }
        }

        private AllianceReportRoot getAlliance()
        {
            AllianceReportRoot res = new AllianceReportRoot();

            res.AName = alliance;
            res.AScore = 0;

            foreach (ContinentInfo c in world.Continents)
                if (c.Loaded)
                {
                    if (c.AlliancesOldWay.ContainsKey(res.AName))
                    {
                        AllianceInfo a = c.AlliancesOldWay[res.AName];
                        res.AScore += a.Score;
                        AllianceReportEntry ae = new AllianceReportEntry();
                        ae.AScore = a.Score;
                        res.Continents.Add(c.ID, ae);
                        foreach (PlayerInfo p in a.PlayersOldWay.Values)
                        {
                            PlayerReportEntry e = new PlayerReportEntry();
                            e.AName = a.Name;
                            e.AScore = a.Score;
                            e.PName = p.Name;
                            e.PScore = p.Score;
                            ae.Players.Add(e);
                            foreach (CityInfo ci in p.AllCities)
                            {
                                if (ci.Castle && (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle))
                                    e.Castles.Add(ci);
                                if (!ci.Castle && (m_Type == CityCastleType.Both || m_Type == CityCastleType.City))
                                    e.Cities.Add(ci);
                            }
                        }
                    }
                }
            return res;
        }
    }
}
