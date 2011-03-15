using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities;

namespace LouMapInfo.Reports.Items
{
    public class CityInfoReportItem : ReportItem
    {
        protected CityInfo m_Info;

        public CityInfoReportItem(CityInfo info, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Info = info;
        }

        public override string Value(ReportOption options)
        {
            string s = String.Format("[city]{0}[/city]", m_Info.Location);
            if ((options & ReportOption.CityName) != 0)
                s += String.Format(" [name]{0}[/name]", m_Info.Name);
            if ((options & ReportOption.CityScore) != 0)
                s += String.Format(" ({0})", DisplayUtility.Score(m_Info.Score));
            return s;
        }
    }
}
