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

            //Console.WriteLine();
            //Console.WriteLine("loadShrines() indentation in JSON data format:");
            //Console.WriteLine(jsonObject.ToString());
            //Console.WriteLine();
            WorldInfo w = worlds[10];
            List<int> cont = new List<int>();
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
                /*
                int worldID = int.Parse(field.Name);
                DateTime val = DateTime.Parse((string)field.GetValue());
                worlds.Add(worldID,new WorldInfo(worldID, val));*/
            }

        }
        static void Main(string[] args)
        {
            loadUpdated();
            //foreach (WorldInfo wi in worlds.Values)
            //    Console.WriteLine("World #{0}, last updated {1:yyyy}-{1:mm}-{1:dd}", wi.ID, wi.LastUpdated);
            //Console.ReadLine();
            loadShrines();
            foreach (ContinentInfo c in worlds[10].Continents)
            {
                foreach (Pt p in worlds[10].Cont(c.ID).Shrines)
                {
                    Console.WriteLine("Shrine   World " + c.World.ID + " Cont " + c.ID + ": " + p);
                }
                foreach (Pt p in worlds[10].Cont(41).MoonGates)
                {
                    Console.WriteLine("MoonGate World " + c.World.ID + " Cont " + c.ID + ": " + p);
                }
            }
            Console.ReadLine();
        }
    }
}
