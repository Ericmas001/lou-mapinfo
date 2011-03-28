using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Entities
{
    public class AllianceInfo : AbstractLoadingTuple, IComparable<AllianceInfo>
    {
        private readonly Dictionary<string, PlayerInfo> m_Players = new Dictionary<string, PlayerInfo>();

        Dictionary<int, List<PlayerInfo>> m_PlayersByCont = new Dictionary<int, List<PlayerInfo>>();
        Dictionary<int, int> m_ScoreByCont = new Dictionary<int, int>();

        private readonly WorldInfo m_World;
        private readonly string m_Name;
        private readonly int m_Id;

        private int m_Score = 0;

        public int Id { get { return m_Id; } }
        public int Score { get { return String.IsNullOrEmpty(m_Name) ? 0 : m_Score; } }
        public string Name { get { return m_Name; } }
        public WorldInfo World { get { return m_World; } }

        public int[] ActiveContinents
        {
            get
            {
                int[] res = new int[m_PlayersByCont.Count];
                m_PlayersByCont.Keys.CopyTo(res, 0);
                Array.Sort(res);
                return res;
            }
        }
        public int CScore(int continent)
        {
            if (m_ScoreByCont.ContainsKey(continent))
                return m_ScoreByCont[continent];
            return 0;
        }

        public AllianceInfo(WorldInfo world, string name, int id)
            : base()
        {
            m_World = world;
            m_Name = name;
            m_Id = id;
        }
        protected override void OnLoad()
        {
        }
        public void AddPlayer(PlayerInfo p)
        {
            m_Score += p.Score;
            m_Players.Add(p.Name, p);
        }
        public void InformActiveContinent(PlayerInfo p)
        {
            foreach (int i in p.ActiveContinents)
            {
                if (!m_PlayersByCont.ContainsKey(i))
                {
                    m_PlayersByCont.Add(i, new List<PlayerInfo>());
                    m_ScoreByCont.Add(i, 0);
                }
                m_PlayersByCont[i].Add(p);
                m_ScoreByCont[i] += p.CScore(i);
            }
        }
        public PlayerInfo[] Players(int continent)
        {
            if (m_PlayersByCont.ContainsKey(continent))
            {
                PlayerInfo[] res = new PlayerInfo[m_PlayersByCont[continent].Count];
                m_PlayersByCont[continent].CopyTo(res, 0);
                
                Array.Sort(res, new PlayerContinentCom(continent));
                Array.Reverse(res);
                return res;
            }
            return new PlayerInfo[0];
        }

        class PlayerContinentCom : IComparer<PlayerInfo>
        {
            private int m_C;
            public PlayerContinentCom(int c)
            {
                m_C = c;
            }
            #region IComparer<LoUPlayerInfo> Members

            public int Compare(PlayerInfo x, PlayerInfo y)
            {
                return x.CScore(m_C).CompareTo(y.CScore(m_C));
            }

            #endregion
        }
        public PlayerInfo[] Players()
        {
            PlayerInfo[] res = new PlayerInfo[m_Players.Count];
            m_Players.Values.CopyTo(res, 0);
            Array.Sort(res);
            Array.Reverse(res);
            return res;
        }

        #region IComparable<LoUAllianceInfo> Members

        public int CompareTo(AllianceInfo other)
        {
            return Score.CompareTo(other.Score);
        }

        #endregion
    }
}
