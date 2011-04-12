using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using LouMapInfo.Entities;
using LouMapInfo.Entities.Filter;
using LouMapInfo.Reports.Items;

namespace LouMapInfo.Reports.core
{
    public abstract class ReportInfo : AbstractLoadingTuple
    {
        private ReportOption options = ReportOption.None;
        protected ReportItem title;
        protected ReportItem subtitle = null;
        protected List<ReportItem> root = new List<ReportItem>();
        protected Dictionary<FilterType, bool> m_Filters = new Dictionary<FilterType, bool>();
        public Dictionary<string, bool> BBCodeDisplay = new Dictionary<string, bool>();
        
        public bool hasFilter(FilterType f)
        {
            return m_Filters.ContainsKey(f);
        }
        public bool hasType0Filter()
        {
            return m_Filters.ContainsKey(FilterType.TypeCastle) || m_Filters.ContainsKey(FilterType.TypeCity) || m_Filters.ContainsKey(FilterType.TypePalace);
        }
        public bool hasType1Filter()
        {
            return m_Filters.ContainsKey(FilterType.BorderingLand) || m_Filters.ContainsKey(FilterType.BorderingWater);
        }
        public bool hasType2Filter()
        {
            return m_Filters.ContainsKey(FilterType.NoCities);
        }
        public bool hasType3Filter()
        {
            return m_Filters.ContainsKey(FilterType.NoAlliance);
        }
        public bool FilterEnabled(FilterType f)
        {
            return !m_Filters.ContainsKey(f) || m_Filters[f];
        }

        public void SetFilter(FilterType f, bool value)
        {
            if (m_Filters.ContainsKey(f))
            {
                bool old = m_Filters[f];
                m_Filters[f] = value;
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
        public string[] SayCityType()
        {
            List<string> lines = new List<string>();
            if (hasType0Filter())
            {
                bool hci = hasFilter(FilterType.TypeCity);
                bool hca = hasFilter(FilterType.TypeCastle);
                bool hpa = hasFilter(FilterType.TypePalace);
                bool eci = FilterEnabled(FilterType.TypeCity);
                bool eca = FilterEnabled(FilterType.TypeCastle);
                bool epa = FilterEnabled(FilterType.TypePalace);

                if ((hci && !eci) || (hca && !eca) || (hpa && !epa))
                {
                    if (eci && (!hca || !eca) && (!hpa || !epa))
                        lines.Add("Non-Castled cities only");
                    else if (eca && (!hci || !eci) && (!hpa || !epa))
                        lines.Add("Castles only");
                    else if (epa && (!hci || !eci) && (!hca || !eca))
                        lines.Add("Palaces only");
                    else if (!eci)
                        lines.Add("Non-Castled cities excluded");
                    else if (!eca)
                        lines.Add("Castles excluded");
                    else if (!epa)
                        lines.Add("Palaces excluded");
                }
            }
            if (hasType1Filter())
            {
                bool hl = hasFilter(FilterType.BorderingLand);
                bool hw = hasFilter(FilterType.BorderingWater);
                bool el = FilterEnabled(FilterType.BorderingLand);
                bool ew = FilterEnabled(FilterType.BorderingWater);

                if ((hl && !el) || (hw && !ew))
                {
                    if (el)
                        lines.Add("Land-Locked only");
                    else if (ew)
                        lines.Add("Water-Based only");
                }
            }
            if (hasType2Filter())
            {
                bool h = hasFilter(FilterType.NoCities);
                bool e = FilterEnabled(FilterType.NoCities);

                if (h && !e)
                    lines.Add("\"No Cities\" excluded");
            }
            if (hasType3Filter())
            {
                bool h = hasFilter(FilterType.NoAlliance);
                bool e = FilterEnabled(FilterType.NoAlliance);

                if (h && !e)
                    lines.Add("\"No Alliance\" excluded");
            }
            string[] res = new string[lines.Count];
            lines.CopyTo(res, 0);
            return res;
        }
        protected virtual int ShowCities(ReportItem r, CityType cityType, int ic, PlayerInfo p)
        {
            FilterType type = Filters.Filter(cityType);
            if (FilterEnabled(type))
            {
                bool el = FilterEnabled(FilterType.BorderingLand);
                bool ew = FilterEnabled(FilterType.BorderingWater);
                CityInfo[] citiesW = p.Cities(ic, FilterType.BorderingWater, type);
                CityInfo[] citiesL = p.Cities(ic, FilterType.BorderingLand, type);
                int count = 0;
                if (el)
                    count += citiesL.Length;
                if (ew)
                    count += citiesW.Length;
                if (FilterEnabled(FilterType.NoCities) || count > 0)
                {
                    ReportItem r3;
                    if (!el)
                        r3 = new CityTypeReportItem(citiesW.Length, cityType, BorderingType.Water, true);
                    else if (!ew)
                        r3 = new CityTypeReportItem(citiesL.Length, cityType, BorderingType.Land, true);
                    else
                        r3 = new CityTypeReportItem(count, cityType, true);

                    if (ew && citiesW.Length > 0)
                    {
                        ReportItem r4 = !el ? r3 : new BorderingTypeReportItem(citiesW.Length, BorderingType.Water, true);
                        Array.Sort(citiesW);
                        Array.Reverse(citiesW);
                        foreach (CityInfo c in citiesW)
                        {
                            if (c.TypeCity == CityType.Palace)
                            {
                                c.LoadIfNeeded();
                                r4.Items.Add(new DetailedPalaceInfoReportItem(c, true, false, false, false, true, true));
                            }
                            else
                                r4.Items.Add(new CityInfoReportItem(c, true));
                        }
                        if (el)
                            r3.Items.Add(r4);
                    }
                    if (el && citiesL.Length > 0)
                    {
                        ReportItem r4 = !ew ? r3 : new BorderingTypeReportItem(citiesL.Length, BorderingType.Land, true);
                        Array.Sort(citiesL);
                        Array.Reverse(citiesL);
                        foreach (CityInfo c in citiesL)
                            if (c.TypeCity == CityType.Palace)
                            {
                                c.LoadIfNeeded();
                                r4.Items.Add(new DetailedPalaceInfoReportItem(c, true, false, false, false, true, true));
                            }
                            else
                                r4.Items.Add(new CityInfoReportItem(c, true));
                        if (ew)
                            r3.Items.Add(r4);
                    }
                    r.Items.Add(r3);
                }
                return count;
            }
            return 0;
        }
    }
    

}
