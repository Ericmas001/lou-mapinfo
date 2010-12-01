using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using EricUtility.Networking.Gathering;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Loading
{
    public static class ContinentLoading
    {
        public static void LoadOverlay(Dictionary<int, WorldInfo> worlds, int iw, int ic)
        {
            WorldInfo world = worlds[iw];
            ContinentInfo continent = world.Cont(ic);
            if (!continent.Loaded)
            {
                string s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/overlay" + iw + "c" + ic + ".json");
                //string s = File.ReadAllText("../../testData/overlay"+iw+"c"+ic+".json");
                JsonTextParser parser = new JsonTextParser();
                JsonObject jsonObject = parser.Parse(s);
                foreach (JsonObjectCollection a in jsonObject as JsonObjectCollection)
                {
                    string aid = a.Name;
                    string name = (string)((JsonStringValue)a["name"]).Value;
                    int pts = (name == AllianceInfo.NO_ALLIANCE) ? 0 : (int)((JsonNumericValue)a["points"]).Value;
                    AllianceInfo alliance = new AllianceInfo(int.Parse(aid), name, pts, continent);
                    if (continent.AlliancesOldWay.ContainsKey(name))
                        alliance = continent.AlliancesOldWay[name];
                    else
                        continent.AlliancesOldWay.Add(name, alliance);
                    JsonObjectCollection players = (JsonObjectCollection)a["players"];
                    foreach (JsonObjectCollection p in players)
                    {
                        string pid = p.Name;
                        string pname = (string)((JsonStringValue)p["name"]).Value;
                        int ppts = (pname == PlayerInfo.LAWLESS) ? 0 : (int)((JsonNumericValue)p["points"]).Value;
                        PlayerInfo player = new PlayerInfo(int.Parse(pid), pname, ppts, alliance);
                        if (alliance.PlayersOldWay.ContainsKey(pname))
                            player = alliance.PlayersOldWay[pname];
                        else
                            alliance.PlayersOldWay.Add(pname, player);
                        JsonObjectCollection pcities = (JsonObjectCollection)p["cities"];
                        foreach (JsonObjectCollection c in pcities)
                        {
                            string cid = c.Name;
                            string cname = (string)((JsonStringValue)c["name"]).Value;
                            int cpts = (int)((JsonNumericValue)c["points"]).Value;
                            bool castle = (bool)((JsonBooleanValue)c["castle"]).Value;
                            Pt loc = new Pt((int)((JsonNumericValue)c["x"]).Value, (int)((JsonNumericValue)c["y"]).Value);
                            CityInfo city = new CityInfo(int.Parse(cid), cname, cpts, castle, loc, player);
                            player.AddCity(city);
                            if (castle)
                                Console.WriteLine(alliance + ": " + player + ": " + city);
                        }
                    }
                }
                continent.Loaded = true;
            }
        }
        private static void LoadContinentFile(ContinentInfo continent, bool castle, JsonObject jsonObject)
        {
            foreach (JsonObjectCollection o1 in jsonObject as JsonObjectCollection)
            {
                foreach (JsonObject o in o1 as JsonObjectCollection)
                {
                    if (o is JsonObjectCollection)
                    {
                        JsonObjectCollection o2 = (JsonObjectCollection)o;
                        JsonNumericValue oX = (JsonNumericValue)o2["x"];
                        JsonNumericValue oY = (JsonNumericValue)o2["y"];
                        JsonStringValue oCName = (JsonStringValue)o2["name"];
                        JsonNumericValue oCScore = (JsonNumericValue)o2["points"];
                        JsonNumericValue oPIndex = (JsonNumericValue)o2["playerIndex"];
                        JsonStringValue oPName = (JsonStringValue)o2["player"];
                        JsonNumericValue oPScore = (JsonNumericValue)o2["ppoints"];
                        JsonNumericValue oAIndex = (JsonNumericValue)o2["allianceIndex"];
                        JsonStringValue oAName = (JsonStringValue)o2["alliance"];
                        CityInfo city = new CityInfo(-1, oCName.Value, (int)oCScore.Value, castle, new Pt((int)oX.Value, (int)oY.Value), continent.Alliance(oAName.Value).Player(oPName.Value));
                        continent.Alliance(oAName.Value).Player(oPName.Value).AddCityAddScore(city);
                    }
                }
            }
        }
        public static void LoadContinent(Dictionary<int, WorldInfo> worlds, int iw, int ic)
        {
            WorldInfo world = worlds[iw];
            ContinentInfo continent = world.Cont(ic);
            if (!continent.Loaded)
            {
                string s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/w" + iw + "c" + ic + ".json");
                //string s = File.ReadAllText("../../testData/overlay"+iw+"c"+ic+".json");
                JsonTextParser parser = new JsonTextParser();
                JsonObject jsonObject = parser.Parse(s);
                LoadContinentFile(continent, false, jsonObject);
                s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/w" + iw + "s" + ic + ".json");
                //string s = File.ReadAllText("../../testData/overlay"+iw+"c"+ic+".json");
                parser = new JsonTextParser();
                jsonObject = parser.Parse(s);
                LoadContinentFile(continent, true, jsonObject);
                continent.Loaded = true;
            }
        }
    }
}
