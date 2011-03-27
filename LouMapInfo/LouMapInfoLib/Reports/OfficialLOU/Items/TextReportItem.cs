using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports.OfficialLOU.Items
{
    public class TextReportItem : ReportItem
    {
        private string m_Text;
        
        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        public TextReportItem(string text, bool showIfEmpty)
            : base(showIfEmpty)
        {
            m_Text = text;
        }

        public override string Value(ReportOption options)
        {
            return m_Text;
        }
    }
}
