using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class CityExtendedInfo : CityInfo
    {
        protected string m_Title;

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        public CityExtendedInfo(WorldInfo world, PlayerInfo player, string name, int id, Pt location, BorderingType bordering, CityType type, int score)
            : base(world, player, name, id, location, bordering, type, score)
        {}
        protected override void OnLoad()
        {
            base.OnLoad();
        }
    }
    
}
