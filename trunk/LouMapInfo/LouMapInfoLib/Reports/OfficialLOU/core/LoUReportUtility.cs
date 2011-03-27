using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.Reports.OfficialLOU.core
{
    public static class LoUReportUtility
    {
        public static string SayCityType(params LoUCityType[] type)
        {
            return SayCityType(new List<LoUCityType>(type));
        }
        public static string SayCityType(List<LoUCityType> types)
        {
            if (types.Count == 0)
                return "No cities displayed";
            else if (types.Count == 1)
            {
                switch (types[0])
                {
                    case LoUCityType.City:
                        return "Non-Castled cities only";
                    case LoUCityType.Castle:
                        return "Castles only";
                    case LoUCityType.Palace:
                        return "Palaces only";
                }
            }
            else if (types.Count == 2)
            {
                if (!types.Contains(LoUCityType.City))
                    return "Non-Castled cities excluded";
                if (!types.Contains(LoUCityType.Castle))
                    return "Castles excluded";
                if (!types.Contains(LoUCityType.Palace))
                    return "Palaces excluded";
            }
            return "All cities displayed";
        }
    }
}
