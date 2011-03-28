using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class PlayerInfoReportItem : ReportItem
    {
        private PlayerInfo m_Info;
        private int m_Continent;

        public PlayerInfoReportItem(PlayerInfo info, int cont, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Info = info;
            m_Continent = cont;
        }

        public override string Value(ReportOption options)
        {
            string s = String.Format("[player]{0}[/player]", m_Info.Name);

            int score = m_Continent == -1 ? m_Info.Score : m_Info.CScore(m_Continent);
            if ((options & ReportOption.PlayerScore) != 0)
                s += String.Format(" ([score]{0}[/score])", score.ToString("N0"));
            return s;
        }
    }
}
