using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LouMapInfo.Entities;
using LouMapInfo.Reports;
using LouMapInfo;
using LouMapInfo.Reports.core;

namespace LouMapInfoOnlineMVC.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public string Index()
        {
            return "This is my <b>default</b> action...";
        }
        public string Players(string name)
        {
            if (Session["louSession"] == null)
                return "You must be connected to use the Report Feature";
            else
            {
                SessionInfo session = (SessionInfo)Session["betaSession"];
                PlayerInfo info = session.World.Player(session.PlayerID);
                if (info != null)
                    return new PlayerOverviewReport(info).Report();
                else
                    return "The player '" + name + "' doesn't exist!";
            }
        }
        public string Players2(string name, string s)
        {
            SessionInfo session = new SessionInfo(s, ServerList.WORLD_21.Name);
            if (session.Connect())
            {
                session.World.ForceLoad();
                PlayerInfo info = session.World.Player(name);
                if (info != null)
                {
                    ReportInfo report = new PlayerOverviewReport(info);
                    foreach (ReportOption o in Enum.GetValues(typeof(ReportOption)))
                    {
                        report.SetOption(o, true);
                    }
                    return report.Report();
                }
                else
                    return "The player '" + name + "' doesn't exist!";
            }
            else
                return "Provided session is invalid";
        }

    }
}
