using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Reports.core
{
    public abstract class ReportInfo
    {
        protected abstract int depth { get; }
        protected string title;
        protected string subtitle = null;
        protected List<ReportItem> root = new List<ReportItem>();
        public Dictionary<string, bool> BBCodeDisplay = new Dictionary<string, bool>();

        public ReportInfo()
        {
            BBCodeDisplay.Add("b", true);
            BBCodeDisplay.Add("i", true);
            BBCodeDisplay.Add("s", true);
            BBCodeDisplay.Add("u", true);
            BBCodeDisplay.Add("url", true);
            BBCodeDisplay.Add("city", false);
            BBCodeDisplay.Add("player", true);
            BBCodeDisplay.Add("alliance", true);
        }

        public string Report(int d)
        {
            String report = String.Format("<center><h1>{0}</h1></center>", title);
            if (!String.IsNullOrEmpty(subtitle))
                report += String.Format("<center><h2>{0}</h2></center>", subtitle);
            foreach (ReportItem it1 in root)
            {
                if (it1.ShowEmpty || it1.Items.Count > 0)
                {
                    report += "<hr />";
                    if (!String.IsNullOrEmpty(it1.Text))
                        report += String.Format("<center><h3>{0}</h3></center>", it1.Text);
                    report += "<ul>";
                    foreach (ReportItem it2 in it1.Items)
                    {
                        if (it2.ShowEmpty || it2.Items.Count > 0 || d == 1)
                        {
                            if (!String.IsNullOrEmpty(it2.Text))
                                report += String.Format("<li>{0}</li>", it2.Text);
                            if (d > 1 && it2.Items.Count > 0)
                            {
                                report += "<ul>";
                                foreach (ReportItem it3 in it2.Items)
                                {
                                    if (it3.ShowEmpty || it3.Items.Count > 0 || d == 2)
                                    {
                                        report += String.Format("<li>{0}</li>", it3.Text);
                                        if (d > 2 && it3.Items.Count > 0)
                                        {
                                            report += "<ul>";
                                            foreach (ReportItem it4 in it3.Items)
                                            {
                                                report += String.Format("<li>{0}</li>", it4.Text);
                                            }
                                            report += "</ul>";
                                        }
                                    }
                                }
                                report += "</ul>";
                            }

                        }
                    }
                    report += "</ul>";
                }
            }
            return ReportText(report);
        }

        public string BBCode(int d)
        {
            String report = String.Format("[b][u]{0}[/b][/u]\n", title);
            if (!String.IsNullOrEmpty(subtitle))
                report += String.Format("[b]{0}[b]\n", subtitle);
            report += "\n";
            foreach (ReportItem it1 in root)
            {
                if (it1.ShowEmpty || it1.Items.Count > 0)
                {
                    report += "[hr]\n";
                    if (!String.IsNullOrEmpty(it1.Text))
                        report += String.Format("[b]{0}[/b]", it1.Text);
                    if (it1.Items.Count > 0)
                        report += "\n";

                    foreach (ReportItem it2 in it1.Items)
                    {
                        if (it2.ShowEmpty || it2.Items.Count > 0 || d == 1)
                        {
                            if (d > 1 && it2.Items.Count > 0)
                                report += "\n";
                            if (!String.IsNullOrEmpty(it2.Text))
                                report += String.Format("{0}\n", it2.Text);
                            if (d > 1 && it2.Items.Count > 0)
                            {
                                foreach (ReportItem it3 in it2.Items)
                                {
                                    if (it3.ShowEmpty || it3.Items.Count > 0 || d == 2)
                                    {
                                        report += String.Format("{0}\n", it3.Text);
                                        if (d > 2 && it3.Items.Count > 0)
                                        {
                                            foreach (ReportItem it4 in it3.Items)
                                            {
                                                report += String.Format("{0}\n", it4.Text);
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            return BBCodeText(report);
        }

        public string Title
        {
            get { return title; }
        }

        public string SubTitle
        {
            get { return subtitle; }
        }

        public string ReportText(string s)
        {
            return s
                .Replace("\n", "<br />")
                .Replace("[city]", "<b>")
                .Replace("[/city]", "</b>")
                .Replace("[name]", "<i>")
                .Replace("[/name]", "</i>")
                .Replace("[score]", "")
                .Replace("[/score]", "")
                .Replace("[alliance]", "<b>")
                .Replace("[/alliance]", "</b>")
                .Replace("[player]", "<b>")
                .Replace("[/player]", "</b>")
                ;
        }

        public string BBCodeText(string s)
        {
            string res = s
                .Replace("\n", Environment.NewLine)
                .Replace("[name]", "[i]")
                .Replace("[/name]", "[/i]")
                .Replace("[score]", "")
                .Replace("[/score]", "")
                ;
            foreach (string b in BBCodeDisplay.Keys)
                if (!BBCodeDisplay[b])
                    res = res
                        .Replace("["+b+"]", "")
                        .Replace("[/" + b + "]", "");
            return res;
        }
    }
}
