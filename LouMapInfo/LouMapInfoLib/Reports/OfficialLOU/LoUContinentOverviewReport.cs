using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.OfficialLOU.Items;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUContinentOverviewReport : LoUReportInfo
    {
        private LoUContinentInfo cont;
        public LoUContinentOverviewReport(LoUContinentInfo c, LoUCityType type)
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
            title = new TextReportItem(DisplayUtility.Cont(cont.Id) + " Overview", true);
            subtitle = new TextReportItem(LoUReportUtility.SayCityType(LoUType), true);

            for (int i = 0; i < cont.Alliances.Length; ++i)
            {
                LoUPlayerInfo[] players = cont.Alliances[i].Players();
                ReportItem r = new MultiLineReportItem(false,
                    new LoUAllianceInfoReportItem(cont.Alliances[i], false, i + 1),
                    new PlayerCountReportItem(players.Length, m_Type, false)
                    );

                foreach (LoUPlayerInfo p in players)
                {
                    ReportItem r2 = new LoUPlayerInfoReportItem(p, cont.Id, false);

                    //First palaces
                    if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                    {
                        LoUCityInfo[] citiesW = p.Cities(LoUCityType.Palace, false,true, cont.Id);
                        LoUCityInfo[] citiesL = p.Cities(LoUCityType.Palace, true,false, cont.Id);
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
                    if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                    {
                        LoUCityInfo[] citiesW = p.Cities(LoUCityType.Castle, false,true, cont.Id);
                        LoUCityInfo[] citiesL = p.Cities(LoUCityType.Castle, true,false, cont.Id);
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
                    if (m_Type == CityCastleType.Both || m_Type == CityCastleType.City)
                    {
                        LoUCityInfo[] citiesW = p.Cities(LoUCityType.City, false,true, cont.Id);
                        LoUCityInfo[] citiesL = p.Cities(LoUCityType.City, true, false, cont.Id);
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
