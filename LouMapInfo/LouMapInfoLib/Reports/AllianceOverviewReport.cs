﻿using System;
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

        public int ShowCities(ReportItem r, CityType cityType, int ic, PlayerInfo p)
        {
            FilterType type = Filters.Filter(cityType);
            if (FilterEnabled(type))
            {
                bool el = FilterEnabled(FilterType.BorderingLand);
                bool ew = FilterEnabled(FilterType.BorderingWater);
                CityInfo[] citiesW = p.Cities(ic, FilterType.BorderingWater, type);
                CityInfo[] citiesL = p.Cities(ic, FilterType.BorderingLand, type);
                int count = 0;
                if (el)
                    count += citiesL.Length;
                if (ew)
                    count += citiesW.Length;
                if (FilterEnabled(FilterType.NoCities) || count > 0)
                {
                    ReportItem r3;
                    if (!el)
                        r3 = new CityTypeReportItem(citiesW.Length, cityType, BorderingType.Water, true);
                    else if (!ew)
                        r3 = new CityTypeReportItem(citiesL.Length, cityType, BorderingType.Land, true);
                    else
                        r3 = new CityTypeReportItem(count, cityType, true);

                    if (ew && citiesW.Length > 0)
                    {
                        ReportItem r4 = !el ? r3 : new BorderingTypeReportItem(citiesW.Length, BorderingType.Water, true);
                        Array.Sort(citiesW);
                        Array.Reverse(citiesW);
                        foreach (CityInfo c in citiesW)
                        {
                            if (c.TypeCity == CityType.Palace)
                            {
                                c.LoadIfNeeded();
                                r4.Items.Add(new DetailedPalaceInfoReportItem(c, true, false, false, false, true, true));
                            }
                            else
                                r4.Items.Add(new CityInfoReportItem(c, true));
                        }
                        if(el)
                            r3.Items.Add(r4);
                    }
                    if (el && citiesL.Length > 0)
                    {
                        ReportItem r4 = !ew ? r3 : new BorderingTypeReportItem(citiesL.Length, BorderingType.Land, true);
                        Array.Sort(citiesL);
                        Array.Reverse(citiesL);
                        foreach (CityInfo c in citiesL)
                            if (c.TypeCity == CityType.Palace)
                            {
                                c.LoadIfNeeded();
                                r4.Items.Add(new DetailedPalaceInfoReportItem(c, true, false, false, false, true, true));
                            }
                            else
                                r4.Items.Add(new CityInfoReportItem(c, true));
                        r3.Items.Add(r4);
                    }
                    if( ew)
                        r.Items.Add(r3);
                }
                return count;
            }
            return 0;
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
