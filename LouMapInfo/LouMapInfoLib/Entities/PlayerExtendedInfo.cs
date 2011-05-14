using System;
using System.Collections.Generic;
using System.Text;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Entities
{
    public class PlayerExtendedInfo : PlayerInfo
    {
        private int m_Gold;
        private int m_Mana;
        private int m_PurWood;
        private int m_PurStone;
        private int m_PurIron;
        private int m_PurFood;

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

            JsonArrayCollection test = EndPoint.GetVIS(m_World.Url, m_World.Session.SessionID);
        }
    }
}
