using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class BorderingTypeReportItem : ReportItem
    {
        private int m_Count;
        private BorderingType m_Type;

        public BorderingTypeReportItem(int count, BorderingType type, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Count = count;
            m_Type = type;
        }

        public override string Value(ReportOption options)
        {
            String name = "";
            switch (m_Type)
            {
                case BorderingType.Land:
                    name = "Land-Locked"; break;
                case BorderingType.Water:
                    name = "Water-Based"; break;
            }

            String s = "";
            if (m_Count == 0)
            {
                s = "No " + name;
            }
            else
            {
                if ((options & ReportOption.CityCount) != 0)
                    s = m_Count + " ";

                s += name;
            }
            return s;
        }
    }
}
