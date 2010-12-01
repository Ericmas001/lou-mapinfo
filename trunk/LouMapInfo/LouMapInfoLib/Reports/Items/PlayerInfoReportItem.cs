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

        public PlayerInfoReportItem(PlayerInfo info, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Info = info;
        }

        public override string Value(ReportOption options)
        {
            string s = String.Format("[player]{0}[/player]", m_Info.Name);
            if ((options & ReportOption.PlayerScore) != 0)
                s += String.Format(" ({0})", DisplayUtility.Score(m_Info.Score));
            return s;
        }
    }
}
