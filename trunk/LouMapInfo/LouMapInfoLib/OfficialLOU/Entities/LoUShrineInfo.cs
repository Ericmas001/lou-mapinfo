using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUShrineInfo : AbstractLoadingTuple
    {
        private readonly LoUWorldInfo m_World;
        private readonly int m_Id;
        private readonly LoUPt m_Location;
        private readonly LoUShrineType m_Virtue;

        public int Id { get { return m_Id; } }
        public LoUPt Location { get { return m_Location; } }
        public LoUShrineType Virtue { get { return m_Virtue; } }

        public LoUShrineInfo(LoUWorldInfo world, int id, LoUPt location, LoUShrineType virtue)
            : base()
        {
            m_World = world;
            m_Id = id;
            m_Location = location;
            m_Virtue = virtue;
        }
        protected override void OnLoad()
        {

        }

        public override string ToString()
        {
            return m_Location.ToString() + "(" + m_Virtue.ToString() + ")";
        }
    }
}
