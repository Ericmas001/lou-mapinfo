using System;
using System.Collections.Generic;
using EricUtility;
using EricUtility.Networking.Commands;
using System.Text;

namespace LouZeusConnector.Commands.Account
{
    public class ChangePasswordCommand : AbstractLobbyCommand
    {
        protected override string CommandName
        {
            get { return COMMAND_NAME; }
        }
        public static string COMMAND_NAME = "lobby_CHANGE_PASSWORD";

        private readonly string m_Password;

        public string Password
        {
            get { return m_Password; }
        }


        public ChangePasswordCommand(StringTokenizer argsToken)
        {
            m_Password = argsToken.NextToken();
        }

        public ChangePasswordCommand(string password)
        {
            m_Password = password;
        }

        public override void Encode(StringBuilder sb)
        {
            Append(sb, m_Password);
        }

        public string EncodeResponse(bool success)
        {
            return new ChangePasswordResponse(this, success).Encode();
        }
    }
}
