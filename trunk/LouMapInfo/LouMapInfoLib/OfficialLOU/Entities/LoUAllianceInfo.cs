using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUAllianceInfo : AbstractLoadingTuple
    {
        private readonly Dictionary<string, LoUPlayerInfo> m_Players = new Dictionary<string, LoUPlayerInfo>();

        Dictionary<int, List<LoUPlayerInfo>> m_PlayersByCont = new Dictionary<int, List<LoUPlayerInfo>>();
        Dictionary<int, int> m_ScoreByCont = new Dictionary<int, int>();

        private readonly LoUWorldInfo m_World;
        private readonly string m_Name;
        private readonly int m_Id;

        private int m_Score = 0;

        public int Id { get { return m_Id; } }
        public int Score { get { return m_Score; } }
        public string Name { get { return m_Name; } }
        public LoUWorldInfo World { get { return m_World; } }

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

        public LoUAllianceInfo(LoUWorldInfo world, string name, int id)
            : base()
        {
            m_World = world;
            m_Name = name;
            m_Id = id;
        }
        protected override void OnLoad()
        {
        }
        public void AddPlayer(LoUPlayerInfo p)
        {
            m_Score += p.Score;
            m_Players.Add(p.Name, p);
        }
        public void InformActiveContinent(LoUPlayerInfo p)
        {
            foreach (int i in p.ActiveContinents)
            {
                if (!m_PlayersByCont.ContainsKey(i))
                {
                    m_PlayersByCont.Add(i, new List<LoUPlayerInfo>());
                    m_ScoreByCont.Add(i, 0);
                }
                m_PlayersByCont[i].Add(p);
                m_ScoreByCont[i] += p.CScore(i);
            }
        }
        public LoUPlayerInfo[] Players(int continent)
        {
            if (m_PlayersByCont.ContainsKey(continent))
            {
                LoUPlayerInfo[] res = new LoUPlayerInfo[m_PlayersByCont[continent].Count];
                m_PlayersByCont[continent].CopyTo(res, 0);
                Array.Sort(res);
                Array.Reverse(res);
                return res;
            }
            return new LoUPlayerInfo[0];
        }
        public LoUPlayerInfo[] Players()
        {
            LoUPlayerInfo[] res = new LoUPlayerInfo[m_Players.Count];
            m_Players.Values.CopyTo(res, 0);
            Array.Sort(res);
            Array.Reverse(res);
            return res;
        }
    }
}
