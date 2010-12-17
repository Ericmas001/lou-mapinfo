using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU;
using System.Threading;

namespace LouMapInfoApp
{
    public partial class LiveTabPageContent : UserControl
    {

        private System.Windows.Forms.Timer waitingTimer;
        private int waitingCounter = 0;
        private SessionInfo m_Session = null;
        public LiveTabPageContent()
        {
            InitializeComponent();
        }

        private void LiveTabPageContent_Load(object sender, EventArgs e)
        {
            ((TextBox)txtPassword.Control).PasswordChar = '*';
            foreach (string s in ServerList.Servers.Keys)
                lstServerNames.Items.Add(s);
            txtUsername.Text = Properties.Settings.Default.liveUsername;
            txtPassword.Text = Properties.Settings.Default.livePassword;
            lstServerNames.SelectedItem = Properties.Settings.Default.liveUsername;
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
                SetConnected(true);
                btnConnect.Enabled = false;
                StartWaiting();
                 SessionInfo session = new SessionInfo(txtUsername.Text, txtPassword.Text);
                 new Thread(new ParameterizedThreadStart(Connect)).Start(session);
            }
        }

        private void Connect(object state_session)
        {
            SessionInfo session = (SessionInfo)state_session; 
            bool connect = session.Connect();
            if (connect)
            {
                m_Session = session;
                SetConnected(true);
            }
            else
                SetConnected(false);
            StopWaiting();
        }
        delegate void BoolHandler(bool isConnected);
        private void SetConnected(bool isConnected)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(SetConnected), isConnected);
            }
            txtUsername.Enabled = !isConnected;
            txtPassword.Enabled = !isConnected;
            lstServerNames.Enabled = !isConnected;
            btnConnect.Text = isConnected ? "Disconnect" : "Connect";
            btnConnect.Enabled = true;
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
    }
}
