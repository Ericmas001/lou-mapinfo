// Ultra giga thanks to : http://code.google.com/p/lou-tools-empire/
// This class works because of their clean code :)

using System;
using System.Collections.Generic;
using System.Text;
using EricUtility.Networking.JSON;
using System.Net;
using System.IO;
using System.Net.Cache;

namespace LouMapInfo
{
    public static class EndPoint
    {
        public static JsonObject Query(string baseurl, string endpoint, JsonObjectCollection args)
        {
            string url = baseurl + "/Presentation/Service.svc/ajaxEndpoint/" + endpoint;
            byte[] bytes = new UTF8Encoding().GetBytes(args.ToString());
            CookieContainer cookies = new CookieContainer();


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Timeout = 50000;
            request.ContentType = "application/json; charset=utf-8";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            request.ContentLength = bytes.Length;
            using (Stream writeStream = request.GetRequestStream())
            {
                writeStream.Write(bytes, 0, bytes.Length);
            }
            request.CookieContainer = cookies;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            String res = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return new JsonTextParser().Parse(res);
        }

        public static JsonArrayCollection GetAllianceList(string baseurl, string session, int continent, int type, int sort)
        {
            string endpoint = "AllianceGetRange";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("start", 0));
            args.Add(new JsonNumericValue("end", 999999999));
            args.Add(new JsonNumericValue("continent", continent));
            args.Add(new JsonStringValue("sort", sort.ToString()));
            args.Add(new JsonNumericValue("type", type));
            args.Add(new JsonBooleanValue("ascending", true));
            return (JsonArrayCollection)Query(baseurl, endpoint, args);
        }

        public static JsonArrayCollection GetPlayerList(string baseurl, string session, int continent, int type, int sort)
        {
            string endpoint = "PlayerGetRange";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("start", 0));
            args.Add(new JsonNumericValue("end", 999999999));
            args.Add(new JsonNumericValue("continent", continent));
            args.Add(new JsonStringValue("sort", sort.ToString()));
            args.Add(new JsonNumericValue("type", type));
            args.Add(new JsonBooleanValue("ascending", true));
            return (JsonArrayCollection)Query(baseurl, endpoint, args);
        }

        public static JsonArrayCollection GetPlayerList(string baseurl, string session)
        {
            return GetPlayerList(baseurl, session, -1, 0, 0);
        }

        public static JsonObjectCollection GetPublicPlayerInfo(string baseurl, string session, int idPlayer)
        {
            string endpoint = "GetPublicPlayerInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("id", idPlayer));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        public static JsonObjectCollection GetPublicAllianceInfo(string baseurl, string session, int idAlliance)
        {
            string endpoint = "GetPublicAllianceInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("id", idAlliance));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        public static JsonObjectCollection GetServerInfo(string baseurl, string session)
        {
            string endpoint = "GetServerInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        public static JsonObjectCollection OpenSession(string baseurl, string session)
        {
            string endpoint = "OpenSession";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        public static JsonArrayCollection GetVIS(string baseurl, string session)
        {
            string endpoint = "Poll"; //
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonStringValue("requestid", "42"));
            //args.Add(new JsonStringValue("requests", "VIS:w:0:0:-0:-0:1000000:1000000"));

            args.Add(new JsonStringValue("requests", "TM:71,50,\fCAT:1\fSERVER:\fALLIANCE:\fQUEST:\fTE:\fPLAYER:\fCITY:9830667\fWC:\fWORLD:\fVIS:c:9830667:0:-964:-582:1016:677\fUFP:\fREPORT:\fMAIL:\fFRIENDINV:\fTIME:1305347895979\fCHAT:\fSUBSTITUTION:\fINV:\fALL_AT:\fMAT:9830667\f"));
            JsonObject jo = Query(baseurl, endpoint, args);
            JsonArrayCollection ac1 = jo as JsonArrayCollection;
            foreach (JsonObjectCollection oc1 in ac1)
            {
                if (((JsonStringValue)oc1["C"]).Value == "VIS")
                {
                    return ((JsonObjectCollection)((JsonObjectCollection)oc1["D"]))["u"] as JsonArrayCollection;
                }
            }
            return null;
        }

        public static JsonObjectCollection GetShrineInfo(string baseurl, string session, int id)
        {
            string endpoint = "GetPublicShrineInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("id", id));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        public static JsonArrayCollection GetPlayersWithPalace(string baseurl, string session)
        {
            string endpoint = "PlayerGetRange";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("start", 0));
            args.Add(new JsonNumericValue("end", 999999999));
            args.Add(new JsonNumericValue("continent", -1));
            args.Add(new JsonStringValue("sort", "18"));
            args.Add(new JsonBooleanValue("ascending", true));
            args.Add(new JsonStringValue("type", "7"));
            JsonObject jo = Query(baseurl, endpoint, args);
            return (JsonArrayCollection)jo;
        }

        public static JsonObjectCollection GetPublicCityInfo(string baseurl, string session, int idCity)
        {
            string endpoint = "GetPublicCityInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("id", idCity));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        
        public static JsonObjectCollection GetMyPlayerInfoLight(string baseurl, string session)
        {
            string endpoint = "GetPlayerInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        public static JsonObjectCollection GetMyPlayerInfo(string baseurl, string session)
        {
            string endpoint = "Poll"; //
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonStringValue("requestid", "42"));
            args.Add(new JsonStringValue("requests", "PLAYER:"));
            JsonObject jo = Query(baseurl, endpoint, args);
            JsonArrayCollection ac1 = jo as JsonArrayCollection;
            foreach (JsonObjectCollection oc1 in ac1)
            {
                if (((JsonStringValue)oc1["C"]).Value == "PLAYER")
                {
                    return (JsonObjectCollection)oc1["D"];
                }
            }
            return null;
        }

        public static JsonObjectCollection GetMyAllianceInfo(string baseurl, string session)
        {
            string endpoint = "GetAllianceInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }

        public static void CityNoteSet(string baseurl, string session, int cid, string title, string text)
        {
            //CHARS AVAILABLE IN CITYNOTES: 1000
            //USED BY LAYOUT: 331 (294 sans le début)
            string endpoint = "CityNoteSet";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonStringValue("cityid", "" + cid));
            args.Add(new JsonStringValue("reference", title));
            args.Add(new JsonStringValue("text", text));
            Query(baseurl, endpoint, args);
        }

        public static void RenameCity(string baseurl, string session, int cid, string name)
        {
            string endpoint = "RenameCity";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonStringValue("cityid", "" + cid));
            args.Add(new JsonStringValue("name", name));
            Query(baseurl, endpoint, args);
        }

        public static JsonObjectCollection GetCityInfo(string baseurl, string session, int cid)
        {
            string endpoint = "Poll";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonStringValue("requestid", "42"));
            args.Add(new JsonStringValue("requests", "CITY:" + cid));
            JsonArrayCollection jo = (JsonArrayCollection)Query(baseurl, endpoint, args);
            JsonObjectCollection city = (JsonObjectCollection)jo[1];
            return (JsonObjectCollection)city["D"];
        }

        public static JsonArrayCollection GetCityLayout(string baseurl, string session, int cid)
        {
            string endpoint = "Poll"; 
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonStringValue("requestid", "42"));
            args.Add(new JsonStringValue("requests", "VIS:c:" + cid + ":0:-964:-582:1016:677"));
            JsonArrayCollection jo = (JsonArrayCollection)Query(baseurl, endpoint, args);
            JsonObjectCollection vis = (JsonObjectCollection)jo[1];
            JsonObjectCollection content = (JsonObjectCollection)vis["D"];
            return (JsonArrayCollection)content["u"];

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
        }
    }
}
