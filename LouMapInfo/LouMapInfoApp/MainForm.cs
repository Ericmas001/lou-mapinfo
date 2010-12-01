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

        bool loaded = false;
        private Dictionary<int, WorldInfo> worlds = new Dictionary<int, WorldInfo>();
        public void loadUpdated(int iw)
        {
            if (!loaded)
            {
                loaded = true;
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
        }


        public void loadShrines(int iw)
        {
            //string s = File.ReadAllText("../../testData/sea" + iw + ".json");

            WorldInfo w = worlds[iw];
            if (!w.Loaded)
            {
                string s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/sea" + iw + ".json");
                JsonTextParser parser = new JsonTextParser();
                JsonObject jsonObject = parser.Parse(s);
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
                w.Loaded = true;
            }
        }


        public void loadOverlay( int iw, int ic )
        {
            WorldInfo world = worlds[iw];
            ContinentInfo continent = world.Cont(ic);
            if (!continent.Loaded)
            {
                string s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/overlay" + iw + "c" + ic + ".json");
                //string s = File.ReadAllText("../../testData/overlay"+iw+"c"+ic+".json");
                JsonTextParser parser = new JsonTextParser();
                JsonObject jsonObject = parser.Parse(s);
                foreach (JsonObjectCollection a in jsonObject as JsonObjectCollection)
                {
                    string aid = a.Name;
                    string name = (string)((JsonStringValue)a["name"]).Value;
                    int pts = (name == AllianceInfo.NO_ALLIANCE) ? 0 : (int)((JsonNumericValue)a["points"]).Value;
                    AllianceInfo alliance = new AllianceInfo(int.Parse(aid), name, pts, continent);
                    if (continent.AlliancesOldWay.ContainsKey(name))
                        alliance = continent.AlliancesOldWay[name];
                    else
                        continent.AlliancesOldWay.Add(name, alliance);
                    JsonObjectCollection players = (JsonObjectCollection)a["players"];
                    foreach (JsonObjectCollection p in players)
                    {
                        string pid = p.Name;
                        string pname = (string)((JsonStringValue)p["name"]).Value;
                        int ppts = (pname == PlayerInfo.LAWLESS) ? 0 : (int)((JsonNumericValue)p["points"]).Value;
                        PlayerInfo player = new PlayerInfo(int.Parse(pid), pname, ppts, alliance);
                        if (alliance.PlayersOldWay.ContainsKey(pname))
                            player = alliance.PlayersOldWay[pname];
                        else
                            alliance.PlayersOldWay.Add(pname, player);
                        JsonObjectCollection pcities = (JsonObjectCollection)p["cities"];
                        foreach (JsonObjectCollection c in pcities)
                        {
                            string cid = c.Name;
                            string cname = (string)((JsonStringValue)c["name"]).Value;
                            int cpts = (int)((JsonNumericValue)c["points"]).Value;
                            bool castle = (bool)((JsonBooleanValue)c["castle"]).Value;
                            Pt loc = new Pt((int)((JsonNumericValue)c["x"]).Value, (int)((JsonNumericValue)c["y"]).Value);
                            CityInfo city = new CityInfo(int.Parse(cid), cname, cpts, castle, loc, player);
                            player.AddCity(city);
                            if (castle)
                                Console.WriteLine(alliance + ": " + player + ": " + city);
                        }
                    }
                }
                continent.Loaded = true;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            //lstCityType.SelectedIndex = 0;
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
            //worlds.Clear();
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

        public delegate void IntIntHandler(KeyValuePair<int, int> info);
        private void EndLoadContinent(KeyValuePair<int, int> info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new IntIntHandler(EndLoadContinent), info);
                return;
            }
            statePictureBox1.Etat = StatePictureBoxStates.None;
            foreach (AllianceInfo a in worlds[info.Key].Cont(info.Value).AlliancesOldWay.Values)
            {

                foreach (PlayerInfo p in a.PlayersOldWay.Values)
                {

                    foreach (CityInfo c in p.AllCities)
                    {
                        dgvCities.Rows.Add(a.Name, a.Score, p.Name, p.Score, c.Location.X, c.Location.Y, c.Name, c.Castle, c.Score);
                    }

                }
            }
            dgvCities.Sort(dgvCities.Columns["AllianceName"], ListSortDirection.Ascending);
            lblStatus.Text = String.Format("Word: {0:00}, Continent: {1:00}, Last Updated: {2:yyyy}-{2:MM}-{2:dd}",info.Key,info.Value,worlds[info.Key].LastUpdated);
            tpageReports.Text = String.Format("C{0:00} Reports", info.Value);
            tabControl1.TabPages.Insert(1,tpageReports); 
            this.Enabled = true;
        }
        private void EndLoadContinentBadly(KeyValuePair<int, int> info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new IntIntHandler(EndLoadContinentBadly), info);
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
            string bbcode = "[b] Lawless cities on C" + co + "[/b]\n";
            List<CityInfo> lawless = new List<CityInfo>();
            foreach (AllianceInfo a in worlds[w].Cont(co).AlliancesOldWay.Values)
                if (a.PlayersOldWay.ContainsKey(PlayerInfo.LAWLESS))
                    lawless.AddRange(a.PlayersOldWay[PlayerInfo.LAWLESS].AllCities);
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
                bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
            }
            report += "</ul>";
            cities = new CityInfo[lawlessCastles.Count];
            lawlessCastles.CopyTo(cities, 0);
            Array.Sort(cities);
            Array.Reverse(cities);
            bbcode += "\n\n[b] Lawless castles on C" + co + "[/b]\n";
            report += "<h2>Castles</h2><ul>";
            foreach (CityInfo c in cities)
            {
                bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
            }
            report += "</ul>";
            new ReportForm(title,report,bbcode).Show();
        }

        private void btnReportAllCities_Click(object sender, EventArgs e)
        {
            int w = (int)nudWorld.Value;
            int co = (int)nudContinent.Value;
            String title = "Cities on C" + co + " (World " + w + ")";
            string report = "<center><h1>" + title + "</h1></center>";
            string bbcode = "";
            AllianceInfo[] alliances = new AllianceInfo[worlds[w].Cont(co).AlliancesOldWay.Count];
            worlds[w].Cont(co).AlliancesOldWay.Values.CopyTo(alliances, 0);
            Array.Sort(alliances);
            Array.Reverse(alliances);
            for (int i = 0; i < alliances.Length; ++i)
            {
                Dictionary<PlayerInfo, KeyValuePair<List<CityInfo>, List<CityInfo>>> players = new Dictionary<PlayerInfo, KeyValuePair<List<CityInfo>, List<CityInfo>>>();
                foreach (PlayerInfo p in alliances[i].PlayersOldWay.Values)
                {
                    foreach (CityInfo c in p.AllCities)
                    {
                        if (!players.ContainsKey(p))
                            players.Add(p, new KeyValuePair<List<CityInfo>, List<CityInfo>>(new List<CityInfo>(), new List<CityInfo>()));
                        if (c.Castle)
                            players[p].Value.Add(c);
                        else
                            players[p].Key.Add(c);
                    }
                }
                if (players.Count > 0)
                {
                    bbcode += String.Format("\n\n\n[b][u]Alliance{0}: {1}[/u][/b]", alliances[i].Name == AllianceInfo.NO_ALLIANCE ? "" : String.Format(" ranked #{0:00} ", (i + 1)), alliances[i].Name == AllianceInfo.NO_ALLIANCE ? "None" : "[alliance]" + alliances[i].Name + "[/alliance]");
                    report += String.Format("<hr /><center><h2>{0}{1}</h2></center>", alliances[i].Name == AllianceInfo.NO_ALLIANCE ? "" : String.Format("#{0:00} ", (i + 1)), alliances[i]);
                    PlayerInfo[] ps = new PlayerInfo[players.Count];
                    players.Keys.CopyTo(ps, 0);
                    Array.Sort(ps);
                    Array.Reverse(ps);
                    foreach (PlayerInfo p in ps)
                    {
                        bbcode += String.Format("\n\n[b][player]{0}[/player][/b] ({1})\n", p.Name, p.SayScore);
                        report += String.Format("<h3>{0}</h3>", p);
                        if (chooReportAllCities.City && players[p].Key.Count > 0)
                        {
                            bbcode += "[b]Cities[/b]\n";
                            report += String.Format("<h4>Cities</h4><ul>");
                            CityInfo[] cs = new CityInfo[players[p].Key.Count];
                            players[p].Key.CopyTo(cs, 0);
                            Array.Sort(cs);
                            Array.Reverse(cs);
                            foreach (CityInfo c in cs)
                            {
                                bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                                report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
                            }
                            report += String.Format("</ul>");
                        }
                        if (chooReportAllCities.Castle && players[p].Value.Count > 0)
                        {
                            bbcode += "[b]Castles[/b]\n";
                            report += String.Format("<h4>Castles</h4><ul>");
                            CityInfo[] cs = new CityInfo[players[p].Value.Count];
                            players[p].Value.CopyTo(cs, 0);
                            Array.Sort(cs);
                            Array.Reverse(cs);
                            foreach (CityInfo c in cs)
                            {
                                bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                                report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
                            }
                            report += String.Format("</ul>");
                        }
                    }
                }
            }
            new ReportForm(title, report, bbcode).Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnReportPlayer.Enabled = !String.IsNullOrEmpty(txtPlayerName.Text);
        }

        private class GlobalReportEntry
        {
            public int World;
            public string Param;
            public CityCastleType CityCastle;
            public GlobalReportEntry(int w, string p, CityCastleType cc)
            {
                World = w;
                Param = p;
                CityCastle = cc;
            }
        }

        private void btnReportPlayer_Click(object sender, EventArgs e)
        {
            //lblStatus.Text = "";
            this.Enabled = false;
            statePictureBox1.Etat = StatePictureBoxStates.Waiting;
            //dgvCities.Rows.Clear();
            //worlds.Clear();
            //tabControl1.TabPages.Remove(tpageReports);
            new Thread(new ParameterizedThreadStart(LoadPlayerInfo)).Start(new GlobalReportEntry((int)nudWorld.Value, txtPlayerName.Text,chooReportPlayer.Value));
            
        }
        private class PlayerReportEntry
        {
            public string AName;
            public int AScore;
            public string PName;
            public int PScore;
            public List<CityInfo> Cities = new List<CityInfo>();
            public List<CityInfo> Castles = new List<CityInfo>();
        }
        private class PlayerReportRoot
        {
            public string AName;
            public int AScore;
            public string PName;
            public int PScore;
            public Dictionary<int,PlayerReportEntry> Continents = new Dictionary<int,PlayerReportEntry>();
        }
        private PlayerReportRoot getPlayer(string player, int world, CityCastleType cc)
        {
            PlayerReportRoot res = new PlayerReportRoot();
            res.AName = null;
            res.AScore = 0;
            res.PName = player;
            res.PScore = 0;
            foreach (ContinentInfo c in worlds[world].Continents)
                if (c.Loaded)
                {
                    if( res.AName!= null && c.AlliancesOldWay.ContainsKey(res.AName))
                    {
                        AllianceInfo a = c.AlliancesOldWay[res.AName];
                        res.AScore += a.Score;
                        if (a.PlayersOldWay.ContainsKey(player))
                        {
                            PlayerInfo p = a.PlayersOldWay[player];
                            PlayerReportEntry e = new PlayerReportEntry();
                            e.AName = a.Name;
                            e.AScore = a.Score;
                            e.PName = player;
                            e.PScore = p.Score;
                            res.Continents.Add(c.ID,e);
                            res.PScore += p.Score;
                            foreach (CityInfo ci in p.AllCities)
                            {
                                if (ci.Castle && (cc == CityCastleType.Both || cc == CityCastleType.Castle))
                                    e.Castles.Add(ci);
                                if (!ci.Castle && (cc == CityCastleType.Both || cc == CityCastleType.City))
                                    e.Cities.Add(ci);
                            }
                        }
                    }
                    else if (res.AName == null)
                    {
                        foreach (AllianceInfo a in c.AlliancesOldWay.Values)
                        {
                            if (res.AName == null || a.Name == res.AName)
                            {
                                if (a.PlayersOldWay.ContainsKey(player))
                                {
                                    res.AName = a.Name;
                                    res.AScore += a.Score;
                                    PlayerInfo p = a.PlayersOldWay[player];
                                    PlayerReportEntry e = new PlayerReportEntry();
                                    e.AName = a.Name;
                                    e.AScore = a.Score;
                                    e.PName = player;
                                    e.PScore = p.Score;
                                    res.Continents.Add(c.ID, e);
                                    res.PScore += p.Score;
                                    foreach (CityInfo ci in p.AllCities)
                                    {
                                        if (ci.Castle && (cc == CityCastleType.Both || cc == CityCastleType.Castle))
                                            e.Castles.Add(ci);
                                        if (!ci.Castle && (cc == CityCastleType.Both || cc == CityCastleType.City))
                                            e.Cities.Add(ci);
                                    }
                                }
                            }
                        }
                    }
                }
            return res;
        }
        public void LoadPlayerInfo(object State)
        {
            GlobalReportEntry info = (GlobalReportEntry)State;
            int world = info.World;
            string player = info.Param;
            try
            {
                loadUpdated(world);
                loadShrines(world);
                foreach (ContinentInfo c in worlds[world].Continents)
                    try { loadOverlay(world, c.ID); }
                    catch { }
                PlayerReportRoot res = getPlayer(player, world,info.CityCastle);
                EndLoadPlayerInfo(res);
            }
            catch
            {
                EndLoadPlayerInfoBadly(info);
            }
        }

        private delegate void PlayerReportRootHandler(PlayerReportRoot info);
        private void EndLoadPlayerInfo(PlayerReportRoot info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PlayerReportRootHandler(EndLoadPlayerInfo), info);
                return;
            }
            int w = (int)nudWorld.Value;
            int co = (int)nudContinent.Value;
            String title = "Report on " + info.PName + " ("+(info.PScore > 10000 ? String.Format("{0:0,0,0,0,0}", info.PScore) : (info.PScore > 1000 ? String.Format("{0:0,0}", info.PScore) : "" + info.PScore))+")";
            string report = "<center><h1>" + title + "</h1><h2>" + info.AName + " (" + (info.AScore > 10000 ? String.Format("{0:0,0,0,0,0}", info.AScore) : (info.AScore > 1000 ? String.Format("{0:0,0}", info.AScore) : "" + info.AScore)) + ")</h2></center>";
            string bbcode = "[b][u]Report on [player]" + info.PName + "[/player] (" + (info.PScore > 10000 ? String.Format("{0:0,0,0,0,0}", info.PScore) : (info.PScore > 1000 ? String.Format("{0:0,0}", info.PScore) : "" + info.PScore)) + ")[/u][/b]\n";
            bbcode += "[b]Alliance: [alliance]" + info.AName + "[/alliance] (" + (info.AScore > 10000 ? String.Format("{0:0,0,0,0,0}", info.AScore) : (info.AScore > 1000 ? String.Format("{0:0,0}", info.AScore) : "" + info.AScore)) + ")[/u][/b]\n";
            foreach (int ic in info.Continents.Keys)
            {
                PlayerReportEntry e = info.Continents[ic];
                bbcode += "\n\n[b]C" + String.Format("{0:00}", ic) + " (" + (e.PScore > 10000 ? String.Format("{0:0,0,0,0,0}", e.PScore) : (e.PScore > 1000 ? String.Format("{0:0,0}", e.PScore) : "" + e.PScore)) + ")[/b]\n";
                report += "<hr /><center><h3>C" + String.Format("{0:00}", ic) + " (" + (e.PScore > 10000 ? String.Format("{0:0,0,0,0,0}", e.PScore) : (e.PScore > 1000 ? String.Format("{0:0,0}", e.PScore) : "" + e.PScore)) + ")</h2></center>";
                if (e.Cities.Count > 0)
                {
                    bbcode += String.Format("Cities\n");
                    report += String.Format("<h4>Cities</h4><ul>");
                    CityInfo[] cs = new CityInfo[e.Cities.Count];
                    e.Cities.CopyTo(cs, 0);
                    Array.Sort(cs);
                    Array.Reverse(cs);
                    foreach (CityInfo c in cs)
                    {
                        bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                        report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
                    }
                    report += String.Format("</ul>");
                }
                if (e.Castles.Count > 0)
                {
                    bbcode += String.Format("Castles\n");
                    report += String.Format("<h4>Castles</h4><ul>");
                    CityInfo[] cs = new CityInfo[e.Castles.Count];
                    e.Castles.CopyTo(cs, 0);
                    Array.Sort(cs);
                    Array.Reverse(cs);
                    foreach (CityInfo c in cs)
                    {
                        bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                        report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
                    }
                    report += String.Format("</ul>");
                }
            }
            new ReportForm(title, report,bbcode).Show();
            statePictureBox1.Etat = StatePictureBoxStates.None;
            this.Enabled = true;
        }
        private delegate void GlobalReportEntryHandler(GlobalReportEntry info);
        private void EndLoadPlayerInfoBadly(GlobalReportEntry info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new GlobalReportEntryHandler(EndLoadPlayerInfoBadly), info);
                return;
            }
            statePictureBox1.Etat = StatePictureBoxStates.Bad;
            this.Enabled = true;
        }

        private void btnReportAlliance_Click(object sender, EventArgs e)
        {
            //lblStatus.Text = "";
            this.Enabled = false;
            statePictureBox1.Etat = StatePictureBoxStates.Waiting;
            //dgvCities.Rows.Clear();
            //worlds.Clear();
            //tabControl1.TabPages.Remove(tpageReports);
            new Thread(new ParameterizedThreadStart(LoadAllianceInfo)).Start(new GlobalReportEntry((int)nudWorld.Value, txtAllianceName.Text,chooReportAlliance.Value));
        }

        private void txtAllianceName_TextChanged(object sender, EventArgs e)
        {
            btnReportAlliance.Enabled = !String.IsNullOrEmpty(txtAllianceName.Text);
        }
        private class AllianceReportEntry
        {
            public int AScore;
            public List<PlayerReportEntry> Players = new List<PlayerReportEntry>();
        }
        private class AllianceReportRoot
        {
            public string AName;
            public int AScore;
            public Dictionary<int, AllianceReportEntry> Continents = new Dictionary<int, AllianceReportEntry>();
        }
        private AllianceReportRoot getAlliance(string alliance, int world, CityCastleType cc)
        {
            AllianceReportRoot res = new AllianceReportRoot();
            
            res.AName = alliance;
            res.AScore = 0;

            foreach (ContinentInfo c in worlds[world].Continents)
                if (c.Loaded)
                {
                    if (c.AlliancesOldWay.ContainsKey(res.AName))
                    {
                        AllianceInfo a = c.AlliancesOldWay[res.AName];
                        res.AScore += a.Score;
                        AllianceReportEntry ae = new AllianceReportEntry();
                        ae.AScore = a.Score;
                        res.Continents.Add(c.ID, ae);
                        foreach( PlayerInfo p in a.PlayersOldWay.Values)
                        {
                            PlayerReportEntry e = new PlayerReportEntry();
                            e.AName = a.Name;
                            e.AScore = a.Score;
                            e.PName = p.Name;
                            e.PScore = p.Score;
                            ae.Players.Add(e);
                            foreach (CityInfo ci in p.AllCities)
                            {
                                if (ci.Castle &&(cc == CityCastleType.Both || cc == CityCastleType.Castle))
                                    e.Castles.Add(ci);
                                if (!ci.Castle && (cc == CityCastleType.Both || cc == CityCastleType.City))
                                    e.Cities.Add(ci);
                            }
                        }
                    }
                }
            return res;
        }
        public void LoadAllianceInfo(object State)
        {
            GlobalReportEntry info = (GlobalReportEntry) State;
            int world = info.World;
            string alliance = info.Param;
            try
            {
                loadUpdated(world);
                loadShrines(world);
                foreach (ContinentInfo c in worlds[world].Continents)
                    try { loadOverlay(world, c.ID); }
                    catch { }
                AllianceReportRoot res = getAlliance(alliance, world, info.CityCastle);
                EndLoadAllianceInfo(res);
            }
            catch
            {
                EndLoadAllianceInfoBadly(info);
            }
        }

        private delegate void AllianceReportRootHandler(AllianceReportRoot info);
        private void EndLoadAllianceInfo(AllianceReportRoot info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AllianceReportRootHandler(EndLoadAllianceInfo), info);
                return;
            }
            int w = (int)nudWorld.Value;
            int co = (int)nudContinent.Value;
            String title = "Report on " + info.AName + " (" + (info.AScore > 10000 ? String.Format("{0:0,0,0,0,0}", info.AScore) : (info.AScore > 1000 ? String.Format("{0:0,0}", info.AScore) : "" + info.AScore)) + ")";
            string report = "<center><h1>" + title + "</h1></center>";
            string bbcode = "[b][u]Report on [alliance]" + info.AName + "[/alliance] (" + (info.AScore > 10000 ? String.Format("{0:0,0,0,0,0}", info.AScore) : (info.AScore > 1000 ? String.Format("{0:0,0}", info.AScore) : "" + info.AScore)) + ")[/u][/b]\n";
            foreach (int ic in info.Continents.Keys)
            {
                AllianceReportEntry e = info.Continents[ic];
                bbcode += "\n\n[b]C" + String.Format("{0:00}", ic) + " (" + (e.AScore > 10000 ? String.Format("{0:0,0,0,0,0}", e.AScore) : (e.AScore > 1000 ? String.Format("{0:0,0}", e.AScore) : "" + e.AScore)) + ")[/b]\n";
                report += "<hr /><center><h3>C" + String.Format("{0:00}", ic) + " (" + (e.AScore > 10000 ? String.Format("{0:0,0,0,0,0}", e.AScore) : (e.AScore > 1000 ? String.Format("{0:0,0}", e.AScore) : "" + e.AScore)) + ")</h2></center>";

                foreach (PlayerReportEntry p in e.Players)
                {
                    bbcode += String.Format("\n\n[b][player]{0}[/player][/b] ({1})\n", p.PName, (p.PScore > 10000 ? String.Format("{0:0,0,0,0,0}", p.PScore) : (p.PScore > 1000 ? String.Format("{0:0,0}", p.PScore) : "" + p.PScore)));
                    report += String.Format("<br /><br /><h3>{0} ({1})</h3>", p.PName, (p.PScore > 10000 ? String.Format("{0:0,0,0,0,0}", p.PScore) : (p.PScore > 1000 ? String.Format("{0:0,0}", p.PScore) : "" + p.PScore)));
                    if (p.Cities.Count > 0)
                    {
                        bbcode += String.Format("Cities\n");
                        report += String.Format("<h4>Cities</h4><ul>");
                        CityInfo[] cs = new CityInfo[p.Cities.Count];
                        p.Cities.CopyTo(cs, 0);
                        Array.Sort(cs);
                        Array.Reverse(cs);
                        foreach (CityInfo c in cs)
                        {
                            bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                            report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
                        }
                        report += String.Format("</ul>");
                    }
                    if (p.Castles.Count > 0)
                    {
                        bbcode += String.Format("Castles\n");
                        report += String.Format("<h4>Castles</h4><ul>");
                        CityInfo[] cs = new CityInfo[p.Castles.Count];
                        p.Castles.CopyTo(cs, 0);
                        Array.Sort(cs);
                        Array.Reverse(cs);
                        foreach (CityInfo c in cs)
                        {
                            bbcode += String.Format("{0} [i]{1}[/i] ({2})\n", c.Location, c.Name, c.SayScore);
                            report += String.Format("<li>{0}  <b>{1}</b>  ({3})</li>", c.Location, c.Name, (c.Castle ? "[*]" : ""), c.SayScore);
                        }
                        report += String.Format("</ul>");
                    }
                }
            }
            new ReportForm(title, report, bbcode).Show();
            statePictureBox1.Etat = StatePictureBoxStates.None;
            this.Enabled = true;
        }
        //public delegate void IntStringHandler(KeyValuePair<int, string> info);
        private void EndLoadAllianceInfoBadly(GlobalReportEntry info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new GlobalReportEntryHandler(EndLoadAllianceInfoBadly), info);
                return;
            }
            statePictureBox1.Etat = StatePictureBoxStates.Bad;
            this.Enabled = true;
        }

        private void btnReportShrines_Click(object sender, EventArgs e)
        {
            int w = (int)nudWorld.Value;
            int co = (int)nudContinent.Value;
            String title = "Shrines & Moongates on C" + co + " (World " + w + ")";
            string report = "<center><h1>" + title + "</h1></center>";
            string bbcode = "[b][u]Shrines on C" + co + "[/u][/b]\n";
            report += "<h2>Shrines</h2><ul>";
            foreach (Pt p in worlds[w].Cont(co).Shrines)
            {
                bbcode += String.Format("[b]{0}[/b]\n", p);
                report += String.Format("<li><b>{0}</b></li><ul>", p);
                foreach( AllianceInfo ai in worlds[w].Cont(co).AlliancesOldWay.Values)
                    foreach( PlayerInfo pi in ai.PlayersOldWay.Values )
                        foreach (CityInfo ci in pi.Neighbours(p.X, p.Y, 3))
                        {
                            if ((chooReportShrines.City && !ci.Castle) || (chooReportShrines.Castle && ci.Castle))
                            {
                                bbcode += String.Format("{0}{1} [i]{2}[/i] ({3}), [player]{4}[/player], [alliance]{5}[/alliance]\n", (ci.Castle ? "[*] " : ""), ci.Location, ci.Name, ci.SayScore, pi.Name, ai.Name);
                                report += String.Format("<li>{0}{1} <i>{2}</i> ({3}), <b>{4}</b>, {5}</li>", (ci.Castle ? "[*] " : ""), ci.Location, ci.Name, ci.SayScore, pi.Name, ai.Name);
                            }
                        }
                report += "</ul>";
            }
            report += "</ul>";
            bbcode += "\n\n[b][u]Moongates on C" + co + "[/u][/b]\n";
            report += "<hr /><h2>Moongates</h2><ul>";
            foreach (Pt p in worlds[w].Cont(co).MoonGates)
            {
                bbcode += String.Format("{0}\n", p);
                report += String.Format("<li>{0}</li>", p);
            }
            report += "</ul>";
            new ReportForm(title, report, bbcode).Show();
        }

        private void btnCityType_ButtonClick(object sender, EventArgs e)
        {
            btnCityType.ShowDropDown();
        }

        private void btnBoth_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnBoth.Text;
        }

        private void btnCastles_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnCastles.Text;
        }

        private void btnCities_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnCities.Text;
        }
    }
}
