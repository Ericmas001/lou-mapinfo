using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class CityTypeReportItem : ReportItem
    {
        private int m_Count;
        private CityCastleType m_Type;

        public CityTypeReportItem(int count, CityCastleType type, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Count = count;
            m_Type = type;
        }

        public override string Value(ReportOption options)
        {
            String s = "";
            if (m_Count == 0)
            {
                if (m_Type == CityCastleType.City || m_Type == CityCastleType.Both)
                    s = "No Castled City";
                else
                    s = "No Non-Castled City";
            }
            else
            {
                if ((options & ReportOption.CityCount) != 0)
                    s = m_Count + " ";

                if (m_Type == CityCastleType.City || m_Type == CityCastleType.Both)
                    s += "Cit" + (m_Count == 1 ? "y" : "ies");
                else
                    s += "Castle" + (m_Count == 1 ? "" : "s");
            }
            return s;
        }
    }
}
