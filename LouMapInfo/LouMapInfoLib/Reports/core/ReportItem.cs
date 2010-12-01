using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports.core
{
    public class ReportItem
    {
        private string m_Text;
        private List<ReportItem> m_Items = new List<ReportItem>();
        private bool m_ShowEmpty;

        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        public List<ReportItem> Items
        {
            get { return m_Items; }
            set { m_Items = value; }
        }

        public bool ShowEmpty
        {
            get { return m_ShowEmpty; }
            set { m_ShowEmpty = value; }
        }

        public ReportItem(string text, bool showIfEmpty)
        {
            m_Text = text;
            m_ShowEmpty = showIfEmpty;
        }
    }
}
