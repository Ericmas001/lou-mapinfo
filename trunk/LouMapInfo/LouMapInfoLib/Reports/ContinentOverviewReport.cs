using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo.Entities.Filter;

namespace LouMapInfo.Reports
{
    public class ContinentOverviewReport : ReportInfo
    {
        private ContinentInfo cont;
        public ContinentOverviewReport(ContinentInfo c)
            : base()
        {
            this.cont = c;
            m_Filters.Add(FilterType.BorderingLand, true);
            m_Filters.Add(FilterType.BorderingWater, true);
            m_Filters.Add(FilterType.NoCities, true);
            m_Filters.Add(FilterType.NoAlliance, true);
            m_Filters.Add(FilterType.TypeCastle, true);
            m_Filters.Add(FilterType.TypeCity, true);
            m_Filters.Add(FilterType.TypePalace, true);
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            title = new TextReportItem("C" + cont.Id.ToString("00") + " Overview", true);
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true,lines);

            for (int i = 0; i < cont.Alliances.Length; ++i)
            {
                if (cont.Alliances[i].Name != "" || FilterEnabled(FilterType.NoAlliance))
                {
                    int supercount = 0;
                    PlayerInfo[] players = cont.Alliances[i].Players();
                    PlayerCountReportItem pcri = new PlayerCountReportItem(players.Length, false);
                    ReportItem r = new MultiLineReportItem(false,
                        new AllianceInfoReportItem(cont.Alliances[i], false, i + 1),
                        pcri
                        );

                    foreach (PlayerInfo p in players)
                    {
                        ReportItem r2 = new PlayerInfoReportItem(p, cont.Id, false);

                        int count = 0;

                        count += ShowCities(r2, CityType.Palace, cont.Id, p);
                        count += ShowCities(r2, CityType.Castle, cont.Id, p);
                        count += ShowCities(r2, CityType.City, cont.Id, p);
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
}
