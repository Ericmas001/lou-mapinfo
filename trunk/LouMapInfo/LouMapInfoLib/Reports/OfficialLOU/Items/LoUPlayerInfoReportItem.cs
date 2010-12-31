using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class LoUPlayerInfoReportItem : ReportItem
    {
        private LoUPlayerInfo m_Info;

        public LoUPlayerInfoReportItem(LoUPlayerInfo info, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Info = info;
        }

        public override string Value(ReportOption options)
        {
            string s = String.Format("[player]{0}[/player]", m_Info.Name);
            if ((options & ReportOption.PlayerScore) != 0)
                s += String.Format(" ([score]{0}[/score])", m_Info.Score.ToString("N0"));
            return s;
        }
    }
}
