using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.OfficialLOU.Entities;

namespace LouMapInfo.OfficialLOU
{
    public static class LoUServerList
    {
        //private static string WORLD_10 { get { return "World 10 (Europe)"; } }
        //private static string WORLD_21 { get { return "World 21 (USA East Coast)"; } }

        private static readonly List<LoUServerInfo> m_AllServers = new List<LoUServerInfo>();
        private static readonly Dictionary<string, LoUServerInfo> m_ServersByName = new Dictionary<string, LoUServerInfo>();
        private static readonly Dictionary<int, LoUServerInfo> m_ServersById = new Dictionary<int, LoUServerInfo>();

        public static List<LoUServerInfo> AllServers
        {
            get 
            {
                if (!m_Loaded)
                    Load();
                return LoUServerList.m_AllServers;
            }
        }
        public static Dictionary<string, LoUServerInfo> ServersByName
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return LoUServerList.m_ServersByName;
            }
        }
        public static Dictionary<int, LoUServerInfo> ServersById
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return LoUServerList.m_ServersById;
            }
        }
        public static LoUServerInfo WORLD_10
        {
            get
            {
                if (!m_Loaded)
                    Load();
                return m_ServersById[14];
            }
        }
        public static LoUServerInfo WORLD_21
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
            m_AllServers.Add(new LoUServerInfo(2, "World 1 (Europe)", 2));
            m_AllServers.Add(new LoUServerInfo(3, "World 2 (Europe)", 5));
            m_AllServers.Add(new LoUServerInfo(5, "World 3 (USA East Coast)", 9));
            m_AllServers.Add(new LoUServerInfo(6, "World 4 (Europe)", 4));
            m_AllServers.Add(new LoUServerInfo(7, "World 5 (USA East Coast)", 1));
            m_AllServers.Add(new LoUServerInfo(9, "World 6 (Europe)", 2));
            m_AllServers.Add(new LoUServerInfo(10, "World 7 (USA East Coast)", 6));
            m_AllServers.Add(new LoUServerInfo(11, "World 8 (Europe)", 8));
            m_AllServers.Add(new LoUServerInfo(12, "World 9 (USA East Coast)", 10));
            m_AllServers.Add(new LoUServerInfo(14, "World 10 (Europe)", 5));
            m_AllServers.Add(new LoUServerInfo(15, "World 11 (USA East Coast)", 7));
            m_AllServers.Add(new LoUServerInfo(16, "World 12 (Europe)", 4));
            m_AllServers.Add(new LoUServerInfo(17, "World 13 (USA West Coast)", 10));
            m_AllServers.Add(new LoUServerInfo(18, "World 14 (USA East Coast)", 5));
            m_AllServers.Add(new LoUServerInfo(20, "World 15 (Europe)", 12));
            m_AllServers.Add(new LoUServerInfo(21, "World 16 (USA West Coast)", 12));
            m_AllServers.Add(new LoUServerInfo(22, "World 17 (USA East Coast)", 13));
            m_AllServers.Add(new LoUServerInfo(23, "World 18 (Europe)", 13));
            m_AllServers.Add(new LoUServerInfo(24, "World 19 (Europe)", 11));
            m_AllServers.Add(new LoUServerInfo(32, "World 20 (USA West Coast)", 9));
            m_AllServers.Add(new LoUServerInfo(33, "World 21 (USA East Coast)", 10));
            m_AllServers.Add(new LoUServerInfo(34, "World 22 (Australia)", 4));
            m_AllServers.Add(new LoUServerInfo(35, "World 23 (Europe)", 1));
            m_AllServers.Add(new LoUServerInfo(38, "World 24 (USA East Coast)", 6));
            m_AllServers.Add(new LoUServerInfo(39, "World 25 (USA West Coast)", 2));
            m_AllServers.Add(new LoUServerInfo(40, "World 26 (Australia)", 3));
            m_AllServers.Add(new LoUServerInfo(41, "World 27 (Europe)", 8));
            m_AllServers.Add(new LoUServerInfo(42, "World 28 (USA East Coast)", 5));

            m_AllServers.Add(new LoUServerInfo(37, "Castle 1", 3));

            m_AllServers.Add(new LoUServerInfo(4, "(de) Welt 1", 7));
            m_AllServers.Add(new LoUServerInfo(13, "(de) Welt 2", 3));
            m_AllServers.Add(new LoUServerInfo(19, "(de) Welt 3", 11));
            m_AllServers.Add(new LoUServerInfo(25, "(de) Welt 4", 12));
            m_AllServers.Add(new LoUServerInfo(36, "(de) Welt 5", 2));

            m_AllServers.Add(new LoUServerInfo(28, "(es) Mundo 1", 5));
            m_AllServers.Add(new LoUServerInfo(46, "(es) Mundo 2", 7));

            m_AllServers.Add(new LoUServerInfo(26, "(fr) Monde 1", 13));
            m_AllServers.Add(new LoUServerInfo(48, "(fr) Monde 2", 8));

            m_AllServers.Add(new LoUServerInfo(27, "(it) Mondo 1", 4));
            m_AllServers.Add(new LoUServerInfo(47, "(it) Mondo 2", 7));

            m_AllServers.Add(new LoUServerInfo(31, "(pl) Świata 1", 8));
            m_AllServers.Add(new LoUServerInfo(43, "(pl) Świata 2", 5));

            m_AllServers.Add(new LoUServerInfo(29, "(pt) Mundo 1", 6));
            m_AllServers.Add(new LoUServerInfo(45, "(pt) Mundo 2", 4));

            m_AllServers.Add(new LoUServerInfo(30, "(ru) Мир 1", 7));
            m_AllServers.Add(new LoUServerInfo(44, "(ru) Мир 2", 4));

            foreach (LoUServerInfo info in m_AllServers)
            {
                m_ServersById.Add(info.Id, info);
                m_ServersByName.Add(info.Name, info);
            }

            m_Loaded = true;
        }
    }
}
