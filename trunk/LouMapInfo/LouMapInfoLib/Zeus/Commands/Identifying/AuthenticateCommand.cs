using System;
using System.Collections.Generic;
using EricUtility;
using EricUtility.Networking.Commands;
using System.Text;

namespace LouMapInfo.Zeus.Commands.Identifying
{
    public class AuthenticateCommand : AbstractLobbyCommand
    {
        protected override string CommandName
        {
            get { return COMMAND_NAME; }
        }
        public static string COMMAND_NAME = "lobby_AUTHENTICATE";

        private readonly string m_Name;
        private readonly string m_Password;


        public string Name
        {
            get { return m_Name; }
        }
        public string Password
        {
            get { return m_Password; }
        }


        public AuthenticateCommand(StringTokenizer argsToken)
        {
            m_Name = argsToken.NextToken();
            m_Password = argsToken.NextToken();
        }

        public AuthenticateCommand(string name, string password)
        {
            m_Name = name;
            m_Password = password;
        }

        public override void Encode(StringBuilder sb)
        {
            Append(sb, m_Name);
            Append(sb, m_Password);
        }

        public string EncodeResponse(bool success)
        {
            return new AuthenticateResponse(this, success).Encode();
        }
    }
}
