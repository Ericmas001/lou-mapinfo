using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports
{
    public class PlayerOverviewReport : ReportInfo
    {
        private PlayerInfo player;
        public PlayerOverviewReport(PlayerInfo p, params CityType[] type)
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
            title = new PlayerInfoReportItem(player, -1, true);
            subtitle = new MultiLineReportItem(true,
                    new AllianceInfoReportItem(player.Alliance, true),
                    new TextReportItem("", true),
                    new TextReportItem(ReportUtility.SayCityType(m_Types), true)); 

            foreach (int ic in player.ActiveContinents)
            {
                ReportItem r = new ContinentScoreReportItem(ic, player.CScore(ic), true, false);

                //First palaces
                if (m_Types.Contains(CityType.Palace))
                {
                    CityInfo[] citiesW = player.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypePalace);
                    CityInfo[] citiesL = player.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypePalace);
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
                if (m_Types.Contains(CityType.Castle))
                {
                    CityInfo[] citiesW = player.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCastle);
                    CityInfo[] citiesL = player.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCastle);
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
                if (m_Types.Contains(CityType.City))
                {
                    CityInfo[] citiesW = player.Cities(ic, ReportFeatureType.BorderingWater, ReportFeatureType.TypeCity);
                    CityInfo[] citiesL = player.Cities(ic, ReportFeatureType.BorderingLand, ReportFeatureType.TypeCity);
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
