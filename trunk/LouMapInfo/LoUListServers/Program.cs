using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LouMapInfo.Entities;
using System.Net;
using EricUtility.Networking.Gathering;

namespace LoUListServers
{
    class Program
    {
        static void Main(string[] args)
        {
            string main = "en";
            string[] others = { "de", "fr", "it", "pl", "pt", "ru", "es", "tr" };
            Array.Sort(others);

            Console.WriteLine(" ==== Retrieve LoU Servers List !! ==== ");
            Console.Write("Mail: ");
            string mail = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();

            CookieContainer cookies = SessionInfo.ConnectToLoU(mail, pass);
            List<ServerInfo> servers = getList(main, null, cookies);
            foreach (string l in others)
                servers.AddRange(getList(l, l, cookies));


        }
        public static List<ServerInfo> getList(string lang, string prefix, CookieContainer cookies)
        {
            List<ServerInfo> servers = new List<ServerInfo>();

            string s = GatheringUtility.GetPageSource("http://www.lordofultima.com/"+ lang + "/game", cookies);

                

            return servers;
        }
    }
}
