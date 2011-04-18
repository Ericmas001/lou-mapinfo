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
    public partial class Continent : System.Web.UI.Page
    {
        OfficialMasterPage Official;
        protected void Page_Load(object sender, EventArgs e)
        {
            Official = Master as OfficialMasterPage;
            if (Session["louSession"] == null)
            {
                Server.Transfer("Default.aspx");
            }
            else
            {
                SessionInfo session = (SessionInfo)Session["louSession"];
                foreach (int c in session.World.Player(session.PlayerID).ActiveContinents)
                {
                    Button b = new Button();
                    b.ID = "btnActiveC" + c.ToString("00");
                    b.Text = c.ToString("00");
                    b.Click += new EventHandler(btnContinent_Click);
                    pnlActiveContinent.Controls.Add(b);
                }
                for( int i = 0; i < session.World.NbContinentsX; ++i )
                    for (int j = 0; j < session.World.NbContinentsY; ++j)
                    {
                        Control btn = pnlChooseContinent.FindControl("btnC" + i.ToString() + j.ToString());
                        btn.Visible = true;
                    }
            }
        }

        protected void btnContinent_Click(object sender, EventArgs e)
        {
            SessionInfo session = (SessionInfo)Session["louSession"];
            string c = ((Button)sender).Text;
            Official.OpenReport(new ContinentOverviewReport(session.World.Continent(int.Parse(c))));
        }
    }
}