using System;
using System.Collections.Generic;
using System.Text;
using EricUtility;
using EricUtility.Networking.Commands;

namespace LouMapInfo.Zeus.Commands.Account
{
    public class ChangePasswordResponse : AbstractLobbyResponse<ChangePasswordCommand>
    {

        protected override string CommandName
        {
            get { return COMMAND_NAME; }
        }
        public static string COMMAND_NAME = "lobbyCHANGE_PASSWORD_RESPONSE";
        private readonly bool m_OK;
        public bool OK
        {
            get { return m_OK; }
        }


        public ChangePasswordResponse(StringTokenizer argsToken)
            : base(new ChangePasswordCommand(argsToken))
        {
            m_OK = bool.Parse(argsToken.NextToken());
        }

        public ChangePasswordResponse(ChangePasswordCommand command, bool ok)
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
