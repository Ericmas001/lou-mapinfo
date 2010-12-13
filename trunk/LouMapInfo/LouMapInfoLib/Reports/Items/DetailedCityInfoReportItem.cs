using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class DetailedCityInfoReportItem : CityInfoReportItem
    {
        private PlayerInfo m_PInfo;
        private AllianceInfo m_AInfo;

        public DetailedCityInfoReportItem(CityInfo info, bool showIfEmpty, PlayerInfo p, AllianceInfo a)
            : base(info, showIfEmpty)
        {
            m_PInfo = p;
            m_AInfo = a;
        }

        public override string Value(ReportOption options)
        {
            string s = base.Value(options);
            if (m_PInfo.Name != PlayerInfo.LAWLESS)
                s += ", " + new PlayerInfoReportItem(m_PInfo, true).Value(options);
            if (m_AInfo.Name != AllianceInfo.NO_ALLIANCE)
                s += ", " + new AllianceInfoReportItem(m_AInfo,-1, true).Value(options);
            return s;
        }
    }
}
