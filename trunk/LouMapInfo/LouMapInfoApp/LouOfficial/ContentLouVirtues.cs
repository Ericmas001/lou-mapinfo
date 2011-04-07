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
using LouMapInfo;
using EricUtility.Networking.JSON;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouVirtues : UserControl, ILouContent
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
                if (Session.AllianceID > 0)
                {
                    string aName = Session.World.Alliance(Session.AllianceID).Name;
                    btnAllianceReportMe.Text = aName;
                }
                else
                {
                    btnAllianceReportMe.Visible = false;
                    famousSeparator.Visible = false;
                    lblOther.Visible = false;
                }
            }
        }
        public ContentLouVirtues()
        {
            InitializeComponent();
        }

        private void btnAllianceReportMe_Click(object sender, EventArgs e)
        {
            OpenAllianceReport(Session.AllianceID);
        }

        private void btnAllianceReportOther_Click(object sender, EventArgs e)
        {
            OpenAllianceReport(txtAllianceReportOther.Text);
        }

        private void OpenAllianceReport(object a)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenAllianceReportAsync)).Start(a);
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

                VirtuePalaceReport rep = new VirtuePalaceReport(Session.World, VirtueType.None, a);
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
            tbReportByAlliance.Enabled = value;
            tbReportByVirtue.Enabled = value;
            tbReportBattle.Enabled = value;
            tbReportShrine.Enabled = value;
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

        private void btnVirtueReport_Click(object sender, EventArgs e)
        {
            OpenVirtueReport(((ToolStripButton)sender).Text);
        }

        private void OpenVirtueReport(string v)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenVirtueReportAsync)).Start(v);
        }

        private void OpenVirtueReportAsync(object o)
        {
            string v = o as string;
            VirtueType virtue;

            if (String.IsNullOrEmpty(v))
                virtue = VirtueType.None;
            else
                virtue = (VirtueType)Enum.Parse(typeof(VirtueType), v);

            VirtuePalaceReport rep = new VirtuePalaceReport(Session.World, virtue, null);
            rep.LoadIfNeeded();
            OpenReport(rep);
            ContentEnabling(true);
        }

        private void btnVirtueReportAll_Click(object sender, EventArgs e)
        {
            OpenVirtueReport("");
        }

        private void OpenBattleReport(BattleType type)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenBattleReportAsync)).Start(type);
        }

        private void OpenBattleReportAsync(object o)
        {
            BattleType type = (BattleType)o;

            BattlePalaceReport rep = new BattlePalaceReport(Session.World, type);
            rep.LoadIfNeeded();
            OpenReport(rep);
            ContentEnabling(true);
        }

        private void btnBattleHigherLvl_Click(object sender, EventArgs e)
        {
            OpenBattleReport(BattleType.HighestLevel);
        }

        private void btnBattlePalaceCount_Click(object sender, EventArgs e)
        {
            OpenBattleReport(BattleType.MostPalaces);
        }

        private void btnBattleHighestFaith_Click(object sender, EventArgs e)
        {
            OpenBattleReport(BattleType.HighestFaith);
        }

        private void btnShrineLocation_Click(object sender, EventArgs e)
        {
            try
            {
                Pt loc = new Pt(txtShrineLocation.Text);
                ContentEnabling(false);
                new Thread(new ParameterizedThreadStart(OpenShrineReportAsync)).Start(loc);
            }
            catch { }
        }

        private void OpenShrineReportAsync(object o)
        {
            Pt pt = (Pt)o;
            ShrineRadiusReport rep = new ShrineRadiusReport(Session.World, pt);
            rep.LoadIfNeeded();
            OpenReport(rep);
            ContentEnabling(true);
        }
    }
}
