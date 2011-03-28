using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;

namespace LouMapInfo.Entities
{
    public class MoonGateInfo : AbstractLoadingTuple
    {
        private readonly WorldInfo m_World;
        private readonly int m_Id;
        private readonly Pt m_Location;

        public int Id { get { return m_Id; } }
        public Pt Location { get { return m_Location; } }

        public MoonGateInfo(WorldInfo world, int id, Pt location)
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
