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
        public LoUReportInfo(LoUCityType type) : base()
        {
            switch (type)
            {
                case LoUCityType.None:
                    m_Type = CityCastleType.None; break;
                case LoUCityType.City:
                    m_Type = CityCastleType.City; break;
                case LoUCityType.Castle:
                case LoUCityType.Palace:
                case LoUCityType.CastlePalace:
                    m_Type = CityCastleType.Castle; break;
                case LoUCityType.CityPalace:
                case LoUCityType.CityCastle:
                case LoUCityType.CityCastlePalace:
                    m_Type = CityCastleType.Both; break;
            }

        }
        protected LoUCityType LoUType
        {
            get
            {
                switch (m_Type)
                {
                    case CityCastleType.None:
                        return LoUCityType.None;
                    case CityCastleType.City:
                        return LoUCityType.City;
                    case CityCastleType.Castle:
                        return LoUCityType.CastlePalace;
                    case CityCastleType.Both:
                        return LoUCityType.CityCastlePalace;
                }
                return LoUCityType.None;
            }
        }
    }
}
