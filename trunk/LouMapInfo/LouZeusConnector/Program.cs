using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using LouMapInfo.Zeus;

namespace LouZeusConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.MessageLogged += new LogDelegate(LogManager_MessageLogged);
            int port = 42042;
            string address = "127.0.0.1";
            string pj = "Dirnahm";
            LobbyTCPClient server = new LobbyTCPClient(address,port);
            if (server.Connect())
            {
                Console.WriteLine("Connected to Zeus");
                server.Start();
                bool exist = server.Identify(pj);
                if (!exist)
                {
                    Console.WriteLine("You are here for the first time, Zeus will send you a password on LoU.");
                    server.RequestPassword();
                }
                Console.WriteLine("Enter the password:");
                string password = Console.ReadLine();
                if (server.Authenticate(pj, password))
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You are IN !!!");
                    Console.ForegroundColor = old;
                    server.ChangePassword("ILoveMyNewPassword");
                }
                else
                {
                    ConsoleColor old = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are not OUT !!");
                    Console.ForegroundColor = old;
                }
                server.Disconnect();
            }
            else
                Console.WriteLine("ERROR");
            Console.ReadLine();

        }

        static void LogManager_MessageLogged(string from, string message, int level)
        {
            if (level >= (int)LogLevel.MessageLow)
            {
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ForegroundColor = old;
            }
        }
    }
}
