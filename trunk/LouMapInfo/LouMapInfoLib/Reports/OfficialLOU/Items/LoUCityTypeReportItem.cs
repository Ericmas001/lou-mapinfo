using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.OfficialLOU;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class LoUCityTypeReportItem : ReportItem
    {
        private int m_Count;
        private OldLoUCityType m_Type;
        private LoUVirtue m_Virtue;

        public LoUCityTypeReportItem(int count, OldLoUCityType type, LoUVirtue virtue, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Count = count;
            m_Type = type;
            m_Virtue = virtue;
        }

        public LoUCityTypeReportItem(int count, OldLoUCityType type, bool showIfEmpty)
            : this( count,  type, LoUVirtue.None, showIfEmpty)
        {
        }

        public void setCountAsItemCount()
        {
            m_Count = Items.Count;
        }

        public override string Value(ReportOption options)
        {
            String name = "";
            switch (m_Type)
            {
                case OldLoUCityType.City:
                    name = "Non-Castled Cit" + (m_Count <= 1 ? "y" : "ies"); break;
                case OldLoUCityType.Castle:
                    name = "Castle" + (m_Count <= 1 ? "" : "s"); break;
                case OldLoUCityType.Palace:
                    name = (m_Virtue != LoUVirtue.None ? m_Virtue + " " : "" ) + "Palace" + (m_Count <= 1 ? "" : "s"); break;
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
