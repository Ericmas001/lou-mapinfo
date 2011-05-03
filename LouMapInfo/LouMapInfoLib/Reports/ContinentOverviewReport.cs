using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;

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

            m_Grouping.Add(GroupingType.Alliance, true);
            m_Grouping.Add(GroupingType.Player, true);
            m_Grouping.Add(GroupingType.CityType, true);
            m_Grouping.Add(GroupingType.Bordering, true);
            LoadIfNeeded();
        }

        protected override void OnLoad()
        {
            title = new TextReportItem(false, "C" + cont.Id.ToString("00") + " Overview");
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            if (GroupingEnabled(GroupingType.Alliance))
            {
                for (int i = 0; i < cont.Alliances.Length; ++i)
                {
                    if (cont.Alliances[i].Name != "" || FilterEnabled(FilterType.NoAlliance))
                    {
                        int supercount = 0;
                        PlayerInfo[] players = cont.Alliances[i].Players();
                        PlayerCountReportItem pcri = new PlayerCountReportItem(false, players.Length);
                        ReportItem r = new MultiLineReportItem(false,
                            new AllianceInfoReportItem(false, cont.Alliances[i], i + 1),
                            pcri
                            );

                        foreach (PlayerInfo p in players)
                        {
                            ReportItem r2 = new PlayerInfoReportItem(false, p, cont.Id);

                            int count = 0;

                            if (GroupingEnabled(GroupingType.CityType))
                            {
                                count += ShowCities(r2, CityType.Palace, cont.Id, p);
                                count += ShowCities(r2, CityType.Castle, cont.Id, p);
                                count += ShowCities(r2, CityType.City, cont.Id, p);
                            }
                            else
                                count += ShowCities(r2, CityType.None, cont.Id, p);
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
                                count += ShowCities(r, CityType.Palace, cont.Id, cont.Alliances[i]);
                                count += ShowCities(r, CityType.Castle, cont.Id, cont.Alliances[i]);
                                count += ShowCities(r, CityType.City, cont.Id, cont.Alliances[i]);
                            }
                            else
                                count += ShowCities(r, CityType.None, cont.Id, cont.Alliances[i]);
                        }
                        pcri.Count = supercount;
                        if (FilterEnabled(FilterType.NoCities) || supercount > 0)
                            root.Add(r);
                    }
                }
            }
            else
            {
                int supercount = 0;
                PlayerInfo[] players = cont.World.Players;
                PlayerCountReportItem pcri = new PlayerCountReportItem(false, players.Length);
                ReportItem r = new TextReportItem(false, "");

                foreach (PlayerInfo p in players)
                {
                    ReportItem r2 = new PlayerInfoReportItem(false, p, cont.Id);

                    int count = 0;

                    if (GroupingEnabled(GroupingType.CityType))
                    {
                        count += ShowCities(r2, CityType.Palace, cont.Id, p);
                        count += ShowCities(r2, CityType.Castle, cont.Id, p);
                        count += ShowCities(r2, CityType.City, cont.Id, p);
                    }
                    else
                        count += ShowCities(r2, CityType.None, cont.Id, p);
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
                        count += ShowCities(r, CityType.Palace, cont);
                        count += ShowCities(r, CityType.Castle, cont);
                        count += ShowCities(r, CityType.City, cont);
                    }
                    else
                        count += ShowCities(r, CityType.None, cont);
                }
                pcri.Count = supercount;
                if (FilterEnabled(FilterType.NoCities) || supercount > 0)
                    foreach( ReportItem ri in r.Items )
                        root.Add(ri);
            }
        }
    }
}