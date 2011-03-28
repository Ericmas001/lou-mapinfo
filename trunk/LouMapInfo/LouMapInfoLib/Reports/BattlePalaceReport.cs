using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using LouMapInfo;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports
{
    public class BattlePalaceReport : ReportInfo
    {
        private WorldInfo world;
        private BattleType type;
        public BattlePalaceReport(WorldInfo w, BattleType b)
            : base(CityType.City, CityType.Castle, CityType.Palace)
        {
            this.world = w;
            this.type = b;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }


        class PalaceComp : IComparer<CityInfo>
        {
            public PalaceComp()
            {
            }
            #region IComparer<LoUPlayerInfo> Members

            public int Compare(CityInfo x, CityInfo y)
            {
                int xScore = (x.PalaceLvl * 1000000) + x.Score;
                int yScore = (y.PalaceLvl * 1000000) + y.Score;
                return xScore.CompareTo(yScore);
            }

            #endregion
        }
        protected override void OnLoad()
        {
            switch (type)
            {
                case BattleType.HighestLevel: title = new TextReportItem("Highest Level Battle", true); break;
                default: return;
            }
            VirtueType[] virtues = new VirtueType[] { VirtueType.Compassion, VirtueType.Honesty, VirtueType.Honor, VirtueType.Humility, VirtueType.Justice, VirtueType.Sacrifice, VirtueType.Spirituality, VirtueType.Valor };
            Dictionary<VirtueType, Dictionary<string, CityInfo>> palaces = new Dictionary<VirtueType, Dictionary<string, CityInfo>>();
            foreach (VirtueType v in virtues)
            {
                palaces.Add(v, new Dictionary<string, CityInfo>());
                string[] players = world.PalacesOwnersByVirtue(v);
                foreach (string p in players)
                {
                    PlayerInfo pl = world.Player(p);
                    pl.LoadIfNeeded();
                    foreach (CityInfo city in pl.Cities(ReportFeatureType.TypePalace, ReportFeatureType.BorderingLand, ReportFeatureType.BorderingWater))
                    {
                        city.LoadIfNeeded();
                        if (city.VirtueType == v)
                        {
                            if (!palaces[v].ContainsKey(pl.Alliance.Name))
                                palaces[v].Add(pl.Alliance.Name, city);
                            else if (city.PalaceLvl > palaces[v][pl.Alliance.Name].PalaceLvl || (city.PalaceLvl == palaces[v][pl.Alliance.Name].PalaceLvl && city.Score > palaces[v][pl.Alliance.Name].Score))
                                palaces[v][pl.Alliance.Name] = city;
                        }
                    }
                }
            }
            foreach (VirtueType v in virtues)
            {
                if (palaces[v].Count > 0)
                {
                    ReportItem r = new TextReportItem(v + " Palaces", true);

                    CityInfo[] cities = new CityInfo[palaces[v].Count];
                    int count = 0;
                    foreach (string a in palaces[v].Keys)
                        cities[count++] = palaces[v][a];
                    Array.Sort(cities, new PalaceComp());
                    Array.Reverse(cities);
                    int rank = 1;
                    foreach( CityInfo p in cities )
                    {
                        ReportItem r2 = new AllianceInfoReportItem(p.Player.Alliance, true, rank++);
                        r2.Items.Add(new DetailedPalaceInfoReportItem(p, true, true, false, true, true));
                        r.Items.Add(r2);
                    }
                    root.Add(r);
                }
            }
        }
    }
}
