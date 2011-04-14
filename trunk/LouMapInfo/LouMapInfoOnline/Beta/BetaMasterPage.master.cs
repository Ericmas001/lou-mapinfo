using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Entities.Filter;

namespace LoUMapInfoOnline
{
    public partial class BetaMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["betaSession"] != null)
            {
                pnlConnectedMenu.Visible = true;
                pnlDisconnectedMenu.Visible = false;
                SessionInfo session = (SessionInfo)Session["betaSession"];
                string pName = session.World.Player(session.PlayerID).Name;
                string aName = session.World.Alliance(session.AllianceID).Name;
                lblbetaSession.Text = pName + (String.IsNullOrEmpty(aName) ? "" : (" (" + aName + ")")) + " on " + session.World.Name;
            }
            else
            {
                pnlConnectedMenu.Visible = false;
                pnlDisconnectedMenu.Visible = true;
            }
        }
        public void OpenReport(ReportInfo report)
        {
            Session["report"] = report;
            chkFilterCastle.Visible = report.hasFilter(FilterType.TypeCastle);
            chkFilterCity.Visible = report.hasFilter(FilterType.TypeCity);
            chkFilterPalace.Visible = report.hasFilter(FilterType.TypePalace);
            sepFilter1.Visible = report.hasType0Filter() && (report.hasType1Filter() || report.hasType2Filter() || report.hasType3Filter());

            chkFilterLand.Visible = report.hasFilter(FilterType.BorderingLand);
            chkFilterWater.Visible = report.hasFilter(FilterType.BorderingWater);
            sepFilter2.Visible = report.hasType1Filter() && (report.hasType2Filter() || report.hasType3Filter());

            chkFilterNoCities.Visible = report.hasFilter(FilterType.NoCities);
            sepFilter3.Visible = report.hasType2Filter() && report.hasType3Filter();

            chkFilterNoAlliance.Visible = report.hasFilter(FilterType.NoAlliance);

            foreach (ReportOption o in Enum.GetValues(typeof(ReportOption)))
                report.SetOption(o, true);
            foreach (FilterType o in Enum.GetValues(typeof(FilterType)))
                report.SetFilter(o, true);
            
            pnlReport.Visible = true;
            RefreshReports();
        }
        private void RefreshReports()
        {
            ReportInfo report = (ReportInfo)Session["report"];
            ReportLiteral.Text = report.Report().Replace("<hr />", "");
            BBCodeLabel.Text = report.BBCode().Replace("\n", "<br />");
        }

        protected void btnShowBBCode_Click(object sender, EventArgs e)
        {
            pnlBBCode.Visible = true;
            pnlHtml.Visible = false;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            pnlBBCode.Visible = false;
            pnlHtml.Visible = true;
        }

        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            Server.Transfer("Disconnect.aspx");
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportInfo report = (ReportInfo)Session["report"];
            report.ShowDetail = (RadioButtonList1.SelectedIndex == 0);
            RefreshReports();
        }

        protected void chkFilterCastle_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFilterCastle.Checked && !chkFilterCity.Checked && !chkFilterPalace.Checked)
                chkFilterCastle.Checked = true;
            else
            {
                ReportInfo report = (ReportInfo)Session["report"];
                report.SetFilter(FilterType.TypeCastle, chkFilterCastle.Checked);
                RefreshReports();
            }
        }

        protected void chkFilterCity_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFilterCastle.Checked && !chkFilterCity.Checked && !chkFilterPalace.Checked)
                chkFilterCity.Checked = true;
            else
            {
                ReportInfo report = (ReportInfo)Session["report"];
                report.SetFilter(FilterType.TypeCity, chkFilterCity.Checked);
                RefreshReports();
            }
        }

        protected void chkFilterPalace_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFilterCastle.Checked && !chkFilterCity.Checked && !chkFilterPalace.Checked)
                chkFilterPalace.Checked = true;
            else
            {
                ReportInfo report = (ReportInfo)Session["report"];
                report.SetFilter(FilterType.TypePalace, chkFilterPalace.Checked);
                RefreshReports();
            }
        }

        protected void chkFilterLand_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFilterLand.Checked && !chkFilterWater.Checked)
                chkFilterLand.Checked = true;
            else
            {
                ReportInfo report = (ReportInfo)Session["report"];
                report.SetFilter(FilterType.BorderingLand, chkFilterLand.Checked);
                RefreshReports();
            }
        }

        protected void chkFilterWater_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFilterLand.Checked && !chkFilterWater.Checked)
                chkFilterWater.Checked = true;
            else
            {
                ReportInfo report = (ReportInfo)Session["report"];
                report.SetFilter(FilterType.BorderingWater, chkFilterWater.Checked);
                RefreshReports();
            }
        }

        protected void chkFilterNoCities_CheckedChanged(object sender, EventArgs e)
        {
            ReportInfo report = (ReportInfo)Session["report"];
            report.SetFilter(FilterType.NoCities, chkFilterNoCities.Checked);
            RefreshReports();
        }

        protected void chkFilterNoAlliance_CheckedChanged(object sender, EventArgs e)
        {
            ReportInfo report = (ReportInfo)Session["report"];
            report.SetFilter(FilterType.NoAlliance, chkFilterNoAlliance.Checked);
            RefreshReports();
        }
    }
}