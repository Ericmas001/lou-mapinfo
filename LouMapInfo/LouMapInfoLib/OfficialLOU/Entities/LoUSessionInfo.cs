﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using EricUtility.Networking.Gathering;
using EricUtility;
using EricUtility.Networking.JSON;

namespace LouMapInfo.OfficialLOU.Entities
{
    public class LoUSessionInfo
    {
        private readonly string m_Mail;
        private readonly string m_Password;
        private bool m_Connected;
        private string m_SessionID;
        private CookieContainer m_Cookies;
        private readonly LoUWorldInfo m_World;
        private int m_MyPID;
        private int m_MyAID;

        public LoUWorldInfo World { get { return m_World; } }
        public string Mail { get { return m_Mail; } }
        public string Password { get { return m_Password; } }
        public bool Connected { get { return m_Connected; } }
        public string SessionID { get { return m_SessionID; } }
        public int PlayerID { get { return m_MyPID; } }
        public int AllianceID { get { return m_MyAID; } }

        public LoUSessionInfo(string mail, string password, string world)
        {
            m_Mail = mail;
            m_Password = password;
            m_World = new LoUWorldInfo(this, world);
        }

        public bool Connect()
        {
            m_Cookies = GatheringUtility.SignInWebsite("https://www.lordofultima.com/en/user/login?destination=%40homepage%3F", "mail=" + m_Mail + "&password=" + m_Password + "&remember_me=true", true);
            string s = GatheringUtility.GetPageSource("http://www.lordofultima.com/en/game", m_Cookies);
            m_SessionID = StringUtility.Extract(s, "<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\"", "\"");
            if (m_SessionID == null)
                m_SessionID = "0af6308a-fa8c-4e9b-aced-d551677de258";//return false;

            JsonObjectCollection me = LoUEndPoint.GetPlayerInfo(m_World.Url, m_SessionID);
            m_MyPID = (int)((JsonNumericValue)me["Id"]).Value;
            m_MyAID = (int)((JsonNumericValue)me["AllianceId"]).Value;

            m_Connected = true;
            return true;
        }
    }
}