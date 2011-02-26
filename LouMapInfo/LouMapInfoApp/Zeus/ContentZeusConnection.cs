using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.OfficialLOU;
using System.Threading;
using LouMapInfo.Zeus;

namespace LouMapInfoApp.Zeus
{
    public partial class ContentZeusConnection : UserControl
    {
        private MainForm m_Parent;
        public ContentZeusConnection(MainForm parent)
        {
            m_Parent = parent;
            InitializeComponent();
            //foreach (string s in LoUServerList.Servers.Keys)
            //{
            lstServerNames1.Items.Add(LoUServerList.WORLD_10);
            lstServerNames2.Items.Add(LoUServerList.WORLD_10);
            //}
            txtUsername.Text = Properties.Settings.Default.zeusUsername;
            txtUsername2.Text = Properties.Settings.Default.zeusUsername;
            txtPassword.Text = Properties.Settings.Default.zeusPassword;
            lstServerNames1.SelectedIndex = 0;
            lstServerNames2.SelectedIndex = 0;
            lstServerNames1.SelectedItem = Properties.Settings.Default.zeusWorld;
            lstServerNames2.SelectedItem = Properties.Settings.Default.zeusWorld;
        }

        private void ContentLouConnection_Resize(object sender, EventArgs e)
        {
            centerPanel.Location = new Point((Width / 2) - (centerPanel.Width / 2), (Height / 2) - (centerPanel.Height / 2));
        }

        private void btnConnectCredentials_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0 && lstServerNames1.SelectedIndex >= 0)
            {
                // We connect
                Properties.Settings.Default.zeusUsername = txtUsername.Text;
                Properties.Settings.Default.zeusPassword = txtPassword.Text;
                Properties.Settings.Default.zeusWorld = lstServerNames1.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                EnableAll(false);
                statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.Waiting;
                ZeusSessionInfo session = new ZeusSessionInfo(txtUsername.Text, txtPassword.Text, lstServerNames1.SelectedItem.ToString(),"127.0.0.1",42042);
                new Thread(new ParameterizedThreadStart(Connect)).Start(session);
            }
        }

        private void Connect(object state_session)
        {
            ZeusSessionInfo session = (ZeusSessionInfo)state_session;
            bool connect = session.Connect();
            if (connect)
            {
                if (!session.Exist())
                {
                    MessageBox.Show(session.Username + " doesn't exist on Zeus. To register, use the bottom panel.", "Unregistered!");
                }
                else if (!session.Authenticate())
                {
                    MessageBox.Show("Entered password is incorrect. If you can't remember your password, use the bottom panel.", "Wrong Password!");
                }
                else
                    InitSession(session);
            }
            else
            {
                MessageBox.Show("Zeus is currently unreachable!", "Zeus Unreachable!");
            }
            EnableAll(true);
            statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.None;
        }

        private void LostPassword(object state_session)
        {
            ZeusSessionInfo session = (ZeusSessionInfo)state_session;
            bool connect = session.Connect();
            if (connect)
            {
                session.RequestPassword();
                MessageBox.Show("Zeus just sent your password by LoU-Mail to " + session.Username + " on " + session.World + ".", "Password Sent !");
            }
            else
            {
                MessageBox.Show("Zeus is currently unreachable!", "Zeus Unreachable!");
            }
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



        delegate void SessionHandler(ZeusSessionInfo isConnected);
        private void InitSession(ZeusSessionInfo session)
        {
            if (InvokeRequired)
            {
                Invoke(new SessionHandler(InitSession), session);
                return;
            }
            m_Parent.ZeusSession = session;
            m_Parent.FillZeus();
        }

        private void btnLostPassword_Click(object sender, EventArgs e)
        {
            if (txtUsername2.Text.Length > 0 && lstServerNames2.SelectedIndex >= 0)
            {
                // We connect
                Properties.Settings.Default.zeusUsername = txtUsername2.Text;
                Properties.Settings.Default.zeusWorld = lstServerNames2.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                EnableAll(false);
                statePictureBox1.Etat = EricUtility.Windows.Forms.StatePictureBoxStates.Waiting;
                ZeusSessionInfo session = new ZeusSessionInfo(txtUsername.Text, lstServerNames1.SelectedItem.ToString(), "127.0.0.1", 42042);
                new Thread(new ParameterizedThreadStart(LostPassword)).Start(session);
            }
        }
    }
}
