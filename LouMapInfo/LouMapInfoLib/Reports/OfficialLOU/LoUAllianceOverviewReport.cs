﻿using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.Entities;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.OfficialLOU.Items;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUAllianceOverviewReport : LoUReportInfo
    {
        private LoUAllianceInfo alliance;
        public LoUAllianceOverviewReport(LoUAllianceInfo a, OldLoUCityType type)
            : base(type)
        {
            this.alliance = a;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 3; }
        }
        protected override void OnLoad()
        {
            title = new LoUAllianceInfoReportItem(alliance, true);
            subtitle = new TextReportItem(LoUReportUtility.SayCityType(LoUType), true);
            foreach (LoUPlayerInfo p in alliance.Players())
            {
                p.LoadIfNeeded();
            }
            foreach (int ic in alliance.ActiveContinents)
            {
                LoUPlayerInfo[] pjs = alliance.Players(ic);
                ReportItem r = new MultiLineReportItem(false,
                    new ContinentScoreReportItem(ic, alliance.CScore(ic), false, false),
                    new PlayerCountReportItem(pjs.Length, CityCastleType.Both, false));
                foreach (LoUPlayerInfo p in pjs)
                {
                    ReportItem r2 = new LoUPlayerInfoReportItem(p, false);

                    //First palaces
                    if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                    {
                        LoUCityInfo[] citiesW = p.Cities(OldLoUCityType.Palace, LoUBorderingType.Water, ic);
                        LoUCityInfo[] citiesL = p.Cities(OldLoUCityType.Palace, LoUBorderingType.Land, ic);
                        ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, OldLoUCityType.Palace, true);
                        if (citiesW.Length > 0)
                        {
                            ReportItem r4 = new LoUBorderingTypeReportItem(citiesW.Length, LoUBorderingType.Water, true);
                            Array.Sort(citiesW);
                            Array.Reverse(citiesW);
                            foreach (LoUCityInfo c in citiesW)
                                r4.Items.Add(new LoUCityInfoReportItem(c, true));
                            r3.Items.Add(r4);
                        }
                        if (citiesL.Length > 0)
                        {
                            ReportItem r4 = new LoUBorderingTypeReportItem(citiesL.Length, LoUBorderingType.Land, true);
                            Array.Sort(citiesL);
                            Array.Reverse(citiesL);
                            foreach (LoUCityInfo c in citiesL)
                                r4.Items.Add(new LoUCityInfoReportItem(c, true));
                            r3.Items.Add(r4);
                        }
                        r2.Items.Add(r3);
                    }

                    //Then castles
                    if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                    {
                        LoUCityInfo[] citiesW = p.Cities(OldLoUCityType.Castle, LoUBorderingType.Water, ic);
                        LoUCityInfo[] citiesL = p.Cities(OldLoUCityType.Castle, LoUBorderingType.Land, ic);
                        ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, OldLoUCityType.Castle, true);
                        if (citiesW.Length > 0)
                        {
                            ReportItem r4 = new LoUBorderingTypeReportItem(citiesW.Length, LoUBorderingType.Water, true);
                            Array.Sort(citiesW);
                            Array.Reverse(citiesW);
                            foreach (LoUCityInfo c in citiesW)
                                r4.Items.Add(new LoUCityInfoReportItem(c, true));
                            r3.Items.Add(r4);
                        }
                        if (citiesL.Length > 0)
                        {
                            ReportItem r4 = new LoUBorderingTypeReportItem(citiesL.Length, LoUBorderingType.Land, true);
                            Array.Sort(citiesL);
                            Array.Reverse(citiesL);
                            foreach (LoUCityInfo c in citiesL)
                                r4.Items.Add(new LoUCityInfoReportItem(c, true));
                            r3.Items.Add(r4);
                        }
                        r2.Items.Add(r3);
                    }

                    //Then non-castled cities
                    if (m_Type == CityCastleType.Both || m_Type == CityCastleType.City)
                    {
                        LoUCityInfo[] citiesW = p.Cities(OldLoUCityType.City, LoUBorderingType.Water, ic);
                        LoUCityInfo[] citiesL = p.Cities(OldLoUCityType.City, LoUBorderingType.Land, ic);
                        ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, OldLoUCityType.City, true);
                        if (citiesW.Length > 0)
                        {
                            ReportItem r4 = new LoUBorderingTypeReportItem(citiesW.Length, LoUBorderingType.Water, true);
                            Array.Sort(citiesW);
                            Array.Reverse(citiesW);
                            foreach (LoUCityInfo c in citiesW)
                                r4.Items.Add(new LoUCityInfoReportItem(c, true));
                            r3.Items.Add(r4);
                        }
                        if (citiesL.Length > 0)
                        {
                            ReportItem r4 = new LoUBorderingTypeReportItem(citiesL.Length, LoUBorderingType.Land, true);
                            Array.Sort(citiesL);
                            Array.Reverse(citiesL);
                            foreach (LoUCityInfo c in citiesL)
                                r4.Items.Add(new LoUCityInfoReportItem(c, true));
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