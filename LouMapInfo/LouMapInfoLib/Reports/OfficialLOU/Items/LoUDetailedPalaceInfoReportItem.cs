using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class LoUDetailedPalaceInfoReportItem : LoUDetailedCityInfoReportItem
    {
        private bool m_Showlvl;

        public LoUDetailedPalaceInfoReportItem(LoUCityInfo info, bool showIfEmpty, bool showPlayer, bool showAlliance, bool showContinent, bool showPalacelvl)
            : base(info, showIfEmpty, showPlayer, showAlliance, showContinent)
        {
            m_Showlvl = showPalacelvl;
        }

        public override string Value(ReportOption options)
        {
            string s = base.Value(options);
            if (m_Showlvl)
                s = String.Format("Palace lvl {0}{1}", m_Info.PalaceLvl, m_ShowCont ? " on " : ": ");
            return s + base.Value(options);
        }
    }
}
