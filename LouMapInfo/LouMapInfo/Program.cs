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
                worlds.Add(worldID,new WorldInfo(worldID, val));
            }

        }
        static void Main(string[] args)
        {
            loadUpdated();
            foreach (WorldInfo wi in worlds.Values)
                Console.WriteLine("World #{0}, last updated {1:yyyy}-{1:mm}-{1:dd}", wi.ID, wi.LastUpdated);
            Console.ReadLine();
        }
    }
}
