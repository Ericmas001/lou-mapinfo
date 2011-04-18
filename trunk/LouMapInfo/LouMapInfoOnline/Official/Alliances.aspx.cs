using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LouMapInfo.Entities;
using LouMapInfo.Reports;
using LouMapInfo.Reports.core;

namespace LoUMapInfoOnline.Official
{
    public partial class Alliance : System.Web.UI.Page
    {
        OfficialMasterPage Official;
        static AllianceInfo[] list = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Official = Master as OfficialMasterPage;
            Page.Form.DefaultButton = btnShowAllianceReport.UniqueID;
            if (Session["louSession"] == null)
            {
                Server.Transfer("Default.aspx");
            }
            else
            {
                SessionInfo session = (SessionInfo)Session["louSession"];
                if (Alliance.list == null)
                    Alliance.list = session.World.Alliances;
                if (session.AllianceID > 0)
                    btnMe.Text = session.World.Alliance(session.AllianceID).Name;
                else
                {
                    btnMe.Visible = false;
                    lblOther.Visible = false;
                }
            }
        }

        protected void btnShowAllianceReport_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            AllianceInfo info = session.World.Alliance(txtAllianceName.Text);
            if (info != null)
                Official.OpenReport(new AllianceOverviewReport(info));
        }

        protected void btnMe_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            AllianceInfo info = session.World.Alliance(session.AllianceID);
            if (info != null)
                Official.OpenReport(new AllianceOverviewReport(info));
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            // Return matching players  
            return (from a in list where a.Name.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select a.Name).Take(count).ToArray();
        } 
    }
}