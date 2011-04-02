using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo.Entities.Filter;

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
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 3; }
        }
        protected override void OnLoad()
        {
            title = new PlayerInfoReportItem(player, -1, true);
            string[] lines = SayCityType();
            if (lines.Length > 0)
            {
                ReportItem[] items = new ReportItem[lines.Length + 2];
                items[0] = new AllianceInfoReportItem(player.Alliance, true);
                items[1] = new TextReportItem("", true);
                for( int i = 0; i < lines.Length; ++i)
                    items[i + 2] = new TextReportItem(lines[i],true);
                subtitle = new MultiLineReportItem(true,items);
            }
            else
                subtitle = new AllianceInfoReportItem(player.Alliance, true);

            foreach (int ic in player.ActiveContinents)
            {
                ReportItem r = new ContinentScoreReportItem(ic, player.CScore(ic), true, false);

                //First palaces
                if (FilterEnabled(FilterType.TypePalace))
                {
                    CityInfo[] citiesW = player.Cities(ic, FilterType.BorderingWater, FilterType.TypePalace);
                    CityInfo[] citiesL = player.Cities(ic, FilterType.BorderingLand, FilterType.TypePalace);
                    ReportItem r3 = new CityTypeReportItem(citiesW.Length + citiesL.Length, CityType.Palace, true);
                    if (citiesW.Length > 0)
                    {
                        ReportItem r4 = new BorderingTypeReportItem(citiesW.Length, BorderingType.Water, true);
                        Array.Sort(citiesW);
                        Array.Reverse(citiesW);
                        foreach (CityInfo c in citiesW)
                            r4.Items.Add(new CityInfoReportItem(c, true));
                        r3.Items.Add(r4);
                    }
                    if (citiesL.Length > 0)
                    {
                        ReportItem r4 = new BorderingTypeReportItem(citiesL.Length, BorderingType.Land, true);
                        Array.Sort(citiesL);
                        Array.Reverse(citiesL);
                        foreach (CityInfo c in citiesL)
                            r4.Items.Add(new CityInfoReportItem(c, true));
                        r3.Items.Add(r4);
                    }
                    r.Items.Add(r3);
                }

                //Then castles
                if (FilterEnabled(FilterType.TypeCastle))
                {
                    CityInfo[] citiesW = player.Cities(ic, FilterType.BorderingWater, FilterType.TypeCastle);
                    CityInfo[] citiesL = player.Cities(ic, FilterType.BorderingLand, FilterType.TypeCastle);
                    ReportItem r3 = new CityTypeReportItem(citiesW.Length + citiesL.Length, CityType.Castle, true);
                    if (citiesW.Length > 0)
                    {
                        ReportItem r4 = new BorderingTypeReportItem(citiesW.Length, BorderingType.Water, true);
                        Array.Sort(citiesW);
                        Array.Reverse(citiesW);
                        foreach (CityInfo c in citiesW)
                            r4.Items.Add(new CityInfoReportItem(c, true));
                        r3.Items.Add(r4);
                    }
                    if (citiesL.Length > 0)
                    {
                        ReportItem r4 = new BorderingTypeReportItem(citiesL.Length, BorderingType.Land, true);
                        Array.Sort(citiesL);
                        Array.Reverse(citiesL);
                        foreach (CityInfo c in citiesL)
                            r4.Items.Add(new CityInfoReportItem(c, true));
                        r3.Items.Add(r4);
                    }
                    r.Items.Add(r3);
                }

                //Then non-castled cities
                if (FilterEnabled(FilterType.TypeCity))
                {
                    CityInfo[] citiesW = player.Cities(ic, FilterType.BorderingWater, FilterType.TypeCity);
                    CityInfo[] citiesL = player.Cities(ic, FilterType.BorderingLand, FilterType.TypeCity);
                    ReportItem r3 = new CityTypeReportItem(citiesW.Length + citiesL.Length, CityType.City, true);
                    if (citiesW.Length > 0)
                    {
                        ReportItem r4 = new BorderingTypeReportItem(citiesW.Length, BorderingType.Water, true);
                        Array.Sort(citiesW);
                        Array.Reverse(citiesW);
                        foreach (CityInfo c in citiesW)
                            r4.Items.Add(new CityInfoReportItem(c, true));
                        r3.Items.Add(r4);
                    }
                    if (citiesL.Length > 0)
                    {
                        ReportItem r4 = new BorderingTypeReportItem(citiesL.Length, BorderingType.Land, true);
                        Array.Sort(citiesL);
                        Array.Reverse(citiesL);
                        foreach (CityInfo c in citiesL)
                            r4.Items.Add(new CityInfoReportItem(c, true));
                        r3.Items.Add(r4);
                    }
                    r.Items.Add(r3);
                }
                root.Add(r);

            }
        }
    }
}
