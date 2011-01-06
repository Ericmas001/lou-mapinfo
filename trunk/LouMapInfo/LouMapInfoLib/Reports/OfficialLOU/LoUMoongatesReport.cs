using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.Items;
using LouMapInfo.Reports.OfficialLOU.core;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU.Items;

namespace LouMapInfo.Reports.OfficialLOU
{
    public class LoUMoongatesReport : LoUReportInfo
    {
        private Dictionary<int, LoUMoonGateInfo[]> allGates;
        public LoUMoongatesReport(Dictionary<int, LoUMoonGateInfo[]> l)
            : base(OldLoUCityType.None)
        {
            allGates = l;
            LoadIfNeeded();
        }
        protected override void OnLoad()
        {
            title = new TextReportItem("Moongates Location", true);

            foreach (int ic in allGates.Keys)
            {
                ReportItem r = new ContinentScoreReportItem(ic, -1, false, false);
                foreach (LoUMoonGateInfo mg in allGates[ic])
                {
                    r.Items.Add(new TextReportItem(mg.ToString(),true));
                }
                root.Add(r);
            }
        }

        protected override int depth
        {
            get { return 2; }
        }
    }
}
