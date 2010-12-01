using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports.core
{
    public abstract class ReportItem
    {
        private List<ReportItem> m_Items = new List<ReportItem>();
        private bool m_ShowEmpty;

        public bool ShowEmpty
        {
            get { return m_ShowEmpty; }
            set { m_ShowEmpty = value; }
        }

        public List<ReportItem> Items
        {
            get { return m_Items; }
            set { m_Items = value; }
        }
        public ReportItem(bool showIfEmpty)
        {
            m_ShowEmpty = showIfEmpty;
        }
        public abstract string Value(ReportOption options);
    }
}
