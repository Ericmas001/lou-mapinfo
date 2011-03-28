﻿using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;

namespace LouMapInfo
{
    public static class ServerList
    {
        //private static string WORLD_10 { get { return "World 10 (Europe)"; } }
        //private static string WORLD_21 { get { return "World 21 (USA East Coast)"; } }

        private static readonly List<ServerInfo> m_AllServers = new List<ServerInfo>();
        private static readonly Dictionary<string, ServerInfo> m_ServersByName = new Dictionary<string, ServerInfo>();
        private static readonly Dictionary<int, ServerInfo> m_ServersById = new Dictionary<int, ServerInfo>();

        public static List<ServerInfo> AllServers
        {
            get 
            {
                if (!m_Loaded)
                    Load();
                return ServerList.m_AllServers;
            }
        }
        public static Dictionary<string, ServerInfo> ServersByName
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return ServerList.m_ServersByName;
            }
        }
        public static Dictionary<int, ServerInfo> ServersById
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return ServerList.m_ServersById;
            }
        }
        public static ServerInfo WORLD_10
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return m_ServersById[14];
            }
        }
        public static ServerInfo WORLD_21
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return m_ServersById[33];
            }
        }
        
        private static bool m_Loaded = false;
        private static void Load()
        {
            m_AllServers.Add(new ServerInfo(2, "World 1 (Europe)", 2));
            m_AllServers.Add(new ServerInfo(3, "World 2 (Europe)", 5));
            m_AllServers.Add(new ServerInfo(5, "World 3 (USA East Coast)", 9));
            m_AllServers.Add(new ServerInfo(6, "World 4 (Europe)", 4));
            m_AllServers.Add(new ServerInfo(7, "World 5 (USA East Coast)", 1));
            m_AllServers.Add(new ServerInfo(9, "World 6 (Europe)", 2));
            m_AllServers.Add(new ServerInfo(10, "World 7 (USA East Coast)", 6));
            m_AllServers.Add(new ServerInfo(11, "World 8 (Europe)", 8));
            m_AllServers.Add(new ServerInfo(12, "World 9 (USA East Coast)", 10));
            m_AllServers.Add(new ServerInfo(14, "World 10 (Europe)", 5));
            m_AllServers.Add(new ServerInfo(15, "World 11 (USA East Coast)", 7));
            m_AllServers.Add(new ServerInfo(16, "World 12 (Europe)", 4));
            m_AllServers.Add(new ServerInfo(17, "World 13 (USA West Coast)", 10));
            m_AllServers.Add(new ServerInfo(18, "World 14 (USA East Coast)", 5));
            m_AllServers.Add(new ServerInfo(20, "World 15 (Europe)", 12));
            m_AllServers.Add(new ServerInfo(21, "World 16 (USA West Coast)", 12));
            m_AllServers.Add(new ServerInfo(22, "World 17 (USA East Coast)", 13));
            m_AllServers.Add(new ServerInfo(23, "World 18 (Europe)", 13));
            m_AllServers.Add(new ServerInfo(24, "World 19 (Europe)", 11));
            m_AllServers.Add(new ServerInfo(32, "World 20 (USA West Coast)", 9));
            m_AllServers.Add(new ServerInfo(33, "World 21 (USA East Coast)", 10));
            m_AllServers.Add(new ServerInfo(34, "World 22 (Australia)", 4));
            m_AllServers.Add(new ServerInfo(35, "World 23 (Europe)", 1));
            m_AllServers.Add(new ServerInfo(38, "World 24 (USA East Coast)", 6));
            m_AllServers.Add(new ServerInfo(39, "World 25 (USA West Coast)", 2));
            m_AllServers.Add(new ServerInfo(40, "World 26 (Australia)", 3));
            m_AllServers.Add(new ServerInfo(41, "World 27 (Europe)", 8));
            m_AllServers.Add(new ServerInfo(42, "World 28 (USA East Coast)", 5));

            m_AllServers.Add(new ServerInfo(37, "Castle 1", 3));

            m_AllServers.Add(new ServerInfo(4, "(de) Welt 1", 7));
            m_AllServers.Add(new ServerInfo(13, "(de) Welt 2", 3));
            m_AllServers.Add(new ServerInfo(19, "(de) Welt 3", 11));
            m_AllServers.Add(new ServerInfo(25, "(de) Welt 4", 12));
            m_AllServers.Add(new ServerInfo(36, "(de) Welt 5", 2));

            m_AllServers.Add(new ServerInfo(28, "(es) Mundo 1", 5));
            m_AllServers.Add(new ServerInfo(46, "(es) Mundo 2", 7));

            m_AllServers.Add(new ServerInfo(26, "(fr) Monde 1", 13));
            m_AllServers.Add(new ServerInfo(48, "(fr) Monde 2", 8));

            m_AllServers.Add(new ServerInfo(27, "(it) Mondo 1", 4));
            m_AllServers.Add(new ServerInfo(47, "(it) Mondo 2", 7));

            m_AllServers.Add(new ServerInfo(31, "(pl) Świata 1", 8));
            m_AllServers.Add(new ServerInfo(43, "(pl) Świata 2", 5));

            m_AllServers.Add(new ServerInfo(29, "(pt) Mundo 1", 6));
            m_AllServers.Add(new ServerInfo(45, "(pt) Mundo 2", 4));

            m_AllServers.Add(new ServerInfo(30, "(ru) Мир 1", 7));
            m_AllServers.Add(new ServerInfo(44, "(ru) Мир 2", 4));

            foreach (ServerInfo info in m_AllServers)
            {
                m_ServersById.Add(info.Id, info);
                m_ServersByName.Add(info.Name, info);
            }

            m_Loaded = true;
        }
    }
}
