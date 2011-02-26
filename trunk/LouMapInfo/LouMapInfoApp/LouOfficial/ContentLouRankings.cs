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
    public partial class ContentLouRankings : UserControl, ILouContent
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
                dgvPlayers.Rows.Clear();
                foreach (LoUPlayerInfo p in Session.World.Players)
                {
                    dgvPlayers.Rows.Add(p.Name, p.Alliance.Name, p.Score, p.Rank, p.CityCount);
                }
            }
        }
        public ContentLouRankings()
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

        private void dgvPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPlayersName.Index)
                OpenPlayerReport(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString());

            if (e.ColumnIndex == dgvPlayersAlliance.Index)
                OpenAllianceReport(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString());
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
                OpenReport(rep, 4);
                ContentEnabling(true);
            }
        }

        private void OpenAllianceReport(object a)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenAllianceReportAsync)).Start(a);
        }

        private void OpenAllianceReportAsync(object o)
        {
            LoUAllianceInfo a = null;
            if (o is int)
                a = Session.World.Alliance((int)o);
            else if (o is string)
                a = Session.World.Alliance((string)o);

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
        delegate void BoolHandler(bool isConnected);
        public void ContentEnabling(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(ContentEnabling), value);
                return;
            }
            dgvPlayers.Enabled = value;
            if (value)
                Frame.StopWaiting();
            else
            {
                Frame.StartWaiting();
            }
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
            //ContentReport content = new ContentReport(r, lvl);
            //pnlContent.Controls.Add(content);
            //content.Dock = DockStyle.Fill;
        }
    }
}
