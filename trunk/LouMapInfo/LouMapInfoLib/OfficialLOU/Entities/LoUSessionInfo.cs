using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using EricUtility.Networking.Gathering;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUSessionInfo
    {
        private readonly string m_Mail;
        private readonly string m_Password;
        private bool m_Connected;
        private string m_SessionID;
        private bool m_UsingCredentials;
        private CookieContainer m_Cookies;
        private readonly LoUWorldInfo m_World;
        private int m_MyPID;
        private int m_MyAID;

        public LoUWorldInfo World { get { return m_World; } }
        public string Mail { get { return m_Mail; } }
        public string Password { get { return m_Password; } }
        public bool Connected { get { return m_Connected; } }
        public string SessionID { get { return m_SessionID; } }
        public int PlayerID { get { return m_MyPID; } }
        public int AllianceID { get { return m_MyAID; } }

        public LoUSessionInfo(string mail, string password, string world)
        {
            m_Mail = mail;
            m_Password = password;
            m_UsingCredentials = true;
            m_World = new LoUWorldInfo(this, world);
        }
        public LoUSessionInfo(string ssid, string world)
        {
            m_SessionID = ssid;
            m_UsingCredentials = false;
            m_World = new LoUWorldInfo(this, world);
        }

        public bool Connect()
        {
            if (m_UsingCredentials)
            {
                m_Cookies = GatheringUtility.SignInWebsite("https://www.lordofultima.com/en/user/login?destination=%40homepage%3F", "mail=" + m_Mail + "&password=" + m_Password + "&remember_me=true", true);
                string s = GatheringUtility.GetPageSource("http://www.lordofultima.com/en/game", m_Cookies);
                m_SessionID = StringUtility.Extract(s, "<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\"", "\"");
            }
            if (m_SessionID == null)
                return false;
            //try
            //{
                JsonObjectCollection o = LoUEndPoint.OpenSession(m_World.Url, m_SessionID);
                m_SessionID = ((JsonStringValue)o["i"]).Value;
                
                JsonObjectCollection me = LoUEndPoint.GetMyPlayerInfo(m_World.Url, m_SessionID);
                int cid = (int)((JsonNumericValue)((JsonObjectCollection)((JsonArrayCollection)me["Cities"])[0])["i"]).Value;
                m_MyPID = (int)((JsonNumericValue)me["Id"]).Value;
                JsonArrayCollection jo = (JsonArrayCollection)LoUEndPoint.TestPoll(m_World.Url, m_SessionID);
                JsonObjectCollection vis = (JsonObjectCollection)jo[1];
                JsonObjectCollection content = (JsonObjectCollection)vis["D"];
                JsonArrayCollection layout = (JsonArrayCollection)content["u"];
                Dictionary<int, JsonObjectCollection> buildings = new Dictionary<int, JsonObjectCollection>();
                foreach (JsonObjectCollection joc in layout)
                {
                    //CHARS AVAILABLE IN CITYNOTES: 1000
                    //USED BY LAYOUT: 331 (294 sans le début)

                    //x: /128
                    //y: /80
                    //t: type
                    // 4: Building
                    //  v = buildingType
                    //     1: WoodCutterOld
                    //     2: QuarryOld
                    //     3: FarmOld
                    //     4: Cottage
                    //     5: Marketplace
                    //     6: IronMineOld
                    //     7: Sawmill
                    //     8: Mill
                    //     9: Hideout
                    //    10: Stonemasson
                    //    11: Foundry
                    //    12: TownHall
                    //    13: Townhouse
                    //    14: Barrack
                    //    15: CityGuardHouse
                    //    16: TrainingGround
                    //    17: Stable
                    //    18: Workshop
                    //    19: Shipyard
                    //    20: Warehouse
                    //    21: Castle
                    //    22: Harbor
                    //    36: MoonglowTower
                    //    37: TrinsicTemple
                    //    38: LookoutTower
                    //    39: BallistaTower
                    //    40: GuardianTower
                    //    41: RangerTower
                    //    42: TemplarTower
                    //    43: PitfallTrap
                    //    44: Barricade
                    //    45: ArcaneTrap
                    //    46: CamouflageTrap
                    //    47: WoodcutterNew
                    //    48: QuarryNew
                    //    49: IronMineNew
                    //    50: FarmNew
                    //    51: Palace
                    //  l = level
                    //  s = ?
                    //  ss = ?
                    //  se = ?
                    //  
                    // 5: BuildingPlace
                    //   b = buildingType
                    //     1: Normal
                    //     2: Tower
                    // 9: Resource
                    // -> v0r2 iron, v1r1 wood, v0r3 lake, v2r1 wood
                    //   v = imageId
                    //   r = resourceType
                    //     0: Stone
                    //     1: Wood
                    //     2: Iron
                    //     3: Lake
                    // 10: Un bout de Wall
                    // 13: Wall, the object

                    int id = (int)((JsonNumericValue)joc["i"]).Value;
                    buildings.Add(id, joc);
                }
                //JsonObjectCollection city = LoUEndPoint.GetMyCityInfo(m_World.Url, m_SessionID, cid);
                m_MyAID = (int)((JsonNumericValue)me["AllianceId"]).Value;

                m_Connected = true;
                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
    }
}
