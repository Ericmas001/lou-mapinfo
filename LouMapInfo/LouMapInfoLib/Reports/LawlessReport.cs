using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;

namespace LouMapInfo.Reports
{
    public class LawlessReport : ReportInfo
    {
        private ContinentInfo cont;
        protected override void OnLoad()
        {
            CityCastleType type = m_Type;
            title = new TextReportItem("Lawless cities on " + DisplayUtility.Cont(cont.ID), true);

            if (type == CityCastleType.Castle)
                subtitle = new TextReportItem("Castled Cities only",true);
            else if (type == CityCastleType.City)
                subtitle = new TextReportItem("Non-Castled Cities only",true);

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

            ReportItem r = new CityTypeReportItem(lawlessCity.Count, CityCastleType.City, false);
            CityInfo[] cities = new CityInfo[lawlessCity.Count];
            lawlessCity.CopyTo(cities, 0);
            Array.Sort(cities);
            Array.Reverse(cities);
            foreach (CityInfo c in cities)
                r.Items.Add(new CityInfoReportItem(c, true));
            root.Add(r);

            r = new CityTypeReportItem(lawlessCastles.Count, CityCastleType.Castle, false);
            cities = new CityInfo[lawlessCastles.Count];
            lawlessCastles.CopyTo(cities, 0);
            Array.Sort(cities);
            Array.Reverse(cities);
            foreach (CityInfo c in cities)
                r.Items.Add(new CityInfoReportItem(c, true));
            root.Add(r);
        }
        public LawlessReport(ContinentInfo c, CityCastleType type)
            : base(type)
        {
            this.cont = c;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 1; }
        }
    }
}
