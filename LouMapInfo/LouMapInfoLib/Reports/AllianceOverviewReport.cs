using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;


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

            m_Grouping.Add(GroupingType.Continent, true);
            m_Grouping.Add(GroupingType.Player, true);
            m_Grouping.Add(GroupingType.CityType, true);
            m_Grouping.Add(GroupingType.Bordering, true);
            LoadIfNeeded();
        }

        protected override void OnLoad()
        {
            title = new AllianceInfoReportItem(false, alliance);
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            foreach (PlayerInfo p in alliance.Players())
            {
                p.LoadIfNeeded();
            }
            if (GroupingEnabled(GroupingType.Continent))
            {
                foreach (int ic in alliance.ActiveContinents)
                {
                    int supercount = 0;
                    PlayerInfo[] pjs = alliance.Players(ic);
                    PlayerCountReportItem pcri = new PlayerCountReportItem(false, pjs.Length);
                    ReportItem r = new MultiLineReportItem(false,
                        new ContinentScoreReportItem(false, ic, alliance.CScore(ic), false),
                        pcri);
                    foreach (PlayerInfo p in pjs)
                    {
                        ReportItem r2 = new PlayerInfoReportItem(false, p, ic);
                        int count = 0;

                        if (GroupingEnabled(GroupingType.CityType))
                        {
                            count += ShowCities(r2, CityType.Palace, ic, p);
                            count += ShowCities(r2, CityType.Castle, ic, p);
                            count += ShowCities(r2, CityType.City, ic, p);
                        }
                        else
                            count += ShowCities(r2, CityType.None, ic, p);
                        if (FilterEnabled(FilterType.NoCities) || count > 0)
                        {
                            supercount++;
                            r.Items.Add(r2);
                        }
                    }
                    if (!GroupingEnabled(GroupingType.Player))
                    {
                        r.Items.Clear();
                        int count = 0;

                        if (GroupingEnabled(GroupingType.CityType))
                        {
                            count += ShowCities(r, CityType.Palace, ic, alliance);
                            count += ShowCities(r, CityType.Castle, ic, alliance);
                            count += ShowCities(r, CityType.City, ic, alliance);
                        }
                        else
                            count += ShowCities(r, CityType.None, ic, alliance);
                    }
                    pcri.Count = supercount;
                    if (FilterEnabled(FilterType.NoCities) || supercount > 0)
                        root.Add(r);
                }
            }
            else
            {
                ReportItem r = new TextReportItem(false, "");

                PlayerInfo[] pjs = alliance.Players();

                if (GroupingEnabled(GroupingType.Player))
                {
                    foreach (PlayerInfo p in pjs)
                    {
                        ReportItem r2 = new PlayerInfoReportItem(false, p, -1);
                        int count = 0;

                        if (GroupingEnabled(GroupingType.CityType))
                        {
                            count += ShowCities(r2, CityType.Palace, -1, p);
                            count += ShowCities(r2, CityType.Castle, -1, p);
                            count += ShowCities(r2, CityType.City, -1, p);
                        }
                        else
                            count += ShowCities(r2, CityType.None, -1, p);
                        if (FilterEnabled(FilterType.NoCities) || count > 0)
                            r.Items.Add(r2);
                    }
                }
                else
                {
                    r.Items.Clear();
                    int count = 0;

                    if (GroupingEnabled(GroupingType.CityType))
                    {
                        count += ShowCities(r, CityType.Palace, -1, alliance);
                        count += ShowCities(r, CityType.Castle, -1, alliance);
                        count += ShowCities(r, CityType.City, -1, alliance);
                    }
                    else
                        count += ShowCities(r, CityType.None, -1, alliance);
                }

                foreach (ReportItem ri in r.Items)
                    root.Add(ri);
            }

        }
    }
}
