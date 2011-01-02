using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;
using EricUtility;

namespace LouMapInfo.Reports.core
{
    public abstract class ReportInfo : AbstractLoadingTuple
    {
        private ReportOption options = ReportOption.None;
        protected abstract int depth { get; }
        protected ReportItem title;
        protected ReportItem subtitle = null;
        protected List<ReportItem> root = new List<ReportItem>();
        public Dictionary<string, bool> BBCodeDisplay = new Dictionary<string, bool>();
        protected CityCastleType m_Type;

        public ReportOption Options
        {
            get { return options; }
        }

        public void SetOption(ReportOption o, bool value)
        {
            if (value)
                options |= o;
            else
                options &= ~o;
        }

        public CityCastleType Type
        {
            get { return m_Type; }
            set
            {
                if (m_Type != value)
                {
                    m_Type = value;
                    title = null;
                    subtitle = null;
                    root = new List<ReportItem>();
                    ForceLoad();
                }
            }
        }

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

        public ReportInfo(CityCastleType type) : this()
        {
            m_Type = type;
        }

        public string Report(int d)
        {
            String report = "";
            if (title != null && !String.IsNullOrEmpty(title.Value(options)))
                report += String.Format("<center><h1>{0}</h1></center>", title.Value(options));
            if (subtitle != null && !String.IsNullOrEmpty(subtitle.Value(options)))
                report += String.Format("<center><h2>{0}</h2></center>", subtitle.Value(options));
            foreach (ReportItem it1 in root)
            {
                if (it1.ShowEmpty || it1.Items.Count > 0)
                {
                    report += "<hr />";
                    if (!String.IsNullOrEmpty(it1.Value(options)))
                        report += String.Format("<center><h3>{0}</h3></center>", it1.Value(options));
                    report += "<ul>";
                    foreach (ReportItem it2 in it1.Items)
                    {
                        if (it2.ShowEmpty || it2.Items.Count > 0 || d == 1)
                        {
                            if (!String.IsNullOrEmpty(it2.Value(options)))
                                report += String.Format("<li>{0}</li>", it2.Value(options));
                            if (d > 1 && it2.Items.Count > 0)
                            {
                                report += "<ul>";
                                foreach (ReportItem it3 in it2.Items)
                                {
                                    if (it3.ShowEmpty || it3.Items.Count > 0 || d == 2)
                                    {
                                        report += String.Format("<li>{0}</li>", it3.Value(options));
                                        if (d > 2 && it3.Items.Count > 0)
                                        {
                                            report += "<ul>";
                                            foreach (ReportItem it4 in it3.Items)
                                            {
                                                if (it4.ShowEmpty || it4.Items.Count > 0 || d == 3)
                                                {
                                                    report += String.Format("<li>{0}</li>", it4.Value(options));
                                                    if (d > 3 && it4.Items.Count > 0)
                                                    {
                                                        report += "<ul>";
                                                        foreach (ReportItem it5 in it4.Items)
                                                        {
                                                            report += String.Format("<li>{0}</li>", it5.Value(options));
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
                    }
                    report += "</ul>";
                }
            }
            return ReportText(report);
        }

        public string BBCode(int d)
        {
            String report = "";
            if (title != null && !String.IsNullOrEmpty(title.Value(options)))
                report += String.Format("[b][u]{0}[/b][/u]\n", title.Value(options));
            if (subtitle != null && !String.IsNullOrEmpty(subtitle.Value(options)))
                report += String.Format("[b]{0}[/b]\n", subtitle.Value(options));
            report += "\n";
            foreach (ReportItem it1 in root)
            {
                if (it1.ShowEmpty || it1.Items.Count > 0)
                {
                    report += "[hr]\n";
                    if (!String.IsNullOrEmpty(it1.Value(options)))
                        report += String.Format("[b]{0}[/b]", it1.Value(options));
                    if (it1.Items.Count > 0)
                        report += "\n";

                    foreach (ReportItem it2 in it1.Items)
                    {
                        if (it2.ShowEmpty || it2.Items.Count > 0 || d == 1)
                        {
                            if (d > 1 && it2.Items.Count > 0)
                                report += "\n";
                            if (!String.IsNullOrEmpty(it2.Value(options)))
                                report += String.Format("{0}\n", it2.Value(options));
                            if (d > 1 && it2.Items.Count > 0)
                            {
                                foreach (ReportItem it3 in it2.Items)
                                {
                                    if (it3.ShowEmpty || it3.Items.Count > 0 || d == 2)
                                    {
                                        report += String.Format("{0}\n", it3.Value(options));
                                        if (d > 2 && it3.Items.Count > 0)
                                        {
                                            foreach (ReportItem it4 in it3.Items)
                                            {
                                                if (it4.ShowEmpty || it4.Items.Count > 0 || d == 3)
                                                {
                                                    report += String.Format("{0}\n", it4.Value(options));
                                                    if (d > 3 && it4.Items.Count > 0)
                                                    {
                                                        foreach (ReportItem it5 in it4.Items)
                                                        {
                                                            report += String.Format("{0}\n", it5.Value(options));
                                                        }
                                                    }
                                                }
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
            get { return title.Value(options); }
        }

        public string SubTitle
        {
            get { return subtitle.Value(options); }
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
