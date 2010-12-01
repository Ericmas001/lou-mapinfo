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
                    if (continent.Alliances.ContainsKey(name))
                        alliance = continent.Alliances[name];
                    else
                        continent.Alliances.Add(name, alliance);
                    JsonObjectCollection players = (JsonObjectCollection)a["players"];
                    foreach (JsonObjectCollection p in players)
                    {
                        string pid = p.Name;
                        string pname = (string)((JsonStringValue)p["name"]).Value;
                        int ppts = (pname == PlayerInfo.LAWLESS) ? 0 : (int)((JsonNumericValue)p["points"]).Value;
                        PlayerInfo player = new PlayerInfo(int.Parse(pid), pname, ppts, alliance);
                        if (alliance.Players.ContainsKey(pname))
                            player = alliance.Players[pname];
                        else
                            alliance.Players.Add(pname, player);
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
    }
}
