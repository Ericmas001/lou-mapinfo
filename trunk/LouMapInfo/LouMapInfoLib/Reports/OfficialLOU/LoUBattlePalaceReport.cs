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
    public class LoUBattlePalaceReport : LoUReportInfo
    {
        private LoUWorldInfo world;
        private LoUBattleType type;
        public LoUBattlePalaceReport(LoUWorldInfo w, LoUBattleType b)
            : base(LoUCityType.CityCastlePalace)
        {
            this.world = w;
            this.type = b;
            LoadIfNeeded();
        }

        protected override int depth
        {
            get { return 2; }
        }


        class PalaceComp : IComparer<LoUCityInfo>
        {
            public PalaceComp()
            {
            }
            #region IComparer<LoUPlayerInfo> Members

            public int Compare(LoUCityInfo x, LoUCityInfo y)
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
                case LoUBattleType.HighestLevel: title = new TextReportItem("Highest Level Battle", true); break;
                default: return;
            }
            LoUVirtue[] virtues = new LoUVirtue[] { LoUVirtue.Compassion, LoUVirtue.Honesty, LoUVirtue.Honor, LoUVirtue.Humility, LoUVirtue.Justice, LoUVirtue.Sacrifice, LoUVirtue.Spirituality, LoUVirtue.Valor };
            Dictionary<LoUVirtue, Dictionary<string, LoUCityInfo>> palaces = new Dictionary<LoUVirtue, Dictionary<string, LoUCityInfo>>();
            foreach (LoUVirtue v in virtues)
            {
                palaces.Add(v, new Dictionary<string, LoUCityInfo>());
                string[] players = world.PalacesOwnersByVirtue(v);
                foreach (string p in players)
                {
                    LoUPlayerInfo pl = world.Player(p);
                    pl.LoadIfNeeded();
                    foreach (LoUCityInfo city in pl.Cities(LoUCityType.Palace))
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
            foreach (LoUVirtue v in virtues)
            {
                if (palaces[v].Count > 0)
                {
                    ReportItem r = new TextReportItem(v + " Palaces", true);

                    LoUCityInfo[] cities = new LoUCityInfo[palaces[v].Count];
                    int count = 0;
                    foreach (string a in palaces[v].Keys)
                        cities[count++] = palaces[v][a];
                    Array.Sort(cities, new PalaceComp());
                    Array.Reverse(cities);
                    int rank = 1;
                    foreach( LoUCityInfo p in cities )
                    {
                        ReportItem r2 = new LoUAllianceInfoReportItem(p.Player.Alliance, true, rank++);
                        r2.Items.Add(new LoUDetailedPalaceInfoReportItem(p, true, true, false, true, true));
                        r.Items.Add(r2);
                    }
                    root.Add(r);
                }
            }
        }
    }
}
