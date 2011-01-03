using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUContinentInfo : AbstractLoadingTuple
    {
        Dictionary<int, LoUAllianceInfo> m_Alliances = new Dictionary<int, LoUAllianceInfo>();
        private readonly LoUWorldInfo m_World;
        private readonly int m_Id;

        public int Id { get { return m_Id; } }
        public LoUWorldInfo World { get { return m_World; } }

        public LoUAllianceInfo[] Alliances
        {
            get
            {
                LoUAllianceInfo[] res = new LoUAllianceInfo[m_Alliances.Count];
                m_Alliances.Values.CopyTo(res, 0);
                Array.Sort(res);
                Array.Reverse(res);
                return res;
            }
        }
        public LoUContinentInfo(LoUWorldInfo world, int id)
            : base()
        {
            m_World = world;
            m_Id = id;
        }
        protected override void OnLoad()
        {
            JsonArrayCollection players = LoUEndPoint.GetPlayerList(m_World.Url, m_World.Session.SessionID, m_Id);
            foreach (JsonObjectCollection p in players)
            {
                string n = ((JsonStringValue)p["n"]).Value;
                int r = (int)((JsonNumericValue)p["r"]).Value;
                int c = (int)((JsonNumericValue)p["c"]).Value;
                LoUPlayerInfo player = World.Player(n);
                if (!m_Alliances.ContainsKey(player.Alliance.Id))
                    m_Alliances.Add(player.Alliance.Id, new LoUAllianceInfo(World, player.Alliance.Name, player.Alliance.Id));
                LoUPlayerInfo cPlayer = new LoUPlayerInfo(World, player.Name, player.Id, m_Alliances[player.Alliance.Id], player.CScore(Id), r, c);
                foreach (LoUCityInfo city in player.Cities(41))
                {
                    cPlayer.AddCity(new LoUCityInfo(World, cPlayer, city.Name, city.Id, city.Location, city.Bordering, city.TypeCity, city.Score));
                }
                m_Alliances[player.Alliance.Id].InformActiveContinent(cPlayer);
            }
        }
    }
}
