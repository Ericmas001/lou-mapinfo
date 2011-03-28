using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;

namespace LouMapInfo.Entities
{
    public class ShrineInfo : AbstractLoadingTuple
    {
        private readonly WorldInfo m_World;
        private readonly int m_Id;
        private readonly Pt m_Location;
        private readonly ShrineType m_Virtue;

        public int Id { get { return m_Id; } }
        public Pt Location { get { return m_Location; } }
        public ShrineType Virtue { get { return m_Virtue; } }

        public ShrineInfo(WorldInfo world, int id, Pt location, ShrineType virtue)
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
