using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.OfficialLOU
{
    public static class LoUVirtues
    {
        private static readonly Dictionary<string, int> m_VirtuesIDs = new Dictionary<string, int>();
        private static readonly Dictionary<int, string> m_VirtuesNames = new Dictionary<int, string>();
        private static bool m_Loaded = false;
        public static Dictionary<string, int> VirtuesIDs { get { if (!m_Loaded)Load(); return m_VirtuesIDs; } }
        public static Dictionary<int, string> VirtuesNames { get { if (!m_Loaded)Load(); return m_VirtuesNames; } }
        private static void Load()
        {
            m_VirtuesIDs.Add("Compassion", 1);
            m_VirtuesIDs.Add("Honesty", 2);
            m_VirtuesIDs.Add("Honor", 3);
            m_VirtuesIDs.Add("Humility", 4);
            m_VirtuesIDs.Add("Justice", 5);
            m_VirtuesIDs.Add("Sacrifice", 6);
            m_VirtuesIDs.Add("Spirituality", 7);
            m_VirtuesIDs.Add("Valor", 8);

            foreach (string k in m_VirtuesIDs.Keys)
                m_VirtuesNames.Add(m_VirtuesIDs[k], k);
            m_Loaded = true;
        }
    }
}
