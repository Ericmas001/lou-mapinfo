using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports.core
{
    public enum ReportOption
    {
        None = 0,
        CityCount = 1,
        CityScore = 2,
        CityName = 4,
        PlayerCount = 8,
        PlayerScore = 16,
        AllianceRank = 32,
        AllianceScore = 64,
    }
}
