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
    public partial class ContentLouAlliances : UserControl, ILouContent
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
                    btnCSVCityListMe.Text = aName;
                    tbCSVCityList.Visible = true;
                }
                else
                {
                    btnAllianceReportMe.Visible = false;
                    famousSeparator.Visible = false;
                    lblOther.Visible = false;
                    tbCSVCityList.Visible = false;
                }
            }
        }
        public ContentLouAlliances()
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
            tbReportAllianceOverview.Enabled = value;
            tbCSVCityList.Enabled = value;
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

        private void btnCSVCityListOther_Click(object sender, EventArgs e)
        {
            OpenCityListCSV(txtAllianceReportOther.Text);
        }

        private void btnCSVCityListMe_Click(object sender, EventArgs e)
        {
            OpenCityListCSV(Session.AllianceID);
        }

        private void btnCSVCityListNoAlliance_Click(object sender, EventArgs e)
        {
            OpenCityListCSV("");
        }
        private void OpenCityListCSV(object a)
        {
            ContentEnabling(false);
            if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                string csvName = saveFileDialogCSV.FileName;
                if (!csvName.EndsWith(".csv"))
                    csvName = csvName + ".csv";
                new Thread(new ParameterizedThreadStart(OpenCityListCSVAsync)).Start(new KeyValuePair<object,string>(a,csvName));
            }
            else
                ContentEnabling(true);
        }

        private void OpenCityListCSVAsync(object o)
        {
            KeyValuePair<object, string> kvp = (KeyValuePair<object, string>)o;
            AllianceInfo a = null;
            if (kvp.Key is int)
                a = Session.World.Alliance((int)kvp.Key);
            else if (kvp.Key is string)
                a = Session.World.Alliance((string)kvp.Key);

            if (a == null)
                ContentEnabling(true);
            else
            {
                AllianceCitiesListCSV csv = new AllianceCitiesListCSV(a);
                csv.ProduceReport(kvp.Value, true);
                OpenCSV(csv,kvp.Value);
                ContentEnabling(true);
            }
        }
        public delegate void CSVHandler(ReportCSV r, string filename);
        public void OpenCSV(ReportCSV r, string filename)
        {
            if (InvokeRequired)
            {
                Invoke(new CSVHandler(OpenCSV), r, filename);
                return;
            }
            ContentCSV content = new ContentCSV(r, filename);
            pnlContent.Controls.Add(content);
            content.Dock = DockStyle.Fill;
        }
    }
}
