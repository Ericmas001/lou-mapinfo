using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.OfficialLOU;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLoUOfficial : UserControl
    {
        private System.Windows.Forms.Timer waitingTimer;
        private int waitingCounter = 0;
        private MainForm m_Parent;
        private Image m_Logo;

        public MainForm MainForm
        {
            get { return m_Parent; }
        }

        public ContentLoUOfficial(MainForm parent, ILouContent content, Image logo)
        {
            m_Logo = logo;
            m_Parent = parent;
            content.Frame = this;
            Control child = content as Control;
            Controls.Add(child);
            child.Dock = DockStyle.Fill;
            LoUSessionInfo session = m_Parent.Session;
            InitializeComponent();
            string pName = session.World.Player(session.PlayerID).Name;
            string aName = session.World.Alliance(session.AllianceID).Name;
            lblImage.Image = m_Logo;
            lblWorldInfo.Text = pName + (String.IsNullOrEmpty(aName) ? "" : (" (" + aName + ")")) + " on " + session.World.Name;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            m_Parent.Session = null;
            m_Parent.FillOfficial();
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
                lblImage.Image = EricUtility.Windows.Forms.Properties.Resources.waiting0;
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
                lblImage.Image = m_Logo;
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
    }
}
