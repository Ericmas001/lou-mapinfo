using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;
using EricUtility.Networking.Gathering;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Loading
{
    public static class WorldLoading
    {
        public static void LoadShrines(Dictionary<int, WorldInfo> worlds, int iw)
        {
            //string s = File.ReadAllText("../../testData/sea" + iw + ".json");

            WorldInfo w = worlds[iw];
            if (!w.Loaded)
            {
                string s = GatheringUtility.GetPageSource("http://www.lou-map.com/data/sea" + iw + ".json");
                JsonTextParser parser = new JsonTextParser();
                JsonObject jsonObject = parser.Parse(s);
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
                w.Loaded = true;
            }
        }
    }
}
