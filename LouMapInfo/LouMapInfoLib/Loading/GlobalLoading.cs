using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using EricUtility.Networking.Gathering;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Loading
{
    public static class GlobalLoading
    {
        public static void LoadUpdated(Dictionary<int, WorldInfo> worlds)
        {
            if (worlds.Count == 0)
            {
                //string s = File.ReadAllText("../../testData/updated.json");
                string s = GatheringUtility.GetPageSource("http://www.lou-map.com/updated.json");
                JsonTextParser parser = new JsonTextParser();
                JsonObject jsonObject = parser.Parse(s);

                foreach (JsonObject field in jsonObject as JsonObjectCollection)
                {
                    int worldID = int.Parse(field.Name);
                    DateTime val = DateTime.Parse((string)field.GetValue());
                    worlds.Add(worldID, new WorldInfo(worldID, val));
                }
            }
        }
    }
}
