using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo;


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

            m_Grouping.Add(GroupingType.PalaceLevel, true);
            m_Grouping.Add(GroupingType.VirtueType, true);
            m_Grouping.Add(GroupingType.Bordering, true);
            LoadIfNeeded();
        }

        protected override void OnLoad()
        {
            VirtueType[] virtues = (virtue == VirtueType.None ? new VirtueType[] { VirtueType.Compassion, VirtueType.Honesty, VirtueType.Honor, VirtueType.Humility, VirtueType.Justice, VirtueType.Sacrifice, VirtueType.Spirituality, VirtueType.Valor } : new VirtueType[] { virtue });

            title = new TextReportItem(false, (virtue == VirtueType.None ? "Virtues" : virtue.ToString()) + " Overview");
            string[] lines = SayCityType();
            if (lines.Length > 0)
                subtitle = new MultiLineReportItem(true, lines);
            string a = alliance == null ? "" : alliance.Name;
            if (alliance != null)
                subtitle = new AllianceInfoReportItem(false, alliance);
            Dictionary<int, Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>> palaces = getPalaces(a, virtues);
            if (GroupingEnabled(GroupingType.PalaceLevel))
            {
                for (int i = 10; i > 0; --i)
                {
                    bool something = false;
                    if (palaces[i].Count > 0)
                    {
                        ReportItem r = new TextReportItem(false, "Level " + i + " Palaces");
                        if (GroupingEnabled(GroupingType.VirtueType))
                        {
                            foreach (VirtueType v in virtues)
                                if (printPalaces(r, v, palaces[i][v].Key, palaces[i][v].Value))
                                    something = true;
                        }
                        else
                        {
                            KeyValuePair<List<CityInfo>, List<CityInfo>> alls = new KeyValuePair<List<CityInfo>, List<CityInfo>>(new List<CityInfo>(), new List<CityInfo>());
                            foreach (VirtueType v in virtues)
                            {
                                alls.Key.AddRange(palaces[i][v].Key);
                                alls.Value.AddRange(palaces[i][v].Value);
                            }
                            if (printPalaces(r, VirtueType.None, alls.Key, alls.Value))
                                something = true;
                        }
                        if (something)
                            root.Add(r);
                    }
                }
            }
            else
            {
                Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>> palacesV = new Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>();
                for (int i = 10; i > 0; --i)
                {
                    foreach( VirtueType v in palaces[i].Keys )
                    {
                        if (!palacesV.ContainsKey(v))
                            palacesV.Add(v, new KeyValuePair<List<CityInfo>, List<CityInfo>>(new List<CityInfo>(), new List<CityInfo>()));
                        palacesV[v].Key.AddRange(palaces[i][v].Key);
                        palacesV[v].Value.AddRange(palaces[i][v].Value);
                    }
                }
                if (palacesV.Count > 0)
                {
                    ReportItem r = new TextReportItem(false, "");
                    if (GroupingEnabled(GroupingType.VirtueType))
                    {
                        foreach (VirtueType v in virtues)
                            printPalaces(r, v, palacesV[v].Key, palacesV[v].Value);
                    }
                    else
                    {
                        KeyValuePair<List<CityInfo>, List<CityInfo>> alls = new KeyValuePair<List<CityInfo>, List<CityInfo>>(new List<CityInfo>(), new List<CityInfo>());
                        foreach (VirtueType v in virtues)
                        {
                            alls.Key.AddRange(palacesV[v].Key);
                            alls.Value.AddRange(palacesV[v].Value);
                        }
                        printPalaces(r, VirtueType.None, alls.Key, alls.Value);
                    }
                    foreach( ReportItem ri in r.Items)
                        root.Add(ri);
                }
            }

        }
        

        private Dictionary<int, Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>> getPalaces(string a, VirtueType[] virtues)
        {
            bool el = FilterEnabled(FilterType.BorderingLand);
            bool ew = FilterEnabled(FilterType.BorderingWater);
            Dictionary<int, Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>> palaces = new Dictionary<int, Dictionary<VirtueType, KeyValuePair<List<CityInfo>, List<CityInfo>>>>();
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
            return palaces;
        }

        private bool printPalaces(ReportItem r, VirtueType v, List<CityInfo> cw, List<CityInfo>cl)
        {
            bool gt = GroupingEnabled(GroupingType.CityType);
            bool gb = GroupingEnabled(GroupingType.Bordering);
            bool el = FilterEnabled(FilterType.BorderingLand);
            bool ew = FilterEnabled(FilterType.BorderingWater);

            int count = 0;
            if (!gb || el)
                count += cl.Count;
            if (!gb || ew)
                count += cw.Count;

            if (count > 0)
            {

                ReportItem r3;
                if (v != VirtueType.None)
                {
                    if (!el)
                        r3 = new CityTypeReportItem(false, count, CityType.Palace, BorderingType.Water,v);
                    else if (!ew)
                        r3 = new CityTypeReportItem(false, count, CityType.Palace, BorderingType.Land,v);
                    else
                        r3 = new CityTypeReportItem(false, count, CityType.Palace,v);
                }
                else
                    r3 = r;

                if (gb)
                {
                    CityInfo[] cities = new CityInfo[cw.Count];
                    cw.CopyTo(cities, 0);
                    ShowBorderingGroup(r3, BorderingType.Water, cities);

                    cities = new CityInfo[cl.Count];
                    cl.CopyTo(cities, 0);
                    ShowBorderingGroup(r3, BorderingType.Land, cities);
                }
                else
                {

                    CityInfo[] cities = new CityInfo[cw.Count + cl.Count];
                    cw.CopyTo(cities, 0);
                    cl.CopyTo(cities, cw.Count);
                    ShowCityDetailLine(r3, cities);
                }
                if (v != VirtueType.None)
                    r.Items.Add(r3);
            }
            return count > 0;
        }
        protected override void ShowCityDetailLine(ReportItem r, CityInfo[] cities)
        {
            Array.Sort(cities);
            Array.Reverse(cities);
            foreach (CityInfo c in cities)
                    r.Items.Add(new DetailedCityInfoReportItem(true, c, true, alliance == null, true));
        }
    }
}
