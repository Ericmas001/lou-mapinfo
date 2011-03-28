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
    public class ContinentOverviewReport : ReportInfo
    {
        private ContinentInfo cont;
        public ContinentOverviewReport(ContinentInfo c, params CityType[] type)
            : base(type)
        {
            this.cont = c;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            title = new TextReportItem("C" + cont.Id.ToString("00") + " Overview", true);
            subtitle = new TextReportItem(ReportUtility.SayCityType(m_Types), true);

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
                    if (m_Types.Contains(CityType.Palace))
                    {
                        CityInfo[] citiesW = p.Cities(cont.Id,ReportFeatureType.BorderingWater, ReportFeatureType.TypePalace);
                        CityInfo[] citiesL = p.Cities(cont.Id, ReportFeatureType.BorderingLand, ReportFeatureType.TypePalace);
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
                    if (m_Types.Contains(CityType.Castle))
                    {
                        CityInfo[] citiesW = p.Cities(cont.Id, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCastle);
                        CityInfo[] citiesL = p.Cities(cont.Id, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCastle);
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
                    if (m_Types.Contains(CityType.City))
                    {
                        CityInfo[] citiesW = p.Cities(cont.Id, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCity);
                        CityInfo[] citiesL = p.Cities(cont.Id, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCity);
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
