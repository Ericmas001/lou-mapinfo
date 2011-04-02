﻿using System;
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
            m_Features.Add(FilterType.BorderingLand, true);
            m_Features.Add(FilterType.BorderingWater, true);
            m_Features.Add(FilterType.NoCities, true);
            m_Features.Add(FilterType.NoAlliance, true);
            m_Features.Add(FilterType.TypeCastle, true);
            m_Features.Add(FilterType.TypeCity, true);
            m_Features.Add(FilterType.TypePalace, true);
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
                PlayerInfo[] players = cont.Alliances[i].Players();
                ReportItem r = new MultiLineReportItem(false,
                    new AllianceInfoReportItem(cont.Alliances[i], false, i + 1),
                    new PlayerCountReportItem(players.Length, false)
                    );

                foreach (PlayerInfo p in players)
                {
                    ReportItem r2 = new PlayerInfoReportItem(p, cont.Id, false);

                    //First palaces
                    if (FeatureEnabled(FilterType.TypePalace))
                    {
                        CityInfo[] citiesW = p.Cities(cont.Id,FilterType.BorderingWater, FilterType.TypePalace);
                        CityInfo[] citiesL = p.Cities(cont.Id, FilterType.BorderingLand, FilterType.TypePalace);
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
                        r2.Items.Add(r3);
                    }

                    //Then castles
                    if (FeatureEnabled(FilterType.TypeCastle))
                    {
                        CityInfo[] citiesW = p.Cities(cont.Id, FilterType.BorderingWater, FilterType.TypeCastle);
                        CityInfo[] citiesL = p.Cities(cont.Id, FilterType.BorderingLand, FilterType.TypeCastle);
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
                        r2.Items.Add(r3);
                    }

                    //Then non-castled cities
                    if (FeatureEnabled(FilterType.TypeCity))
                    {
                        CityInfo[] citiesW = p.Cities(cont.Id, FilterType.BorderingWater, FilterType.TypeCity);
                        CityInfo[] citiesL = p.Cities(cont.Id, FilterType.BorderingLand, FilterType.TypeCity);
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
                        r2.Items.Add(r3);
                    }
                    r.Items.Add(r2);
                }
                root.Add(r);
            }
        }
    }
}
