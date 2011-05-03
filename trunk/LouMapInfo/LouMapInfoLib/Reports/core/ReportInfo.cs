using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using LouMapInfo.Entities;
using LouMapInfo.Reports.Items;

namespace LouMapInfo.Reports.core
{
    public abstract class ReportInfo : AbstractLoadingTuple
    {
        protected int m_LockedGroups = 0;
        private bool m_ShowDetail = true;
        private ReportOption options = ReportOption.None;
        protected ReportItem title;
        protected ReportItem subtitle = null;
        protected List<ReportItem> root = new List<ReportItem>();
        protected Dictionary<FilterType, bool> m_Filters = new Dictionary<FilterType, bool>();
        protected Dictionary<GroupingType, bool> m_Grouping = new Dictionary<GroupingType, bool>();
        public Dictionary<string, bool> BBCodeDisplay = new Dictionary<string, bool>();

        public bool ShowDetail
        {
            get { return m_ShowDetail; }
            set { m_ShowDetail = value; }
        }

        public bool hasFilter(FilterType f)
        {
            return m_Filters.ContainsKey(f);
        }
        public bool hasGrouping(GroupingType g)
        {
            return m_Grouping.ContainsKey(g);
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
        public bool GroupingEnabled(GroupingType f)
        {
            return !m_Grouping.ContainsKey(f) || m_Grouping[f];
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

        public void SetGrouping(GroupingType g, bool value)
        {
            if (m_Grouping.ContainsKey(g))
            {
                bool old = m_Grouping[g];
                m_Grouping[g] = value;
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

        public int ReportDepth
        {
            get
            {
                int count = 0;
                foreach (GroupingType g in Enum.GetValues(typeof(GroupingType)))
                {
                    if (hasGrouping(g) && GroupingEnabled(g))
                        count++;
                }
                return count + m_LockedGroups;
            }
        }

        private void ReportDetail(StringBuilder sb, ReportItem it, bool detail)
        {
            if (it.Items.Count > 0)
            {
                sb.Append("<ul>");
                foreach (ReportItem it2 in it.Items)
                {
                    if (!it2.IsDetailLine || detail)
                    {
                        sb.Append(String.Format("<li>{0}</li>", it2.Value(options)));
                        ReportDetail(sb, it2, detail);
                    }
                }
                sb.Append("</ul>");
            }
        }

        public string Report()
        {
            bool detail = m_ShowDetail || ReportDepth == 0;
            StringBuilder sb = new StringBuilder();
            if (title != null && !String.IsNullOrEmpty(title.Value(options)))
                sb.Append(String.Format("<center><h1>{0}</h1></center>", title.Value(options)));
            if (subtitle != null && !String.IsNullOrEmpty(subtitle.Value(options)))
                sb.Append(String.Format("<center><h2>{0}</h2></center>", subtitle.Value(options)));
            sb.Append(String.Format("<p align=\"right\">{0:yyyy}-{0:MM}-{0:dd}</p>", DateTime.Now));
            if (ReportDepth <= 1)
                sb.Append("<hr /><ul>");
            foreach (ReportItem it1 in root)
            {
                if (ReportDepth > 1)
                {
                    sb.Append("<hr />");
                    if (!String.IsNullOrEmpty(it1.Value(options)))
                        sb.Append(String.Format("<center><h3>{0}</h3></center>", StringUtility.RemoveBBCodeTags(it1.Value(options))));
                }
                else
                    sb.Append(String.Format("<li>{0}</li>", it1.Value(options)));
                ReportDetail(sb, it1, detail);
            }
            if (ReportDepth <= 1)
                sb.Append("</ul>");
            return ReportText(sb.ToString());
        }

        private void BBCodeDetail(StringBuilder sb, ReportItem it, bool detail)
        {
            if (it.Items.Count > 0)
            {
                foreach (ReportItem it2 in it.Items)
                {
                    if (!it2.IsDetailLine || detail)
                    {
                        sb.Append(String.Format("{0}\n", it2.Value(options)));
                        BBCodeDetail(sb, it2, detail);
                    }
                }
                sb.Append("\n");
            }
        }

        public string BBCode()
        {
            bool detail = m_ShowDetail || ReportDepth <= 1;
            StringBuilder sb = new StringBuilder();
            if (title != null && !String.IsNullOrEmpty(title.Value(options)))
                sb.Append(String.Format("[b][u]{0}[/b][/u]\n", title.Value(options)));
            if (subtitle != null && !String.IsNullOrEmpty(subtitle.Value(options)))
                sb.Append(String.Format("[b]{0}[/b]\n", subtitle.Value(options)));
            sb.Append("\n");
            sb.Append(String.Format("{0:yyyy}-{0:MM}-{0:dd}", DateTime.Now));
            sb.Append("\n");
            if (ReportDepth <= 1)
                sb.Append("[hr]\n");
            foreach (ReportItem it1 in root)
            {
                if (it1.IsDetailLine)
                {
                    sb.Append(String.Format("{0}\n", it1.Value(options)));
                }
                else if (it1.Items.Count > 0)
                {
                    sb.Append("[hr]\n");
                    if (!String.IsNullOrEmpty(it1.Value(options)))
                        sb.Append(String.Format("[b]{0}[/b]", it1.Value(options)));
                    BBCodeDetail(sb, it1, detail);
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
                        .Replace("[" + b + "]", "")
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
        protected virtual void ShowCityDetailLine(ReportItem r, CityInfo[] cities)
        {
            Array.Sort(cities);
            Array.Reverse(cities);
            foreach (CityInfo c in cities)
            {
                if (c.TypeCity == CityType.Palace)
                {
                    c.LoadIfNeeded();
                    r.Items.Add(new DetailedPalaceInfoReportItem(true, c, false, false, false, true, true));
                }
                else
                    r.Items.Add(new CityInfoReportItem(true, c));
            }
        }
        protected virtual void ShowBorderingGroup(ReportItem r, BorderingType b, CityInfo[] cities)
        {
            bool me = b == BorderingType.Water ? FilterEnabled(FilterType.BorderingWater) : FilterEnabled(FilterType.BorderingLand);
            bool ot = b == BorderingType.Land ? FilterEnabled(FilterType.BorderingWater) : FilterEnabled(FilterType.BorderingLand);
            bool gt = GroupingEnabled(GroupingType.CityType);
            if (me && cities.Length > 0)
            {
                ReportItem r4 = !ot && gt ? r : new BorderingTypeReportItem(false, cities.Length, b);
                ShowCityDetailLine(r4, cities);
                if (ot || !gt)
                    r.Items.Add(r4);
            }
        }

        protected virtual CityInfo[] getCities(int ic, PlayerInfo p, CityType cityType, params FilterType[] bordering)
        {
            bool gt = GroupingEnabled(GroupingType.CityType);
            List<FilterType> filters = new List<FilterType>(bordering);

            if (gt)
            {
                if(  FilterEnabled(Filters.Filter(cityType)) )
                    filters.Add(Filters.Filter(cityType));
            }
            else
            {
                if (FilterEnabled(FilterType.TypeCastle))
                    filters.Add(FilterType.TypeCastle);
                if (FilterEnabled(FilterType.TypeCity))
                    filters.Add(FilterType.TypeCity);
                if (FilterEnabled(FilterType.TypePalace))
                    filters.Add(FilterType.TypePalace);
            }

            FilterType[] fs = new FilterType[filters.Count];
            filters.CopyTo(fs, 0);
            return p.Cities(ic, fs);
        }

        protected virtual CityInfo[] getCities(int ic, AllianceInfo a, CityType cityType, params FilterType[] bordering)
        {
            bool gt = GroupingEnabled(GroupingType.CityType);
            List<FilterType> filters = new List<FilterType>(bordering);

            if (gt)
            {
                if (FilterEnabled(Filters.Filter(cityType)))
                    filters.Add(Filters.Filter(cityType));
            }
            else
            {
                if (FilterEnabled(FilterType.TypeCastle))
                    filters.Add(FilterType.TypeCastle);
                if (FilterEnabled(FilterType.TypeCity))
                    filters.Add(FilterType.TypeCity);
                if (FilterEnabled(FilterType.TypePalace))
                    filters.Add(FilterType.TypePalace);
            }

            FilterType[] fs = new FilterType[filters.Count];
            filters.CopyTo(fs, 0);
            List<CityInfo> cities = new List<CityInfo>();
            foreach (PlayerInfo p in a.Players())
                cities.AddRange(p.Cities(ic, fs));
            CityInfo[] res = new CityInfo[cities.Count];
            cities.CopyTo(res, 0);
            Array.Sort(res);
            Array.Reverse(res);
            return res;
        }

        protected virtual CityInfo[] getCities(ContinentInfo c, CityType cityType, params FilterType[] bordering)
        {
            bool gt = GroupingEnabled(GroupingType.CityType);
            List<FilterType> filters = new List<FilterType>(bordering);

            if (gt)
            {
                if (FilterEnabled(Filters.Filter(cityType)))
                    filters.Add(Filters.Filter(cityType));
            }
            else
            {
                if (FilterEnabled(FilterType.TypeCastle))
                    filters.Add(FilterType.TypeCastle);
                if (FilterEnabled(FilterType.TypeCity))
                    filters.Add(FilterType.TypeCity);
                if (FilterEnabled(FilterType.TypePalace))
                    filters.Add(FilterType.TypePalace);
            }

            FilterType[] fs = new FilterType[filters.Count];
            filters.CopyTo(fs, 0);
            List<CityInfo> cities = new List<CityInfo>();
            foreach (AllianceInfo a in c.Alliances)
            {
                foreach (PlayerInfo p in a.Players(c.Id))
                    cities.AddRange(p.Cities(c.Id, fs));
            }
            CityInfo[] res = new CityInfo[cities.Count];
            cities.CopyTo(res, 0);
            Array.Sort(res);
            Array.Reverse(res);
            return res;
        }
        protected virtual int ShowCities(ReportItem r, CityType cityType, int ic, PlayerInfo p)
        {
            bool gt = GroupingEnabled(GroupingType.CityType);
            bool gb = GroupingEnabled(GroupingType.Bordering);
            bool el = FilterEnabled(FilterType.BorderingLand);
            bool ew = FilterEnabled(FilterType.BorderingWater);
            CityInfo[] citiesW = new CityInfo[0];
            CityInfo[] citiesL = new CityInfo[0];
            CityInfo[] cities = new CityInfo[0];
            if (gb)
            {
                citiesW = getCities(ic, p, cityType, FilterType.BorderingWater);
                citiesL = getCities(ic, p, cityType, FilterType.BorderingLand);
            }
            else
            {
                if (!el)
                    cities = getCities(ic, p, cityType, FilterType.BorderingWater);
                else if (!ew)
                    cities = getCities(ic, p, cityType, FilterType.BorderingLand);
                else
                    cities = getCities(ic, p, cityType, FilterType.BorderingLand, FilterType.BorderingWater);
            }

            int count = cities.Length;
            if (el)
                count += citiesL.Length;
            if (ew)
                count += citiesW.Length;
            if (FilterEnabled(FilterType.NoCities) || count > 0)
            {

                ReportItem r3;
                if (gt)
                {
                    if (!el)
                        r3 = new CityTypeReportItem(false, count, cityType, BorderingType.Water);
                    else if (!ew)
                        r3 = new CityTypeReportItem(false, count, cityType, BorderingType.Land);
                    else
                        r3 = new CityTypeReportItem(false, count, cityType);
                }
                else
                    r3 = r;

                if (gb)
                {
                    ShowBorderingGroup(r3, BorderingType.Water, citiesW);
                    ShowBorderingGroup(r3, BorderingType.Land, citiesL);
                }
                else
                    ShowCityDetailLine(r3, cities);
                if (gt)
                    r.Items.Add(r3);
            }
            return count;
        }
        protected virtual int ShowCities(ReportItem r, CityType cityType, int ic, AllianceInfo a)
        {
            bool gt = GroupingEnabled(GroupingType.CityType);
            bool gb = GroupingEnabled(GroupingType.Bordering);
            bool el = FilterEnabled(FilterType.BorderingLand);
            bool ew = FilterEnabled(FilterType.BorderingWater);
            CityInfo[] citiesW = new CityInfo[0];
            CityInfo[] citiesL = new CityInfo[0];
            CityInfo[] cities = new CityInfo[0];
            if (gb)
            {
                citiesW = getCities(ic, a, cityType, FilterType.BorderingWater);
                citiesL = getCities(ic, a, cityType, FilterType.BorderingLand);
            }
            else
            {
                if (!el)
                    cities = getCities(ic, a, cityType, FilterType.BorderingWater);
                else if (!ew)
                    cities = getCities(ic, a, cityType, FilterType.BorderingLand);
                else
                    cities = getCities(ic, a, cityType, FilterType.BorderingLand, FilterType.BorderingWater);
            }

            int count = cities.Length;
            if (el)
                count += citiesL.Length;
            if (ew)
                count += citiesW.Length;
            if (FilterEnabled(FilterType.NoCities) || count > 0)
            {

                ReportItem r3;
                if (gt)
                {
                    if (!el)
                        r3 = new CityTypeReportItem(false, count, cityType, BorderingType.Water);
                    else if (!ew)
                        r3 = new CityTypeReportItem(false, count, cityType, BorderingType.Land);
                    else
                        r3 = new CityTypeReportItem(false, count, cityType);
                }
                else
                    r3 = r;

                if (gb)
                {
                    ShowBorderingGroup(r3, BorderingType.Water, citiesW);
                    ShowBorderingGroup(r3, BorderingType.Land, citiesL);
                }
                else
                    ShowCityDetailLine(r3, cities);
                if (gt)
                    r.Items.Add(r3);
            }
            return count;
        }
        protected virtual int ShowCities(ReportItem r, CityType cityType, ContinentInfo c)
        {
            bool gt = GroupingEnabled(GroupingType.CityType);
            bool gb = GroupingEnabled(GroupingType.Bordering);
            bool el = FilterEnabled(FilterType.BorderingLand);
            bool ew = FilterEnabled(FilterType.BorderingWater);
            CityInfo[] citiesW = new CityInfo[0];
            CityInfo[] citiesL = new CityInfo[0];
            CityInfo[] cities = new CityInfo[0];
            if (gb)
            {
                citiesW = getCities(c, cityType, FilterType.BorderingWater);
                citiesL = getCities(c, cityType, FilterType.BorderingLand);
            }
            else
            {
                if (!el)
                    cities = getCities(c, cityType, FilterType.BorderingWater);
                else if (!ew)
                    cities = getCities(c, cityType, FilterType.BorderingLand);
                else
                    cities = getCities(c, cityType, FilterType.BorderingLand, FilterType.BorderingWater);
            }

            int count = cities.Length;
            if (el)
                count += citiesL.Length;
            if (ew)
                count += citiesW.Length;
            if (FilterEnabled(FilterType.NoCities) || count > 0)
            {

                ReportItem r3;
                if (gt)
                {
                    if (!el)
                        r3 = new CityTypeReportItem(false, count, cityType, BorderingType.Water);
                    else if (!ew)
                        r3 = new CityTypeReportItem(false, count, cityType, BorderingType.Land);
                    else
                        r3 = new CityTypeReportItem(false, count, cityType);
                }
                else
                    r3 = r;

                if (gb)
                {
                    ShowBorderingGroup(r3, BorderingType.Water, citiesW);
                    ShowBorderingGroup(r3, BorderingType.Land, citiesL);
                }
                else
                    ShowCityDetailLine(r3, cities);
                if (gt)
                    r.Items.Add(r3);
            }
            return count;
        }
    }
}
