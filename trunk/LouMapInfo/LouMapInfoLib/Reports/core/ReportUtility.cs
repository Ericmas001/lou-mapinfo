using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.core
{
    public static class ReportUtility
    {
        public static string SayCityType(params CityType[] type)
        {
            return SayCityType(new List<CityType>(type));
        }
        public static string SayCityType(List<CityType> types)
        {
            if (types.Count == 0)
                return "No cities displayed";
            else if (types.Count == 1)
            {
                switch (types[0])
                {
                    case CityType.City:
                        return "Non-Castled cities only";
                    case CityType.Castle:
                        return "Castles only";
                    case CityType.Palace:
                        return "Palaces only";
                }
            }
            else if (types.Count == 2)
            {
                if (!types.Contains(CityType.City))
                    return "Non-Castled cities excluded";
                if (!types.Contains(CityType.Castle))
                    return "Castles excluded";
                if (!types.Contains(CityType.Palace))
                    return "Palaces excluded";
            }
            return "All cities displayed";
        }
    }
}
