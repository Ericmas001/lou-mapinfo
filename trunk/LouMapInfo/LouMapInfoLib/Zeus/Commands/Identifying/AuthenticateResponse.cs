using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.Commands;

namespace LouMapInfo.Zeus.Commands.Identifying
{
    public class AuthenticateResponse : AbstractLobbyResponse<AuthenticateCommand>
    {

        protected override string CommandName
        {
            get { return COMMAND_NAME; }
        }
        public static string COMMAND_NAME = "lobbyAUTHENTICATE_RESPONSE";
        private readonly bool m_OK;
        public bool OK
        {
            get { return m_OK; }
        }


        public AuthenticateResponse(StringTokenizer argsToken)
            : base(new AuthenticateCommand(argsToken))
        {
            m_OK = bool.Parse(argsToken.NextToken());
        }

        public AuthenticateResponse(AuthenticateCommand command, bool ok)
            : base(command)
        {
            m_OK = ok;
        }

        public override void Encode(StringBuilder sb)
        {
            base.Encode(sb);
            Append(sb, m_OK);
        }
    }
}
