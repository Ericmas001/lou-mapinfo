using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoUMapInfoOnline.Official
{
    public partial class Disconnect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["louSession"] = null;
            Server.Transfer("~/Default.aspx");
        }
    }
}