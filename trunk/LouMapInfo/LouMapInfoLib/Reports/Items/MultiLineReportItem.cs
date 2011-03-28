using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports.Items
{
    public class MultiLineReportItem : ReportItem
    {
        private List<ReportItem> m_Lines = new List<ReportItem>();

        public List<ReportItem> Lines
        {
            get { return m_Lines; }
            set { m_Lines = value; }
        }

        public MultiLineReportItem(bool showIfEmpty, params ReportItem[] items)
            : base(showIfEmpty)
        {
            m_Lines.AddRange(items);
        }

        public override string Value(ReportOption options)
        {
            String s = "";
            for (int i = 0; i < m_Lines.Count; ++i)
            {
                if (i > 0)
                    s += "\n";
                s += m_Lines[i].Value(options);
            }
            return s;
        }
    }
}
