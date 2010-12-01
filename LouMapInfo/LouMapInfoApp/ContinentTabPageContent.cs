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

namespace LouMapInfoApp
{
    public partial class ContinentTabPageContent : UserControl
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
        int continent;
        int lvl;
        CityCastleType type = CityCastleType.Both;
        public WorldInfo World
        {
            get { return worlds[world]; }
        }
        public ContinentInfo Continent
        {
            get { return worlds[world].Cont(continent); }
        }

        public ContinentTabPageContent()
        {
            InitializeComponent();
            world = Properties.Settings.Default.lastCWorld;
            continent = Properties.Settings.Default.lastCCont;
            lvl = Properties.Settings.Default.lastCDetailLvl;
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
            for (int i = 0; i <= 6; ++i)
            {
                for (int j = 0; j <= 6; ++j)
                {
                    ToolStripMenuItem btn = new ToolStripMenuItem();
                    btn.Name = "btnContinent_" + i  + "" + j;
                    btn.Text = "Continent " + i + "" + j;
                    btnContinent.DropDownItems.Add(btn);
                    btn.Click += new EventHandler(btnContinent_X_Click);
                }
            }
            CityCastleType t = (CityCastleType)Properties.Settings.Default.lastCCityType;
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
            btnContinent.Text = "C" + String.Format("{0:00}", continent);
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
                Properties.Settings.Default.lastCCityType = (int)type;
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
                Properties.Settings.Default.lastCCityType = (int)type;
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
                Properties.Settings.Default.lastCCityType = (int)type;
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
            Properties.Settings.Default.lastCWorld = world;
            Properties.Settings.Default.Save();
        }

        private void btnContinent_ButtonClick(object sender, EventArgs e)
        {
            btnContinent.ShowDropDown();
        }

        void btnContinent_X_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)btnContinent.DropDownItems["btnContinent_" + String.Format("{0:00}", continent)]).Checked = false;
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            continent = int.Parse(btn.Text.Substring(btn.Text.LastIndexOf(' ') + 1));
            btnContinent.Text = "C" + String.Format("{0:00}", continent);
            btn.Checked = true;
            Properties.Settings.Default.lastCCont = continent;
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
            new Thread(new ThreadStart(LoadContinent)).Start();
        }

        public void LoadContinent()
        {
            try
            {
                GlobalLoading.LoadUpdated(worlds);
                WorldLoading.LoadShrines(worlds,world);
                ContinentLoading.LoadContinent(worlds, world, continent);
                //ContinentLoading.LoadOverlay(worlds,world, continent);
                EndLoadContinent();
                
            }
            catch
            {
                EndLoadContinentBadly();
            }
        }
        private void RenderGrid()
        {
            dgvCities.Rows.Clear();
            foreach (AllianceInfo a in worlds[world].Cont(continent).AlliancesOldWay.Values)
            {
                foreach (PlayerInfo p in a.PlayersOldWay.Values)
                {
                    foreach (CityInfo c in p.AllCities)
                    {
                        if (type == CityCastleType.Both || (!c.Castle && type == CityCastleType.City) || (c.Castle && type == CityCastleType.Castle))
                        dgvCities.Rows.Add(a.Name, a.Score, p.Name, p.Score, c.Location.X, c.Location.Y, c.Name, c.Castle, c.Score);
                    }
                }
            }
        }
        public delegate void IntIntHandler(KeyValuePair<int, int> info);
        private void EndLoadContinent()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EndLoadContinent));
                return;
            }
            StopWaiting();
            dgvCities.Sort(dgvCities.Columns["AllianceName"], ListSortDirection.Ascending);
            Enable(true);
            RenderGrid();
            pnlContent.Visible = true;
        }
        private void EndLoadContinentBadly()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EndLoadContinentBadly));
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
            btnContinent.Enabled = value;
        }

        private void btnReportLawless_Click(object sender, EventArgs e)
        {
            new ReportForm2(new LawlessReport(Continent, type), lvl).Show();
        }

        private void btnReportContinent_Click(object sender, EventArgs e)
        {
            new ReportForm2(new ContinentOverviewReport(Continent, type), lvl).Show();
        }

        private void btnReportShrines_Click(object sender, EventArgs e)
        {
            new ReportForm2(new ShrinesReport(Continent, type), lvl).Show();
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
                Properties.Settings.Default.lastCDetailLvl = lvl;
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
                Properties.Settings.Default.lastCDetailLvl = lvl;
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
                Properties.Settings.Default.lastCDetailLvl = lvl;
                Properties.Settings.Default.Save();
            }
        }
    }
}
