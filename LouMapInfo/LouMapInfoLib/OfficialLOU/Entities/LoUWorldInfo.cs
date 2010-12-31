using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;
using EricUtility.Networking.Gathering;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUWorldInfo : AbstractLoadingTuple
    {
        private readonly LoUSessionInfo m_Session;
        private readonly string m_Name;
        private readonly string m_Url;
        private readonly Dictionary<string, LoUPlayerInfo> m_PlayersByName = new Dictionary<string, LoUPlayerInfo>();
        private readonly Dictionary<int, LoUPlayerInfo> m_PlayersById = new Dictionary<int, LoUPlayerInfo>();
        private readonly Dictionary<string, LoUAllianceInfo> m_AlliancesByName = new Dictionary<string, LoUAllianceInfo>();
        private readonly Dictionary<int, LoUAllianceInfo> m_AlliancesById = new Dictionary<int, LoUAllianceInfo>();

        public LoUSessionInfo Session { get { return m_Session; } }
        public string Url { get { return m_Url; } }
        public string Name { get { return m_Name; } }
        public LoUPlayerInfo[] Players
        {
            get
            {
                LoUPlayerInfo[] res = new LoUPlayerInfo[m_PlayersByName.Count];
                m_PlayersByName.Values.CopyTo(res, 0);
                return res;
            }
        }

        public LoUWorldInfo(LoUSessionInfo session, string name)
            : base()
        {
            m_Session = session;
            m_Name = name;
            m_Url = LoUServerList.Servers[name];
        }
        protected override void OnLoad()
        {
            m_PlayersByName.Clear();
            m_PlayersById.Clear();
            m_AlliancesByName.Clear();
            m_AlliancesById.Clear();
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
                    LoUAllianceInfo aInfo = new LoUAllianceInfo(pA, pJ);
                    m_AlliancesById.Add(pJ, aInfo);
                    m_AlliancesByName.Add(pA, aInfo);
                }
                LoUAllianceInfo a = m_AlliancesById[pJ];
                LoUPlayerInfo pInfo = new LoUPlayerInfo(this,pN, pI, a, pP, pR, pC);
                m_PlayersByName.Add(pN, pInfo);
                m_PlayersById.Add(pI, pInfo);
            }
            m_PlayersById[m_Session.PlayerID].ForceLoad();
        }
        public LoUPlayerInfo Player(int id)
        {
            if (m_PlayersById.ContainsKey(id))
                return m_PlayersById[id];
            return null;
        }
        public LoUPlayerInfo Player(string name)
        {
            if (m_PlayersByName.ContainsKey(name))
                return m_PlayersByName[name];
            return null;
        }
        public LoUAllianceInfo Alliance(int id)
        {
            if (m_AlliancesById.ContainsKey(id))
                return m_AlliancesById[id];
            return null;
        }
        public LoUAllianceInfo Alliance(string name)
        {
            if (m_AlliancesByName.ContainsKey(name))
                return m_AlliancesByName[name];
            return null;
        }
    }
}
