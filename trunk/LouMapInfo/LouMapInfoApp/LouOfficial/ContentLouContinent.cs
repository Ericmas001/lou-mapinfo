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

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouContinent : UserControl, ILouContent
    {
        private ContentLoUOfficial m_Frame;

        public SessionInfo Session
        {
            get { return m_Frame.MainForm.Session; }
        }
        public ContentLoUOfficial Frame
        {
            get { return m_Frame; }
            set
            {
                m_Frame = value;
                int ind = 1;
                foreach (int ic in Session.World.Alliance(Session.AllianceID).ActiveContinents)
                {
                    ToolStripButton btnContinent = new ToolStripButton(ic.ToString("00"));
                    btnContinent.Click += new EventHandler(btnContinent_Click);
                    tbReportContinentOverview.Items.Insert(ind, btnContinent);
                    ind++;
                }
            }
        }
        public ContentLouContinent()
        {
            InitializeComponent();
        }

        private void btnChooseContinent_Click(object sender, EventArgs e)
        {
            ContinentPicker cp = new ContinentPicker(Session.World.NbContinentsX, Session.World.NbContinentsY);
            cp.ShowDialog();
            if (cp.Continent >= 0)
            {
                btnChooseContinent.Text = "C" + cp.Continent.ToString("00") + " - Choose Continent";
                OpenContinentReport(cp.Continent);
            }
        }

        void btnContinent_Click(object sender, EventArgs e)
        {
            OpenContinentReport(int.Parse(((ToolStripButton)sender).Text));
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
                ContinentInfo c = Session.World.Continent((int)o);
                if (c != null)
                {
                    ContinentOverviewReport rep = new ContinentOverviewReport(c);
                    rep.LoadIfNeeded();
                    OpenReport(rep);
                }
            }
            ContentEnabling(true);

            PlayerInfo p = null;
            if (o is int)
                p = Session.World.Player((int)o);
            else if (o is string)
                p = Session.World.Player((string)o);

            if (p == null)
                ContentEnabling(true);
            else
            {
                PlayerOverviewReport rep = new PlayerOverviewReport(p);
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
            tbReportContinentOverview.Enabled = value;
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
            ContentReport content = new ContentReport(r, Properties.Settings.Default.detailLevel);
            pnlContent.Controls.Add(content);
            content.Dock = DockStyle.Fill;
        }
    }
}
