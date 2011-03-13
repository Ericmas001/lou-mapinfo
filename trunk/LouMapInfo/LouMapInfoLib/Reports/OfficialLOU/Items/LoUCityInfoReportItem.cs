using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class LoUCityInfoReportItem : ReportItem
    {
        private LoUCityInfo m_Info;
        private bool m_Extended;

        public LoUCityInfoReportItem(LoUCityInfo info, bool extended, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Info = info;
            m_Extended = extended;
        }

        public LoUCityInfoReportItem(LoUCityInfo info, bool showIfEmpty)
            : this(info, false, showIfEmpty)
        {
        }

        public override string Value(ReportOption options)
        {
            string s = String.Format("[city]{0}[/city]", m_Info.Location);
            if ((options & ReportOption.CityName) != 0)
                s += String.Format(" [name]{0}[/name]", m_Info.Name);
            if ((options & ReportOption.CityScore) != 0)
                s += String.Format(" ([score]{0}[/score])", m_Info.Score.ToString("N0"));
            if (m_Extended)
            {
                string p = new LoUPlayerInfoReportItem(m_Info.Player, -1, true).Value(options);
                string a = new LoUAllianceInfoReportItem(m_Info.Player.Alliance, true).Value(options);
                s += ", " + p + ", " + a;
            }
            return s;
        }
    }
}
