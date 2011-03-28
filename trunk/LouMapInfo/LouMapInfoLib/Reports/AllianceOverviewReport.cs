using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports
{
    public class AllianceOverviewReport : ReportInfo
    {
        private AllianceInfo alliance;
        public AllianceOverviewReport(AllianceInfo a, params CityType[] type)
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
            title = new AllianceInfoReportItem(alliance, true);
            subtitle = new TextReportItem(ReportUtility.SayCityType(m_Types), true);
            foreach (PlayerInfo p in alliance.Players())
            {
                p.LoadIfNeeded();
            }
            foreach (int ic in alliance.ActiveContinents)
            {
                PlayerInfo[] pjs = alliance.Players(ic);
                ReportItem r = new MultiLineReportItem(false,
                    new ContinentScoreReportItem(ic, alliance.CScore(ic), false, false),
                    new PlayerCountReportItem(pjs.Length, false));
                foreach (PlayerInfo p in pjs)
                {
                    ReportItem r2 = new PlayerInfoReportItem(p, ic, false);

                    //First palaces
                    if (m_Types.Contains(CityType.Palace))
                    {
                        CityInfo[] citiesW = p.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypePalace);
                        CityInfo[] citiesL = p.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypePalace);
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
                    if (m_Types.Contains(CityType.Palace))
                    {
                        CityInfo[] citiesW = p.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypePalace);
                        CityInfo[] citiesL = p.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypePalace);
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
                    if (m_Types.Contains(CityType.Palace))
                    {
                        CityInfo[] citiesW = p.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCastle);
                        CityInfo[] citiesL = p.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCastle);
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
