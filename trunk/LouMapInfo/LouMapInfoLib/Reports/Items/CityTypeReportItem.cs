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
        private BorderingType m_Border;

        public CityTypeReportItem(bool isDetailLine, int count, CityType type, BorderingType border, VirtueType virtue)
            : base(isDetailLine)
        {
            m_Count = count;
            m_Type = type;
            m_Virtue = virtue;
            m_Border = border;
        }
        public CityTypeReportItem(bool isDetailLine, int count, CityType type, VirtueType virtue)
            : this(isDetailLine, count, type, BorderingType.Unknown, virtue)
        {
        }
        public CityTypeReportItem(bool isDetailLine, int count, CityType type, BorderingType border)
            : this(isDetailLine, count, type, border, VirtueType.None)
        {
        }

        public CityTypeReportItem(bool isDetailLine, int count, CityType type)
            : this(isDetailLine, count, type, BorderingType.Unknown, VirtueType.None)
        {
        }

        public void setCountAsItemCount()
        {
            m_Count = Items.Count;
        }

        public override string Value(ReportOption options)
        {
            String name = "";

            if (m_Border == BorderingType.Land)
                name = "Land ";
            else if (m_Border == BorderingType.Water)
                name = "Water ";

            switch (m_Type)
            {
                case CityType.City:
                    name = name + "Non-Castled Cit" + (m_Count <= 1 ? "y" : "ies"); break;
                case CityType.Castle:
                    name = name + "Castle" + (m_Count <= 1 ? "" : "s"); break;
                case CityType.Palace:
                    name = name + (m_Virtue != VirtueType.None && (options & ReportOption.PalaceVirtue) != 0 ? m_Virtue + " " : "" ) + "Palace" + (m_Count <= 1 ? "" : "s"); break;
            }

            String s = "";
            if (m_Count == 0)
            {
                s = "No " + name;
            }
            else
            {
                if (m_Count > 0 && (options & ReportOption.CityCount) != 0)
                    s = m_Count + " ";

                s += name;
            }
            return s;
        }
    }
}
