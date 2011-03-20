using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Layout;

namespace LouMapInfoApp.Tools
{
    public class LayoutEntry
    {
        private int m_X;

        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }
        private int m_Y;

        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }
        private BuildingType m_Info;

        public BuildingType Info
        {
            get { return m_Info; }
            set
            {
                if (m_X == 9 && m_Y == 9)
                    m_Info = BuildingType.None;
                else
                    m_Info = value;
            }
        }
        public LayoutEntry(int x, int y, BuildingType type)
        {
            m_X = x;
            m_Y = y;
            if (x == 9 && y == 9)
                m_Info = BuildingType.None;
            else
                m_Info = type;
        }
    }
}
