using System;
using System.Collections.Generic;
using System.Text;

namespace LouMapInfo.Entities
{
    public class ServerInfo
    {
        readonly int m_Id;
        readonly string m_Name;
        readonly int m_Prod;

        public int Id
        {
            get { return m_Id; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public string Url
        {
            get { return "http://prodgame"+m_Prod.ToString("00")+".lordofultima.com/" + m_Id; }
        }

        public int Prod
        {
            get { return m_Prod; }
        }

        public ServerInfo(int id, string name, int prod)
        {
            m_Id = id;
            m_Name = name;
            m_Prod = prod;
        }
        public override string ToString()
        {
            return m_Name;
        }
    }
}
