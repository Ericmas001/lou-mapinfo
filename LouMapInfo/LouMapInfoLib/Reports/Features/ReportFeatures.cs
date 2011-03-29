using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Features
{
    public class ReportFeatures
    {
        private List<ReportFeatureType> m_Features = new List<ReportFeatureType>();

        public List<ReportFeatureType> Features
        {
            get { return m_Features; }
            set { m_Features = value; }
        }
        public ReportFeatures(params ReportFeatureType[] features)
        {
            m_Features.AddRange(features);
        }
        public static ReportFeatureType Feature(CityType type)
        {
            if (type == CityType.City)
                return ReportFeatureType.TypeCity;
            else if (type == CityType.Castle)
                return ReportFeatureType.TypeCastle;
            else
                return ReportFeatureType.TypePalace;
        }
    }
}
