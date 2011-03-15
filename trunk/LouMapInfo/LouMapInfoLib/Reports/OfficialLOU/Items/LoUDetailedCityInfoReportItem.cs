using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class LoUDetailedCityInfoReportItem : LoUCityInfoReportItem
    {
        private bool m_PInfo;
        private bool m_AInfo;
        private bool m_ShowCont;

        public LoUDetailedCityInfoReportItem(LoUCityInfo info, bool showIfEmpty, bool showPlayer, bool showAlliance, bool showContinent)
            : base(info, showIfEmpty)
        {
            m_PInfo = showPlayer;
            m_AInfo = showAlliance;
            m_ShowCont = showContinent;
        }

        public override string Value(ReportOption options)
        {
            string s = base.Value(options);
            if (m_ShowCont)
                s = String.Format("C{0:00}: {1}", m_Info.Location.Continent,s);
            if (m_PInfo && m_Info.Player.Name != PlayerInfo.LAWLESS)
                s += ", " + new LoUPlayerInfoReportItem(m_Info.Player, -1, true).Value(options);
            if (m_AInfo && m_Info.Player.Alliance.Name != AllianceInfo.NO_ALLIANCE)
                s += ", " + new LoUAllianceInfoReportItem(m_Info.Player.Alliance, true).Value(options);
            return s;
        }
    }
}
