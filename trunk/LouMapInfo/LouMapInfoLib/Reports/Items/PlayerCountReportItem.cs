using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports.Items
{
    public class PlayerCountReportItem : ReportItem
    {
        private int m_Count;

        public PlayerCountReportItem(int count, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Count = count;
        }

        public override string Value(ReportOption options)
        {
            string s2 = "";

            String s = "";
            if (m_Count == 0)
            {
                s = "No Player";
            }
            else
            {
                if ((options & ReportOption.PlayerCount) != 0)
                    s = m_Count + " ";
                s += "Player" + (m_Count == 1 ? "" : "s");
            }
            return s + s2;
        }
    }
}
