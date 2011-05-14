using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.JSON;
using EricUtility.Networking.Gathering;
using LouMapInfo.Layout;

namespace LouMapInfo.Entities
{
    public class WorldInfo : AbstractLoadingTuple
    {
        private readonly SessionInfo m_Session;
        private readonly string m_Name;
        private readonly ServerInfo m_Server;
        private bool m_VisLoaded = false;
        private readonly Dictionary<string, PlayerInfo> m_PlayersByName = new Dictionary<string, PlayerInfo>();
        private readonly Dictionary<int, PlayerInfo> m_PlayersById = new Dictionary<int, PlayerInfo>();
        private readonly Dictionary<string, AllianceInfo> m_AlliancesByName = new Dictionary<string, AllianceInfo>();
        private readonly Dictionary<int, AllianceInfo> m_AlliancesById = new Dictionary<int, AllianceInfo>();
        private readonly Dictionary<int, ContinentInfo> m_ContinentById = new Dictionary<int, ContinentInfo>();
        private readonly Dictionary<int, List<CityInfo>> m_LawlessByCont = new Dictionary<int, List<CityInfo>>();
        private readonly Dictionary<int, List<ShrineInfo>> m_ShrinesByCont = new Dictionary<int, List<ShrineInfo>>();
        private readonly Dictionary<ShrineType, List<ShrineInfo>> m_ShrinesByVirtue = new Dictionary<ShrineType, List<ShrineInfo>>();
        private readonly Dictionary<int, List<MoonGateInfo>> m_MoonGatesByCont = new Dictionary<int, List<MoonGateInfo>>();
        private readonly Dictionary<VirtueType, List<string>> m_PalacesOwnersByVirtue = new Dictionary<VirtueType, List<string>>();
        private readonly Dictionary<string, List<string>> m_PalacesOwnersByAlliance = new Dictionary<string, List<string>>();

        private int m_NbContinentsX;
        private int m_NbContinentsY;
        private int m_ContinentsWidth;

        public int ContinentsWidth
        {
            get { return m_ContinentsWidth; }
        }
        private int m_ContinentsHeight;

        public int ContinentsHeight
        {
            get { return m_ContinentsHeight; }
        }
        private int m_ServerVersion;

        public int ServerVersion
        {
            get { return m_ServerVersion; }
        }
        private readonly Dictionary<RankingType, List<object[]>> m_Rankings = new Dictionary<RankingType, List<object[]>>();

        public SessionInfo Session { get { return m_Session; } }
        public string Url { get { return m_Server.Url; } }
        public string Name { get { return m_Name; } }
        public int NbContinentsX { get { return m_NbContinentsX; } }
        public int NbContinentsY { get { return m_NbContinentsY; } }
        public PlayerInfo[] Players
        {
            get
            {
                PlayerInfo[] res = new PlayerInfo[m_PlayersByName.Count];
                m_PlayersByName.Values.CopyTo(res, 0);
                return res;
            }
        }
        public AllianceInfo[] Alliances
        {
            get
            {
                AllianceInfo[] res = new AllianceInfo[m_AlliancesByName.Count];
                m_AlliancesByName.Values.CopyTo(res, 0);
                return res;
            }
        }

        public WorldInfo(SessionInfo session, string name)
            : base()
        {
            m_Session = session;
            m_Name = name;
            m_Server = ServerList.ServersByName[name];
        }
        protected override void OnLoad()
        {
            m_PlayersByName.Clear();
            m_PlayersById.Clear();
            m_AlliancesByName.Clear();
            m_AlliancesById.Clear();

            JsonObjectCollection nfo = EndPoint.GetServerInfo(Url, m_Session.SessionID);
            m_NbContinentsX = (int)((JsonNumericValue)nfo["cx"]).Value;
            m_NbContinentsY = (int)((JsonNumericValue)nfo["cy"]).Value;
            m_ServerVersion = (int)((JsonNumericValue)nfo["sv"]).Value;
            m_ContinentsHeight = (int)((JsonNumericValue)nfo["ch"]).Value;
            m_ContinentsWidth = (int)((JsonNumericValue)nfo["cw"]).Value;
            JsonArrayCollection players = EndPoint.GetPlayerList(Url, m_Session.SessionID);
            foreach (JsonObjectCollection p in players)
            {
                int pI = (int)((JsonNumericValue)p["i"]).Value;
                string pN = (string)((JsonStringValue)p["n"]).Value;
                char prefix = pN[0];
                if (m_ServerVersion >= 314249) //Stupid A prefix :)
                    pN = pN.Substring(1);
                int pJ = (int)((JsonNumericValue)p["j"]).Value;
                string pA = (string)((JsonStringValue)p["a"]).Value;
                int pP = (int)((JsonNumericValue)p["p"]).Value;
                int pR = (int)((JsonNumericValue)p["r"]).Value;
                int pC = (int)((JsonNumericValue)p["c"]).Value;
                if (!m_AlliancesById.ContainsKey(pJ))
                {
                    AllianceInfo aInfo = new AllianceInfo(this, pA, pJ);
                    m_AlliancesById.Add(pJ, aInfo);
                    m_AlliancesByName.Add(pA, aInfo);
                }
                AllianceInfo a = m_AlliancesById[pJ];

                PlayerInfo pInfo;
                if (pI == Session.PlayerID)
                {
                    pInfo = new PlayerExtendedInfo(this, pN, pI, a, pP, pR, pC);
                    Session.MyPlayer = (PlayerExtendedInfo)pInfo;
                }
                else
                    pInfo = new PlayerInfo(this, pN, pI, a, pP, pR, pC);
                pInfo.Prefix = prefix;
                m_PlayersByName.Add(pN, pInfo);
                m_PlayersById.Add(pI, pInfo);
            }

            for (int i = 0; i < m_NbContinentsX; ++i)
            {
                for (int j = 0; j < m_NbContinentsY; ++j)
                {
                    int c = (i * 10) + j;
                    m_ContinentById.Add(c, new ContinentInfo(this, c));
                }
            }
            Session.MyPlayer.ForceLoad();
            //CompleteLayout cl = CompleteLayout.GetLayoutFromCity(m_PlayersById[m_Session.PlayerID].Cities()[10]);
            string[] vkeys = new string[] { "c", "o", "h", "u", "ju", "f", "s", "v" };
            for (int k = 0; k <= 8; ++k)
                m_PalacesOwnersByVirtue.Add((VirtueType)k, new List<string>());
            JsonArrayCollection jac = EndPoint.GetPlayersWithPalace(Session.World.Url, Session.SessionID);
            if (jac != null)
            {
                foreach (JsonObjectCollection p in jac)
                {
                    string name = ((JsonStringValue)p["n"]).Value;
                    if (m_ServerVersion >= 314249) //Stupid A prefix :)
                        name = name.Substring(1);
                    string alliance = ((JsonStringValue)p["a"]).Value;
                    if (!m_PalacesOwnersByAlliance.ContainsKey(alliance))
                        m_PalacesOwnersByAlliance.Add(alliance, new List<string>());
                    m_PalacesOwnersByAlliance[alliance].Add(name);
                    for (int i = 0; i < 8; ++i)
                    {
                        if (((JsonNumericValue)p[vkeys[i]]).Value > 0)
                        {
                            m_PalacesOwnersByVirtue[(VirtueType)(i + 1)].Add(name);
                            if (!m_PalacesOwnersByVirtue[VirtueType.None].Contains(name))
                                m_PalacesOwnersByVirtue[VirtueType.None].Add(name);
                        }
                    }
                }
            }


        }

        public List<object[]> Ranking(RankingType type)
        {
            if (m_Rankings.ContainsKey(type))
                return m_Rankings[type];

            switch (type)
            {
                case RankingType.PRanking:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p0 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 0, 0);
                        foreach (JsonObjectCollection p in p0)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pJ = (int)((JsonNumericValue)p["j"]).Value;
                            string pA = (string)((JsonStringValue)p["a"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pC = (int)((JsonNumericValue)p["c"]).Value;
                            res.Add(new object[] { pR, pN, pP, pA, pC});
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.PResources:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p1 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 1, 5);
                        foreach (JsonObjectCollection p in p1)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            int pW = (int)((JsonNumericValue)p["w"]).Value;
                            int pS = (int)((JsonNumericValue)p["s"]).Value;
                            int pE = (int)((JsonNumericValue)p["e"]).Value;
                            int pF = (int)((JsonNumericValue)p["f"]).Value;
                            int pG = (int)((JsonNumericValue)p["g"]).Value;
                            res.Add(new object[] { pR, pN, pP, pW, pS, pE, pF, pG });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.PMilitary:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p2 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 2, 11);
                        foreach (JsonObjectCollection p in p2)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            int pT = (int)((JsonNumericValue)p["t"]).Value;
                            int pS = (int)((JsonNumericValue)p["s"]).Value;
                            res.Add(new object[] { pR, pN, pP, pT, pS});
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.POffense:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p3 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 3, 14);
                        foreach (JsonObjectCollection p in p3)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            res.Add(new object[] { pR, pN, pP });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.PDefense:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p4 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 4, 15);
                        foreach (JsonObjectCollection p in p4)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            res.Add(new object[] { pR, pN, pP });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.PUnits:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p5 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 5, 17);
                        foreach (JsonObjectCollection p in p5)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pJ = (int)((JsonNumericValue)p["j"]).Value;
                            string pA = (string)((JsonStringValue)p["a"]).Value;
                            long pP = (long)((JsonNumericValue)p["p"]).Value;
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pG = (int)((JsonNumericValue)p["g"]).Value;
                            res.Add(new object[] { pR, pN, pP, pA, pG });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.PPlunder:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p6 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 6, 16);
                        foreach (JsonObjectCollection p in p6)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pJ = (int)((JsonNumericValue)p["j"]).Value;
                            string pA = (string)((JsonStringValue)p["a"]).Value;
                            long pP = (long)((JsonNumericValue)p["p"]).Value;
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pG = (int)((JsonNumericValue)p["g"]).Value;
                            res.Add(new object[] { pR, pN, pP, pA, pG });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.PFaith:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection p7 = EndPoint.GetPlayerList(Url, Session.SessionID, -1, 7, 18);
                        foreach (JsonObjectCollection p in p7)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            if (m_ServerVersion >= 314249) //Stupid A prefix :)
                                pN = pN.Substring(1);
                            int pJ = (int)((JsonNumericValue)p["j"]).Value;
                            string pA = (string)((JsonStringValue)p["a"]).Value;
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            int pPP = (int)((JsonNumericValue)p["pp"]).Value;
                            int pH = (int)((JsonNumericValue)p["h"]).Value;
                            int pV = (int)((JsonNumericValue)p["v"]).Value;
                            int pC = (int)((JsonNumericValue)p["c"]).Value;
                            int pO = (int)((JsonNumericValue)p["o"]).Value;
                            int pS = (int)((JsonNumericValue)p["s"]).Value;
                            int pU = (int)((JsonNumericValue)p["u"]).Value;
                            int pF = (int)((JsonNumericValue)p["f"]).Value;
                            int pJU = (int)((JsonNumericValue)p["ju"]).Value;
                            int pHP = (int)((JsonNumericValue)p["hp"]).Value;
                            int pVP = (int)((JsonNumericValue)p["vp"]).Value;
                            int pCP = (int)((JsonNumericValue)p["cp"]).Value;
                            int pOP = (int)((JsonNumericValue)p["op"]).Value;
                            int pSP = (int)((JsonNumericValue)p["sp"]).Value;
                            int pUP = (int)((JsonNumericValue)p["up"]).Value;
                            int pFP = (int)((JsonNumericValue)p["fp"]).Value;
                            int pJUP = (int)((JsonNumericValue)p["jup"]).Value;
                            res.Add(new object[] { pR, pN, pA, 
                                String.Format("{0:0000}_{1:0000}", pPP, pP),
                                String.Format("{0:0000}_{1:0000}", pCP, pC),
                                String.Format("{0:0000}_{1:0000}", pOP, pO),
                                String.Format("{0:0000}_{1:0000}", pHP, pH),
                                String.Format("{0:0000}_{1:0000}", pUP, pU),
                                String.Format("{0:0000}_{1:0000}", pJUP, pJU),
                                String.Format("{0:0000}_{1:0000}", pFP, pF),
                                String.Format("{0:0000}_{1:0000}", pSP, pS),
                                String.Format("{0:0000}_{1:0000}", pVP, pV),
                            });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.ARanking:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection a0 = EndPoint.GetAllianceList(Url, Session.SessionID, -1, 0, 0);
                        foreach (JsonObjectCollection p in a0)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pC = (int)((JsonNumericValue)p["c"]).Value;
                            int pM = (int)((JsonNumericValue)p["m"]).Value;
                            int pA = (int)((JsonNumericValue)p["a"]).Value;
                            res.Add(new object[] { pR, pN, pP, pM, pA, pC });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.AUnits:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection a1 = EndPoint.GetAllianceList(Url, Session.SessionID, -1, 1, 6);
                        foreach (JsonObjectCollection p in a1)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            long pP = (long)((JsonNumericValue)p["p"]).Value;
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            res.Add(new object[] { pR, pN, pP});
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
                case RankingType.AFaith:
                    {
                        List<object[]> res = new List<object[]>();
                        JsonArrayCollection a2 = EndPoint.GetAllianceList(Url, Session.SessionID, -1, 2, 7);

                        foreach (JsonObjectCollection p in a2)
                        {
                            int pI = (int)((JsonNumericValue)p["i"]).Value;
                            string pN = (string)((JsonStringValue)p["n"]).Value;
                            int pR = (int)((JsonNumericValue)p["r"]).Value;
                            int pP = (int)((JsonNumericValue)p["p"]).Value;
                            int pPP = (int)((JsonNumericValue)p["pp"]).Value;
                            int pH = (int)((JsonNumericValue)p["h"]).Value;
                            int pV = (int)((JsonNumericValue)p["v"]).Value;
                            int pC = (int)((JsonNumericValue)p["c"]).Value;
                            int pO = (int)((JsonNumericValue)p["o"]).Value;
                            int pS = (int)((JsonNumericValue)p["s"]).Value;
                            int pU = (int)((JsonNumericValue)p["u"]).Value;
                            int pF = (int)((JsonNumericValue)p["f"]).Value;
                            int pJ = (int)((JsonNumericValue)p["j"]).Value;
                            int pHP = (int)((JsonNumericValue)p["hp"]).Value;
                            int pVP = (int)((JsonNumericValue)p["vp"]).Value;
                            int pCP = (int)((JsonNumericValue)p["cp"]).Value;
                            int pOP = (int)((JsonNumericValue)p["op"]).Value;
                            int pSP = (int)((JsonNumericValue)p["sp"]).Value;
                            int pUP = (int)((JsonNumericValue)p["up"]).Value;
                            int pFP = (int)((JsonNumericValue)p["fp"]).Value;
                            int pJP = (int)((JsonNumericValue)p["jp"]).Value;
                            res.Add(new object[] { pR, pN,
                                String.Format("{0:0000}_{1:0000}", pPP, pP),
                                String.Format("{0:0000}_{1:0000}", pCP, pC),
                                String.Format("{0:0000}_{1:0000}", pOP, pO),
                                String.Format("{0:0000}_{1:0000}", pHP, pH),
                                String.Format("{0:0000}_{1:0000}", pUP, pU),
                                String.Format("{0:0000}_{1:0000}", pJP, pJ),
                                String.Format("{0:0000}_{1:0000}", pFP, pF),
                                String.Format("{0:0000}_{1:0000}", pSP, pS),
                                String.Format("{0:0000}_{1:0000}", pVP, pV),
                            });
                        }
                        m_Rankings.Add(type, res);
                        break;
                    }
            }
            return m_Rankings[type];
        }

        public void LoadVis()
        {
            if (!m_VisLoaded)
            {
                foreach (JsonObjectCollection oc2 in EndPoint.GetVIS(m_Session.World.Url, m_Session.SessionID))
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
                                Pt loc = new Pt(this, x, y);
                                MoonGateInfo mi = new MoonGateInfo(this, i, loc);
                                if (!m_MoonGatesByCont.ContainsKey(loc.Continent))
                                    m_MoonGatesByCont.Add(loc.Continent, new List<MoonGateInfo>());
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
                                    Pt loc = new Pt(this,x, y);
                                    CityInfo ci = new CityInfo(this, null, name, i, loc, BorderingType.Unknown, name.Contains("castle") ? CityType.Castle : CityType.City, p);
                                    if (!m_LawlessByCont.ContainsKey(c))
                                        m_LawlessByCont.Add(c, new List<CityInfo>());
                                    m_LawlessByCont[c].Add(ci);
                                }
                                break;
                            }
                        case 14: // Shrine
                            {
                                int i = (int)((JsonNumericValue)oc2["si"]).Value; // id
                                int st = (int)((JsonNumericValue)oc2["m"]).Value; // shrine type
                                Pt loc = new Pt(this,x, y);
                                ShrineInfo si = new ShrineInfo(this, i, loc, (ShrineType)st);
                                if (!m_ShrinesByCont.ContainsKey(loc.Continent))
                                    m_ShrinesByCont.Add(loc.Continent, new List<ShrineInfo>());
                                m_ShrinesByCont[loc.Continent].Add(si);
                                if (!m_ShrinesByVirtue.ContainsKey(si.Virtue))
                                    m_ShrinesByVirtue.Add(si.Virtue, new List<ShrineInfo>());
                                m_ShrinesByVirtue[si.Virtue].Add(si);
                                break;
                            }
                    }
                }
                m_VisLoaded = true;
            }
        }
        public PlayerInfo Player(int id)
        {
            PlayerInfo res = null;
            if (m_PlayersById.ContainsKey(id))
            {
                res = m_PlayersById[id];
                res.LoadIfNeeded();
            }
            return res;
        }
        public PlayerInfo Player(string name)
        {
            PlayerInfo res = null;
            if (m_PlayersByName.ContainsKey(name))
            {
                res = m_PlayersByName[name];
                res.LoadIfNeeded();
            }
            return res;
        }
        public AllianceInfo Alliance(int id)
        {
            AllianceInfo res = null;
            if (m_AlliancesById.ContainsKey(id))
            {
                res = m_AlliancesById[id];
                res.LoadIfNeeded();
            }
            return res;
        }
        public AllianceInfo Alliance(string name)
        {
            AllianceInfo res = null;
            if (m_AlliancesByName.ContainsKey(name))
            {
                res = m_AlliancesByName[name];
                res.LoadIfNeeded();
            }
            return res;
        }
        public ContinentInfo Continent(int id)
        {
            ContinentInfo res = null;
            if (m_ContinentById.ContainsKey(id))
            {
                res = m_ContinentById[id];
                res.LoadIfNeeded();
            }
            return res;
        }
        public Dictionary<int, CityInfo[]> Lawless(params int[] who)
        {
            LoadVis();
            bool all = who.Length == 0;
            List<int> conts = new List<int>(who);
            int[] ids = new int[m_LawlessByCont.Keys.Count];
            m_LawlessByCont.Keys.CopyTo(ids, 0);
            Array.Sort(ids);
            Dictionary<int, CityInfo[]> res = new Dictionary<int, CityInfo[]>();
            foreach (int i in ids)
            {
                if( all || conts.Contains(i) )
                {
                    CityInfo[] cs = new CityInfo[m_LawlessByCont[i].Count];
                    m_LawlessByCont[i].CopyTo(cs, 0);
                    Array.Sort(cs);
                    Array.Reverse(cs);
                    res.Add(i, cs);
                }
            }
            return res;
        }
        public List<ShrineInfo> Shrines(int cid)
        {
            LoadVis();
            List<ShrineInfo> res = new List<ShrineInfo>();
            if (m_ShrinesByCont.ContainsKey(cid))
                res = m_ShrinesByCont[cid];
            return res;
        }
        public List<ShrineInfo> ActivatedShrines()
        {
            LoadVis();
            List<ShrineInfo> res = new List<ShrineInfo>();
            foreach (ShrineType t in m_ShrinesByVirtue.Keys)
                if (t != ShrineType.UnActivated)
                    res.AddRange(m_ShrinesByVirtue[t]);
            return res;
        }
        public List<ShrineInfo> Shrines(ShrineType virtue)
        {
            LoadVis();
            List<ShrineInfo> res = new List<ShrineInfo>();
            if (m_ShrinesByVirtue.ContainsKey(virtue))
                res = m_ShrinesByVirtue[virtue];
            return res;
        }
        public Dictionary<int, MoonGateInfo[]> MoonGates(params int[] who)
        {
            LoadVis();
            bool all = who.Length == 0;
            List<int> conts = new List<int>(who);
            int[] ids = new int[m_MoonGatesByCont.Keys.Count];
            m_MoonGatesByCont.Keys.CopyTo(ids, 0);
            Array.Sort(ids);
            Dictionary<int, MoonGateInfo[]> res = new Dictionary<int, MoonGateInfo[]>();
            foreach (int i in ids)
            {
                if (all || conts.Contains(i))
                {
                    MoonGateInfo[] cs = new MoonGateInfo[m_MoonGatesByCont[i].Count];
                    m_MoonGatesByCont[i].CopyTo(cs, 0);
                    res.Add(i, cs);
                }
            }
            return res;
        }
        public string[] PalacesOwnersByVirtue(VirtueType vid)
        {
            string[] res = new string[m_PalacesOwnersByVirtue[vid].Count];
            m_PalacesOwnersByVirtue[vid].CopyTo(res);
            return res;
        }
        public string[] PalacesOwnersByAlliance(string a)
        {
            if (!m_PalacesOwnersByAlliance.ContainsKey(a))
                return new string[0];
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
