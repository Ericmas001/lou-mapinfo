using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports.core
{
    public abstract class ReportItem
    {
        private List<ReportItem> m_Items = new List<ReportItem>();
        private bool m_IsDetailLine;

        public bool IsDetailLine
        {
            get { return m_IsDetailLine; }
            set { m_IsDetailLine = value; }
        }

        public List<ReportItem> Items
        {
            get { return m_Items; }
            set { m_Items = value; }
        }
        public ReportItem(bool isDetailLine)
        {
            m_IsDetailLine = isDetailLine;
        }
        public abstract string Value(ReportOption options);
    }
}
