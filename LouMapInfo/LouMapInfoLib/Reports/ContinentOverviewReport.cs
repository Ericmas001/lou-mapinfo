using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports
{
    public class ContinentOverviewReport : ReportInfo
    {
        private ContinentInfo cont;
        public override void generateReport()
        {
            CityCastleType type = m_Type;
            title = DisplayUtility.Cont(cont.ID) + " Overview";

            if (type == CityCastleType.Castle)
                subtitle = "Castled Cities only";
            else if (type == CityCastleType.City)
                subtitle = "Non-Castled Cities only";

            AllianceInfo[] alliances = new AllianceInfo[cont.AlliancesOldWay.Count];
            cont.AlliancesOldWay.Values.CopyTo(alliances, 0);
            Array.Sort(alliances);
            Array.Reverse(alliances);
            for (int i = 0; i < alliances.Length; ++i)
            {
                Dictionary<PlayerInfo, KeyValuePair<List<CityInfo>, List<CityInfo>>> players = new Dictionary<PlayerInfo, KeyValuePair<List<CityInfo>, List<CityInfo>>>();
                foreach (PlayerInfo p in alliances[i].PlayersOldWay.Values)
                {
                    List<CityInfo> infos = new List<CityInfo>();
                    switch (type)
                    {
                        case CityCastleType.Both: infos.AddRange(p.AllCities); break;
                        case CityCastleType.Castle: infos.AddRange(p.CastlesOnly); break;
                        case CityCastleType.City: infos.AddRange(p.CitiesOnly); break;
                    }

                    foreach (CityInfo c in infos)
                    {
                        if (!players.ContainsKey(p))
                            players.Add(p, new KeyValuePair<List<CityInfo>, List<CityInfo>>(new List<CityInfo>(), new List<CityInfo>()));
                        if (c.Castle)
                            players[p].Value.Add(c);
                        else
                            players[p].Key.Add(c);
                    }
                }
                string s = "";
                if (alliances[i].Name == AllianceInfo.NO_ALLIANCE)
                    s += alliances[i];
                else
                    s += String.Format("#{0:00} ", (i + 1)) + ": [alliance]" + alliances[i].Name + "[/alliance] (" + DisplayUtility.Score(alliances[i].Score) + ")";

                string s2 = "";
                if (type == CityCastleType.City)
                    s2 = players.Count + " players with non-castled cities";
                else if (type == CityCastleType.Castle)
                    s2 = players.Count + " players with castled cities";
                else
                    s2 = players.Count + " players";

                s += "\n" + s2;

                ReportItem r = new ReportItem(s, false);
                PlayerInfo[] ps = new PlayerInfo[players.Count];
                players.Keys.CopyTo(ps, 0);
                Array.Sort(ps);
                Array.Reverse(ps);
                foreach (PlayerInfo p in ps)
                {
                    ReportItem r2 = new ReportItem("[player]" + p.Name + "[/player] (" + DisplayUtility.Score(p.Score) + ")", false);

                    if (type == CityCastleType.Both || type == CityCastleType.City)
                    {
                        ReportItem r3 = new ReportItem(players[p].Key.Count + " Cities", false);
                        CityInfo[] cities = new CityInfo[players[p].Key.Count];
                        players[p].Key.CopyTo(cities, 0);
                        Array.Sort(cities);
                        Array.Reverse(cities);
                        foreach (CityInfo c in cities)
                            r3.Items.Add(new ReportItem(String.Format("[city]{0}[/city] [name]{1}[/name] ({2})", c.Location, c.Name, DisplayUtility.Score(c.Score)), true));
                        r2.Items.Add(r3);
                    }

                    if (type == CityCastleType.Both || type == CityCastleType.Castle)
                    {
                        ReportItem r3 = new ReportItem(players[p].Value.Count + " Castles", false);
                        CityInfo[] cities = new CityInfo[players[p].Value.Count];
                        players[p].Value.CopyTo(cities, 0);
                        Array.Sort(cities);
                        Array.Reverse(cities);
                        foreach (CityInfo c in cities)
                            r3.Items.Add(new ReportItem(String.Format("[city]{0}[/city] [name]{1}[/name] ({2})", c.Location, c.Name, DisplayUtility.Score(c.Score)), true));
                        r2.Items.Add(r3);

                        r.Items.Add(r2);
                    }
                }
                root.Add(r);
            }
        }
        public ContinentOverviewReport(ContinentInfo c, CityCastleType type)
            : base(type)
        {
            this.cont = c;
            generateReport();
        }

        protected override int depth
        {
            get { return 2; }
        }
    }
}
