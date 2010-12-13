using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.Entities;

namespace LouMapInfo.Reports
{
    public class PlayerOverviewReport : ReportInfo
    {
        private String player;
        private WorldInfo world;
        public PlayerOverviewReport(WorldInfo w, String playerName, CityCastleType type)
            : base(type)
        {
            this.player = playerName;
            this.world = w;
            generateReport();
        }

        protected override int depth
        {
            get { return 3; }
        }
        public override void generateReport()
        {
            PlayerReportRoot info = getPlayer();

            CityCastleType type = m_Type;
            title = new PlayerInfoReportItem(new PlayerInfo(-1, info.PName, info.PScore, null), true);
            AllianceInfoReportItem allianceT = new AllianceInfoReportItem(new AllianceInfo(-1, info.AName, info.AScore, null),-1,true);
            if (type == CityCastleType.Castle)
                subtitle = new MultiLineReportItem(true,
                    allianceT,
                    new TextReportItem("Castled Cities only", true));
            else if (type == CityCastleType.City)
                subtitle = new MultiLineReportItem(true,
                    allianceT,
                    new TextReportItem("Non-Castled Cities only", true));
            else
                subtitle = allianceT;
            foreach (int ic in info.Continents.Keys)
            {
                PlayerReportEntry e = info.Continents[ic];
                ReportItem r = new ContinentScoreReportItem(ic, e.PScore, true, false);


                if (type == CityCastleType.Both || type == CityCastleType.City)
                {
                    ReportItem r3 = new CityTypeReportItem(e.Cities.Count, CityCastleType.City, true);
                    CityInfo[] cities = new CityInfo[e.Cities.Count];
                    e.Cities.CopyTo(cities, 0);
                    Array.Sort(cities);
                    Array.Reverse(cities);
                    foreach (CityInfo c in cities)
                        r3.Items.Add(new CityInfoReportItem(c, true));
                    r.Items.Add(r3);
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
                    r.Items.Add(r3);
                }
                root.Add(r);
            }
        }

        private PlayerReportRoot getPlayer()
        {
            PlayerReportRoot res = new PlayerReportRoot();
            res.AName = null;
            res.AScore = 0;
            res.PName = player;
            res.PScore = 0;
            foreach (ContinentInfo c in world.Continents)
                if (c.Loaded)
                {
                    if (res.AName != null && c.AlliancesOldWay.ContainsKey(res.AName))
                    {
                        AllianceInfo a = c.AlliancesOldWay[res.AName];
                        res.AScore += a.Score;
                        if (a.PlayersOldWay.ContainsKey(player))
                        {
                            PlayerInfo p = a.PlayersOldWay[player];
                            PlayerReportEntry e = new PlayerReportEntry();
                            e.AName = a.Name;
                            e.AScore = a.Score;
                            e.PName = player;
                            e.PScore = p.Score;
                            res.Continents.Add(c.ID, e);
                            res.PScore += p.Score;
                            foreach (CityInfo ci in p.AllCities)
                            {
                                if (ci.Castle && (Type == CityCastleType.Both || Type == CityCastleType.Castle))
                                    e.Castles.Add(ci);
                                if (!ci.Castle && (Type == CityCastleType.Both || Type == CityCastleType.City))
                                    e.Cities.Add(ci);
                            }
                        }
                    }
                    else if (res.AName == null)
                    {
                        foreach (AllianceInfo a in c.AlliancesOldWay.Values)
                        {
                            if (res.AName == null || a.Name == res.AName)
                            {
                                if (a.PlayersOldWay.ContainsKey(player))
                                {
                                    res.AName = a.Name;
                                    res.AScore += a.Score;
                                    PlayerInfo p = a.PlayersOldWay[player];
                                    PlayerReportEntry e = new PlayerReportEntry();
                                    e.AName = a.Name;
                                    e.AScore = a.Score;
                                    e.PName = player;
                                    e.PScore = p.Score;
                                    res.Continents.Add(c.ID, e);
                                    res.PScore += p.Score;
                                    foreach (CityInfo ci in p.AllCities)
                                    {
                                        if (ci.Castle && (Type == CityCastleType.Both || Type == CityCastleType.Castle))
                                            e.Castles.Add(ci);
                                        if (!ci.Castle && (Type == CityCastleType.Both || Type == CityCastleType.City))
                                            e.Cities.Add(ci);
                                    }
                                }
                            }
                        }
                    }
                }
            return res;
        }
    }
}
