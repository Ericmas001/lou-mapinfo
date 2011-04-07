using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Entities
{
    public class ContinentInfo : AbstractLoadingTuple
    {
        Dictionary<int, AllianceInfo> m_Alliances = new Dictionary<int, AllianceInfo>();
        private readonly WorldInfo m_World;
        private readonly int m_Id;

        public int Id { get { return m_Id; } }
        public WorldInfo World { get { return m_World; } }

        public AllianceInfo[] Alliances
        {
            get
            {
                AllianceInfo[] res = new AllianceInfo[m_Alliances.Count];
                m_Alliances.Values.CopyTo(res, 0);
                Array.Sort(res);
                Array.Reverse(res);
                return res;
            }
        }
        public ContinentInfo(WorldInfo world, int id)
            : base()
        {
            m_World = world;
            m_Id = id;
        }
        protected override void OnLoad()
        {
            JsonArrayCollection players = EndPoint.GetPlayerList(m_World.Url, m_World.Session.SessionID, m_Id, 0, 0);
            foreach (JsonObjectCollection p in players)
            {
                string n = ((JsonStringValue)p["n"]).Value;
                int r = (int)((JsonNumericValue)p["r"]).Value;
                int c = (int)((JsonNumericValue)p["c"]).Value;
                PlayerInfo player = World.Player(n);
                if (!m_Alliances.ContainsKey(player.Alliance.Id))
                    m_Alliances.Add(player.Alliance.Id, new AllianceInfo(World, player.Alliance.Name, player.Alliance.Id));
                PlayerInfo cPlayer = new PlayerInfo(World, player.Name, player.Id, m_Alliances[player.Alliance.Id], player.CScore(Id), r, c);
                foreach (CityInfo city in player.Cities(m_Id))
                {
                    cPlayer.AddCity(new CityInfo(World, cPlayer, city.Name, city.Id, city.Location, city.Bordering, city.TypeCity, city.Score));
                }
                m_Alliances[player.Alliance.Id].InformActiveContinent(cPlayer);
            }
        }
    }
}
