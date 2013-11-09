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
            Console.WriteLine(" ==== Retrieve LoU Servers List !! ==== ");
            Console.Write("Mail: ");
            string mail = "ericmas001@gmail.com"; //Console.ReadLine();
            Console.WriteLine(mail);
            Console.Write("Password: ");
            string pass = Console.ReadLine();

            CookieContainer cookies = SessionInfo.ConnectToLoU(mail, pass);
            string session = SessionInfo.GetSessionID(cookies);
                                //                         http://prodgame.lordofultima.com/Farm/service.svc/ajaxEndpoint/1/session/b2ab6bf0-e607-45fb-bd85-df559c123f8e/worlds?SessionType=1

            string xml = GatheringUtility.GetPageSource("http://prodgame.lordofultima.com/Farm/service.svc/ajaxEndpoint/1/session/" + session + "/worlds?SessionType=1", "application/xml ; charset=UTF-8", cookies, Encoding.UTF8);
            xml = xml.Replace("</server>\n\t<server>", "</server>|<server>");
            string[] servers = xml.Split('|');
            ServerList.LoadFromWeb = false;
            foreach (string sr in servers)
            {
                string url = StringUtility.Extract(sr, "<serverURL>", "/serverURL>");
                string srv = StringUtility.Extract(url, "prodgame", ".lordofultima.com");
                string id = StringUtility.Extract(url, ".com/", "/index");

                string name = StringUtility.Extract(sr, "<servername>", "</servername>").Trim().Replace("العالم","Arab World");

                string lang = StringUtility.Extract(sr, "<region>", "</region>");
                string[] langs = lang.Split('_');

                string l = langs[0].ToLower();
                string c = langs[1].ToLower();

                if (l != "en" && c != "us")
                    name = "(" + (l == c ? l : lang) + ") " + name;
                else
                {
                    name = "  " + name;
                    if (name.Contains("Castle"))
                        name = name.Substring(1);
                }

                ServerInfo si = new ServerInfo(int.Parse(id), name, int.Parse(srv));
                ServerList.AllServers.Add(si);
            }

            ServerList.PopulateDictionnaries();
            string[] names = new string[ServerList.AllServers.Count];
            ServerList.ServersByName.Keys.CopyTo(names, 0);
            Array.Sort(names);
            
            StreamWriter sw = File.CreateText("worlds.txt");
            foreach (string w in names)
            {
                string line = String.Format("{0};{1};{2}", ServerList.ServersByName[w].Id, w.Trim(), ServerList.ServersByName[w].Prod);
                sw.WriteLine(line);
                Console.WriteLine(line);
            }
            sw.Close();
        }
    }
}
