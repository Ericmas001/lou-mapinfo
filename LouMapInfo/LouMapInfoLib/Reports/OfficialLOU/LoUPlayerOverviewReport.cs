using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.Entities;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Entities;
using LouMapInfo.Reports.OfficialLOU.Items;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUPlayerOverviewReport : LoUReportInfo
    {
        private LoUPlayerInfo player;
        public LoUPlayerOverviewReport(LoUPlayerInfo p, params LoUCityType[] type)
            : base(type)
        {
            player = p;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 3; }
        }
        protected override void OnLoad()
        {
            title = new LoUPlayerInfoReportItem(player, -1, true);
            subtitle = new MultiLineReportItem(true,
                    new LoUAllianceInfoReportItem(player.Alliance, true),
                    new TextReportItem("", true),
                    new TextReportItem(LoUReportUtility.SayCityType(LoUType), true)); 

            foreach (int ic in player.ActiveContinents)
            {
                ReportItem r = new ContinentScoreReportItem(ic, player.CScore(ic), true, false);

                //First palaces
                if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                {
                    LoUCityInfo[] citiesW = player.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypePalace);
                    LoUCityInfo[] citiesL = player.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypePalace);
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
                    r.Items.Add(r3);
                }

                //Then castles
                if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                {
                    LoUCityInfo[] citiesW = player.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCastle);
                    LoUCityInfo[] citiesL = player.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCastle);
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
                    r.Items.Add(r3);
                }

                //Then non-castled cities
                if (m_Type == CityCastleType.Both || m_Type == CityCastleType.City)
                {
                    LoUCityInfo[] citiesW = player.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCity);
                    LoUCityInfo[] citiesL = player.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCity);
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
                    r.Items.Add(r3);
                }
                root.Add(r);

            }
        }
    }
}
