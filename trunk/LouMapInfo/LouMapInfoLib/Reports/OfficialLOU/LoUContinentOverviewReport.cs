using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.OfficialLOU.Items;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUContinentOverviewReport : ReportInfo
    {
        private LoUContinentInfo cont;
        public LoUContinentOverviewReport(LoUContinentInfo c, params LoUCityType[] type)
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
            subtitle = new TextReportItem(LoUReportUtility.SayCityType(m_Types), true);

            for (int i = 0; i < cont.Alliances.Length; ++i)
            {
                LoUPlayerInfo[] players = cont.Alliances[i].Players();
                ReportItem r = new MultiLineReportItem(false,
                    new LoUAllianceInfoReportItem(cont.Alliances[i], false, i + 1),
                    new PlayerCountReportItem(players.Length, false)
                    );

                foreach (LoUPlayerInfo p in players)
                {
                    ReportItem r2 = new LoUPlayerInfoReportItem(p, cont.Id, false);

                    //First palaces
                    if (m_Types.Contains(LoUCityType.Palace))
                    {
                        LoUCityInfo[] citiesW = p.Cities(cont.Id,ReportFeatureType.BorderingWater, ReportFeatureType.TypePalace);
                        LoUCityInfo[] citiesL = p.Cities(cont.Id, ReportFeatureType.BorderingLand, ReportFeatureType.TypePalace);
                        ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, LoUCityType.Palace, true);
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
                    if (m_Types.Contains(LoUCityType.Castle))
                    {
                        LoUCityInfo[] citiesW = p.Cities(cont.Id, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCastle);
                        LoUCityInfo[] citiesL = p.Cities(cont.Id, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCastle);
                        ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, LoUCityType.Castle, true);
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
                    if (m_Types.Contains(LoUCityType.City))
                    {
                        LoUCityInfo[] citiesW = p.Cities(cont.Id, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCity);
                        LoUCityInfo[] citiesL = p.Cities(cont.Id, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCity);
                        ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, LoUCityType.City, true);
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
