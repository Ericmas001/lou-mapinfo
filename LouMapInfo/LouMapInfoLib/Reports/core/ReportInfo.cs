using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.Reports.core
{
    public abstract class ReportInfo : AbstractLoadingTuple
    {
        private ReportOption options = ReportOption.None;
        protected abstract int depth { get; }
        protected ReportItem title;
        protected ReportItem subtitle = null;
        protected List<ReportItem> root = new List<ReportItem>();
        protected Dictionary<ReportFeatureType, bool> m_Features = new Dictionary<ReportFeatureType, bool>();
        public Dictionary<string, bool> BBCodeDisplay = new Dictionary<string, bool>();
        protected List<CityType> m_Types;

        public bool hasFeature(ReportFeatureType f)
        {
            return m_Features.ContainsKey(f);
        }
        public bool hasType0Feature()
        {
            return m_Features.ContainsKey(ReportFeatureType.TypeCastle) || m_Features.ContainsKey(ReportFeatureType.TypeCity) || m_Features.ContainsKey(ReportFeatureType.TypePalace);
        }
        public bool hasType1Feature()
        {
            return m_Features.ContainsKey(ReportFeatureType.BorderingLand) || m_Features.ContainsKey(ReportFeatureType.BorderingWater);
        }
        public bool hasType2Feature()
        {
            return m_Features.ContainsKey(ReportFeatureType.NoCities);
        }
        public bool hasType3Feature()
        {
            return m_Features.ContainsKey(ReportFeatureType.NoAlliance);
        }
        public bool FeatureEnabled(ReportFeatureType f)
        {
            return !m_Features.ContainsKey(f) || m_Features[f];
        }

        public void SetFeature(ReportFeatureType f, bool value)
        {
            if (m_Features.ContainsKey(f))
            {
                bool old = m_Features[f];
                m_Features[f] = value;
                if (old != value)
                {
                    title = null;
                    subtitle = null;
                    root = new List<ReportItem>();
                    ForceLoad();
                }
            }
        }

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

        public List<CityType> Types
        {
            get { return m_Types; }
        }
        public void SetTypes(params CityType[] types)
        {
            m_Types = new List<CityType>(types);
            title = null;
            subtitle = null;
            root = new List<ReportItem>();
            ForceLoad();
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

        public ReportInfo(params CityType[] types)
            : this()
        {
            m_Types = new List<CityType>(types);
        }

        public string Report(int d)
        {
            StringBuilder sb = new StringBuilder();
            if (title != null && !String.IsNullOrEmpty(title.Value(options)))
                sb.Append(String.Format("<center><h1>{0}</h1></center>", title.Value(options)));
            if (subtitle != null && !String.IsNullOrEmpty(subtitle.Value(options)))
                sb.Append(String.Format("<center><h2>{0}</h2></center>", subtitle.Value(options)));
            sb.Append(String.Format("<p align=\"right\">{0:yyyy}-{0:MM}-{0:dd}</p>", DateTime.Now));
            foreach (ReportItem it1 in root)
            {
                if (it1.ShowEmpty || it1.Items.Count > 0)
                {
                    sb.Append("<hr />");
                    if (!String.IsNullOrEmpty(it1.Value(options)))
                        sb.Append(String.Format("<center><h3>{0}</h3></center>", StringUtility.RemoveBBCodeTags(it1.Value(options))));
                    sb.Append("<ul>");
                    foreach (ReportItem it2 in it1.Items)
                    {
                        if (it2.ShowEmpty || it2.Items.Count > 0 || d == 1)
                        {
                            if (!String.IsNullOrEmpty(it2.Value(options)))
                                sb.Append(String.Format("<li>{0}</li>", it2.Value(options)));
                            if (d > 1 && it2.Items.Count > 0)
                            {
                                sb.Append("<ul>");
                                foreach (ReportItem it3 in it2.Items)
                                {
                                    if (it3.ShowEmpty || it3.Items.Count > 0 || d == 2)
                                    {
                                        sb.Append(String.Format("<li>{0}</li>", it3.Value(options)));
                                        if (d > 2 && it3.Items.Count > 0)
                                        {
                                            sb.Append("<ul>");
                                            foreach (ReportItem it4 in it3.Items)
                                            {
                                                if (it4.ShowEmpty || it4.Items.Count > 0 || d == 3)
                                                {
                                                    sb.Append(String.Format("<li>{0}</li>", it4.Value(options)));
                                                    if (d > 3 && it4.Items.Count > 0)
                                                    {
                                                        sb.Append("<ul>");
                                                        foreach (ReportItem it5 in it4.Items)
                                                        {
                                                            sb.Append(String.Format("<li>{0}</li>", it5.Value(options)));
                                                        }
                                                        sb.Append("</ul>");
                                                    }
                                                }
                                            }
                                            sb.Append("</ul>");
                                        }
                                    }
                                }
                                sb.Append("</ul>");
                            }

                        }
                    }
                    sb.Append("</ul>");
                }
            }
            return ReportText(sb.ToString());
        }

        public string BBCode(int d)
        {
            StringBuilder sb = new StringBuilder();
            if (title != null && !String.IsNullOrEmpty(title.Value(options)))
                sb.Append(String.Format("[b][u]{0}[/b][/u]\n", title.Value(options)));
            if (subtitle != null && !String.IsNullOrEmpty(subtitle.Value(options)))
                sb.Append(String.Format("[b]{0}[/b]\n", subtitle.Value(options)));
            sb.Append("\n");
            sb.Append(String.Format("{0:yyyy}-{0:MM}-{0:dd}", DateTime.Now));
            sb.Append("\n");
            foreach (ReportItem it1 in root)
            {
                if (it1.ShowEmpty || it1.Items.Count > 0)
                {
                    sb.Append("[hr]\n");
                    if (!String.IsNullOrEmpty(it1.Value(options)))
                        sb.Append(String.Format("[b]{0}[/b]", it1.Value(options)));
                    if (it1.Items.Count > 0)
                        sb.Append("\n");

                    foreach (ReportItem it2 in it1.Items)
                    {
                        if (it2.ShowEmpty || it2.Items.Count > 0 || d == 1)
                        {
                            if (d > 1 && it2.Items.Count > 0)
                                sb.Append("\n");
                            if (!String.IsNullOrEmpty(it2.Value(options)))
                                sb.Append(String.Format("{0}\n", it2.Value(options)));
                            if (d > 1 && it2.Items.Count > 0)
                            {
                                foreach (ReportItem it3 in it2.Items)
                                {
                                    if (it3.ShowEmpty || it3.Items.Count > 0 || d == 2)
                                    {
                                        sb.Append(String.Format("{0}\n", it3.Value(options)));
                                        if (d > 2 && it3.Items.Count > 0)
                                        {
                                            foreach (ReportItem it4 in it3.Items)
                                            {
                                                if (it4.ShowEmpty || it4.Items.Count > 0 || d == 3)
                                                {
                                                    sb.Append(String.Format("{0}\n", it4.Value(options)));
                                                    if (d > 3 && it4.Items.Count > 0)
                                                    {
                                                        foreach (ReportItem it5 in it4.Items)
                                                        {
                                                            sb.Append(String.Format("{0}\n", it5.Value(options)));
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
            return BBCodeText(sb.ToString());
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
