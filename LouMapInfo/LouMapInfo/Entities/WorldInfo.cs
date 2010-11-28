using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class WorldInfo : IComparable<WorldInfo>
    {
        private readonly int m_ID;
        private readonly DateTime m_LastUpdated;
        private readonly Dictionary<int,ContinentInfo> m_Continents = new Dictionary<int,ContinentInfo>();

        public int ID { get { return m_ID; } }
        public DateTime LastUpdated { get { return m_LastUpdated; } }
        public ContinentInfo[] Continents
        {
            get
            {
                ContinentInfo[] cs = new ContinentInfo[m_Continents.Count];
                m_Continents.Values.CopyTo(cs,0);
                Array.Sort(cs);
                return cs;
            }
        }

        public WorldInfo(int id, DateTime lastUpdated)
        {
            m_ID = id;
            m_LastUpdated = lastUpdated;
        }

        public ContinentInfo Cont(int contID)
        {
            if (!m_Continents.ContainsKey(contID))
                m_Continents.Add(contID, new ContinentInfo(contID,this));
            return m_Continents[contID];
        }

        #region IComparable<WorldInfo> Members

        public int CompareTo(WorldInfo other)
        {
            return m_ID.CompareTo(other.ID);
        }

        #endregion
    }
}
