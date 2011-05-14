using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class Pt
    {
        private readonly WorldInfo m_World;
        private int m_x;

        public int X
        {
            get { return m_x; }
            set { m_x = value; }
        }
        private int m_y;

        public int Y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public int Continent
        {
            get { return ((m_y / m_World.ContinentsHeight) * 10) + (m_x / m_World.ContinentsHeight); }
        }
        public Pt(WorldInfo world)
        {
            m_World = world;
        }
        public Pt(WorldInfo world, int x, int y)
        {
            m_World = world;
            m_x = x;
            m_y = y;
        }
        public Pt(WorldInfo world, string loc)
        {
            m_World = world;
            string[] s = loc.Split(':');
            m_x = int.Parse(s[0]);
            m_y = int.Parse(s[1]);
        }
        public override string ToString()
        {
            return String.Format(" {0:000}:{1:000} ", m_x, m_y);
        }
    }
}
