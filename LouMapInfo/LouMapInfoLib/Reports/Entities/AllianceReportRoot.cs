using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports.Entities
{
    public class AllianceReportRoot
    {
        public string AName;
        public int AScore;
        public Dictionary<int, AllianceReportEntry> Continents = new Dictionary<int, AllianceReportEntry>();
    }
}
