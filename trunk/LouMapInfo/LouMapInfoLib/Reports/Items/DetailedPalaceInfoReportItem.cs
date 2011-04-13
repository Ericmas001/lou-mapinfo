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
        private bool m_ShowType;

        public DetailedPalaceInfoReportItem(bool isDetailLine, CityInfo info, bool showPlayer, bool showAlliance, bool showContinent, bool showPalacelvl, bool showPalaceType)
            : base(isDetailLine, info, showPlayer, showAlliance, showContinent)
        {
            m_Showlvl = showPalacelvl;
            m_ShowType = showPalaceType;
        }

        public override string Value(ReportOption options)
        {
            string s = base.Value(options);
            string type = m_ShowType && (options & ReportOption.PalaceVirtue) != 0 ? (m_Info.VirtueType + " ") : "";
            if (m_Showlvl)
                s = type + "Palace" + ((options & ReportOption.PalaceLevel) != 0 ? " lvl " + m_Info.PalaceLvl : "") + (m_ShowCont ? " on " : ": ");
            return s + base.Value(options);
        }
    }
}
