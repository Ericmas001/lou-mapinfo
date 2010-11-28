using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class Pt
    {
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
        public Pt()
        {
        }
        public Pt(int x, int y)
        {
            m_x = x;
            m_y = y;
        }
        public override string ToString()
        {
            return m_x + ":" + m_y;
        }
    }
}
