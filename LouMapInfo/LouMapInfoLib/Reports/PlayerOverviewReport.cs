using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports
{
    public class PlayerOverviewReport : ReportInfo
    {
        public PlayerOverviewReport(ContinentInfo cont, CityCastleType type)
        {
            title = "Shrines & Moongates on " + DisplayUtility.Cont(cont.ID);

            List<CityInfo> lawless = new List<CityInfo>();
            foreach (AllianceInfo a in cont.AlliancesOldWay.Values)
                if (a.PlayersOldWay.ContainsKey(PlayerInfo.LAWLESS))
                {
                    switch (type)
                    {
                        case CityCastleType.Both: lawless.AddRange(a.PlayersOldWay[PlayerInfo.LAWLESS].AllCities); break;
                        case CityCastleType.Castle: lawless.AddRange(a.PlayersOldWay[PlayerInfo.LAWLESS].CastlesOnly); break;
                        case CityCastleType.City: lawless.AddRange(a.PlayersOldWay[PlayerInfo.LAWLESS].CitiesOnly); break;
                    }
                }
            List<CityInfo> lawlessCity = new List<CityInfo>();
            List<CityInfo> lawlessCastles = new List<CityInfo>();
            foreach (CityInfo c in lawless)
            {
                if (c.Castle)
                    lawlessCastles.Add(c);
                else
                    lawlessCity.Add(c);
            }

            ReportItem r = new ReportItem(cont.Shrines.Count + " Shrines", false);

            foreach (Pt p in cont.Shrines)
            {
                ReportItem r2 = new ReportItem(p.ToString(), true);
                foreach (AllianceInfo ai in cont.AlliancesOldWay.Values)
                    foreach (PlayerInfo pi in ai.PlayersOldWay.Values)
                        foreach (CityInfo ci in pi.Neighbours(p.X, p.Y, 3))
                            if (type == CityCastleType.Both || (ci.Castle && type == CityCastleType.Castle) || (!ci.Castle && type == CityCastleType.City))
                                r2.Items.Add(new ReportItem(String.Format("{0}[city]{1}[/city] [name]{2}[/name] ({3}), [player]{4}[/player], [alliance]{5}[/alliance]", (ci.Castle ? "[*] " : ""), ci.Location, ci.Name, DisplayUtility.Score(ci.Score), pi.Name, ai.Name), true));
                if (r2.Items.Count == 0)
                    switch (type)
                    {
                        case CityCastleType.Castle: r2.Items.Add(new ReportItem("No castled cities", true)); break;
                        case CityCastleType.City: r2.Items.Add(new ReportItem("No non-castled cities", true)); break;
                        default: r2.Items.Add(new ReportItem("No city", true)); break;
                    }
                r.Items.Add(r2);
            }
            root.Add(r);

            r = new ReportItem(cont.MoonGates.Count + " Moongates", false);
            foreach (Pt p in cont.MoonGates)
            {
                ReportItem r2 = new ReportItem(p.ToString(), true);
                foreach (AllianceInfo ai in cont.AlliancesOldWay.Values)
                    foreach (PlayerInfo pi in ai.PlayersOldWay.Values)
                        foreach (CityInfo ci in pi.Neighbours(p.X, p.Y, 3))
                            if (type == CityCastleType.Both || (ci.Castle && type == CityCastleType.Castle) || (!ci.Castle && type == CityCastleType.City))
                                r2.Items.Add(new ReportItem(String.Format("{0}[city]{1}[/city] [name]{2}[/name] ({3}), [player]{4}[/player], [alliance]{5}[/alliance]", (ci.Castle ? "[*] " : ""), ci.Location, ci.Name, DisplayUtility.Score(ci.Score), pi.Name, ai.Name), true));
                if( r2.Items.Count == 0 )
                    switch (type)
                    {
                        case CityCastleType.Castle: r2.Items.Add(new ReportItem("No castled cities", true)); break;
                        case CityCastleType.City: r2.Items.Add(new ReportItem("No non-castled cities", true)); break;
                        default: r2.Items.Add(new ReportItem("No city", true)); break;
                    }
                r.Items.Add(r2);
            }
            root.Add(r);
        }

        protected override int depth
        {
            get { return 2; }
        }
    }
}
