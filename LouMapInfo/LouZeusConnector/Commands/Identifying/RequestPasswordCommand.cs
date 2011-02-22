using System;
using System.Collections.Generic;
using EricUtility;
using EricUtility.Networking.Commands;
using System.Text;

namespace LouZeusConnector.Commands.Identifying
{
    public class RequestPasswordCommand : AbstractLobbyCommand
    {
        protected override string CommandName
        {
            get { return COMMAND_NAME; }
        }
        public static string COMMAND_NAME = "lobby_REQUEST_PASSWORD";


        public RequestPasswordCommand(StringTokenizer argsToken)
        {
        }

        public RequestPasswordCommand()
        {
        }

        public override void Encode(StringBuilder sb)
        {
        }

        public string EncodeResponse()
        {
            return new RequestPasswordResponse(this, true).Encode();
        }
    }
}
