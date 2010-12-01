using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;

namespace LouMapInfo.Reports
{
    public class ShrinesReport : ReportInfo
    {
        private ContinentInfo cont;
        public override void generateReport()
        {
            CityCastleType type = m_Type;
            title = new TextReportItem("Shrines & Moongates on " + DisplayUtility.Cont(cont.ID),true);

            if (type == CityCastleType.Castle)
                subtitle = new TextReportItem("Castled Cities only", true);
            else if (type == CityCastleType.City)
                subtitle = new TextReportItem("Non-Castled Cities only", true);

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

            TextReportItem r = new TextReportItem(cont.Shrines.Count + " Shrines", false);

            foreach (Pt p in cont.Shrines)
            {
                TextReportItem r2 = new TextReportItem(p.ToString(), true);
                foreach (AllianceInfo ai in cont.AlliancesOldWay.Values)
                    foreach (PlayerInfo pi in ai.PlayersOldWay.Values)
                        foreach (CityInfo ci in pi.Neighbours(p.X, p.Y, 3))
                            if (type == CityCastleType.Both || (ci.Castle && type == CityCastleType.Castle) || (!ci.Castle && type == CityCastleType.City))
                                r2.Items.Add(new CityInfoReportItem(ci, true));
                if (r2.Items.Count == 0)
                    switch (type)
                    {
                        case CityCastleType.Castle: r2.Items.Add(new TextReportItem("No castled cities", true)); break;
                        case CityCastleType.City: r2.Items.Add(new TextReportItem("No non-castled cities", true)); break;
                        default: r2.Items.Add(new TextReportItem("No city", true)); break;
                    }
                r.Items.Add(r2);
            }
            root.Add(r);

            r = new TextReportItem(cont.MoonGates.Count + " Moongates", false);
            foreach (Pt p in cont.MoonGates)
            {
                TextReportItem r2 = new TextReportItem(p.ToString(), true);
                foreach (AllianceInfo ai in cont.AlliancesOldWay.Values)
                    foreach (PlayerInfo pi in ai.PlayersOldWay.Values)
                        foreach (CityInfo ci in pi.Neighbours(p.X, p.Y, 3))
                            if (type == CityCastleType.Both || (ci.Castle && type == CityCastleType.Castle) || (!ci.Castle && type == CityCastleType.City))
                                r2.Items.Add(new CityInfoReportItem(ci, true));
                if (r2.Items.Count == 0)
                    switch (type)
                    {
                        case CityCastleType.Castle: r2.Items.Add(new TextReportItem("No castled cities", true)); break;
                        case CityCastleType.City: r2.Items.Add(new TextReportItem("No non-castled cities", true)); break;
                        default: r2.Items.Add(new TextReportItem("No city", true)); break;
                    }
                r.Items.Add(r2);
            }
            root.Add(r);
        }
        public ShrinesReport(ContinentInfo c, CityCastleType type)
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
