using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using System.Globalization;
using System.IO;

namespace LouMapInfo.CSV
{
    public class AllianceCitiesListCSV : ReportCSV
    {
        private AllianceInfo m_Alliance;
        Dictionary<String, int> m_Players = new Dictionary<String, int>();
        List<String[]> m_Lines = new List<string[]>();

        public AllianceCitiesListCSV(AllianceInfo alliance)
        {
            m_Alliance = alliance;
        }

        protected override void LoadFiles()
        {
            m_Alliance.LoadIfNeeded();
            int i = 1;
            foreach (PlayerInfo p in m_Alliance.Players())
            {
                p.LoadIfNeeded();
                m_Players.Add(p.Name, i++);
            }
        }
        protected override void BuildData()
        {
            int pjsCount = m_Alliance.Players().Length;
            m_Lines.Add(new string[pjsCount + 1]);
            m_Lines[0][0] = "Continent";
            foreach (String p in m_Players.Keys)
                m_Lines[0][m_Players[p]] = p;
            int min = 1;
            int max = 1;
            foreach (int ic in m_Alliance.ActiveContinents)
            {
                Log("C" + ic.ToString("00") + " ...", ConsoleColor.White);

                min = max;
                PlayerInfo[] pjs = m_Alliance.Players(ic);
                foreach (PlayerInfo p in pjs)
                {
                    int curr = min;
                    CityInfo[] cities = p.Cities(ic);
                    Array.Sort(cities);
                    Array.Reverse(cities);
                    foreach (CityInfo c in cities)
                    {
                        if (curr == max)
                        {
                            m_Lines.Add(new string[pjsCount + 1]);
                            m_Lines[curr][0] = "C" + ic.ToString("00");
                            max++;
                        }
                        int col = m_Players[p.Name];
                        m_Lines[curr][col] = "\"" + c.Location + " " + c.Name + " (" + c.Score.ToString("N0", CultureInfo.InvariantCulture) + ")\"";
                        curr++;
                    }
                }

                LogLine(" done !", ConsoleColor.Green);
            }
        }
        public override string RawFile()
        {
            StringWriter sw = new StringWriter();
            foreach (string[] li in m_Lines)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in li)
                {
                    sb.Append(s);
                    sb.Append(";");
                }
                sw.WriteLine(sb.ToString());
            }
            return sw.ToString();
        }
        protected override void WriteCSV(System.IO.StreamWriter sw)
        {
            foreach (string[] li in m_Lines)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in li)
                {
                    sb.Append(s);
                    sb.Append(";");
                }
                sw.WriteLine(sb.ToString());
            }
            sw.Close();
        }
    }
}
