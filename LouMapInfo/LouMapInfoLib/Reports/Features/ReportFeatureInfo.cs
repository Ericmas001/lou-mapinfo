using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports.Features
{

    public class ReportFeatureInfo
    {
        private ReportFeatureType m_Feature;

        public ReportFeatureType Feature
        {
            get { return m_Feature; }
            set { m_Feature = value; }
        }
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public ReportFeatureInfo(ReportFeatureType feature, string name)
        {
            m_Name = name;
            m_Feature = feature;
        }

        private static bool m_Loaded = false;
        private static Dictionary<ReportFeatureType, ReportFeatureInfo> m_Features = new Dictionary<ReportFeatureType, ReportFeatureInfo>();

        private static ReportFeatureInfo[] all = new ReportFeatureInfo[]{

            new ReportFeatureInfo(ReportFeatureType.BorderingLand, "LandLocked"),
            new ReportFeatureInfo(ReportFeatureType.BorderingWater, "WaterBased"),
            new ReportFeatureInfo(ReportFeatureType.NoAlliance, "Players with no alliance"),
            new ReportFeatureInfo(ReportFeatureType.NoCities, "Players with no cities"),
            new ReportFeatureInfo(ReportFeatureType.TypeCastle, "Castles"),
            new ReportFeatureInfo(ReportFeatureType.TypeCity, "Cities"),
            new ReportFeatureInfo(ReportFeatureType.TypePalace, "Palaces"),
        };

        public static Dictionary<ReportFeatureType, ReportFeatureInfo> Features
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return ReportFeatureInfo.m_Features;
            }
        }
        private static void Load()
        {
            foreach (ReportFeatureInfo info in all)
            {
                m_Features.Add(info.m_Feature, info);
            }
        }

    }
}
