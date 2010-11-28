using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EricUtility.Networking.JSON;
using LouMapInfo.Entities;

namespace LouMapInfo
{
    class Program
    {
        // http://www.lou-map.com/updated.json = last update
        // http://www.lou-map.com/data/p1c2.json = player data by continent 1=server 2=continent
        // http://www.lou-map.com/data/w1c2.json = world data cities by continent 1=server 2=continent 
        // http://www.lou-map.com/data/w1s2.json = world data castles by continent 1=server 2=continent 
        // http://www.lou-map.com/data/sea1.json = world data shrines 1=server
        // http://www.lou-map.com/data/overlay1s2.json = overlay data castles by continent 1=server 2=continent
 
        private static Dictionary<int, WorldInfo> worlds = new Dictionary<int,WorldInfo>();
        public static void loadUpdated()
        {
            string s = File.ReadAllText("../../testData/updated.json");
            JsonTextParser parser = new JsonTextParser();
            JsonObject jsonObject = parser.Parse(s);

            foreach (JsonObject field in jsonObject as JsonObjectCollection)
            {
                int worldID = int.Parse(field.Name);
                DateTime val = DateTime.Parse((string)field.GetValue());
                worlds.Add(worldID, new WorldInfo(worldID, val));
            }
        }


        public static void loadShrines()
        {
            string s = File.ReadAllText("../../testData/sea10.json");
            JsonTextParser parser = new JsonTextParser();
            JsonObject jsonObject = parser.Parse(s);
            WorldInfo w = worlds[10];
            foreach (JsonObject o in jsonObject as JsonObjectCollection)
            {
                JsonObjectCollection t = o as JsonObjectCollection;
                if (t != null)
                {
                    foreach (JsonArrayCollection c in t)
                    {
                        int cid = int.Parse(c.Name);
                        switch (t.Name)
                        {
                            case "shrines":
                                {
                                    foreach (JsonArrayCollection i in c)
                                    {
                                        w.Cont(cid).Shrines.Add(new Pt((int)((JsonNumericValue)i[0]).Value, (int)((JsonNumericValue)i[1]).Value));
                                    }
                                    break;
                                }
                            case "moongates":
                                {
                                    foreach (JsonArrayCollection i in c)
                                    {
                                        w.Cont(cid).MoonGates.Add(new Pt((int)((JsonNumericValue)i[0]).Value, (int)((JsonNumericValue)i[1]).Value));
                                    }
                                    break;
                                }
                        }

                    }
                }
            }

        }


        public static void loadOverlay()
        {
            string s = File.ReadAllText("../../testData/overlay10c41.json");
            JsonTextParser parser = new JsonTextParser();
            JsonObject jsonObject = parser.Parse(s);
            WorldInfo world = worlds[10];
            ContinentInfo continent = world.Cont(41);
            foreach (JsonObjectCollection a in jsonObject as JsonObjectCollection)
            {
                string aid = a.Name;
                int pts = (int)((JsonNumericValue)a["points"]).Value;
                string name = (string)((JsonStringValue)a["name"]).Value;
                AllianceInfo alliance = new AllianceInfo(int.Parse(aid), name, pts, continent);
                if (continent.Alliances.ContainsKey(name))
                    alliance = continent.Alliances[name];
                else
                    continent.Alliances.Add(name,alliance);
                JsonObjectCollection players = (JsonObjectCollection)a["players"];
                foreach (JsonObjectCollection p in players)
                {
                    string pid = p.Name;
                    string pname = (string)((JsonStringValue)p["name"]).Value;
                    int ppts = (int)((JsonNumericValue)p["points"]).Value;
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
                        player.Cities.Add(cid,city);
                        if (castle)
                            Console.WriteLine(alliance + ": " + player + ": " + city);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            loadUpdated();
            loadShrines();
            loadOverlay();
            Console.WriteLine();
            Console.WriteLine("======================");
            Console.WriteLine();
            foreach (CityInfo c in worlds[10].Cont(41).Alliances[AllianceInfo.NO_ALLIANCE].Players[PlayerInfo.LAWLESS].Cities.Values)
                Console.WriteLine(c);
            Console.WriteLine();
            Console.WriteLine("======================");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
