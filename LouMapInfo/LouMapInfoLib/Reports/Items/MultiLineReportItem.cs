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

        public MultiLineReportItem(bool isDetailLine, params ReportItem[] items)
            : base(isDetailLine)
        {
            m_Lines.AddRange(items);
        }

        public MultiLineReportItem(bool isDetailLine, params string[] items)
            : base(isDetailLine)
        {
            foreach (string s in items)
                m_Lines.Add(new TextReportItem(isDetailLine, s));
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
