﻿using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;

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
        private LoUCityInfo[] Cities(ICollection<LoUCityInfo> list)
        {
            LoUCityInfo[] res = new LoUCityInfo[list.Count];
            list.CopyTo(res, 0);
            return res;
        }
        private LoUCityInfo[] Cities(ICollection<LoUCityInfo> list, LoUCityType type, bool land, bool water)
        {
            LoUCityInfo[] all = new LoUCityInfo[list.Count];
            list.CopyTo(all, 0);
            if (type == LoUCityType.CityCastlePalace)
                return all;
            List<LoUCityInfo> res = new List<LoUCityInfo>();
            foreach (LoUCityInfo c in all)
            {
                switch (c.TypeCity)
                {
                    case LoUCityType.City:
                        switch (type)
                        {
                            case LoUCityType.City:
                            case LoUCityType.CityCastle:
                            case LoUCityType.CityCastlePalace:
                            case LoUCityType.CityPalace:
                                if ((c.Bordering == LoUBorderingType.Land && land) || (c.Bordering == LoUBorderingType.Water && water))
                                    res.Add(c);
                                break;
                        }
                        break;
                    case LoUCityType.Castle:
                        switch (type)
                        {
                            case LoUCityType.Castle:
                            case LoUCityType.CityCastle:
                            case LoUCityType.CityCastlePalace:
                            case LoUCityType.CastlePalace:
                                if ((c.Bordering == LoUBorderingType.Land && land) || (c.Bordering == LoUBorderingType.Water && water))
                                    res.Add(c);
                                break;
                        }
                        break;
                    case LoUCityType.Palace:
                        switch (type)
                        {
                            case LoUCityType.Palace:
                            case LoUCityType.CastlePalace:
                            case LoUCityType.CityCastlePalace:
                            case LoUCityType.CityPalace:
                                if ((c.Bordering == LoUBorderingType.Land && land) || (c.Bordering == LoUBorderingType.Water && water))
                                    res.Add(c);
                                break;
                        }
                        break;
                }
            }
            return Cities(res);
        }
        private LoUCityInfo[] Cities(ICollection<LoUCityInfo> list, bool land, bool water)
        {
            return Cities(list, LoUCityType.CityCastlePalace, land, water);
        }
        private LoUCityInfo[] Cities(ICollection<LoUCityInfo> list, LoUCityType type)
        {
            return Cities(list, type, true, true);
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
        public LoUCityInfo[] Cities(LoUCityType type)
        {
            return Cities(Cities(), type);
        }
        public LoUCityInfo[] Cities(bool land, bool water)
        {
            return Cities(Cities(), land, water);
        }
        public LoUCityInfo[] Cities(LoUCityType type, int continent)
        {
            return Cities(Cities(continent), type);
        }
        public LoUCityInfo[] Cities(bool land, bool water, int continent)
        {
            return Cities(Cities(continent), land, water);
        }
        public LoUCityInfo[] Cities(LoUCityType type, bool land, bool water, int continent)
        {
            return Cities(Cities(continent), type, land, water);
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
