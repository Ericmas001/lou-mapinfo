using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.OfficialLOU.Entities;
using System.IO;
using System.Globalization;
using LouMapInfo.CSV;

namespace LouMapInfoApp.Tests
{
    class LouCsvMaker
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

            ReportCSV rep = new AllianceCitiesListCSV(session.World.Alliance(session.AllianceID));
            rep.ProduceReport(csvName, false);
        }
    }
}
