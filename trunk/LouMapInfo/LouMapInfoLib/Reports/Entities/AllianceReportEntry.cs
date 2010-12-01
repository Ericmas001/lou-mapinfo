using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Entities
{
    public class AllianceReportEntry
    {
        public int AScore;
        public List<PlayerReportEntry> Players = new List<PlayerReportEntry>();
    }
}
