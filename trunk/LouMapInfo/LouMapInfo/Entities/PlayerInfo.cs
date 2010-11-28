using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class PlayerInfo
    {
        public static string LAWLESS { get { return "-"; } }
        private int m_ID;
        private string m_Name;
        private int m_Score;
        private Dictionary<string, CityInfo> m_Cities = new Dictionary<string, CityInfo>();
        private AllianceInfo m_Alliance;

        public int ID { get { return m_ID; } }
        public string Name { get { return m_Name; } }
        public int Score { get { return m_Score; } }
        public Dictionary<string, CityInfo> Cities { get { return m_Cities; } }
        public AllianceInfo Alliance { get { return m_Alliance; } }

        public PlayerInfo(int id, string name, int pts, AllianceInfo parent)
        {
            m_ID = id;
            m_Name = name;
            m_Score = pts;
            m_Alliance = parent;
        }
        public override string ToString()
        {
            return Name + " (" + Score + ")";
        }
    }
}
