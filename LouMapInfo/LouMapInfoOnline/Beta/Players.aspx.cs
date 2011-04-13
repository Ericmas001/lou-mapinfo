using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LouMapInfo.Entities;
using LouMapInfo.Reports;
using LouMapInfo.Reports.core;

namespace LoUMapInfoOnline.Beta
{
    public partial class Players : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["betaSession"] == null)
            {
                Server.Transfer("Default.aspx");
            }
            else
            {
                SessionInfo session = (SessionInfo)Session["betaSession"];
                PlayerInfo info = session.World.Player(session.PlayerID);
                PlayerOverviewReport report = new PlayerOverviewReport(info);
                foreach(ReportOption o in Enum.GetValues(typeof(ReportOption)))
                {
                    report.SetOption(o, true);
                }
                ReportLiteral.Text = report.Report();
            }
        }
    }
}