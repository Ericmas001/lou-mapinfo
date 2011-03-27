﻿using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.Reports.OfficialLOU.Items;
using LouMapInfo.OfficialLOU;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUVirtuePalaceReport : ReportInfo
    {
        private LoUWorldInfo world;
        private LoUVirtueType virtue;
        private LoUAllianceInfo alliance;
        public LoUVirtuePalaceReport(LoUWorldInfo w, LoUVirtueType v, LoUAllianceInfo a)
            : base(LoUCityType.City, LoUCityType.Castle, LoUCityType.Palace)
        {
            this.world = w;
            this.virtue = v;
            this.alliance = a;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            title = new TextReportItem((virtue == LoUVirtueType.None ? "Virtues" : virtue.ToString() ) + " Overview", true);
            string a = alliance == null ? "" : alliance.Name;
            if (alliance != null)
                subtitle = new LoUAllianceInfoReportItem(alliance, true);
            Dictionary<int, Dictionary<LoUVirtueType, KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>>> palaces = new Dictionary<int, Dictionary<LoUVirtueType, KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>>>();
            LoUVirtueType[] virtues = (virtue == LoUVirtueType.None ? new LoUVirtueType[]{ LoUVirtueType.Compassion, LoUVirtueType.Honesty, LoUVirtueType.Honor, LoUVirtueType.Humility, LoUVirtueType.Justice, LoUVirtueType.Sacrifice, LoUVirtueType.Spirituality, LoUVirtueType.Valor} : new LoUVirtueType[]{ virtue });

            List<string> members = new List<string>(alliance == null ? new string[0] : world.PalacesOwnersByAlliance(a));
            for (int i = 10; i > 0; --i)
            {
                palaces.Add(i, new Dictionary<LoUVirtueType, KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>>());
                foreach (LoUVirtueType v in virtues)
                    palaces[i].Add(v, new KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>(new List<LoUCityInfo>(), new List<LoUCityInfo>()));
            }
            foreach (LoUVirtueType v in virtues)
            {
                string[] players = world.PalacesOwnersByVirtue(v);
                foreach (string p in players)
                {
                    if (alliance == null || members.Contains(p))
                    {
                        LoUPlayerInfo pl = world.Player(p);
                        pl.LoadIfNeeded();
                        foreach (LoUCityInfo city in pl.Cities(ReportFeatureType.TypePalace, ReportFeatureType.BorderingLand, ReportFeatureType.BorderingWater))
                        {
                            city.LoadIfNeeded();
                            if (city.VirtueType == v)
                            {
                                if (city.Bordering == LoUBorderingType.Land)
                                    palaces[city.PalaceLvl][v].Value.Add(city);
                                else
                                    palaces[city.PalaceLvl][v].Key.Add(city);
                            }
                        }
                    }
                }
            }
            for (int i = 10; i > 0; --i)
            {
                bool something = false;
                if (palaces[i].Count > 0)
                {
                    ReportItem r = new TextReportItem("Level " + i + " Palaces", false);
                    foreach (LoUVirtueType v in virtues)
                    {
                        bool something2 = false;
                        ReportItem r2 = new LoUCityTypeReportItem(palaces[i][v].Key.Count + palaces[i][v].Value.Count, LoUCityType.Palace, v, false);
                        if (palaces[i][v].Key.Count > 0)
                        {
                            ReportItem r3 = new LoUBorderingTypeReportItem(palaces[i][v].Key.Count, LoUBorderingType.Water, true);
                            LoUCityInfo[] cities = new LoUCityInfo[palaces[i][v].Key.Count];
                            palaces[i][v].Key.CopyTo(cities);
                            Array.Sort(cities);
                            Array.Reverse(cities);
                            foreach (LoUCityInfo info in cities)
                            {
                                ReportItem r4 = new LoUDetailedCityInfoReportItem(info, true, true, alliance == null, true);
                                r3.Items.Add(r4);
                            }
                            r2.Items.Add(r3);
                            something = true;
                            something2 = true;
                        }
                        if (palaces[i][v].Value.Count > 0)
                        {
                            ReportItem r3 = new LoUBorderingTypeReportItem(palaces[i][v].Value.Count, LoUBorderingType.Land, true);
                            LoUCityInfo[] cities = new LoUCityInfo[palaces[i][v].Value.Count];
                            palaces[i][v].Value.CopyTo(cities);
                            Array.Sort(cities);
                            Array.Reverse(cities);
                            foreach (LoUCityInfo info in cities)
                            {
                                ReportItem r4 = new LoUDetailedCityInfoReportItem(info, true, true, alliance == null, true);
                                r3.Items.Add(r4);
                            }
                            r2.Items.Add(r3);
                            something = true;
                            something2 = true;
                        }
                        if (something2)
                            r.Items.Add(r2);
                    }
                    if( something )
                        root.Add(r);
                }
            }
        }
    }
}
