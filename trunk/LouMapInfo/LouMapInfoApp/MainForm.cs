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
                int pts = (int)((JsonNumericValue)a["points"]).Value;
                string name = (string)((JsonStringValue)a["name"]).Value;
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
                    int ppts = (int)((JsonNumericValue)p["points"]).Value;
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            statePictureBox1.Etat = StatePictureBoxStates.Waiting;
            dgvCities.Rows.Clear();
            worlds.Clear();
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
            dgvCities.Sort(dgvCities.Columns["CityScore"], ListSortDirection.Descending);
            dgvCities.Sort(dgvCities.Columns["PlayerName"], ListSortDirection.Ascending);
            dgvCities.Sort(dgvCities.Columns["AllianceName"], ListSortDirection.Ascending);
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
    }
}
