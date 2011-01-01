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
        public LoUReportInfo(OldLoUCityType type) : base()
        {
            switch (type)
            {
                case OldLoUCityType.None:
                    m_Type = CityCastleType.None; break;
                case OldLoUCityType.City:
                    m_Type = CityCastleType.City; break;
                case OldLoUCityType.Castle:
                case OldLoUCityType.Palace:
                case OldLoUCityType.CastlePalace:
                    m_Type = CityCastleType.Castle; break;
                case OldLoUCityType.CityPalace:
                case OldLoUCityType.CityCastle:
                case OldLoUCityType.CityCastlePalace:
                    m_Type = CityCastleType.Both; break;
            }

        }
        protected OldLoUCityType LoUType
        {
            get
            {
                switch (m_Type)
                {
                    case CityCastleType.None:
                        return OldLoUCityType.None;
                    case CityCastleType.City:
                        return OldLoUCityType.City;
                    case CityCastleType.Castle:
                        return OldLoUCityType.CastlePalace;
                    case CityCastleType.Both:
                        return OldLoUCityType.CityCastlePalace;
                }
                return OldLoUCityType.None;
            }
        }
    }
}
