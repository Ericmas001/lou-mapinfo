using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using EricUtility.Networking.Gathering;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.Entities
{
    public class SessionInfo
    {
        private readonly string m_Mail;
        private readonly string m_Password;
        private bool m_Connected;
        private string m_SessionID;
        private bool m_UsingCredentials;
        private CookieContainer m_Cookies;
        private readonly WorldInfo m_World;
        private int m_MyPID;
        private int m_MyAID;
        private PlayerExtendedInfo m_MyPlayer;

        public PlayerExtendedInfo MyPlayer
        {
            get { return m_MyPlayer; }
            set { m_MyPlayer = value; }
        }

        public WorldInfo World { get { return m_World; } }
        public string Mail { get { return m_Mail; } }
        public string Password { get { return m_Password; } }
        public bool Connected { get { return m_Connected; } }
        public string SessionID { get { return m_SessionID; } }
        public int PlayerID { get { return m_MyPID; } }
        public int AllianceID { get { return m_MyAID; } }

        public SessionInfo(string mail, string password, string world)
        {
            m_Mail = mail;
            m_Password = password;
            m_UsingCredentials = true;
            m_World = new WorldInfo(this, world);
        }
        public SessionInfo(string ssid, string world)
        {
            m_SessionID = ssid;
            m_UsingCredentials = false;
            m_World = new WorldInfo(this, world);
        }
        public static CookieContainer ConnectToLoU(string user, string pass)
        {
            return GatheringUtility.SignInWebsite("https://www.lordofultima.com/j_security_check", "spring-security-redirect=%2Fsignup%2Fsignup&id=step&timezone=-4&j_username=" + user.Replace("@", "%40") + "&j_password=" + pass, true);
        }
        public static string GetSessionID(CookieContainer cookies)
        {
            string s = GatheringUtility.GetPageSource("http://www.lordofultima.com/game/world", cookies);
            return StringUtility.Extract(s, "WebWorldBrowser/index.aspx?sessionID=", "&locale=");
        }
        public bool Connect()
        {
            if (m_UsingCredentials)
            {
                m_Cookies = SessionInfo.ConnectToLoU(m_Mail, m_Password);
                m_SessionID = SessionInfo.GetSessionID(m_Cookies);
            }
            if (m_SessionID == null)
                return false;
            try
            {
                JsonObjectCollection o = EndPoint.OpenSession(m_World.Url, m_SessionID);
                m_SessionID = ((JsonStringValue)o["i"]).Value;

                JsonObjectCollection me = EndPoint.GetMyPlayerInfoLight(m_World.Url, m_SessionID);
                m_MyPID = (int)((JsonNumericValue)me["Id"]).Value;
                m_MyAID = (int)((JsonNumericValue)me["AllianceId"]).Value;

                m_Connected = true;
                return true;
            }
            catch//( Exception e )
            {
                return false;
            }
        }
    }
}
