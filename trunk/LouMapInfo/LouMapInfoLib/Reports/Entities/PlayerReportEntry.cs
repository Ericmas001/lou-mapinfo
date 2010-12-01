using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Entities
{
    public class PlayerReportEntry
    {
        public string AName;
        public int AScore;
        public string PName;
        public int PScore;
        public List<CityInfo> Cities = new List<CityInfo>();
        public List<CityInfo> Castles = new List<CityInfo>();
    }
}
