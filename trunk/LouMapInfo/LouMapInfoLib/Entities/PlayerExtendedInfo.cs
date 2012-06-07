using System;
using System.Collections.Generic;
using System.Text;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Entities
{
    public class PlayerExtendedInfo : PlayerInfo
    {
        private int m_Gold;

        public int Gold
        {
            get { return m_Gold; }
            set { m_Gold = value; }
        }
        private int m_Mana;

        public int Mana
        {
            get { return m_Mana; }
            set { m_Mana = value; }
        }
        private int m_PurWood;

        public int PurWood
        {
            get { return m_PurWood; }
            set { m_PurWood = value; }
        }
        private int m_PurStone;

        public int PurStone
        {
            get { return m_PurStone; }
            set { m_PurStone = value; }
        }
        private int m_PurIron;

        public int PurIron
        {
            get { return m_PurIron; }
            set { m_PurIron = value; }
        }
        private int m_PurFood;

        public int PurFood
        {
            get { return m_PurFood; }
            set { m_PurFood = value; }
        }

        public PlayerExtendedInfo(WorldInfo world, string name, int id, AllianceInfo alliance, int score, int rank, int nbCities)
            : base(world, name, id, alliance, score, rank, nbCities)
        {
        }
        protected override void OnLoad()
        {
            base.OnLoad();

            JsonObjectCollection info = EndPoint.GetMyPlayerInfo(m_World.Url, m_World.Session.SessionID);
            JsonArrayCollection cities = (JsonArrayCollection)info["c"];
            foreach (JsonObjectCollection cInfo in cities)
            {
                int cI = (int)((JsonNumericValue)cInfo["i"]).Value; // id
                string cR = (string)((JsonStringValue)cInfo["r"]).Value; // title
                CityExtendedInfo cei = m_CitiesById[cI] as CityExtendedInfo;
                cei.Title = cR;
            }

            m_Gold = (int)((JsonNumericValue)((JsonObjectCollection)info["g"])["b"]).Value;
            m_Mana = (int)((JsonNumericValue)((JsonObjectCollection)info["m"])["b"]).Value;

            foreach (JsonArrayCollection pur in (JsonArrayCollection)info["vr"])
            {
                int i = (int)((JsonNumericValue)pur[0]).Value;
                int v = (int)((JsonNumericValue)pur[1]).Value;

                switch (i)
                {
                    case 8: m_PurFood = v; break;
                    case 7: m_PurIron = v; break;
                    case 6: m_PurStone = v; break;
                    case 5: m_PurWood = v; break;
                }
            }

            // Not Used anywhere
            //JsonArrayCollection test = EndPoint.GetVIS(m_World.Url, m_World.Session.SessionID);
        }
    }
}
