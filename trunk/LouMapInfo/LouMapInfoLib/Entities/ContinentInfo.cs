using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class ContinentInfo : IComparable<ContinentInfo>
    {
        private bool m_Loaded = false;

        public bool Loaded
        {
            get { return m_Loaded; }
            set { m_Loaded = value; }
        }
        private readonly int m_ID;
        private readonly WorldInfo m_World;
        private readonly List<Pt> m_Shrines = new List<Pt>();
        private readonly List<Pt> m_MoonGates = new List<Pt>();
        private readonly Dictionary<string, AllianceInfo> m_Alliances = new Dictionary<string, AllianceInfo>();

        public int ID { get { return m_ID; } }
        public WorldInfo World { get { return m_World; } }
        public List<Pt> Shrines { get { return m_Shrines; } }
        public List<Pt> MoonGates { get { return m_MoonGates; } }
        public Dictionary<string,AllianceInfo> Alliances { get { return m_Alliances; } }

        public ContinentInfo(int id, WorldInfo parent)
        {
            m_ID = id;
            m_World = parent;
        }

        #region IComparable<ContinentInfo> Members

        public int CompareTo(ContinentInfo other)
        {
            return m_ID.CompareTo(other.ID);
        }

        #endregion
        public override string ToString()
        {
            return ""+ID;
        }
    }
}
