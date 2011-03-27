using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.core
{
    public static class LoUReportUtility
    {
        public static string SayCityType(LoUCityType type)
        {
            switch (type)
            {
                case LoUCityType.None:
                    return "No cities displayed";
                case LoUCityType.City:
                    return "Non-Castled cities only";
                case LoUCityType.Castle:
                    return "Castles only";
                case LoUCityType.Palace:
                    return "Palaces only";
                case LoUCityType.CastlePalace:
                    return "Non-Castled cities excluded";
                case LoUCityType.CityPalace:
                    return "Castles excluded";
                case LoUCityType.CityCastle:
                    return "Palaces excluded";
                case LoUCityType.CityCastlePalace:
                    return "All cities displayed";
            }
            return null;
        }
    }
}
