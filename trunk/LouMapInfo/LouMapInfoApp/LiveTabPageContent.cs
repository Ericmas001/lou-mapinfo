using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU;
using System.Threading;
using System.Net;
using System.Net.Cache;
using EricUtility.Networking.JSON;
using System.IO;
using LouMapInfo.Reports;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.OfficialLOU;
using LouMapInfo.Reports.core;

namespace LouMapInfoApp
{
    public partial class LiveTabPageContent : UserControl
    {

        private System.Windows.Forms.Timer waitingTimer;
        private int waitingCounter = 0;
        private LoUSessionInfo m_Session = null;
        public LiveTabPageContent()
        {
            InitializeComponent();
            dgvPlayers.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvPlayers_CellFormatting);
            dgvPlayers.CellContentClick += new DataGridViewCellEventHandler(dgvPlayers_CellContentClick);
        }

        void dgvPlayers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPlayersScore.Index)
            {
                e.Value = ((int)e.Value).ToString("N0");
            }
        }

        private void LiveTabPageContent_Load(object sender, EventArgs e)
        {
            ((TextBox)txtPassword.Control).PasswordChar = '*';
            foreach (string s in LoUServerList.Servers.Keys)
                lstServerNames.Items.Add(s);
            txtUsername.Text = Properties.Settings.Default.liveUsername;
            txtPassword.Text = Properties.Settings.Default.livePassword;
            lstServerNames.SelectedItem = Properties.Settings.Default.liveWorld;
        }
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (m_Session != null)
            {
                // We disconnect
                m_Session = null;
                SetConnected(false);
            }
            else if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0 && lstServerNames.SelectedIndex >= 0)
            {
                // We connect
                Properties.Settings.Default.liveUsername = txtUsername.Text;
                Properties.Settings.Default.livePassword = txtPassword.Text;
                Properties.Settings.Default.liveWorld = lstServerNames.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                //SetConnected(true);
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                lstServerNames.Enabled = false;
                btnConnect.Enabled = false;
                StartWaiting();
                LoUSessionInfo session = new LoUSessionInfo(txtUsername.Text, txtPassword.Text, lstServerNames.SelectedItem.ToString());
                 new Thread(new ParameterizedThreadStart(Connect)).Start(session);
            }
        }

        private void Connect(object state_session)
        {
            LoUSessionInfo session = (LoUSessionInfo)state_session; 
            bool connect = session.Connect();
            if (connect)
            {
                m_Session = session;
                session.World.ForceLoad();
                InitSession(m_Session);
                SetConnected(true);
            }
            else
                SetConnected(false);
            StopWaiting();
        }

        delegate void SessionHandler(LoUSessionInfo isConnected);
        private void InitSession(LoUSessionInfo session)
        {
            if (InvokeRequired)
            {
                Invoke(new SessionHandler(InitSession), session);
                return;
            }
            dgvPlayers.Rows.Clear();
            foreach (LoUPlayerInfo p in session.World.Players)
            {
                dgvPlayers.Rows.Add(p.Name, p.Alliance.Name, p.Score, p.Rank, p.CityCount);
            }
            string pName = session.World.Player(session.PlayerID).Name;
            string aName = session.World.Alliance(session.AllianceID).Name;
            lblWorldInfo.Text = pName + (String.IsNullOrEmpty(aName) ? "" : (" (" + aName + ")"));
            btnPlayerReportMe.Text = pName;
            btnAllianceReportMe.Text = aName;
            int ind = 1;
            List<int> actives = new List<int>(session.World.Alliance(session.AllianceID).ActiveContinents);
            foreach (int ic in session.World.Alliance(session.AllianceID).ActiveContinents)
            {
                ToolStripButton btnContinent = new ToolStripButton(ic.ToString("00"));
                btnContinent.Click += new EventHandler(btnContinent_Click);
                tbReportContinentOverview.Items.Insert(ind, btnContinent);
                ToolStripButton btnLawless = new ToolStripButton(ic.ToString("00"));
                btnLawless.Click += new EventHandler(btnLawless_Click);
                tbReportLawlessCities.Items.Insert(ind, btnLawless);
                ToolStripButton btnMoonGates = new ToolStripButton(ic.ToString("00"));
                btnMoonGates.Click += new EventHandler(btnMoonGates_Click);
                tbReportMoongatesLocation.Items.Insert(ind, btnMoonGates);
                ind++;
            }
            lstNonActiveContinent.Items.Clear();
            for (int i = 0; i <= 6; ++i)
            {
                for (int j = 0; j <= 6; ++j)
                {
                    int c = (i * 10) + j;
                    if (!actives.Contains(c))
                    {
                        lstNonActiveContinent.Items.Add(c.ToString("00"));
                        lstNonActiveContinentLawless.Items.Add(c.ToString("00"));
                        lstNonActiveContinentMoonGates.Items.Add(c.ToString("00"));
                    }
                }
            }

        }
        delegate void BoolHandler(bool isConnected);
        private void SetConnected(bool isConnected)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(SetConnected), isConnected);
                return;
            }
            txtUsername.Enabled = !isConnected;
            txtPassword.Enabled = !isConnected;
            lstServerNames.Enabled = !isConnected;
            btnConnect.Text = isConnected ? "Disconnect" : "Connect";
            btnConnect.Enabled = true;
            pnlContent.Visible = isConnected;
            lblWorldInfo.Visible = isConnected;
        }


        delegate void EmptyHandler();
        void StartWaiting()
        {
            if (InvokeRequired)
            {
                Invoke(new EmptyHandler(StartWaiting));
                return;
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
                return;
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
                return;
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

        private void button1_Click(object sender, EventArgs e)
        {
            JsonObject res = LoUEndPoint.GetPlayerList("http://prodgame05.lordofultima.com/14/", "63fc09c3-6f32-4af3-8e9a-088f005b5463");
            MessageBox.Show(res.ToString());
        }

        private void dgvPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPlayersName.Index)
                OpenPlayerReport(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString());
                
            if (e.ColumnIndex == dgvPlayersAlliance.Index)
                OpenAllianceReport(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void btnPlayerReportMe_Click(object sender, EventArgs e)
        {
            OpenPlayerReport(m_Session.PlayerID);
        }

        private void btnPlayerReportOther_Click(object sender, EventArgs e)
        {
            OpenPlayerReport(txtPlayerReportOther.Text);
            }

        private void btnAllianceReportMe_Click(object sender, EventArgs e)
        {
            OpenAllianceReport(m_Session.AllianceID);
        }

        private void btnAllianceReportOther_Click(object sender, EventArgs e)
        {
            OpenAllianceReport(txtAllianceReportOther.Text);
        }

        private void btnAllianceReportNoAlliance_Click(object sender, EventArgs e)
        {
            OpenAllianceReport("");
        }

        private void OpenPlayerReport(object p)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenPlayerReportAsync)).Start(p);
        }

        private void OpenAllianceReport(object a)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenAllianceReportAsync)).Start(a);
        }

        private void OpenPlayerReportAsync(object o)
        {
            LoUPlayerInfo p = null;
            if (o is int)
                p = m_Session.World.Player((int)o);
            else if (o is string)
                p = m_Session.World.Player((string)o);

            if (p == null)
                ContentEnabling(true);
            else
            {
                LoUPlayerOverviewReport rep = new LoUPlayerOverviewReport(p, OldLoUCityType.CityCastlePalace);
                rep.LoadIfNeeded();
                OpenReport(rep,4);
                ContentEnabling(true);
            }
        }

        private void OpenAllianceReportAsync(object o)
        {
            LoUAllianceInfo a = null;
            if (o is int)
                a = m_Session.World.Alliance((int)o);
            else if (o is string)
                a = m_Session.World.Alliance((string)o);

            if (a == null)
                ContentEnabling(true);
            else
            {
                LoUAllianceOverviewReport rep = new LoUAllianceOverviewReport(a, OldLoUCityType.CityCastlePalace);
                rep.LoadIfNeeded();
                OpenReport(rep, 4);
                ContentEnabling(true);
            }
        }
        public void ContentEnabling(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(ContentEnabling), value);
                return;
            }
            btnConnect.Enabled = value;
            pnlContent.Enabled = value;

            if (value) 
                StopWaiting(); 
            else 
                StartWaiting();
        }
        public delegate void ReportHandler(ReportInfo r, int lvl);
        public void OpenReport(ReportInfo r, int lvl)
        {
            if (InvokeRequired)
            {
                Invoke(new ReportHandler(OpenReport), r, lvl);
                return;
            }
            new ReportForm(r, lvl).Show();
        }

        private void OpenContinentReport(int c)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenContinentReportAsync)).Start(c);
        }

        private void OpenContinentReportAsync(object o)
        {
            if (o is int)
            {
                LoUContinentInfo c = m_Session.World.Continent((int)o);
                if (c != null)
                {
                    LoUContinentOverviewReport rep = new LoUContinentOverviewReport(c, OldLoUCityType.CityCastlePalace);
                    rep.LoadIfNeeded();
                    OpenReport(rep, 4);
                }
            }
            ContentEnabling(true);
                
            LoUPlayerInfo p = null;
            if (o is int)
                p = m_Session.World.Player((int)o);
            else if (o is string)
                p = m_Session.World.Player((string)o);

            if (p == null)
                ContentEnabling(true);
            else
            {
                LoUPlayerOverviewReport rep = new LoUPlayerOverviewReport(p, OldLoUCityType.CityCastlePalace);
                rep.LoadIfNeeded();
                OpenReport(rep, 4);
                ContentEnabling(true);
            }
        }

        private void btnContinentReportOther_Click(object sender, EventArgs e)
        {
            if (lstNonActiveContinent.SelectedIndex >= 0)
                OpenContinentReport(int.Parse(lstNonActiveContinent.SelectedItem.ToString()));
        }

        void btnContinent_Click(object sender, EventArgs e)
        {
            OpenContinentReport(int.Parse(((ToolStripButton)sender).Text));
        }

        private void OpenLawlessReport(params int[] conts)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenLawlessReportAsync)).Start(conts);
        }

        private void OpenLawlessReportAsync(object o)
        {
            int[] conts = (int[]) o;
            Dictionary<int, LoUCityInfo[]> res = m_Session.World.Lawless(conts);
            LoULawlessReport rep = new LoULawlessReport(res, OldLoUCityType.CityCastlePalace);
            rep.LoadIfNeeded();
            OpenReport(rep, 4);
            ContentEnabling(true);
        }

        void btnLawless_Click(object sender, EventArgs e)
        {
            OpenLawlessReport(int.Parse(((ToolStripButton)sender).Text));
        }

        private void btnContinentLawlessAll_Click(object sender, EventArgs e)
        {
            OpenLawlessReport();
        }

        private void btnContinentLawlessActive_Click(object sender, EventArgs e)
        {
            OpenLawlessReport(m_Session.World.Player(m_Session.PlayerID).ActiveContinents);
        }

        private void btnContinentLawlessOther_Click(object sender, EventArgs e)
        {
            if (lstNonActiveContinentLawless.SelectedIndex >= 0)
                OpenLawlessReport(int.Parse(lstNonActiveContinentLawless.SelectedItem.ToString()));
        }

        private void OpenMoonGatesReport(params int[] conts)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenMoonGatesReportAsync)).Start(conts);
        }

        private void OpenMoonGatesReportAsync(object o)
        {
            int[] conts = (int[])o;
            Dictionary<int, LoUMoonGateInfo[]> res = m_Session.World.MoonGates(conts);
            LoUMoongatesReport rep = new LoUMoongatesReport(res);
            rep.LoadIfNeeded();
            OpenReport(rep, 4);
            ContentEnabling(true);
        }

        private void btnContinentMoonGatesAll_Click(object sender, EventArgs e)
        {
            OpenMoonGatesReport();
        }

        private void btnContinentMoonGatesActive_Click(object sender, EventArgs e)
        {
            OpenMoonGatesReport(m_Session.World.Player(m_Session.PlayerID).ActiveContinents);
        }

        private void btnContinentMoonGatesOther_Click(object sender, EventArgs e)
        {
            if (lstNonActiveContinentMoonGates.SelectedIndex >= 0)
                OpenMoonGatesReport(int.Parse(lstNonActiveContinentMoonGates.SelectedItem.ToString()));
        }

        void btnMoonGates_Click(object sender, EventArgs e)
        {
            OpenMoonGatesReport(int.Parse(((ToolStripButton)sender).Text));
        }
    }
}
