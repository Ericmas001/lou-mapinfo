using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.OfficialLOU.Entities;
using System.IO;
using System.Globalization;

namespace LouCsvMaker
{
    class Program
    {
        static string world = "World 10 (Europe)";
        static ConsoleColor oldColor = Console.ForegroundColor;
        static void Main(string[] args)
        {
            Console.WriteLine(" >> Enter your LoU Mail: ");
            string mail = Console.ReadLine();
            Console.WriteLine(" >> Enter your LoU Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            Console.Write("We are connecting ...");
            LoUSessionInfo session = new LoUSessionInfo(mail, password, world);
            if (session.Connect())
            {
                session.World.LoadIfNeeded();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" done !");
                Console.ForegroundColor = oldColor;
                Console.WriteLine("Welcome " + session.World.Player(session.PlayerID).Name + " from " + session.World.Alliance(session.AllianceID).Name);
                Pause();

                int c = choice();
                while (c != 0)
                {
                    if (c < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: The choice isn't on the list !");
                        Console.ForegroundColor = oldColor;
                    }
                    else
                    {
                        switch (c)
                        {
                            case 1: AllianceCityList(session); break;
                        }
                    }

                    Pause();
                    c = choice();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" error, unable to connect !");
                Console.ForegroundColor = oldColor;
                Pause();
            }
        }
        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue ...");
            Console.ReadLine();
        }
        static int choice()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" >> Menu <<");
            Console.WriteLine("1 - Alliance city list");
            Console.WriteLine();
            Console.WriteLine("X - Exit the Application");
            string c = Console.ReadLine();
            if (c.ToUpper() == "X")
                return 0;
            int res = -1;
            if (int.TryParse(c, out res) && res < 2)
                return res;
            return -1;
        }
        static void AllianceCityList(LoUSessionInfo session)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You are asking alliance city list !!!");


            Console.WriteLine();
            Console.WriteLine(" >> Enter the .csv filename: ");
            string csvName = Console.ReadLine();
            if (!csvName.EndsWith(".csv"))
                csvName = csvName + ".csv";

            Console.WriteLine();
            Console.Write("Loading Alliance & Players ...");
            LoUAllianceInfo alliance = session.World.Alliance(session.AllianceID);
            alliance.LoadIfNeeded();
            Dictionary<String, int> players = new Dictionary<String, int>();
            int i = 1;
            foreach (LoUPlayerInfo p in alliance.Players())
            {
                p.LoadIfNeeded();
                players.Add(p.Name, i++);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" done !");
            Console.ForegroundColor = oldColor;

            Console.WriteLine();
            Console.WriteLine("Building data for continents");
            int pjsCount = alliance.Players().Length;
            List<String[]> lines = new List<string[]>();
            lines.Add(new string[pjsCount + 1]);
            lines[0][0] = "Continent";
            foreach (String p in players.Keys)
                lines[0][players[p]] = p;
            int min = 1;
            int max = 1;
            foreach (int ic in alliance.ActiveContinents)
            {
                Console.Write("C" + ic.ToString("00") + " ...");

                min = max;
                LoUPlayerInfo[] pjs = alliance.Players(ic);
                foreach (LoUPlayerInfo p in pjs)
                {
                    int curr = min;
                    LoUCityInfo[] cities = p.Cities(ic);
                    Array.Sort(cities);
                    Array.Reverse(cities);
                    foreach (LoUCityInfo c in cities)
                    {
                        if (curr == max)
                        {
                            lines.Add(new string[pjsCount + 1]);
                            lines[curr][0] = "C" + ic.ToString("00");
                            max++;
                        }
                        int col = players[p.Name];
                        lines[curr][col] = "\"" + c.Location + " " + c.Name + " (" + c.Score.ToString("N0", CultureInfo.InvariantCulture) + ")\"";
                        curr++;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" done !");
                Console.ForegroundColor = oldColor;
            }

            Console.WriteLine();
            Console.Write("Building  & Saving CSV file ...");

            StreamWriter sw = File.CreateText(csvName);
            foreach (string[] li in lines)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in li)
                {
                    sb.Append(s);
                    sb.Append(";");
                }
                sw.WriteLine(sb.ToString());
            }
            sw.Close();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" done !");
            Console.ForegroundColor = oldColor;
        }
    }
}
