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
        private bool m_VisLoaded = false;
        private readonly Dictionary<string, LoUPlayerInfo> m_PlayersByName = new Dictionary<string, LoUPlayerInfo>();
        private readonly Dictionary<int, LoUPlayerInfo> m_PlayersById = new Dictionary<int, LoUPlayerInfo>();
        private readonly Dictionary<string, LoUAllianceInfo> m_AlliancesByName = new Dictionary<string, LoUAllianceInfo>();
        private readonly Dictionary<int, LoUAllianceInfo> m_AlliancesById = new Dictionary<int, LoUAllianceInfo>();
        private readonly Dictionary<int, LoUContinentInfo> m_ContinentById = new Dictionary<int, LoUContinentInfo>();
        private readonly Dictionary<int, List<LoUCityInfo>> m_LawlessByCont = new Dictionary<int, List<LoUCityInfo>>();
        private readonly Dictionary<int, List<LoUShrineInfo>> m_ShrinesByCont = new Dictionary<int, List<LoUShrineInfo>>();
        private readonly Dictionary<LoUShrineType, List<LoUShrineInfo>> m_ShrinesByVirtue = new Dictionary<LoUShrineType, List<LoUShrineInfo>>();
        private readonly Dictionary<int, List<LoUMoonGateInfo>> m_MoonGatesByCont = new Dictionary<int, List<LoUMoonGateInfo>>();
        private readonly Dictionary<int, List<string>> m_PalacesOwnersByVirtue = new Dictionary<int, List<string>>();
        private readonly Dictionary<string, List<string>> m_PalacesOwnersByAlliance = new Dictionary<string, List<string>>();
            
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
                    LoUAllianceInfo aInfo = new LoUAllianceInfo(this, pA, pJ);
                    m_AlliancesById.Add(pJ, aInfo);
                    m_AlliancesByName.Add(pA, aInfo);
                }
                LoUAllianceInfo a = m_AlliancesById[pJ];
                LoUPlayerInfo pInfo = new LoUPlayerInfo(this,pN, pI, a, pP, pR, pC);
                m_PlayersByName.Add(pN, pInfo);
                m_PlayersById.Add(pI, pInfo);
            }

            for (int i = 0; i <= 6; ++i)
            {
                for (int j = 0; j <= 6; ++j)
                {
                    int c = (i * 10) + j;
                    m_ContinentById.Add(c, new LoUContinentInfo(this, c));
                }
            }
            m_PlayersById[m_Session.PlayerID].ForceLoad();
            string[] vkeys = new string[] { "c", "o", "h", "u", "ju", "f", "s", "v" };
            foreach (int k in LoUVirtues.VirtuesNames.Keys)
                m_PalacesOwnersByVirtue.Add(k, new List<string>());
            JsonArrayCollection jac = LoUEndPoint.GetPlayersWithPalace(Session.World.Url, Session.SessionID);
            foreach (JsonObjectCollection p in jac)
            {
                string name = ((JsonStringValue)p["n"]).Value;
                string alliance = ((JsonStringValue)p["a"]).Value;
                if (!m_PalacesOwnersByAlliance.ContainsKey(alliance))
                    m_PalacesOwnersByAlliance.Add(alliance, new List<string>());
                m_PalacesOwnersByAlliance[alliance].Add(name);
                for (int i = 0; i < 8; ++i)
                {
                    if (((JsonNumericValue)p[vkeys[i]]).Value > 0)
                        m_PalacesOwnersByVirtue[i + 1].Add(name);
                }
            }
        }
        public void LoadVis()
        {
            if (!m_VisLoaded)
            {
                foreach (JsonObjectCollection oc2 in LoUEndPoint.GetVIS(m_Session.World.Url, m_Session.SessionID))
                {
                    // 1: MoonGate
                    // 2: City
                    // 14: Shrine
                    int t = (int)((JsonNumericValue)oc2["t"]).Value; // type
                    int x = (int)((JsonNumericValue)oc2["x"]).Value / 128; //x
                    int y = (int)(((JsonNumericValue)oc2["y"]).Value + 0.5) / 80; // y
                    switch (t)
                    {
                        case 1: // MoonGate
                            {
                                int i = (int)((JsonNumericValue)oc2["mi"]).Value; // id
                                LoUPt loc = new LoUPt(x, y);
                                LoUMoonGateInfo mi = new LoUMoonGateInfo(this, i, loc);
                                if (!m_MoonGatesByCont.ContainsKey(loc.Continent))
                                    m_MoonGatesByCont.Add(loc.Continent, new List<LoUMoonGateInfo>());
                                m_MoonGatesByCont[loc.Continent].Add(mi);
                                break;
                            }
                        case 2: // City
                            {
                                if (String.IsNullOrEmpty(((JsonStringValue)oc2["pn"]).Value))
                                {
                                    int i = (int)((JsonNumericValue)oc2["ci"]).Value; // id
                                    string name = ((JsonStringValue)oc2["n"]).Value; // name
                                    int p = (int)((JsonNumericValue)oc2["p"]).Value; // score
                                    int c = (int)((JsonNumericValue)oc2["k"]).Value; // continent
                                    LoUPt loc = new LoUPt(x, y);
                                    LoUCityInfo ci = new LoUCityInfo(this, null, name, i, loc, LoUBorderingType.Unknown, name.Contains("castle") ? OldLoUCityType.Castle : OldLoUCityType.City, p);
                                    if (!m_LawlessByCont.ContainsKey(c))
                                        m_LawlessByCont.Add(c, new List<LoUCityInfo>());
                                    m_LawlessByCont[c].Add(ci);
                                }
                                break;
                            }
                        case 14: // Shrine
                            {
                                int i = (int)((JsonNumericValue)oc2["si"]).Value; // id
                                int st = (int)((JsonNumericValue)oc2["m"]).Value; // shrine type
                                LoUPt loc = new LoUPt(x, y);
                                LoUShrineInfo si = new LoUShrineInfo(this, i, loc, (LoUShrineType)st);
                                if (!m_ShrinesByCont.ContainsKey(loc.Continent))
                                    m_ShrinesByCont.Add(loc.Continent, new List<LoUShrineInfo>());
                                m_ShrinesByCont[loc.Continent].Add(si);
                                if (!m_ShrinesByVirtue.ContainsKey(si.Virtue))
                                    m_ShrinesByVirtue.Add(si.Virtue, new List<LoUShrineInfo>());
                                m_ShrinesByVirtue[si.Virtue].Add(si);
                                break;
                            }
                    }
                }
                m_VisLoaded = true;
            }
        }
        public LoUPlayerInfo Player(int id)
        {
            LoUPlayerInfo res = null;
            if (m_PlayersById.ContainsKey(id))
            {
                res = m_PlayersById[id];
                res.LoadIfNeeded();
            }
            return res;
        }
        public LoUPlayerInfo Player(string name)
        {
            LoUPlayerInfo res = null;
            if (m_PlayersByName.ContainsKey(name))
            {
                res = m_PlayersByName[name];
                res.LoadIfNeeded();
            }
            return res;
        }
        public LoUAllianceInfo Alliance(int id)
        {
            LoUAllianceInfo res = null;
            if (m_AlliancesById.ContainsKey(id))
            {
                res = m_AlliancesById[id];
                res.LoadIfNeeded();
            }
            return res;
        }
        public LoUAllianceInfo Alliance(string name)
        {
            LoUAllianceInfo res = null;
            if (m_AlliancesByName.ContainsKey(name))
            {
                res = m_AlliancesByName[name];
                res.LoadIfNeeded();
            }
            return res;
        }
        public LoUContinentInfo Continent(int id)
        {
            LoUContinentInfo res = null;
            if (m_ContinentById.ContainsKey(id))
            {
                res = m_ContinentById[id];
                res.LoadIfNeeded();
            }
            return res;
        }
        public Dictionary<int, LoUCityInfo[]> Lawless(params int[] who)
        {
            LoadVis();
            bool all = who.Length == 0;
            List<int> conts = new List<int>(who);
            int[] ids = new int[m_LawlessByCont.Keys.Count];
            m_LawlessByCont.Keys.CopyTo(ids, 0);
            Array.Sort(ids);
            Dictionary<int, LoUCityInfo[]> res = new Dictionary<int, LoUCityInfo[]>();
            foreach (int i in ids)
            {
                if( all || conts.Contains(i) )
                {
                    LoUCityInfo[] cs = new LoUCityInfo[m_LawlessByCont[i].Count];
                    m_LawlessByCont[i].CopyTo(cs, 0);
                    Array.Sort(cs);
                    Array.Reverse(cs);
                    res.Add(i, cs);
                }
            }
            return res;
        }
        public List<LoUShrineInfo> Shrines(int cid)
        {
            LoadVis();
            List<LoUShrineInfo> res = new List<LoUShrineInfo>();
            if (m_ShrinesByCont.ContainsKey(cid))
                res = m_ShrinesByCont[cid];
            return res;
        }
        public List<LoUShrineInfo> ActivatedShrines()
        {
            LoadVis();
            List<LoUShrineInfo> res = new List<LoUShrineInfo>();
            foreach (LoUShrineType t in m_ShrinesByVirtue.Keys)
                if (t != LoUShrineType.UnActivated)
                    res.AddRange(m_ShrinesByVirtue[t]);
            return res;
        }
        public List<LoUShrineInfo> Shrines(LoUShrineType virtue)
        {
            LoadVis();
            List<LoUShrineInfo> res = new List<LoUShrineInfo>();
            if (m_ShrinesByVirtue.ContainsKey(virtue))
                res = m_ShrinesByVirtue[virtue];
            return res;
        }
        public Dictionary<int, LoUMoonGateInfo[]> MoonGates(params int[] who)
        {
            LoadVis();
            bool all = who.Length == 0;
            List<int> conts = new List<int>(who);
            int[] ids = new int[m_MoonGatesByCont.Keys.Count];
            m_MoonGatesByCont.Keys.CopyTo(ids, 0);
            Array.Sort(ids);
            Dictionary<int, LoUMoonGateInfo[]> res = new Dictionary<int, LoUMoonGateInfo[]>();
            foreach (int i in ids)
            {
                if (all || conts.Contains(i))
                {
                    LoUMoonGateInfo[] cs = new LoUMoonGateInfo[m_MoonGatesByCont[i].Count];
                    m_MoonGatesByCont[i].CopyTo(cs, 0);
                    res.Add(i, cs);
                }
            }
            return res;
        }
        public string[] PalacesOwnersByVirtue(int vid)
        {
            string[] res = new string[m_PalacesOwnersByVirtue[vid].Count];
            m_PalacesOwnersByVirtue[vid].CopyTo(res);
            return res;
        }
        public string[] PalacesOwnersByVirtue(string vname)
        {
            return PalacesOwnersByVirtue(LoUVirtues.VirtuesIDs[vname]);
        }
        public string[] PalacesOwnersByAlliance(string a)
        {
            string[] res = new string[m_PalacesOwnersByAlliance[a].Count];
            m_PalacesOwnersByAlliance[a].CopyTo(res);
            return res;
        }
        public string[] PalacesOwnersAlliances()
        {
            string[] res = new string[m_PalacesOwnersByAlliance.Keys.Count];
            m_PalacesOwnersByAlliance.Keys.CopyTo(res,0);
            return res;
        }
    }
}
