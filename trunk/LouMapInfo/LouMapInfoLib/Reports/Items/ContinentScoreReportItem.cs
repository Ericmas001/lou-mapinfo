using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports.Items
{
    public class ContinentScoreReportItem : ReportItem
    {
        private bool m_IsPlayer; // True player, False alliance
        private int m_Score;
        private int m_C;

        public ContinentScoreReportItem(bool isDetailLine, int c, int score, bool isPlayer)
            : base(isDetailLine)
        {
            m_IsPlayer = isPlayer;
            m_C = c;
            m_Score = score;
        }

        public override string Value(ReportOption options)
        {
            string s = "C" + String.Format("{0:00}", m_C);
            if (m_Score >= 0 && ((m_IsPlayer && (options & ReportOption.PlayerScore) != 0) || (!m_IsPlayer && (options & ReportOption.AllianceScore) != 0)))
                s += String.Format(" ({0})", m_Score.ToString("N0"));
            return s;
        }
    }
}
