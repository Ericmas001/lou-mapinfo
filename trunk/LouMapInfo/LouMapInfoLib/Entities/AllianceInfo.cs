using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class AllianceInfo : IComparable<AllianceInfo>
    {
        public static string NO_ALLIANCE { get { return "-"; } }

        private int m_ID;
        private string m_Name;
        private int m_Score;
        private Dictionary<string, PlayerInfo> m_Players = new Dictionary<string, PlayerInfo>();
        private ContinentInfo m_Continent;

        public int ID { get { return m_ID; } }
        public string Name { get { return m_Name; } }
        public int Score { get { return m_Score; } }
        public string SayScore { get { return (Score > 10000 ? String.Format("{0:0,0,0,0,0}", Score) : (Score > 1000 ? String.Format("{0:0,0}", Score) : "" + Score)); } }
        public Dictionary<string, PlayerInfo> Players { get { return m_Players; } }
        public ContinentInfo Continent { get { return m_Continent; } }

        public AllianceInfo(int id, string name, int pts, ContinentInfo parent)
        {
            m_ID = id;
            m_Name = name;
            m_Score = pts;
            m_Continent = parent;
        }
        public override string ToString()
        {
            return Name == AllianceInfo.NO_ALLIANCE ? "No Alliance" :( Name  + " (" + SayScore + ")");
        }

        #region IComparable<AllianceInfo> Members

        public int CompareTo(AllianceInfo other)
        {
            return Score.CompareTo(other.Score);
        }

        #endregion
    }
}
