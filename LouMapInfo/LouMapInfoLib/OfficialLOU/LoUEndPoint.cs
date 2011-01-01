﻿// Ultra giga thanks to : http://code.google.com/p/lou-tools-empire/
// This class works because of their clean code :)

using System;
using System.Collections.Generic;
using System.Text;
using EricUtility.Networking.JSON;
using System.Net;
using System.IO;
using System.Net.Cache;

namespace LouMapInfo.OfficialLOU
{
    public static class LoUEndPoint
    {
        public static JsonObject Query(string baseurl, string endpoint, JsonObjectCollection args)
        {
            string url = baseurl + "/Presentation/Service.svc/ajaxEndpoint/" + endpoint;
            byte[] bytes = new UTF8Encoding().GetBytes(args.ToString());
            CookieContainer cookies = new CookieContainer();


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Timeout = 2000;
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

        public static JsonObjectCollection GetPlayerInfo(string baseurl, string session)
        {
            string endpoint = "GetPlayerInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            return (JsonObjectCollection) Query(baseurl, endpoint, args);
        }

        public static JsonArrayCollection GetPlayerList(string baseurl, string session, int continent)
        {
            string endpoint = "PlayerGetRange";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("start", 0));
            args.Add(new JsonNumericValue("end", 999999999));
            args.Add(new JsonNumericValue("continent", continent));
            args.Add(new JsonStringValue("sort", "0"));
            args.Add(new JsonBooleanValue("ascending", true));
            return (JsonArrayCollection)Query(baseurl, endpoint, args);
        }

        public static JsonArrayCollection GetPlayerList(string baseurl, string session)
        {
            return GetPlayerList(baseurl, session, -1);
        }

        public static JsonObjectCollection GetPublicPlayerInfo(string baseurl, string session, int idPlayer)
        {
            string endpoint = "GetPublicPlayerInfo";
            JsonObjectCollection args = new JsonObjectCollection();
            args.Add(new JsonStringValue("session", session));
            args.Add(new JsonNumericValue("id", idPlayer));
            return (JsonObjectCollection)Query(baseurl, endpoint, args);
        }
    }
}