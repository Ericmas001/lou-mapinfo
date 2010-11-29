using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class CityInfo : IComparable<CityInfo>
    {
        private int m_ID;
        private string m_Name;
        private int m_Score;
        private bool m_Castle;
        private Pt m_Location;
        private PlayerInfo m_Player;

        public int ID { get { return m_ID; } }
        public string Name { get { return m_Name; } }
        public int Score { get { return m_Score; } }
        public string SayScore { get { return (Score > 10000 ? String.Format("{0:0,0,0,0,0}", Score) : (Score > 1000 ? String.Format("{0:0,0}", Score) : "" + Score)); } }
        public bool Castle { get { return m_Castle; } }
        public Pt Location { get { return m_Location; } }
        public PlayerInfo Player { get { return m_Player; } }

        public CityInfo(int id, string name, int pts, bool castle, Pt loc, PlayerInfo parent)
        {
            m_ID = id;
            m_Name = name;
            m_Score = pts;
            m_Castle = castle;
            m_Location = loc;
            m_Player = parent;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}{2} ({3})", Location, Name, (Castle ? "[*]" : ""), SayScore);
        }

        #region IComparable<CityInfo> Members

        public int CompareTo(CityInfo other)
        {
            return Score.CompareTo(other.Score);
        }

        #endregion
    }
}
