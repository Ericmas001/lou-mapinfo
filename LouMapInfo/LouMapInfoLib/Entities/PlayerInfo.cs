using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class PlayerInfo : IComparable<PlayerInfo>
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
        public string SayScore { get { return (Score > 10000 ? String.Format("{0:0,0,0,0,0}", Score) : (Score > 1000 ? String.Format("{0:0,0}", Score) : "" + Score)); } }

        public PlayerInfo(int id, string name, int pts, AllianceInfo parent)
        {
            m_ID = id;
            m_Name = name;
            m_Score = pts;
            m_Alliance = parent;
        }
        public override string ToString()
        {
            return Name == PlayerInfo.LAWLESS ? "Lawless castles" : (Name + " (" + SayScore + ")");
        }

        public List<CityInfo> Neighbours(int x, int y, int range)
        {
            List<CityInfo> cities = new List<CityInfo>();
            foreach (CityInfo c in m_Cities.Values)
            {
                int dx = Math.Abs(x - c.Location.X);
                int dy = Math.Abs(y - c.Location.Y);
                if( dx == 0 && dy == 0 )
                    continue;
                if( dx <= range && dy <= range )
                    cities.Add(c);
            }
            return cities;
        }

        #region IComparable<PlayerInfo> Members

        public int CompareTo(PlayerInfo other)
        {
            return Score.CompareTo(other.Score);
        }

        #endregion
    }
}
