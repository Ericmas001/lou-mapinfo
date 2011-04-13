using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LouMapInfo.Entities;
using LouMapInfo;

namespace LoUMapInfoOnline
{
    public partial class Beta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (ServerInfo s in ServerList.AllServers)
            {
                lstWorlds.Items.Add(s.Name);
            }
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
                    string pName = session.World.Player(session.PlayerID).Name;
                    string aName = session.World.Alliance(session.AllianceID).Name;
                    lblResult.Text = pName + (String.IsNullOrEmpty(aName) ? "" : (" (" + aName + ")")) + " on " + session.World.Name;

                    //InitSession(session);
                }
                else
                    lblErrors.Text += "Impossible to connect with those credentials <br />";
            }
            else
                lblResult.Text = "";

        }
    }
}