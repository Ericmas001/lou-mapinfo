// Ultra giga thanks to : http://code.google.com/p/lou-tools-empire/
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
            request.Timeout = 5000;
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
            args.Add(new JsonStringValue("requests", "UA:\fTM:48,1,\fCAT:1\fWC:A\fWORLD:BA%S-CA?S-DAFhB-EA_(C-FAk0C-hA8+C-iAY%B-jA|1B-kAd)C-lAb'C-%A[2C-&Ax_C-(AJhC-)AB7C-*AO1B-GB'PB-HB_kC-IB]YB-JBv4C-KBQsC-mBquC-nB)LB-oB~cB-pBZnC-qB^pC-+BoiB-,B[SB-.B]2C- BQrC-:B_rC-\fVIS:w:0:0:-264:-66:1016:677\fUFP:\fREPORT:\fMAIL:\fFRIENDINV:\fTIME:1298397592476\fCHAT:\fSUBSTITUTION:\fINV:\fALL_AT:\fMAT:3276896\fFRIENDL:\f"));
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
    }
}
