using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.core
{
    public static class LoUReportUtility
    {
        public static string SayCityType(OldLoUCityType type)
        {
            switch (type)
            {
                case OldLoUCityType.None:
                    return "No cities displayed";
                case OldLoUCityType.City:
                    return "Non-Castled cities only";
                case OldLoUCityType.Castle:
                    return "Castles only";
                case OldLoUCityType.Palace:
                    return "Palaces only";
                case OldLoUCityType.CastlePalace:
                    return "Non-Castled cities excluded";
                case OldLoUCityType.CityPalace:
                    return "Castles excluded";
                case OldLoUCityType.CityCastle:
                    return "Palaces excluded";
                case OldLoUCityType.CityCastlePalace:
                    return "All cities displayed";
            }
            return null;
        }
    }
}
