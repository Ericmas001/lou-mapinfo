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
        private Dictionary<string, CityInfo> m_Castles = new Dictionary<string, CityInfo>();
        private AllianceInfo m_Alliance;

        public int ID { get { return m_ID; } }
        public string Name { get { return m_Name; } }
        public int Score { get { return m_Score; } }
        public CityInfo[] CitiesOnly
        {
            get
            {
                CityInfo[] cities = new CityInfo[m_Cities.Count];
                m_Cities.Values.CopyTo(cities, 0);
                return cities;
            }
        }
        public CityInfo[] CastlesOnly
        {
            get
            {
                CityInfo[] cities = new CityInfo[m_Castles.Count];
                m_Castles.Values.CopyTo(cities, 0);
                return cities;
            }
        }
        public CityInfo[] AllCities
        {
            get
            {
                CityInfo[] cities = new CityInfo[m_Castles.Count+m_Cities.Count];
                m_Castles.Values.CopyTo(cities, 0);
                m_Cities.Values.CopyTo(cities, m_Castles.Count);
                return cities;
            }
        }

        public AllianceInfo Alliance { get { return m_Alliance; } }
        public string SayScore { get { return (Score > 10000 ? String.Format("{0:0,0,0,0,0}", Score) : (Score > 1000 ? String.Format("{0:0,0}", Score) : "" + Score)); } }

        public PlayerInfo(int id, string name, int pts, AllianceInfo parent)
        {
            m_ID = id;
            m_Name = name;
            m_Score = pts;
            m_Alliance = parent;
        }
        public PlayerInfo(string name, AllianceInfo parent)
            : this(-1, name, 0, parent)
        {
        }
        public override string ToString()
        {
            return Name == PlayerInfo.LAWLESS ? "Lawless castles" : (Name + " (" + SayScore + ")");
        }

        public List<CityInfo> Neighbours(int x, int y, int range)
        {
            List<CityInfo> cities = new List<CityInfo>();
            foreach (CityInfo c in AllCities)
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

        public void AddCity(CityInfo c)
        {
            if (c.Castle)
                m_Castles.Add(c.Location.ToString(), c);
            else
                m_Cities.Add(c.Location.ToString(), c);
        }

        public void AddCityAddScore(CityInfo c)
        {
            if (c.Castle)
                m_Castles.Add(c.Location.ToString(), c);
            else
                m_Cities.Add(c.Location.ToString(), c);
            m_Score += c.Score;
            m_Alliance.Score += c.Score;
        }

        public CityInfo City(string location)
        {
            if (m_Castles.ContainsKey(location))
                return m_Castles[location];
            if (m_Cities.ContainsKey(location))
                return m_Cities[location];
            return null;
        }

        public CityInfo City(Pt location)
        {
            return City(location.ToString());
        }

        public CityInfo City(int x, int y)
        {
            return City(new Pt(x,y));
        }
    }
}
