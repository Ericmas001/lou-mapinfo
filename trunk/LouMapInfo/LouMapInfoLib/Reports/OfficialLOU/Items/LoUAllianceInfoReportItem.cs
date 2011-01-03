using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class LoUAllianceInfoReportItem : ReportItem
    {
        private LoUAllianceInfo m_Info;
        private int m_Rank = -1;

        public LoUAllianceInfoReportItem(LoUAllianceInfo info, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Info = info;
        }
        public LoUAllianceInfoReportItem(LoUAllianceInfo info, bool showIfEmpty, int rank)
            : this(info, showIfEmpty)
        {
            m_Rank = rank;
        }

        public override string Value(ReportOption options)
        {
            if (m_Info.Name == "")
                return "Not in an alliance";
            string s = "";
            if (m_Rank > 0 && (options & ReportOption.AllianceRank) != 0)
                s += String.Format("#{0:00} : ", m_Rank);
            s += String.Format(" [alliance]{0}[/alliance]", m_Info.Name);
            if ((options & ReportOption.AllianceScore) != 0)
                s += String.Format(" ({0})", DisplayUtility.Score(m_Info.Score));
            return s;
        }
    }
}
