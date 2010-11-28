using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class WorldInfo
    {
        private readonly int m_ID;
        private readonly DateTime m_LastUpdated;

        public int ID { get { return m_ID; } }
        public DateTime LastUpdated { get { return m_LastUpdated; } }

        public WorldInfo(int id, DateTime lastUpdated)
        {
            m_ID = id;
            m_LastUpdated = lastUpdated;
        }
    }
}
