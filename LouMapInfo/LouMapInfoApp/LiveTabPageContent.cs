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
            if( e.ColumnIndex == dgvPlayersName.Index )
                new ReportForm(new LoUPlayerOverviewReport(m_Session.World.Player(dgvPlayers[e.ColumnIndex,e.RowIndex].Value.ToString()), OldLoUCityType.CityCastlePalace), 3).Show();

            if (e.ColumnIndex == dgvPlayersAlliance.Index)
                new ReportForm(new LoUAllianceOverviewReport(m_Session.World.Alliance(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString()), OldLoUCityType.CityCastlePalace), 4).Show();
        }

        private void btnPlayerReportMe_Click(object sender, EventArgs e)
        {
            new ReportForm(new LoUPlayerOverviewReport(m_Session.World.Player(m_Session.PlayerID), OldLoUCityType.CityCastlePalace), 3).Show();
        }

        private void btnPlayerReportOther_Click(object sender, EventArgs e)
        {
            LoUPlayerInfo player = m_Session.World.Player(txtPlayerReportOther.Text);
            if( player != null )
                new ReportForm(new LoUPlayerOverviewReport(player, OldLoUCityType.CityCastlePalace), 3).Show();
        }

        private void btnAllianceReportMe_Click(object sender, EventArgs e)
        {
            new ReportForm(new LoUAllianceOverviewReport(m_Session.World.Alliance(m_Session.AllianceID), OldLoUCityType.CityCastlePalace), 4).Show();
        }

        private void btnAllianceReportOther_Click(object sender, EventArgs e)
        {
            LoUAllianceInfo alliance = m_Session.World.Alliance(txtAllianceReportOther.Text);
            if (alliance != null)
                new ReportForm(new LoUAllianceOverviewReport(alliance, OldLoUCityType.CityCastlePalace), 4).Show();
        }

        private void btnAllianceReportNoAlliance_Click(object sender, EventArgs e)
        {
            new ReportForm(new LoUAllianceOverviewReport(m_Session.World.Alliance(""), OldLoUCityType.CityCastlePalace), 4).Show();
        }
    }
}
