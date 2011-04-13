﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;

namespace LoUMapInfoOnline
{
    public partial class BetaMasterPage : System.Web.UI.MasterPage
    {
        ReportInfo report;
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
        public void OpenReport(ReportInfo r)
        {
            report = r;
            foreach (ReportOption o in Enum.GetValues(typeof(ReportOption)))
            {
                report.SetOption(o, true);
            }
            ReportLiteral.Text = report.Report();
            BBCodeLabel.Text = report.BBCode();
            pnlReport.Visible = true;
        }

        protected void btnShowBBCode_Click(object sender, EventArgs e)
        {
            BBCodeLabel.Text = report.BBCode();
            pnlBBCode.Visible = true;
            pnlHtml.Visible = false;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            ReportLiteral.Text = report.Report();
            pnlBBCode.Visible = false;
            pnlHtml.Visible = true;
        }
    }
}