using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo;

namespace LouMapInfo.Reports.Items
{
    public class CityTypeReportItem : ReportItem
    {
        private int m_Count;
        private CityType m_Type;
        private VirtueType m_Virtue;

        public CityTypeReportItem(int count, CityType type, VirtueType virtue, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Count = count;
            m_Type = type;
            m_Virtue = virtue;
        }

        public CityTypeReportItem(int count, CityType type, bool showIfEmpty)
            : this( count,  type, VirtueType.None, showIfEmpty)
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
                case CityType.City:
                    name = "Non-Castled Cit" + (m_Count <= 1 ? "y" : "ies"); break;
                case CityType.Castle:
                    name = "Castle" + (m_Count <= 1 ? "" : "s"); break;
                case CityType.Palace:
                    name = (m_Virtue != VirtueType.None ? m_Virtue + " " : "" ) + "Palace" + (m_Count <= 1 ? "" : "s"); break;
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
