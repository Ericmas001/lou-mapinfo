using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Entities
{
    public class PlayerReportRoot
    {
        public string AName;
        public int AScore;
        public string PName;
        public int PScore;
        public Dictionary<int, PlayerReportEntry> Continents = new Dictionary<int, PlayerReportEntry>();
    }
}
