using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Zeus
{
    public class ZeusSessionInfo
    {
        private string m_Username;
        private string m_Password;
        private string m_World;
        private LobbyTCPClient m_Server;

        public string Username { get { return m_Username; } }
        public string Password { get { return m_Password; } }
        public string World { get { return m_World; } }
        public LobbyTCPClient Server { get { return m_Server; } }
        
        public ZeusSessionInfo(string user, string pass, string world, string address, int port)
            : this(user, world, address, port)
        {
            m_Password = pass;
        }
        public ZeusSessionInfo(string user, string world, string address, int port)
        {
            m_Username = user;
            m_World = world;
            m_Server = new LobbyTCPClient(address, port);
        }
        public bool Connect()
        {
            bool ok = m_Server.Connect();
            if (ok)
                m_Server.Start();
            return ok;
        }
        public bool Exist()
        {
            return m_Server.Identify(m_Username);
        }
        public void RequestPassword()
        {
            m_Server.Identify(m_Username);
            m_Server.RequestPassword();
        }
        public bool Authenticate()
        {
            return m_Server.Authenticate(m_Username, m_Password);
        }
        public void ChangePassword(string newPass)
        {
            m_Password = newPass;
            m_Server.ChangePassword(m_Password);
        }
        public void Disconnect()
        {
            m_Server.Disconnect();
        }
    }
}
