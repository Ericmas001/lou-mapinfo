using System;
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
    public class LoUByVirtuePalaceReport : LoUReportInfo
    {
        private LoUWorldInfo world;
        private LoUVirtue virtue;
        public LoUByVirtuePalaceReport(LoUWorldInfo w, LoUVirtue v)
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
            title = new TextReportItem((virtue == LoUVirtue.None ? "Virtues" : virtue.ToString() ) + " Overview", true);
            Dictionary<int, Dictionary<LoUVirtue, KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>>> palaces = new Dictionary<int, Dictionary<LoUVirtue, KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>>>();
            LoUVirtue[] virtues = (virtue == LoUVirtue.None ? new LoUVirtue[]{ LoUVirtue.Compassion, LoUVirtue.Honesty, LoUVirtue.Honor, LoUVirtue.Humility, LoUVirtue.Justice, LoUVirtue.Sacrifice, LoUVirtue.Spirituality, LoUVirtue.Valor} : new LoUVirtue[]{ virtue });
            for (int i = 10; i > 0; --i)
            {
                palaces.Add(i, new Dictionary<LoUVirtue, KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>>());
                foreach (LoUVirtue v in virtues)
                    palaces[i].Add(v, new KeyValuePair<List<LoUCityInfo>, List<LoUCityInfo>>(new List<LoUCityInfo>(), new List<LoUCityInfo>()));
            }
            foreach (LoUVirtue v in virtues)
            {
                string[] players = world.PalacesOwnersByVirtue(v);
                foreach (string p in players)
                {
                    LoUPlayerInfo pl = world.Player(p);
                    pl.LoadIfNeeded();
                    ReportItem r2 = new LoUPlayerInfoReportItem(pl, -1, true);
                    foreach (LoUCityInfo city in pl.Cities(OldLoUCityType.Palace))
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
            for (int i = 10; i > 0; --i)
            {
                bool something = false;
                if (palaces[i].Count > 0)
                {
                    ReportItem r = new TextReportItem("Level " + i + " Palaces", false);
                    foreach (LoUVirtue v in virtues)
                    {
                        bool something2 = false;
                        ReportItem r2 = new LoUCityTypeReportItem(palaces[i][v].Key.Count + palaces[i][v].Value.Count, OldLoUCityType.Palace, v, false);
                        if (palaces[i][v].Key.Count > 0)
                        {
                            ReportItem r3 = new LoUBorderingTypeReportItem(palaces[i][v].Key.Count, LoUBorderingType.Water, true);
                            LoUCityInfo[] cities = new LoUCityInfo[palaces[i][v].Key.Count];
                            palaces[i][v].Key.CopyTo(cities);
                            Array.Sort(cities);
                            Array.Reverse(cities);
                            foreach (LoUCityInfo info in cities)
                            {
                                ReportItem r4 = new LoUDetailedCityInfoReportItem(info, true, true, true, true);
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
                                ReportItem r4 = new LoUDetailedCityInfoReportItem(info, true, true, true, true);
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
