using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.OfficialLOU.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports.OfficialLOU;
using System.Threading;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouPlayers : UserControl, ILouContent
    {
        private ContentLoUOfficial m_Frame;

        public LoUSessionInfo Session
        {
            get { return m_Frame.MainForm.Session; }
        }
        public ContentLoUOfficial Frame
        {
            get { return m_Frame; }
            set
            {
                m_Frame = value;
                string pName = Session.World.Player(Session.PlayerID).Name;
                btnPlayerReportMe.Text = pName;
            }
        }
        public ContentLouPlayers()
        {
            InitializeComponent();
        }

        private void btnPlayerReportOther_Click(object sender, EventArgs e)
        {
            OpenPlayerReport(txtPlayerReportOther.Text);
        }

        private void btnPlayerReportMe_Click(object sender, EventArgs e)
        {
            OpenPlayerReport(Session.PlayerID);
        }

        private void OpenPlayerReport(object p)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenPlayerReportAsync)).Start(p);
        }

        private void OpenPlayerReportAsync(object o)
        {
            LoUPlayerInfo p = null;
            if (o is int)
                p = Session.World.Player((int)o);
            else if (o is string)
                p = Session.World.Player((string)o);

            if (p == null)
                ContentEnabling(true);
            else
            {
                LoUPlayerOverviewReport rep = new LoUPlayerOverviewReport(p, OldLoUCityType.CityCastlePalace);
                rep.LoadIfNeeded();
                OpenReport(rep);
                ContentEnabling(true);
            }
        }
        delegate void BoolHandler(bool isConnected);
        public void ContentEnabling(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(ContentEnabling), value);
                return;
            }
            tbReportPlayerOverview.Enabled = value;
            if (value)
                Frame.StopWaiting();
            else
            {
                pnlContent.Controls.Clear();
                Frame.StartWaiting();
            }
        }
        public delegate void ReportHandler(ReportInfo r);
        public void OpenReport(ReportInfo r)
        {
            if (InvokeRequired)
            {
                Invoke(new ReportHandler(OpenReport), r);
                return;
            }
            // ReportForm.ShowReport(r, Properties.Settings.Default.lastWDetailLvl);
            ContentReport content = new ContentReport(r, Properties.Settings.Default.lastWDetailLvl);
            pnlContent.Controls.Add(content);
            content.Dock = DockStyle.Fill;
        }
    }
}
