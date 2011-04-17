using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LouMapInfo;
using LouMapInfo.Entities;

namespace LoUMapInfoOnline.Official
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["betaSession"] == null)
            {
                pnlConnexion.Visible = true;
                foreach (ServerInfo s in ServerList.AllServers)
                {
                    lstWorlds.Items.Add(s.Name);
                }
            }
            else
                pnlConnexion.Visible = false;
        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            bool ok = true;
            lblErrors.Text = "";
            if (txtUsername.Text.Length == 0)
            {
                lblErrors.Text += "Mail is empty <br />";
                ok = false;
            }
            if (txtPassword.Text.Length == 0)
            {
                lblErrors.Text += "Password is empty <br />";
                ok = false;
            }
            if (lstWorlds.SelectedIndex == -1)
            {
                lblErrors.Text += "You didn't select a World <br />";
                ok = false;
            }
            if (ok)
            {
                SessionInfo session = new SessionInfo(txtUsername.Text, txtPassword.Text, lstWorlds.SelectedItem.ToString());
                bool connect = session.Connect();
                if (connect)
                {
                    session.World.ForceLoad();
                    Session.Add("betaSession", session);
                    Server.Transfer("~/Official/Default.aspx");
                    //InitSession(session);
                }
                else
                    lblErrors.Text += "Impossible to connect with those credentials <br />";
            }
        }
    }
}