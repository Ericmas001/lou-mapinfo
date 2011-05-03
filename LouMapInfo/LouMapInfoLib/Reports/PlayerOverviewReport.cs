using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;


namespace LouMapInfo.Reports
{
    public class PlayerOverviewReport : ReportInfo
    {
        private PlayerInfo player;
        public PlayerOverviewReport(PlayerInfo p)
            : base()
        {
            player = p;
            m_Filters.Add(FilterType.BorderingLand, true);
            m_Filters.Add(FilterType.BorderingWater, true);
            m_Filters.Add(FilterType.NoCities, true);
            m_Filters.Add(FilterType.TypeCastle, true);
            m_Filters.Add(FilterType.TypeCity, true);
            m_Filters.Add(FilterType.TypePalace, true);

            m_Grouping.Add(GroupingType.Continent, true);
            m_Grouping.Add(GroupingType.CityType, true);
            m_Grouping.Add(GroupingType.Bordering, true);
            LoadIfNeeded();
        }
        protected override void OnLoad()
        {
            title = new PlayerInfoReportItem(false, player, -1);
            string[] lines = SayCityType();
            if (lines.Length > 0)
            {
                ReportItem[] items = new ReportItem[lines.Length + 2];
                items[0] = new AllianceInfoReportItem(false, player.Alliance);
                items[1] = new TextReportItem(false, "");
                for( int i = 0; i < lines.Length; ++i)
                    items[i + 2] = new TextReportItem(false, lines[i]);
                subtitle = new MultiLineReportItem(true,items);
            }
            else
                subtitle = new AllianceInfoReportItem(false, player.Alliance);
            if (GroupingEnabled(GroupingType.Continent))
            {
                foreach (int ic in player.ActiveContinents)
                {
                    ReportItem r = new ContinentScoreReportItem(false, ic, player.CScore(ic), true);
                    int count = 0;

                    if (GroupingEnabled(GroupingType.CityType))
                    {
                        count += ShowCities(r, CityType.Palace, ic, player);
                        count += ShowCities(r, CityType.Castle, ic, player);
                        count += ShowCities(r, CityType.City, ic, player);
                    }
                    else
                        count += ShowCities(r, CityType.None, ic, player);
                    if (FilterEnabled(FilterType.NoCities) || count > 0)
                        root.Add(r);

                }
            }
            else
            {
                ReportItem r = new TextReportItem(false, "");
                int count = 0;

                if (GroupingEnabled(GroupingType.CityType))
                {
                    count += ShowCities(r, CityType.Palace, -1, player);
                    count += ShowCities(r, CityType.Castle, -1, player);
                    count += ShowCities(r, CityType.City, -1, player);
                }
                else
                    count += ShowCities(r, CityType.None, -1, player);
                foreach (ReportItem ri in r.Items)
                    root.Add(ri);
            }
        }
    }
}
