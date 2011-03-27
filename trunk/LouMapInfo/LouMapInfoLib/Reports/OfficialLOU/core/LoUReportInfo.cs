using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.Items;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports.OfficialLOU.core
{
    //TODO: This is TEMPORARY
    public abstract class LoUReportInfo : ReportInfo
    {
        public LoUReportInfo(params LoUCityType[] type) : base()
        {
            List<LoUCityType> types = new List<LoUCityType>(type);
            if( types.Count == 0 )
                m_Type = CityCastleType.None;
            else if (types.Count == 1)
            {
                switch (types[0])
                {
                    case LoUCityType.City:
                        m_Type = CityCastleType.City; break;
                    case LoUCityType.Castle:
                    case LoUCityType.Palace:
                        m_Type = CityCastleType.Castle; break;
                }
            }
            else
            {
                if (types.Contains(LoUCityType.City))
                    m_Type = CityCastleType.Both;
                else
                    m_Type = CityCastleType.Castle;
            }
        }
        protected LoUCityType[] LoUType
        {
            get
            {
                switch (m_Type)
                {
                    case CityCastleType.None:
                        return new LoUCityType[0];
                    case CityCastleType.City:
                        return new LoUCityType[] { LoUCityType.City };
                    case CityCastleType.Castle:
                        return new LoUCityType[] { LoUCityType.Castle, LoUCityType.Palace };
                    case CityCastleType.Both:
                        return new LoUCityType[] {  LoUCityType.City, LoUCityType.Castle, LoUCityType.Palace };
                }
                return new LoUCityType[0];
            }
        }
    }
}
