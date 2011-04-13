using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Reports.Items
{
    public class TextReportItem : ReportItem
    {
        private string m_Text;
        
        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        public TextReportItem(bool isDetailLine, string text)
            : base(isDetailLine)
        {
            m_Text = text;
        }

        public override string Value(ReportOption options)
        {
            return m_Text;
        }
    }
}
