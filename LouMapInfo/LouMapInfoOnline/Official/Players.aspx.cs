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
    public partial class Players : System.Web.UI.Page
    {
        OfficialMasterPage Official;
        static PlayerInfo[] list = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Official = Master as OfficialMasterPage;
            Page.Form.DefaultButton = btnShowPlayerReport.UniqueID;
            if (Session["betaSession"] == null)
            {
                Server.Transfer("Default.aspx");
            }
            else
            {
                SessionInfo session = (SessionInfo)Session["betaSession"];
                if (Players.list == null)
                    Players.list = session.World.Players;
                btnMe.Text = session.World.Player(session.PlayerID).Name;
            }
        }

        protected void btnShowPlayerReport_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["betaSession"];
            PlayerInfo info = session.World.Player(txtPlayerName.Text);
            if (info != null)
                Official.OpenReport(new PlayerOverviewReport(info));
        }

        protected void btnMe_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["betaSession"];
            PlayerInfo info = session.World.Player(session.PlayerID);
            if (info != null)
                Official.OpenReport(new PlayerOverviewReport(info));
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            // Return matching players  
            return (from p in list where p.Name.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select p.Name).Take(count).ToArray();
        } 
    }
}