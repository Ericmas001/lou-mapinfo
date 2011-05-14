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
    public partial class Virtue : System.Web.UI.Page
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
                if (Virtue.list == null)
                    Virtue.list = session.World.Alliances;
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
                Official.OpenReport(new VirtuePalaceReport(info.World, VirtueType.None, info));
        }

        protected void btnMe_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            AllianceInfo info = session.World.Alliance(session.AllianceID);
            if (info != null)
                Official.OpenReport(new VirtuePalaceReport(info.World, VirtueType.None, info));
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            // Return matching players  
            return (from a in list where a.Name.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select a.Name).Take(count).ToArray();
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.None, null));
        } 

        protected void btnCompassion_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Compassion, null));
        }

        protected void btnHonesty_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Honesty, null));
        }

        protected void btnHonor_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Honor, null));
        }

        protected void btnHumility_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Humility, null));
        }

        protected void btnJustice_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Justice, null));
        }

        protected void btnSacrifice_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Sacrifice, null));
        }

        protected void btnSpirituality_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Spirituality, null));
        }

        protected void btnValor_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new VirtuePalaceReport(session.World, VirtueType.Valor, null));
        }

        protected void btnShrineRadius_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            try
            {
                Pt loc = new Pt(session.World, txtShrineLocation.Text);
                Official.OpenReport(new ShrineRadiusReport(session.World, loc));
            }
            catch
            { }
        }

        protected void btnHighestLevel_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            Official.OpenReport(new BattlePalaceReport(session.World, BattleType.HighestLevel));
        }
    }
}