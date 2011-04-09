﻿using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo;
using LouMapInfo.Entities.Filter;

namespace LouMapInfo.Reports
{
    public class VirtuePalaceReport : ReportInfo
    {
        private WorldInfo world;
        private VirtueType virtue;
        private AllianceInfo alliance;
        public VirtuePalaceReport(WorldInfo w, VirtueType v, AllianceInfo a)
            : base()
        {
            this.world = w;
            this.virtue = v;
            this.alliance = a;

            m_Filters.Add(FilterType.BorderingLand, true);
            m_Filters.Add(FilterType.BorderingWater, true);
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }

        protected override void OnLoad()
        {
            bool el = FilterEnabled(FilterType.BorderingLand);
            bool ew = FilterEnabled(FilterType.BorderingWater);
            title = new TextReportItem((virtue == VirtueType.None ? "Virtues" : virtue.ToString()) + " Overview", true);
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            string a = alliance == null ? "" : alliance.Name;
            if (alliance != null)
                subtitle = new AllianceInfoReportItem(alliance, true);
            Dictionary<int, Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>> palaces = new Dictionary<int, Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>>();
            VirtueType[] virtues = (virtue == VirtueType.None ? new VirtueType[]{ VirtueType.Compassion, VirtueType.Honesty, VirtueType.Honor, VirtueType.Humility, VirtueType.Justice, VirtueType.Sacrifice, VirtueType.Spirituality, VirtueType.Valor} : new VirtueType[]{ virtue });

            List<string> members = new List<string>(alliance == null ? new string[0] : world.PalacesOwnersByAlliance(a));
            for (int i = 10; i > 0; --i)
            {
                palaces.Add(i, new Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>());
                foreach (VirtueType v in virtues)
                    palaces[i].Add(v, new KeyValuePair<List<CityInfo>, List<CityInfo>>(new List<CityInfo>(), new List<CityInfo>()));
            }
            foreach (VirtueType v in virtues)
            {
                string[] players = world.PalacesOwnersByVirtue(v);
                foreach (string p in players)
                {
                    if (alliance == null || members.Contains(p))
                    {
                        PlayerInfo pl = world.Player(p);
                        pl.LoadIfNeeded();
                        CityInfo[] cities;
                        if (!el)
                            cities = pl.Cities(FilterType.TypePalace, FilterType.BorderingWater);
                        else if (!ew)
                            cities = pl.Cities(FilterType.TypePalace, FilterType.BorderingLand);
                        else
                            cities = pl.Cities(FilterType.TypePalace, FilterType.BorderingLand, FilterType.BorderingWater);

                        foreach (CityInfo city in cities)
                        {
                            city.LoadIfNeeded();
                            if (city.VirtueType == v)
                            {
                                if (city.Bordering == BorderingType.Land)
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
                    foreach (VirtueType v in virtues)
                    {
                        bool something2 = false;
                        //ReportItem r2 = new CityTypeReportItem(palaces[i][v].Key.Count + palaces[i][v].Value.Count, CityType.Palace, v, false);

                        int count = 0;
                        if (el)
                            count += palaces[i][v].Value.Count;
                        if (ew)
                            count += palaces[i][v].Key.Count; 
                        ReportItem r2;
                        if (!el)
                            r2 = new CityTypeReportItem(count, CityType.Palace, BorderingType.Water, true);
                        else if (!ew)
                            r2 = new CityTypeReportItem(count, CityType.Palace, BorderingType.Land, true);
                        else
                            r2 = new CityTypeReportItem(count, CityType.Palace, true);
                        if (ew && palaces[i][v].Key.Count > 0)
                        {
                            ReportItem r3 = !el ? r2 : new BorderingTypeReportItem(palaces[i][v].Key.Count, BorderingType.Water, true);
                            CityInfo[] cities = new CityInfo[palaces[i][v].Key.Count];
                            palaces[i][v].Key.CopyTo(cities);
                            Array.Sort(cities);
                            Array.Reverse(cities);
                            foreach (CityInfo info in cities)
                            {
                                ReportItem r4 = new DetailedCityInfoReportItem(info, true, true, alliance == null, true);
                                r3.Items.Add(r4);
                            }
                            if( el)
                                r2.Items.Add(r3);
                            something = true;
                            something2 = true;
                        }
                        if (el && palaces[i][v].Value.Count > 0)
                        {
                            ReportItem r3 = !ew ? r2 : new BorderingTypeReportItem(palaces[i][v].Value.Count, BorderingType.Land, true);
                            CityInfo[] cities = new CityInfo[palaces[i][v].Value.Count];
                            palaces[i][v].Value.CopyTo(cities);
                            Array.Sort(cities);
                            Array.Reverse(cities);
                            foreach (CityInfo info in cities)
                            {
                                ReportItem r4 = new DetailedCityInfoReportItem(info, true, true, alliance == null, true);
                                r3.Items.Add(r4);
                            }
                            if (ew)
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