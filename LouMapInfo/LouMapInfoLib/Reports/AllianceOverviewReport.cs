using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo.Entities.Filter;

namespace LouMapInfo.Reports
{
    public class AllianceOverviewReport : ReportInfo
    {
        private AllianceInfo alliance;
        public AllianceOverviewReport(AllianceInfo a)
            : base()
        {
            this.alliance = a;
            m_Filters.Add(FilterType.BorderingLand, true);
            m_Filters.Add(FilterType.BorderingWater, true);
            m_Filters.Add(FilterType.NoCities, true);
            m_Filters.Add(FilterType.TypeCastle, true);
            m_Filters.Add(FilterType.TypeCity, true);
            m_Filters.Add(FilterType.TypePalace, true);
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 3; }
        }

        protected override void OnLoad()
        {
            title = new AllianceInfoReportItem(alliance, true);
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            foreach (PlayerInfo p in alliance.Players())
            {
                p.LoadIfNeeded();
            }
            foreach (int ic in alliance.ActiveContinents)
            {
                int supercount = 0;
                PlayerInfo[] pjs = alliance.Players(ic);
                PlayerCountReportItem pcri = new PlayerCountReportItem(pjs.Length, false);
                ReportItem r = new MultiLineReportItem(false,
                    new ContinentScoreReportItem(ic, alliance.CScore(ic), false, false),
                    pcri);
                foreach (PlayerInfo p in pjs)
                {
                    ReportItem r2 = new PlayerInfoReportItem(p, ic, false);
                    int count = 0;

                    count += ShowCities(r2, CityType.Palace, ic, p);
                    count += ShowCities(r2, CityType.Castle, ic, p);
                    count += ShowCities(r2, CityType.City, ic, p);
                    if (FilterEnabled(FilterType.NoCities) || count > 0)
                    {
                        supercount++;
                        r.Items.Add(r2);
                    }
                }
                pcri.Count = supercount;
                if (FilterEnabled(FilterType.NoCities) || supercount > 0)
                    root.Add(r);
            }
        }
    }
}
