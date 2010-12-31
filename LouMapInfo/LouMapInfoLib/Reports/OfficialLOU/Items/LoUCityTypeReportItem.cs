using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class LoUCityTypeReportItem : ReportItem
    {
        private int m_Count;
        private LoUCityType m_Type;

        public LoUCityTypeReportItem(int count, LoUCityType type, bool showIfEmpty)
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
                case LoUCityType.City:
                    name = "Non-Castled Cit" + (m_Count <= 1 ? "y" : "ies"); break;
                case LoUCityType.Castle:
                    name = "Castle" + (m_Count <= 1 ? "" : "s"); break;
                case LoUCityType.Palace:
                    name = "Palace" + (m_Count <= 1 ? "" : "s"); break;
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
