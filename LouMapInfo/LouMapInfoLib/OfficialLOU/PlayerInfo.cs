using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;

namespace LouMapInfo.OfficialLOU
{
    public class PlayerInfo : AbstractLoadingTuple
    {
        private readonly string m_Name;
        private readonly int m_Id;
        private readonly AllianceInfo m_Alliance;
        private int m_Score;
        private int m_Rank;
        private readonly int m_InitCityCount;

        public int Id { get { return m_Id; } }
        public string Name { get { return m_Name; } }
        public AllianceInfo Alliance { get { return m_Alliance; } }
        public int Score { get { return m_Score; } }
        public int Rank { get { return m_Rank; } }
        public int CityCount { get { return m_InitCityCount; } }

        public PlayerInfo(string name, int id, AllianceInfo alliance, int score, int rank, int nbCities)
            : base()
        {
            m_Name = name;
            m_Id = id;
            m_Alliance = alliance;
            m_Score = score;
            m_Rank = rank;
            m_InitCityCount = nbCities;
        }
        protected override void OnLoad()
        {

        }
    }
}
