using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUMoonGateInfo : AbstractLoadingTuple
    {
        private readonly LoUWorldInfo m_World;
        private readonly int m_Id;
        private readonly LoUPt m_Location;

        public int Id { get { return m_Id; } }
        public LoUPt Location { get { return m_Location; } }

        public LoUMoonGateInfo(LoUWorldInfo world, int id, LoUPt location)
            : base()
        {
            m_World = world;
            m_Id = id;
            m_Location = location;
        }
        protected override void OnLoad()
        {

        }

        public override string ToString()
        {
            return m_Location.ToString();
        }
    }
}
