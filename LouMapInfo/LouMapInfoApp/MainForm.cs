using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using System.IO;
using EricUtility.Networking.JSON;
using EricUtility.Windows.Forms;
using System.Threading;
using EricUtility.Networking.Gathering;

namespace LouMapInfoApp
{
    public partial class MainForm : Form
    {
        private static Dictionary<int, WorldInfo> worlds = new Dictionary<int, WorldInfo>();
        public static void loadUpdated(int iw)
        {
            //string s = File.ReadAllText("../../testData/updated.json");
            string s = GatheringUtility.GetPageSource("http://www.lou-map.com/updated.json"); 
            JsonTextParser parser = new JsonTextParser();
            JsonObject jsonObject = parser.Parse(s);

            foreach (JsonObject field in jsonObject as JsonObjectCollection)
            {
                int worldID = int.Parse(field.Name);
                DateTime val = DateTime.Parse((string)field.GetValue());
                worlds.Add(worldID, new WorldInfo(worldID, val));
            }
        }


        public static void loadShrines(int iw)
        {
            //string s = File.ReadAllText("../../testData/sea" + iw + ".json");

            string s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/sea" + iw + ".json"); 
            JsonTextParser parser = new JsonTextParser();
            JsonObject jsonObject = parser.Parse(s);
            WorldInfo w = worlds[iw];
            foreach (JsonObject o in jsonObject as JsonObjectCollection)
            {
                JsonObjectCollection t = o as JsonObjectCollection;
                if (t != null)
                {
                    foreach (JsonArrayCollection c in t)
                    {
                        int cid = int.Parse(c.Name);
                        switch (t.Name)
                        {
                            case "shrines":
                                {
                                    foreach (JsonArrayCollection i in c)
                                    {
                                        w.Cont(cid).Shrines.Add(new Pt((int)((JsonNumericValue)i[0]).Value, (int)((JsonNumericValue)i[1]).Value));
                                    }
                                    break;
                                }
                            case "moongates":
                                {
                                    foreach (JsonArrayCollection i in c)
                                    {
                                        w.Cont(cid).MoonGates.Add(new Pt((int)((JsonNumericValue)i[0]).Value, (int)((JsonNumericValue)i[1]).Value));
                                    }
                                    break;
                                }
                        }

                    }
                }
            }

        }


        public static void loadOverlay( int iw, int ic )
        {
            string s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/overlay" + iw + "c" + ic + ".json");
            //string s = File.ReadAllText("../../testData/overlay"+iw+"c"+ic+".json");
            JsonTextParser parser = new JsonTextParser();
            JsonObject jsonObject = parser.Parse(s);
            WorldInfo world = worlds[iw];
            ContinentInfo continent = world.Cont(ic);
            foreach (JsonObjectCollection a in jsonObject as JsonObjectCollection)
            {
                string aid = a.Name;
                string name = (string)((JsonStringValue)a["name"]).Value;
                int pts = (name == AllianceInfo.NO_ALLIANCE) ? 0 : (int)((JsonNumericValue)a["points"]).Value;
                AllianceInfo alliance = new AllianceInfo(int.Parse(aid), name, pts, continent);
                if (continent.Alliances.ContainsKey(name))
                    alliance = continent.Alliances[name];
                else
                    continent.Alliances.Add(name, alliance);
                JsonObjectCollection players = (JsonObjectCollection)a["players"];
                foreach (JsonObjectCollection p in players)
                {
                    string pid = p.Name;
                    string pname = (string)((JsonStringValue)p["name"]).Value;
                    int ppts = (pname == PlayerInfo.LAWLESS) ? 0 : (int)((JsonNumericValue)p["points"]).Value;
                    PlayerInfo player = new PlayerInfo(int.Parse(pid), pname, ppts, alliance);
                    if (alliance.Players.ContainsKey(pname))
                        player = alliance.Players[pname];
                    else
                        alliance.Players.Add(pname, player);
                    JsonObjectCollection pcities = (JsonObjectCollection)p["cities"];
                    foreach (JsonObjectCollection c in pcities)
                    {
                        string cid = c.Name;
                        string cname = (string)((JsonStringValue)c["name"]).Value;
                        int cpts = (int)((JsonNumericValue)c["points"]).Value;
                        bool castle = (bool)((JsonBooleanValue)c["castle"]).Value;
                        Pt loc = new Pt((int)((JsonNumericValue)c["x"]).Value, (int)((JsonNumericValue)c["y"]).Value);
                        CityInfo city = new CityInfo(int.Parse(cid), cname, cpts, castle, loc, player);
                        player.Cities.Add(cid, city);
                        if (castle)
                            Console.WriteLine(alliance + ": " + player + ": " + city);
                    }
                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tpageReports);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            this.Enabled = false;
            statePictureBox1.Etat = StatePictureBoxStates.Waiting;
            dgvCities.Rows.Clear();
            worlds.Clear();
            tabControl1.TabPages.Remove(tpageReports);
            new Thread(new ParameterizedThreadStart(LoadContinent)).Start(new KeyValuePair<int, int>((int)nudWorld.Value, (int)nudContinent.Value));
        }

        public void LoadContinent(object State)
        {
            KeyValuePair<int, int> info = (KeyValuePair<int, int>)State;
            int world = info.Key;
            int cont = info.Value;
            try
            {
                loadUpdated(world);
                loadShrines(world);
                loadOverlay(world, cont);
                EndLoadContinent(info);
            }
            catch
            {
                EndLoadContinentBadly(info);
            }
        }

        public delegate void EmptyHandler(KeyValuePair<int, int> info);
        private void EndLoadContinent(KeyValuePair<int, int> info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EndLoadContinent), info);
                return;
            }
            statePictureBox1.Etat = StatePictureBoxStates.None;
            foreach (AllianceInfo a in worlds[info.Key].Cont(info.Value).Alliances.Values)
            {

                foreach (PlayerInfo p in a.Players.Values)
                {

                    foreach (CityInfo c in p.Cities.Values)
                    {
                        dgvCities.Rows.Add(a.Name, a.Score, p.Name, p.Score, c.Location.X, c.Location.Y, c.Name, c.Castle, c.Score);
                    }

                }
            }
            dgvCities.Sort(dgvCities.Columns["AllianceName"], ListSortDirection.Ascending);
            lblStatus.Text = String.Format("Word: {0:00}, Continent: {1:00}, Last Updated: {2:yyyy}-{2:MM}-{2:dd}",info.Key,info.Value,worlds[info.Key].LastUpdated);

            tabControl1.TabPages.Add(tpageReports); 
            this.Enabled = true;
        }
        private void EndLoadContinentBadly(KeyValuePair<int, int> info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EndLoadContinentBadly), info);
                return;
            }
            statePictureBox1.Etat = StatePictureBoxStates.Bad;
            this.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnReportLawless_Click(object sender, EventArgs e)
        {
            int w = (int)nudWorld.Value;
            int co = (int)nudContinent.Value;
            String title = "Lawless cities on C" + co + " (World " + w + ")";
            string report = "<center><h1>" + title + "</h1></center>";
            ICollection<CityInfo> lawless = worlds[w].Cont(co).Alliances[AllianceInfo.NO_ALLIANCE].Players[PlayerInfo.LAWLESS].Cities.Values;
            List<CityInfo> lawlessCity = new List<CityInfo>();
            List<CityInfo> lawlessCastles = new List<CityInfo>();
            foreach (CityInfo c in lawless)
            {
                if (c.Castle)
                    lawlessCastles.Add(c);
                else
                    lawlessCity.Add(c);
            }
            CityInfo[] cities = new CityInfo[lawlessCity.Count];
            lawlessCity.CopyTo(cities, 0);
            Array.Sort(cities);
            Array.Reverse(cities);
            report += "<h2>Cities</h2><ul>";
            foreach (CityInfo c in cities)
            {
                report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
            }
            report += "</ul>";
            cities = new CityInfo[lawlessCastles.Count];
            lawlessCastles.CopyTo(cities, 0);
            Array.Sort(cities);
            Array.Reverse(cities);
            report += "<h2>Castles</h2><ul>";
            foreach (CityInfo c in cities)
            {
                report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
            }
            report += "</ul>";
            new ReportForm(title,report).Show();
        }

        private void btnReportCastles_Click(object sender, EventArgs e)
        {
            int w = (int)nudWorld.Value;
            int co = (int)nudContinent.Value;
            String title = "Castles on C" + co + " (World " + w + ")";
            string report = "<center><h1>" + title + "</h1></center>";
            AllianceInfo[] alliances = new AllianceInfo[worlds[w].Cont(co).Alliances.Count];
            worlds[w].Cont(co).Alliances.Values.CopyTo(alliances, 0);
            Array.Sort(alliances);
            Array.Reverse(alliances);
            for (int i = 0; i < alliances.Length; ++i)
            {
                Dictionary<PlayerInfo, List<CityInfo>> players = new Dictionary<PlayerInfo, List<CityInfo>>();
                foreach( PlayerInfo p in alliances[i].Players.Values )
                {
                    foreach (CityInfo c in p.Cities.Values)
                    {
                        if (c.Castle)
                        {
                            if (!players.ContainsKey(p))
                                players.Add(p,new List<CityInfo>());
                            players[p].Add(c);
                        }
                    }
                }
                if (players.Count > 0)
                {
                    report += String.Format("<hr /><center><h2>{0}{1}</h2></center>", alliances[i].Name == AllianceInfo.NO_ALLIANCE ? "" : String.Format("#{0:00} ", (i + 1)), alliances[i]);
                    PlayerInfo[] ps = new PlayerInfo[players.Count];
                    players.Keys.CopyTo(ps, 0);
                    Array.Sort(ps);
                    Array.Reverse(ps);
                    foreach( PlayerInfo p in ps)
                    {
                        report += String.Format("<h3>{0}</h3><ul>", p);
                        CityInfo[] cs = new CityInfo[players[p].Count];
                        players[p].CopyTo(cs, 0);
                        Array.Sort(cs);
                        Array.Reverse(cs);
                        foreach (CityInfo c in cs)
                        {
                            report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
                        }
                        report += String.Format("</ul>");
                    }
                }
            }
            new ReportForm(title, report).Show();
        }
    }
}
