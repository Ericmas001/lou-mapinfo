using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using LouMapInfo;
using LouMapInfo.Zeus;

namespace LouMapInfoApp.Zeus
{
    public partial class ContentZeus : UserControl
    {
        private System.Windows.Forms.Timer waitingTimer;
        private int waitingCounter = 0;
        private MainForm m_Parent;

        public MainForm MainForm
        {
            get { return m_Parent; }
        }

        public ContentZeus(MainForm parent, IZeusContent content)
        {
            m_Parent = parent;
            content.Frame = this;
            Control child = content as Control;
            Controls.Add(child);
            child.Dock = DockStyle.Fill;
            ZeusSessionInfo session = m_Parent.ZeusSession;
            InitializeComponent();
            lblWorldInfo.Text = "Connected to Zeus with " + session.Username + " from " + session.World;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            m_Parent.ZeusSession.Disconnect();
            m_Parent.ZeusSession = null;
            //m_Parent.FillZeus();
        }
        delegate void EmptyHandler();
        public void StartWaiting()
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
                lblImage.BackgroundImage = EricUtility.Windows.Forms.Properties.Resources.waiting0;
            }
        }
        public void StopWaiting()
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
                lblImage.BackgroundImage = Properties.Resources.menu_Zeus;
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
    }
}
