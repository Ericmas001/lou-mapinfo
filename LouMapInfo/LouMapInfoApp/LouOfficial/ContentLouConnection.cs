using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using LouMapInfo;
using System.Threading;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouConnection : UserControl
    {
        private MainForm m_Parent;
        public ContentLouConnection(MainForm parent)
        {
            m_Parent = parent;
            InitializeComponent();
            foreach (ServerInfo s in ServerList.AllServers)
            {
                lstServerNames1.Items.Add(s.Name);
                lstServerNames2.Items.Add(s.Name);
            }
            txtUsername.Text = Properties.Settings.Default.liveUsername;
            txtPassword.Text = Properties.Settings.Default.livePassword;
            lstServerNames1.SelectedItem = Properties.Settings.Default.liveWorld;
            lstServerNames2.SelectedItem = Properties.Settings.Default.liveWorld;
        }

        private void ContentLouConnection_Resize(object sender, EventArgs e)
        {
            centerPanel.Location = new Point((Width / 2) - (centerPanel.Width / 2), (Height / 2) - (centerPanel.Height / 2));
        }

        private void btnConnectSessionID_Click(object sender, EventArgs e)
        {
            if (txtSessionID.Text.Length > 0 && lstServerNames2.SelectedIndex >= 0)
            {
                // We connect
                Properties.Settings.Default.liveWorld = lstServerNames2.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                EnableAll(false);
                statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.Waiting;
                SessionInfo session = new SessionInfo(txtSessionID.Text, lstServerNames2.SelectedItem.ToString());
                new Thread(new ParameterizedThreadStart(Connect)).Start(session);
            }
        }

        private void btnConnectCredentials_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0 && lstServerNames1.SelectedIndex >= 0)
            {
                // We connect
                Properties.Settings.Default.liveUsername = txtUsername.Text;
                Properties.Settings.Default.livePassword = txtPassword.Text;
                Properties.Settings.Default.liveWorld = lstServerNames1.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                EnableAll(false);
                statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.Waiting;
                SessionInfo session = new SessionInfo(txtUsername.Text, txtPassword.Text, lstServerNames1.SelectedItem.ToString());
                new Thread(new ParameterizedThreadStart(Connect)).Start(session);
            }
        }

        private void Connect(object state_session)
        {
            SessionInfo session = (SessionInfo)state_session;
            bool connect = session.Connect();
            if (connect)
            {
                session.World.ForceLoad();
                InitSession(session);
            }
            else
                EnableAll(true);
            statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.None;
        }
        delegate void BoolHandler(bool isEnabled);
        private void EnableAll(bool isEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(EnableAll), isEnabled);
                return;
            }
            centerPanel.Enabled = isEnabled;
        }



        delegate void SessionHandler(SessionInfo isConnected);
        private void InitSession(SessionInfo session)
        {
            if (InvokeRequired)
            {
                Invoke(new SessionHandler(InitSession), session);
                return;
            }
            m_Parent.Session = session;
            m_Parent.FillOfficial();
            EnableAll(true);
        }
    }
}
