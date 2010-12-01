using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports
{
    public class LawlessReport : ReportInfo
    {
        private ContinentInfo cont;
        public override void generateReport()
        {
            CityCastleType type = m_Type;
            title = "Lawless cities on " + DisplayUtility.Cont(cont.ID);

            if (type == CityCastleType.Castle)
                subtitle = "Castled Cities only";
            else if (type == CityCastleType.City)
                subtitle = "Non-Castled Cities only";

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

            ReportItem r = new ReportItem(lawlessCity.Count + " Cities", false);
            CityInfo[] cities = new CityInfo[lawlessCity.Count];
            lawlessCity.CopyTo(cities, 0);
            Array.Sort(cities);
            Array.Reverse(cities);
            foreach (CityInfo c in cities)
                r.Items.Add(new ReportItem(String.Format("[city]{0}[/city] [name]{1}[/name] ({2})", c.Location, c.Name, DisplayUtility.Score(c.Score)), true));
            root.Add(r);

            r = new ReportItem(lawlessCastles.Count + " Castles", false);
            cities = new CityInfo[lawlessCastles.Count];
            lawlessCastles.CopyTo(cities, 0);
            Array.Sort(cities);
            Array.Reverse(cities);
            foreach (CityInfo c in cities)
                r.Items.Add(new ReportItem(String.Format("[city]{0}[/city] [name]{1}[/name] ({2})", c.Location, c.Name, DisplayUtility.Score(c.Score)), true));
            root.Add(r);
        }
        public LawlessReport(ContinentInfo c, CityCastleType type)
            : base(type)
        {
            this.cont = c;
            generateReport();
        }

        protected override int depth
        {
            get { return 1; }
        }
    }
}
