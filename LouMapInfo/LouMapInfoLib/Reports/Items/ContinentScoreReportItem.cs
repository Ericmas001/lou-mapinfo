using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class ContinentScoreReportItem : ReportItem
    {
        private bool m_IsPlayer; // True player, False alliance
        private int m_Score;
        private int m_C;

        public ContinentScoreReportItem(int c, int score, bool isPlayer, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_IsPlayer = isPlayer;
            m_C = c;
            m_Score = score;
        }

        public override string Value(ReportOption options)
        {
            string s = "C" + String.Format("{0:00}", m_C);
            if ((m_IsPlayer && (options & ReportOption.PlayerScore) != 0) || (!m_IsPlayer && (options & ReportOption.AllianceScore) != 0))
                s += String.Format(" ({0})", DisplayUtility.Score(m_Score));
            return s;
        }
    }
}
