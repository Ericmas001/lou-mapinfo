using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;
using LouMapInfo.Reports.Features;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUPlayerInfo : AbstractLoadingTuple, IComparable<LoUPlayerInfo>
    {
        protected readonly Dictionary<string, LoUCityInfo> m_CitiesByCoords = new Dictionary<string, LoUCityInfo>();
        protected readonly Dictionary<int, LoUCityInfo> m_CitiesById = new Dictionary<int, LoUCityInfo>();
        protected readonly Dictionary<int, List<LoUCityInfo>> m_CitiesByContinent = new Dictionary<int, List<LoUCityInfo>>();
        protected readonly Dictionary<int, int> m_ScoreByContinent = new Dictionary<int, int>();


        protected readonly string m_Name;
        protected readonly int m_Id;
        protected readonly LoUAllianceInfo m_Alliance;
        protected readonly LoUWorldInfo m_World;
        protected int m_Score;
        protected int m_Rank;
        protected readonly int m_InitCityCount;

        public int Id { get { return m_Id; } }
        public string Name { get { return m_Name; } }
        public LoUAllianceInfo Alliance { get { return m_Alliance; } }
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

        public LoUPlayerInfo(LoUWorldInfo world, string name, int id, LoUAllianceInfo alliance, int score, int rank, int nbCities)
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

            JsonObjectCollection info = LoUEndPoint.GetPublicPlayerInfo(m_World.Url, m_World.Session.SessionID, m_Id);
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
                LoUPt pt = new LoUPt(cX, cY);
                LoUCityInfo city = new LoUCityInfo(m_World, this, cN, cI, pt, (LoUBorderingType)cW, (LoUCityType)cS, cP);
                if (!m_CitiesByContinent.ContainsKey(pt.Continent))
                {
                    m_CitiesByContinent.Add(pt.Continent, new List<LoUCityInfo>());
                    m_ScoreByContinent.Add(pt.Continent, 0);
                }
                m_CitiesByContinent[pt.Continent].Add(city);
                m_CitiesByCoords.Add(pt.ToString(), city);
                m_CitiesById.Add(cI, city);
                m_ScoreByContinent[pt.Continent] += cP;
            }
            m_Alliance.InformActiveContinent(this);

        }
        public void AddCity(LoUCityInfo city)
        {
            LoUPt pt = city.Location;
            if (!m_CitiesByContinent.ContainsKey(pt.Continent))
            {
                m_CitiesByContinent.Add(pt.Continent, new List<LoUCityInfo>());
                m_ScoreByContinent.Add(pt.Continent, 0);
            }
            m_CitiesByContinent[pt.Continent].Add(city);
            m_CitiesByCoords.Add(pt.ToString(), city);
            m_CitiesById.Add(city.Id, city);
            m_ScoreByContinent[pt.Continent] += city.Score;
        }
        private LoUCityInfo[] Cities(ICollection<LoUCityInfo> list, ReportFeatures f)
        {
            LoUCityInfo[] all = new LoUCityInfo[list.Count];
            list.CopyTo(all, 0);
            List<LoUCityInfo> res = new List<LoUCityInfo>();
            foreach (LoUCityInfo c in all)
            {
                bool ok = true;
                ok = ok && (c.Bordering != LoUBorderingType.Land || f.Features.Contains(ReportFeatureType.BorderingLand));
                ok = ok && (c.Bordering != LoUBorderingType.Water || f.Features.Contains(ReportFeatureType.BorderingWater));
                ok = ok && (c.TypeCity != LoUCityType.City || f.Features.Contains(ReportFeatureType.TypeCity));
                ok = ok && (c.TypeCity != LoUCityType.Castle || f.Features.Contains(ReportFeatureType.TypeCastle));
                ok = ok && (c.TypeCity != LoUCityType.Palace || f.Features.Contains(ReportFeatureType.TypePalace));

                if (ok)
                    res.Add(c);
            }
            return Cities(res);
        }
        private LoUCityInfo[] Cities(ICollection<LoUCityInfo> list)
        {
            LoUCityInfo[] res = new LoUCityInfo[list.Count];
            list.CopyTo(res, 0);
            return res;
        }

        public LoUCityInfo[] Cities()
        {
            return Cities(m_CitiesById.Values);
        }
        public LoUCityInfo[] Cities(int continent)
        {
            if (m_CitiesByContinent.ContainsKey(continent))
                return Cities(m_CitiesByContinent[continent]);
            return new LoUCityInfo[0];
        }
        public LoUCityInfo[] Cities(ReportFeatures f)
        {
            return Cities(Cities(), f);
        }
        public LoUCityInfo[] Cities(ReportFeatures f, int c)
        {
            return Cities(Cities(c), f);
        }
        public LoUCityInfo[] Cities(params ReportFeatureType[] f)
        {
            return Cities(Cities(), new ReportFeatures(f));
        }
        public LoUCityInfo[] Cities(int c, params ReportFeatureType[] f)
        {
            return Cities(Cities(c), new ReportFeatures(f));
        }
        public LoUCityInfo City(string location)
        {
            if (m_CitiesByCoords.ContainsKey(location))
                return m_CitiesByCoords[location];
            return null;
        }
        public LoUCityInfo City(LoUPt location)
        {
            if (m_CitiesByCoords.ContainsKey(location.ToString()))
                return m_CitiesByCoords[location.ToString()];
            return null;
        }
        public LoUCityInfo City(int id)
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

        public int CompareTo(LoUPlayerInfo other)
        {
            return m_Score.CompareTo(other.Score);
        }

        #endregion
    }
}
