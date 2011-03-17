using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using System.Threading;
using LouMapInfo.Loading;
using LouMapInfo.Reports;
using System.Diagnostics;

namespace LouMapInfoApp.LouMap
{
    public partial class ContentLMWorld : UserControl
    {

        private System.Windows.Forms.Timer waitingTimer;
        private int waitingCounter = 0;
        private Dictionary<int, WorldInfo> worlds;
        public Dictionary<int, WorldInfo> Worlds
        {
            get { return worlds; }
        }
        int world = -1;
        int lvl;
        CityCastleType type = CityCastleType.Both;
        public WorldInfo World
        {
            get { return worlds[world]; }
        }
        public ContentLMWorld(Dictionary<int, WorldInfo> w)
        {
            worlds = w;
            InitializeComponent();
            lvl = Properties.Settings.Default.lastCDetailLvl;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWorld.SelectedIndex >= 0)
            {
                world = lstWorld.SelectedIndex + 1;
                pnlReport.Controls.Clear();
                StartWaiting();
                Enable(false);
                pnlContent.Visible = false;
                new Thread(new ThreadStart(LoadWorld)).Start();
            }
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
                lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting0;
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
                lblImage.BackgroundImage = Properties.Resources.menu_Map;
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
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting0;
                        break;
                    case 1:
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting1;
                        break;
                    case 2:
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting2;
                        break;
                    case 3:
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting3;
                        break;
                    case 4:
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting4;
                        break;
                    case 5:
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting5;
                        break;
                    case 6:
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting6;
                        break;
                    case 7:
                        lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting7;
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
            lblLastUpdated.Visible = false;
            pnlContent.Visible = false;
            new Thread(new ThreadStart(LoadWorld)).Start();
        }

        public void LoadWorld()
        {
            try
            {
                GlobalLoading.LoadUpdated(worlds);
                WorldLoading.LoadShrines(worlds, world);
                foreach (ContinentInfo c in World.Continents)
                    try { ContinentLoading.LoadContinent(worlds, world, c.ID); }
                    catch { }
                EndLoadWorld();

            }
            catch
            {
                EndLoadWorld();
            }
        }
        public delegate void IntIntHandler(KeyValuePair<int, int> info);
        private void EndLoadWorld()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EndLoadWorld));
                return;
            }
            StopWaiting();
            Enable(true);
            lblLastUpdated.Text = String.Format("Last Updated: {0:yyyy}-{0:MM}-{0:dd}", World.LastUpdated); ;
            lblLastUpdated.Visible = true;
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
            lblLastUpdated.Text = "Error while Loading";
            lblLastUpdated.Visible = true;
            Enable(true);
            this.Enabled = true;
        }
        delegate void BoolHandler(bool value);
        void Enable(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(Enable), value);
            }
            foreach (ToolStripItem it in toolStrip1.Items)
                if (it != lblImage)
                    it.Enabled = value;
        }

        private void btnReportPlayers_Click(object sender, EventArgs e2)
        {
            Properties.Settings.Default.lastWName = txtName.Text;
            Properties.Settings.Default.Save();
            pnlReport.Controls.Clear();
            ContentReport cr = new ContentReport(new PlayerOverviewReport(World, txtName.Text, type), lvl);
            pnlReport.Controls.Add(cr);
            cr.Dock = DockStyle.Fill;
            cr.Invalidate();
        }

        private void btnReportAlliance_Click(object sender, EventArgs e2)
        {
            Properties.Settings.Default.lastWName = txtName.Text;
            Properties.Settings.Default.Save();
            pnlReport.Controls.Clear();
            ContentReport cr = new ContentReport(new AllianceOverviewReport(World, txtName.Text, type), lvl);
            pnlReport.Controls.Add(cr);
            cr.Dock = DockStyle.Fill;
            cr.Invalidate();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

    }
}
