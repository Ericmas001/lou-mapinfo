using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class PlayerCountReportItem : ReportItem
    {
        private int m_Count;
        private CityCastleType m_Type;

        public PlayerCountReportItem(int count, CityCastleType type, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Count = count;
            m_Type = type;
        }

        public override string Value(ReportOption options)
        {
            string s2 = "";
            if (m_Type == CityCastleType.City)
                s2 = " with non-castled cities";
            else if (m_Type == CityCastleType.Castle)
                s2 = " with castled cities";

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
