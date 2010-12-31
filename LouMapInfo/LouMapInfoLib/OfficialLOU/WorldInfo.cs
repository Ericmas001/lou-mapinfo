using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;
using EricUtility.Networking.Gathering;

namespace LouMapInfo.OfficialLOU
{
    public class WorldInfo : AbstractLoadingTuple
    {
        private readonly SessionInfo m_Session;
        private readonly string m_Name;
        private readonly string m_Url;
        private readonly Dictionary<string, PlayerInfo> m_PlayersByName = new Dictionary<string, PlayerInfo>();
        private readonly Dictionary<int, PlayerInfo> m_PlayersById = new Dictionary<int, PlayerInfo>();
        private readonly Dictionary<string, AllianceInfo> m_AlliancesByName = new Dictionary<string, AllianceInfo>();
        private readonly Dictionary<int, AllianceInfo> m_AlliancesById = new Dictionary<int, AllianceInfo>();

        public SessionInfo Session { get { return m_Session; } }
        public string Url { get { return m_Url; } }
        public string Name { get { return m_Name; } }
        public PlayerInfo[] Players
        {
            get
            {
                PlayerInfo[] res = new PlayerInfo[m_PlayersByName.Count];
                m_PlayersByName.Values.CopyTo(res, 0);
                return res;
            }
        }

        public WorldInfo(SessionInfo session, string name)
            : base()
        {
            m_Session = session;
            m_Name = name;
            m_Url = ServerList.Servers[name];
        }
        protected override void OnLoad()
        {
            m_PlayersByName.Clear();
            m_PlayersById.Clear();
            JsonArrayCollection players = LoUEndPoint.GetPlayerList(m_Url,m_Session.SessionID);
            foreach (JsonObjectCollection p in players)
            {
                int pI = (int)((JsonNumericValue)p["i"]).Value;
                string pN = (string)((JsonStringValue)p["n"]).Value;
                int pJ = (int)((JsonNumericValue)p["j"]).Value;
                string pA = (string)((JsonStringValue)p["a"]).Value;
                int pP = (int)((JsonNumericValue)p["p"]).Value;
                int pR = (int)((JsonNumericValue)p["r"]).Value;
                int pC = (int)((JsonNumericValue)p["c"]).Value;
                if (!m_AlliancesById.ContainsKey(pJ))
                {
                    AllianceInfo aInfo = new AllianceInfo(pA, pJ);
                    m_AlliancesById.Add(pJ, aInfo);
                    m_AlliancesByName.Add(pA, aInfo);
                }
                AllianceInfo a = m_AlliancesById[pJ];
                PlayerInfo pInfo = new PlayerInfo(pN, pI, a, pP, pR, pC);
                m_PlayersByName.Add(pN, pInfo);
                m_PlayersById.Add(pI, pInfo);
            }
        }
        public PlayerInfo Player(int id)
        {
            if (m_PlayersById.ContainsKey(id))
                return m_PlayersById[id];
            return null;
        }
        public PlayerInfo Player(string name)
        {
            if (m_PlayersByName.ContainsKey(name))
                return m_PlayersByName[name];
            return null;
        }
        public AllianceInfo Alliance(int id)
        {
            if (m_AlliancesById.ContainsKey(id))
                return m_AlliancesById[id];
            return null;
        }
        public AllianceInfo Alliance(string name)
        {
            if (m_AlliancesByName.ContainsKey(name))
                return m_AlliancesByName[name];
            return null;
        }
    }
}
