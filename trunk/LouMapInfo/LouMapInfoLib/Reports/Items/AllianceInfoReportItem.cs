using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class AllianceInfoReportItem : ReportItem
    {
        private AllianceInfo m_Info;
        private int m_Rank;

        public AllianceInfoReportItem(AllianceInfo info, int rank, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Info = info;
            m_Rank = rank;
        }

        public override string Value(ReportOption options)
        {
            if (m_Info.Name == AllianceInfo.NO_ALLIANCE)
                return m_Info.Name;
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
