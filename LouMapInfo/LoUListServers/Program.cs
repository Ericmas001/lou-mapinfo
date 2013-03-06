using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using System.Net;
using EricUtility.Networking.Gathering;
using EricUtility;
using LouMapInfo;
using System.IO;

namespace LoUListServers
{
    class Program
    {
        static void Main(string[] args)
        {
            string main = "en";
            string[] others = { "de", "fr", "it", "pl", "pt", "pt_BR", "uk", "ar", "cs", "da", "fi", "nl", "no", "ro", "sk", "sv", "ru", "es", "tr", "hu" };
            Array.Sort(others);

            Console.WriteLine(" ==== Retrieve LoU Servers List !! ==== ");
            Console.Write("Mail: ");
            string mail = "ericmas001@gmail.com"; //Console.ReadLine();
            Console.WriteLine(mail);
            Console.Write("Password: ");
            string pass = Console.ReadLine();

            CookieContainer cookies = SessionInfo.ConnectToLoU(mail, pass);

            string s = GatheringUtility.GetPageSource("http://www.lordofultima.com/en/game", cookies);
            string my = StringUtility.Extract(s, "<div class=\"my-games\">", "<div class=\"world-new\">");
            int ind = -1;
            ServerList.LoadFromWeb = false;
            ServerList.AllServers.AddRange(getList(main, null, cookies));
            while ((ind = my.IndexOf("<li class=\"online menu_bubble\"", ind+1)) >= 0)
            {
                string world = StringUtility.Extract(my, "class=\"online menu_bubble\"", "</li>", ind);
                string name = StringUtility.Extract(world, "id=\"#", "\">");
                string url = StringUtility.Extract(world, "action=\"http://", ".aspx");
                string srv = StringUtility.Extract(url, "prodgame", ".lordofultima.com");
                string id = StringUtility.Extract(url, ".com/", "/index");
                ServerList.AllServers.Add(new ServerInfo(int.Parse(id), name, int.Parse(srv)));
            }
            foreach (string l in others)
                ServerList.AllServers.AddRange(getList(l, l, cookies));

            ServerList.PopulateDictionnaries();
            string[] names = new string[ServerList.AllServers.Count];
            ServerList.ServersByName.Keys.CopyTo(names, 0);
            Array.Sort(names);
            
            StreamWriter sw = File.CreateText("worlds.txt");
            foreach (string w in names)
            {
                string line = ServerList.ServersByName[w].Id + ";"+w.Trim() + ";" + ServerList.ServersByName[w].Prod;
                sw.WriteLine(line);
                Console.WriteLine(line);
            }
            sw.Close();
        }
        public static List<ServerInfo> getList(string lang, string prefix, CookieContainer cookies)
        {
            List<ServerInfo> servers = new List<ServerInfo>();

            string s = GatheringUtility.GetPageSource("http://www.lordofultima.com/"+ lang + "/game", cookies);
            if (s != null)
            {
                s = StringUtility.Extract(s, "<div class=\"world-new\">", "<div id=\"startgame_new\"");

                int ind = -1;
                while ((ind = s.IndexOf("<option", ind + 1)) >= 0)
                {
                    string world = StringUtility.Extract(s, "<option", "/option>", ind);
                    string name = StringUtility.Extract(world, ">", "<").Trim();
                    if (prefix != null)
                        name = "(" + prefix + ") " + name;
                    else
                    {
                        name = "  " + name;
                        if (name.Contains("Castle"))
                            name = name.Substring(1);
                    }
                    if (world.Contains("class=\"low\""))
                        name = name.Remove(name.LastIndexOf('(')).TrimEnd();
                    string url = StringUtility.Extract(world, "http://", ".aspx");
                    string srv = StringUtility.Extract(url, "prodgame", ".lordofultima.com");
                    string id = StringUtility.Extract(url, ".com/", "/index");
                    servers.Add(new ServerInfo(int.Parse(id), name, int.Parse(srv)));
                }
            }
            return servers;
        }
    }
}
