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
    public class LoULawlessReport : LoUReportInfo
    {
        private Dictionary<int, LoUCityInfo[]> allLawless;
        public LoULawlessReport(Dictionary<int, LoUCityInfo[]> l, OldLoUCityType type)
            : base(type)
        {
            allLawless = l;
            LoadIfNeeded();
        }
        protected override void OnLoad()
        {
            title = new TextReportItem("Lawless Report", true);
            subtitle = new TextReportItem(LoUReportUtility.SayCityType(LoUType), true); 

            foreach( int ic in allLawless.Keys )
            {
                LoUCityInfo[] cities = allLawless[ic];
                ReportItem r = new ContinentScoreReportItem(ic, -1, false, false);

                
                //First castles
                if (m_Type == CityCastleType.Both || m_Type == CityCastleType.Castle)
                {
                    List<LoUCityInfo> correct = new List<LoUCityInfo>();
                    LoUCityTypeReportItem r2 = new LoUCityTypeReportItem(0, OldLoUCityType.Castle, true);
                    foreach( LoUCityInfo c in cities )
                    {
                        if( c.TypeCity == OldLoUCityType.Castle )
                            r2.Items.Add(new LoUCityInfoReportItem(c, true));
                    }
                    r2.setCountAsItemCount();
                    r.Items.Add(r2);
                }

                //Then non-castled cities
                if (m_Type == CityCastleType.Both || m_Type == CityCastleType.City)
                {
                    List<LoUCityInfo> correct = new List<LoUCityInfo>();
                    LoUCityTypeReportItem r2 = new LoUCityTypeReportItem(0, OldLoUCityType.City, true);
                    foreach( LoUCityInfo c in cities )
                    {
                        if( c.TypeCity == OldLoUCityType.City )
                            r2.Items.Add(new LoUCityInfoReportItem(c, true));
                    }
                    r2.setCountAsItemCount();
                    r.Items.Add(r2);
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
