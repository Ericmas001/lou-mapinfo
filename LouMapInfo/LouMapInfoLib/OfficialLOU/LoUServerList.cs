using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.OfficialLOU
{
    public static class LoUServerList
    {
        private static readonly Dictionary<string, string> m_Servers = new Dictionary<string, string>();
        private static bool m_Loaded = false;
        public static Dictionary<string, string> Servers { get { if (!m_Loaded)Load(); return m_Servers; } }
        private static void Load()
        {
            m_Servers.Add("World 1 (Europe)", "http://prodgame02.lordofultima.com/2");
            m_Servers.Add("World 2 (Europe)", "http://prodgame05.lordofultima.com/3");
            m_Servers.Add("World 3 (USA East Coast)", "http://prodgame09.lordofultima.com/5");
            m_Servers.Add("World 4 (Europe)", "http://prodgame04.lordofultima.com/6");
            m_Servers.Add("World 5 (USA East Coast)", "http://prodgame01.lordofultima.com/7");
            m_Servers.Add("World 6 (Europe)", "http://prodgame02.lordofultima.com/9");
            m_Servers.Add("World 7 (USA East Coast)", "http://prodgame06.lordofultima.com/10");
            m_Servers.Add("World 8 (Europe)", "http://prodgame08.lordofultima.com/11");
            m_Servers.Add("World 9 (USA East Coast)", "http://prodgame10.lordofultima.com/12");
            m_Servers.Add("World 10 (Europe)", "http://prodgame05.lordofultima.com/14");
            m_Servers.Add("World 11 (USA East Coast)", "http://prodgame07.lordofultima.com/15");
            m_Servers.Add("World 12 (Europe)", "http://prodgame04.lordofultima.com/16");
            m_Servers.Add("World 13 (USA West Coast)", "http://prodgame10.lordofultima.com/17");
            m_Servers.Add("World 14 (USA East Coast)", "http://prodgame05.lordofultima.com/18");
            m_Servers.Add("World 15 (Europe)", "http://prodgame12.lordofultima.com/20");
            m_Servers.Add("World 16 (USA West Coast)", "http://prodgame12.lordofultima.com/21");
            m_Servers.Add("World 17 (USA East Coast)", "http://prodgame13.lordofultima.com/22");
            m_Servers.Add("World 18 (Europe)", "http://prodgame13.lordofultima.com/23");
            m_Servers.Add("World 19 (Europe)", "http://prodgame11.lordofultima.com/24");
            m_Servers.Add("World 20 (USA West Coast)", "http://prodgame09.lordofultima.com/32");
            m_Servers.Add("World 21 (USA East Coast)", "http://prodgame10.lordofultima.com/33");
            m_Servers.Add("World 22 (Australia)", "http://prodgame04.lordofultima.com/34");
            m_Servers.Add("(de) Welt 1", "http://prodgame07.lordofultima.com/4");
            m_Servers.Add("(de) Welt 2", "http://prodgame03.lordofultima.com/13");
            m_Servers.Add("(de) Welt 3", "http://prodgame11.lordofultima.com/19");
            m_Servers.Add("(de) Welt 4", "http://prodgame12.lordofultima.com/25");
            m_Servers.Add("(es) Mundo 1", "http://prodgame05.lordofultima.com/28");
            m_Servers.Add("(Fr) Monde 1", "http://prodgame13.lordofultima.com/26");
            m_Servers.Add("(it) Mondo 1", "http://prodgame04.lordofultima.com/27");
            m_Servers.Add("(pl) Świata 1", "http://prodgame08.lordofultima.com/31");
            m_Servers.Add("(pt) Mundo 1", "http://prodgame06.lordofultima.com/29");
            m_Servers.Add("(ru) Мир 1", "http://prodgame07.lordofultima.com/30");
            m_Loaded = true;
        }
    }
}
