﻿using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.OfficialLOU.Items;
using LouMapInfo.OfficialLOU;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUSingleVirtuePalaceReport : LoUReportInfo
    {
        private LoUWorldInfo world;
        private string virtue;
        public LoUSingleVirtuePalaceReport(LoUWorldInfo w, string v)
            : base(OldLoUCityType.CityCastlePalace)
        {
            this.world = w;
            this.virtue = v;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            title = new TextReportItem(virtue + " Overview", true);
            string[] players = world.PalacesOwnersByVirtue(virtue);
            ReportItem r = new TextReportItem("Player List", true);
            foreach (string p in players)
                r.Items.Add(new TextReportItem(p,true));
            root.Add(r);
            //subtitle = new TextReportItem(LoUReportUtility.SayCityType(LoUType), true);

            //for (int i = 0; i < cont.Alliances.Length; ++i)
            //{
            //    LoUPlayerInfo[] players = cont.Alliances[i].Players();
            //    ReportItem r = new MultiLineReportItem(false,
            //        new LoUAllianceInfoReportItem(cont.Alliances[i], false, i + 1),
            //        new PlayerCountReportItem(players.Length, m_Type, false)
            //        );

            //    foreach (LoUPlayerInfo p in players)
            //    {
            //        ReportItem r2 = new LoUPlayerInfoReportItem(p, cont.Id, false);

            //        //First palaces
            //        if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
            //        {
            //            LoUCityInfo[] citiesW = p.Cities(OldLoUCityType.Palace, LoUBorderingType.Water, cont.Id);
            //            LoUCityInfo[] citiesL = p.Cities(OldLoUCityType.Palace, LoUBorderingType.Land, cont.Id);
            //            ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, OldLoUCityType.Palace, true);
            //            if (citiesW.Length > 0)
            //            {
            //                ReportItem r4 = new LoUBorderingTypeReportItem(citiesW.Length, LoUBorderingType.Water, true);
            //                Array.Sort(citiesW);
            //                Array.Reverse(citiesW);
            //                foreach (LoUCityInfo c in citiesW)
            //                    r4.Items.Add(new LoUCityInfoReportItem(c, true));
            //                r3.Items.Add(r4);
            //            }
            //            if (citiesL.Length > 0)
            //            {
            //                ReportItem r4 = new LoUBorderingTypeReportItem(citiesL.Length, LoUBorderingType.Land, true);
            //                Array.Sort(citiesL);
            //                Array.Reverse(citiesL);
            //                foreach (LoUCityInfo c in citiesL)
            //                    r4.Items.Add(new LoUCityInfoReportItem(c, true));
            //                r3.Items.Add(r4);
            //            }
            //            r2.Items.Add(r3);
            //        }

            //        //Then castles
            //        if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
            //        {
            //            LoUCityInfo[] citiesW = p.Cities(OldLoUCityType.Castle, LoUBorderingType.Water, cont.Id);
            //            LoUCityInfo[] citiesL = p.Cities(OldLoUCityType.Castle, LoUBorderingType.Land, cont.Id);
            //            ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, OldLoUCityType.Castle, true);
            //            if (citiesW.Length > 0)
            //            {
            //                ReportItem r4 = new LoUBorderingTypeReportItem(citiesW.Length, LoUBorderingType.Water, true);
            //                Array.Sort(citiesW);
            //                Array.Reverse(citiesW);
            //                foreach (LoUCityInfo c in citiesW)
            //                    r4.Items.Add(new LoUCityInfoReportItem(c, true));
            //                r3.Items.Add(r4);
            //            }
            //            if (citiesL.Length > 0)
            //            {
            //                ReportItem r4 = new LoUBorderingTypeReportItem(citiesL.Length, LoUBorderingType.Land, true);
            //                Array.Sort(citiesL);
            //                Array.Reverse(citiesL);
            //                foreach (LoUCityInfo c in citiesL)
            //                    r4.Items.Add(new LoUCityInfoReportItem(c, true));
            //                r3.Items.Add(r4);
            //            }
            //            r2.Items.Add(r3);
            //        }

            //        //Then non-castled cities
            //        if (m_Type == CityCastleType.Both || m_Type == CityCastleType.City)
            //        {
            //            LoUCityInfo[] citiesW = p.Cities(OldLoUCityType.City, LoUBorderingType.Water,cont.Id);
            //            LoUCityInfo[] citiesL = p.Cities(OldLoUCityType.City, LoUBorderingType.Land, cont.Id);
            //            ReportItem r3 = new LoUCityTypeReportItem(citiesW.Length + citiesL.Length, OldLoUCityType.City, true);
            //            if (citiesW.Length > 0)
            //            {
            //                ReportItem r4 = new LoUBorderingTypeReportItem(citiesW.Length, LoUBorderingType.Water, true);
            //                Array.Sort(citiesW);
            //                Array.Reverse(citiesW);
            //                foreach (LoUCityInfo c in citiesW)
            //                    r4.Items.Add(new LoUCityInfoReportItem(c, true));
            //                r3.Items.Add(r4);
            //            }
            //            if (citiesL.Length > 0)
            //            {
            //                ReportItem r4 = new LoUBorderingTypeReportItem(citiesL.Length, LoUBorderingType.Land, true);
            //                Array.Sort(citiesL);
            //                Array.Reverse(citiesL);
            //                foreach (LoUCityInfo c in citiesL)
            //                    r4.Items.Add(new LoUCityInfoReportItem(c, true));
            //                r3.Items.Add(r4);
            //            }
            //            r2.Items.Add(r3);
            //        }
            //        r.Items.Add(r2);
            //    }
            //    root.Add(r);
            //}
        }
    }
}
