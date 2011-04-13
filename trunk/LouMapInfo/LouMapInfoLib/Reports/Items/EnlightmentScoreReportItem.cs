using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;
using LouMapInfo;

namespace LouMapInfo.Reports.Items
{
    public class EnlightmentScoreReportItem : ReportItem
    {
        private int m_Score;
        private CityType m_Type;
        private BorderingType m_Border;
        private VirtueType m_Virtue;

        public EnlightmentScoreReportItem(bool isDetailLine, CityType type, BorderingType border, VirtueType virtue, int score)
            : base(isDetailLine)
        {
            m_Type = type;
            m_Border = border;
            m_Score = score;
            m_Virtue = virtue;
        }

        public override string Value(ReportOption options)
        {
            
            String s = "          " + new CityTypeReportItem(IsDetailLine,-1,m_Type,m_Border,m_Virtue).Value(options);
            s += ", Enlightment Score: " + m_Score.ToString("N0");
            return s;
        }
    }
}
