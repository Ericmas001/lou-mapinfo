﻿using System;
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
using LouMapInfo.CSV;
using LouMapInfo.OfficialLOU;
using EricUtility.Networking.JSON;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouVirtues : UserControl, ILouContent
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

        private void btnAllianceReportNoAlliance_Click(object sender, EventArgs e)
        {
            OpenAllianceReport("");
        }

        private void OpenAllianceReport(object a)
        {
            //ContentEnabling(false);
            //new Thread(new ParameterizedThreadStart(OpenAllianceReportAsync)).Start(a);
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
            tbReportAllianceOverview.Enabled = value;
            tbReportAllianceOverview.Enabled = value;
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

        private void btnAllianceReportAll_Click(object sender, EventArgs e)
        {
        }

        private void btnSingleVirtueReport_Click(object sender, EventArgs e)
        {
            OpenSingleVirtueReport(((ToolStripButton)sender).Text);
        }

        private void OpenSingleVirtueReport(string v)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenSingleVirtueReportAsync)).Start(v);
        }

        private void OpenSingleVirtueReportAsync(object o)
        {
            string v = o as string;

            if (String.IsNullOrEmpty(v))
                ContentEnabling(true);
            else
            {
                LoUSingleVirtuePalaceReport rep = new LoUSingleVirtuePalaceReport(Session.World, v);
                rep.LoadIfNeeded();
                OpenReport(rep);
                ContentEnabling(true);
            }
        }
    }
}
