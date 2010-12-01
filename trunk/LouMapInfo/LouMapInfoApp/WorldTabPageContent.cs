using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using LouMapInfo.Loading;
using System.Threading;
using LouMapInfo.Reports;
using LouMapInfo.Reports.Entities;

namespace LouMapInfoApp
{
    public partial class WorldTabPageContent : UserControl
    {
        private Dictionary<int, WorldInfo> worlds;
        public Dictionary<int, WorldInfo> Worlds
        {
            get { return worlds; }
            set { worlds = value; }
        }

        private System.Windows.Forms.Timer waitingTimer;
        private int waitingCounter = 0;
        int world;
        int lvl;
        CityCastleType type = CityCastleType.Both;
        public WorldInfo World
        {
            get { return worlds[world]; }
        }

        public WorldTabPageContent()
        {
            InitializeComponent();
            world = Properties.Settings.Default.lastWWorld;
            lvl = Properties.Settings.Default.lastWDetailLvl;
            for (int i = 1; i <= 22; ++i)
            {
                ToolStripMenuItem btn = new ToolStripMenuItem();
                btn.Name = "btnWorld_" + i;
                btn.Text = "World " + i;
                btnWorld.DropDownItems.Add(btn);
                btn.Click += new EventHandler(btnWorld_X_Click);
                if (i == world)
                    btn.Checked = true;
            }
            CityCastleType t = (CityCastleType)Properties.Settings.Default.lastWCityType;
            switch (t)
            {
                case CityCastleType.Both: btnBoth_Click(null, new EventArgs()); break;
                case CityCastleType.Castle: btnCastles_Click(null, new EventArgs()); break;
                case CityCastleType.City: btnCities_Click(null, new EventArgs()); break;
            }
            switch (lvl)
            {
                case 1: btnReportsLvl1_Click(null, new EventArgs()); break;
                case 2: btnReportsLvl2_Click(null, new EventArgs()); break;
                case 3: btnReportsLvl3_Click(null, new EventArgs()); break;
            }
            btnWorld.Text = "W" + world;
        }
        private void btnCityType_ButtonClick(object sender, EventArgs e)
        {
            btnCityType.ShowDropDown();
        }

        private void btnBoth_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnBoth.Text;
            btnBoth.Checked = true;
            btnCities.Checked = false;
            btnCastles.Checked = false;
            type = CityCastleType.Both;
            if (sender != null)
            {
                RenderGrid();
                Properties.Settings.Default.lastWCityType = (int)type;
                Properties.Settings.Default.Save();
            }
        }

        private void btnCastles_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnCastles.Text;
            btnBoth.Checked = false;
            btnCities.Checked = false;
            btnCastles.Checked = true;
            type = CityCastleType.Castle;
            if (sender != null)
            {
                RenderGrid();
                Properties.Settings.Default.lastWCityType = (int)type;
                Properties.Settings.Default.Save();
            }
        }

        private void btnCities_Click(object sender, EventArgs e)
        {
            btnCityType.Text = btnCities.Text;
            btnBoth.Checked = false;
            btnCities.Checked = true;
            btnCastles.Checked = false;
            type = CityCastleType.City;
            if (sender != null)
            {
                RenderGrid();
                Properties.Settings.Default.lastWCityType = (int)type;
                Properties.Settings.Default.Save();
            }
        }

        private void btnWorld_ButtonClick(object sender, EventArgs e)
        {
            btnWorld.ShowDropDown();
        }

        void btnWorld_X_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)btnWorld.DropDownItems["btnWorld_" + world]).Checked = false;
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            world = int.Parse(btn.Text.Substring(btn.Text.LastIndexOf(' ') + 1));
            btnWorld.Text = "W" + world;
            btn.Checked = true;
            Properties.Settings.Default.lastWWorld = world;
            Properties.Settings.Default.Save();
        }

        delegate void EmptyHandler();
        void StartWaiting()
        {
            if (InvokeRequired)
            {
                Invoke(new EmptyHandler(StartWaiting));
            }
            if (waitingTimer == null)
            {
                waitingTimer = new System.Windows.Forms.Timer();
                waitingTimer.Interval = 100;
                waitingTimer.Tick += new EventHandler(waitingTimer_Tick);
                waitingTimer.Start();
                lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting0;
            }
        }
        void StopWaiting()
        {
            if (InvokeRequired)
            {
                Invoke(new EmptyHandler(StopWaiting));
            }
            if (waitingTimer != null)
            {
                waitingTimer.Stop();
                waitingTimer = null;
                lblImage.Image = Properties.Resources.logo_LOU;
            }
        }

        void waitingTimer_Tick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(waitingTimer_Tick), sender, e);
            }
            if (waitingTimer != null)
            {
                waitingCounter++;
                waitingCounter %= 8;
                switch (waitingCounter)
                {
                    case 0:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting0;
                        break;
                    case 1:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting1;
                        break;
                    case 2:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting2;
                        break;
                    case 3:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting3;
                        break;
                    case 4:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting4;
                        break;
                    case 5:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting5;
                        break;
                    case 6:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting6;
                        break;
                    case 7:
                        lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting7;
                        break;
                }
            }
            else
            {
                waitingTimer.Stop();
                waitingTimer = null;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            StartWaiting();
            Enable(false);
            pnlContent.Visible = false;
            new Thread(new ThreadStart(LoadWorld)).Start();
        }

        public void LoadWorld()
        {
            try
           {
                GlobalLoading.LoadUpdated(worlds);
                WorldLoading.LoadShrines(worlds,world);
                foreach (ContinentInfo c in World.Continents)
                    try { ContinentLoading.LoadContinent(worlds,world, c.ID); }
                    catch { }
                EndLoadWorld();
                
            }
            catch
            {
                EndLoadWorld();
            }
        }
        private void RenderGrid()
        {
            dgvCities.Visible = false;
            dgvCities.Rows.Clear();/*
            foreach (AllianceInfo a in worlds[world].Cont(continent).Alliances.Values)
            {
                foreach (PlayerInfo p in a.Players.Values)
                {
                    foreach (CityInfo c in p.AllCities)
                    {
                        if (type == CityCastleType.Both || (!c.Castle && type == CityCastleType.City) || (c.Castle && type == CityCastleType.Castle))
                        dgvCities.Rows.Add(a.Name, a.Score, p.Name, p.Score, c.Location.X, c.Location.Y, c.Name, c.Castle, c.Score);
                    }
                }
            }*/
        }
        private void EndLoadWorld()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EndLoadWorld));
                return;
            }
            StopWaiting();
            dgvCities.Sort(dgvCities.Columns["AllianceName"], ListSortDirection.Ascending);
            Enable(true);
            RenderGrid();
            pnlContent.Visible = true;
        }
        private void EndLoadWorldBadly()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EndLoadWorldBadly));
                return;
            }
            StopWaiting();
            Enable(true);
            this.Enabled = true;
        }
        delegate void BoolHandler(bool value);
        void Enable(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(Enable),value);
            }
            btnLoad.Enabled = value;
            btnWorld.Enabled = value;
        }

        private void btnReportsLvl_ButtonClick(object sender, EventArgs e)
        {
            btnReportsLvl.ShowDropDown();
        }

        private void btnReportsLvl1_Click(object sender, EventArgs e)
        {
            lvl = 1;
            btnReportsLvl.Text = btnReportsLvl1.Text + ":";
            btnReportsLvl1.Checked = true;
            btnReportsLvl2.Checked = false;
            btnReportsLvl3.Checked = false;
            if (sender != null)
            {
                Properties.Settings.Default.lastWDetailLvl = lvl;
                Properties.Settings.Default.Save();
            }
        }

        private void btnReportsLvl2_Click(object sender, EventArgs e)
        {
            lvl = 2;
            btnReportsLvl.Text = btnReportsLvl2.Text + ":";
            btnReportsLvl1.Checked = false;
            btnReportsLvl2.Checked = true;
            btnReportsLvl3.Checked = false;
            if (sender != null)
            {
                Properties.Settings.Default.lastWDetailLvl = lvl;
                Properties.Settings.Default.Save();
            }
        }

        private void btnReportsLvl3_Click(object sender, EventArgs e)
        {
            lvl = 3;
            btnReportsLvl.Text = btnReportsLvl3.Text + ":";
            btnReportsLvl1.Checked = false;
            btnReportsLvl2.Checked = false;
            btnReportsLvl3.Checked = true;
            if (sender != null)
            {
                Properties.Settings.Default.lastWDetailLvl = lvl;
                Properties.Settings.Default.Save();
            }
        }

        private void btnReportPlayers_Click(object sender, EventArgs e2)
        {
            PlayerReportRoot info = getPlayer(txtName.Text, world, type);
            int w = world;
            String title = "Report on " + info.PName + " (" + (info.PScore > 10000 ? String.Format("{0:0,0,0,0,0}", info.PScore) : (info.PScore > 1000 ? String.Format("{0:0,0}", info.PScore) : "" + info.PScore)) + ")";
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
            new ReportForm(title, report, bbcode).Show();
        }

        private void btnReportAlliance_Click(object sender, EventArgs e2)
        {
            AllianceReportRoot info = getAlliance(txtName.Text, world, type);
            // TODO:
            int w = world;
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
                    if (res.AName != null && c.AlliancesOldWay.ContainsKey(res.AName))
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
                        foreach (PlayerInfo p in a.PlayersOldWay.Values)
                        {
                            PlayerReportEntry e = new PlayerReportEntry();
                            e.AName = a.Name;
                            e.AScore = a.Score;
                            e.PName = p.Name;
                            e.PScore = p.Score;
                            ae.Players.Add(e);
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
            return res;
        }
    }
}
