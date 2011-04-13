using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports;
using System.Threading;
using LouMapInfo.CSV;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouGroups : UserControl, ILouContent
    {
        private ContentLoUOfficial m_Frame;

        public SessionInfo Session
        {
            get { return m_Frame.MainForm.Session; }
        }
        public ContentLoUOfficial Frame
        {
            get { return m_Frame; }
            set { m_Frame = value; }
        }
        public ContentLouGroups()
        {
            InitializeComponent();
        }

        private void OpenAllianceReport(object a)
        {
            //ContentEnabling(false);
            //new Thread(new ParameterizedThreadStart(OpenAllianceReportAsync)).Start(a);
        }

        private void OpenAllianceReportAsync(object o)
        {
            AllianceInfo a = null;
            if (o is int)
                a = Session.World.Alliance((int)o);
            else if (o is string)
                a = Session.World.Alliance((string)o);

            if (a == null)
                ContentEnabling(true);
            else
            {
                AllianceOverviewReport rep = new AllianceOverviewReport(a);
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
            tbReportGroupOverview.Enabled = value;
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
            ContentReport content = new ContentReport(r);
            pnlContent.Controls.Add(content);
            content.Dock = DockStyle.Fill;
        }

        private void btnGroupReportShow_Click(object sender, EventArgs e)
        {

        }

        private void btnGroupReportManage_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            ContentLouGroupsManage content = new ContentLouGroupsManage();
            pnlContent.Controls.Add(content);
            content.Dock = DockStyle.Fill;
            content.CloseIsIminent += new ContentLouGroupsManage.EmptyHandler(content_CloseIsIminent);
            tbReportGroupOverview.Enabled = false;
        }

        void content_CloseIsIminent()
        {
            pnlContent.Controls.Clear();
            tbReportGroupOverview.Enabled = true;
        }
    }
}
