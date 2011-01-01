using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUAllianceInfo : AbstractLoadingTuple
    {
        private readonly Dictionary<string, LoUPlayerInfo> m_Players = new Dictionary<string, LoUPlayerInfo>();

        private readonly LoUWorldInfo m_World;
        private readonly string m_Name;
        private readonly int m_Id;

        private int m_Score = 0;

        public int Id { get { return m_Id; } }
        public int Score { get { return m_Score; } }
        public string Name { get { return m_Name; } }
        public LoUWorldInfo World { get { return m_World; } }

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
    }
}
