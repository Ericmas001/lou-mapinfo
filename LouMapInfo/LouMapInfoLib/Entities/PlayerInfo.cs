using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;
using LouMapInfo.Reports;
using LouMapInfo.Reports.core;

namespace LouMapInfo.Entities
{
    public class PlayerInfo : AbstractLoadingTuple, IComparable<PlayerInfo>
    {
        protected readonly Dictionary<string, CityInfo> m_CitiesByCoords = new Dictionary<string, CityInfo>();
        protected readonly Dictionary<int, CityInfo> m_CitiesById = new Dictionary<int, CityInfo>();
        protected readonly Dictionary<int, List<CityInfo>> m_CitiesByContinent = new Dictionary<int, List<CityInfo>>();
        protected readonly Dictionary<int, int> m_ScoreByContinent = new Dictionary<int, int>();


        protected readonly string m_Name;
        protected readonly int m_Id;
        protected readonly AllianceInfo m_Alliance;
        protected readonly WorldInfo m_World;
        protected int m_Score;
        protected int m_Rank;
        protected readonly int m_InitCityCount;
        private char m_Prefix;

        public char Prefix  // A: Normal Player, C: LordOfUltima
        {
            get { return m_Prefix; }
            set { m_Prefix = value; }
        }

        public int Id { get { return m_Id; } }
        public string Name { get { return m_Name; } }
        public AllianceInfo Alliance { get { return m_Alliance; } }
        public int Score { get { return m_Score; } }
        public int Rank { get { return m_Rank; } }
        public int CityCount { get { return m_InitCityCount; } }
        public int[] ActiveContinents
        {
            get
            {
                int[] res = new int[m_CitiesByContinent.Count];
                m_CitiesByContinent.Keys.CopyTo(res, 0);
                Array.Sort(res);
                return res;
            }
        }

        public PlayerInfo(WorldInfo world, string name, int id, AllianceInfo alliance, int score, int rank, int nbCities)
            : base()
        {
            m_World = world;
            m_Name = name;
            m_Id = id;
            m_Alliance = alliance;
            m_Score = score;
            m_Rank = rank;
            m_InitCityCount = nbCities;
            m_Alliance.AddPlayer(this);
        }
        protected override void OnLoad()
        {
            m_CitiesById.Clear();
            m_CitiesByCoords.Clear();
            m_CitiesByContinent.Clear();

            JsonObjectCollection info = EndPoint.GetPublicPlayerInfo(m_World.Url, m_World.Session.SessionID, m_Id);
            JsonArrayCollection cities = (JsonArrayCollection)info["c"];
            foreach (JsonObjectCollection cInfo in cities)
            {
                int cI = (int)((JsonNumericValue)cInfo["i"]).Value; // id
                string cN = (string)((JsonStringValue)cInfo["n"]).Value; // name
                int cP = (int)((JsonNumericValue)cInfo["p"]).Value; // Points
                int cS = (int)((JsonNumericValue)cInfo["s"]).Value; // CastleInfo
                int cW = (int)((JsonNumericValue)cInfo["w"]).Value; // WaterInfo
                int cX = (int)((JsonNumericValue)cInfo["x"]).Value; // X
                int cY = (int)((JsonNumericValue)cInfo["y"]).Value; // Y
                int continent = ((cY / 100) * 10) + (cX / 100);
                Pt pt = new Pt(m_World,cX, cY);
                CityInfo city;
                if (this is PlayerExtendedInfo)
                    city = new CityExtendedInfo(m_World, this, cN, cI, pt, (BorderingType)cW, (CityType)cS, cP);
                else
                    city = new CityInfo(m_World, this, cN, cI, pt, (BorderingType)cW, (CityType)cS, cP);
                if (!m_CitiesByContinent.ContainsKey(pt.Continent))
                {
                    m_CitiesByContinent.Add(pt.Continent, new List<CityInfo>());
                    m_ScoreByContinent.Add(pt.Continent, 0);
                }
                m_CitiesByContinent[pt.Continent].Add(city);
                m_CitiesByCoords.Add(pt.ToString(), city);
                m_CitiesById.Add(cI, city);
                m_ScoreByContinent[pt.Continent] += cP;
            }
            m_Alliance.InformActiveContinent(this);

        }
        public void AddCity(CityInfo city)
        {
            Pt pt = city.Location;
            if (!m_CitiesByContinent.ContainsKey(pt.Continent))
            {
                m_CitiesByContinent.Add(pt.Continent, new List<CityInfo>());
                m_ScoreByContinent.Add(pt.Continent, 0);
            }
            m_CitiesByContinent[pt.Continent].Add(city);
            m_CitiesByCoords.Add(pt.ToString(), city);
            m_CitiesById.Add(city.Id, city);
            m_ScoreByContinent[pt.Continent] += city.Score;
        }
        private CityInfo[] Cities(ICollection<CityInfo> list, Filters f)
        {
            CityInfo[] all = new CityInfo[list.Count];
            list.CopyTo(all, 0);
            List<CityInfo> res = new List<CityInfo>();
            foreach (CityInfo c in all)
            {
                bool ok = true;
                ok = ok && (c.Bordering != BorderingType.Land || f.AllFilters.Contains(FilterType.BorderingLand));
                ok = ok && (c.Bordering != BorderingType.Water || f.AllFilters.Contains(FilterType.BorderingWater));
                ok = ok && (c.TypeCity != CityType.City || f.AllFilters.Contains(FilterType.TypeCity));
                ok = ok && (c.TypeCity != CityType.Castle || f.AllFilters.Contains(FilterType.TypeCastle));
                ok = ok && (c.TypeCity != CityType.Palace || f.AllFilters.Contains(FilterType.TypePalace));

                if (ok)
                    res.Add(c);
            }
            return Cities(res);
        }
        private CityInfo[] Cities(ICollection<CityInfo> list)
        {
            CityInfo[] res = new CityInfo[list.Count];
            list.CopyTo(res, 0);
            return res;
        }

        public CityInfo[] Cities()
        {
            return Cities(m_CitiesById.Values);
        }
        public CityInfo[] Cities(int continent)
        {
            if (continent == -1)
                return Cities();
            if (m_CitiesByContinent.ContainsKey(continent))
                return Cities(m_CitiesByContinent[continent]);
            return new CityInfo[0];
        }
        public CityInfo[] Cities(Filters f)
        {
            return Cities(Cities(), f);
        }
        public CityInfo[] Cities(Filters f, int c)
        {
            return Cities(Cities(c), f);
        }
        public CityInfo[] Cities(params FilterType[] f)
        {
            return Cities(Cities(), new Filters(f));
        }
        public CityInfo[] Cities(int c, params FilterType[] f)
        {
            return Cities(Cities(c), new Filters(f));
        }
        public CityInfo City(string location)
        {
            if (m_CitiesByCoords.ContainsKey(location))
                return m_CitiesByCoords[location];
            return null;
        }
        public CityInfo City(Pt location)
        {
            if (m_CitiesByCoords.ContainsKey(location.ToString()))
                return m_CitiesByCoords[location.ToString()];
            return null;
        }
        public CityInfo City(int id)
        {
            if (m_CitiesById.ContainsKey(id))
                return m_CitiesById[id];
            return null;
        }
        public int CScore(int continent)
        {
            if (m_ScoreByContinent.ContainsKey(continent))
                return m_ScoreByContinent[continent];
            return 0;
        }

        #region IComparable<LoUPlayerInfo> Members

        public int CompareTo(PlayerInfo other)
        {
            return m_Score.CompareTo(other.Score);
        }

        #endregion
    }
}
