using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class DetailedPalaceInfoReportItem : DetailedCityInfoReportItem
    {
        private bool m_Showlvl;

        public DetailedPalaceInfoReportItem(CityInfo info, bool showIfEmpty, bool showPlayer, bool showAlliance, bool showContinent, bool showPalacelvl)
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
