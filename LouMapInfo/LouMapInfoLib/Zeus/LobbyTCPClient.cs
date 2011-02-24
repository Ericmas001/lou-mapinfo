using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using EricUtility;
using EricUtility.Collections;
using EricUtility.Networking;
using EricUtility.Networking.Commands;
using LouMapInfo.Zeus.Commands.Identifying;
using LouMapInfo.Zeus.Commands.Account;

namespace LouMapInfo.Zeus
{
    public delegate void DisconnectDelegate();
    public class LobbyTCPClient : TCPCommunicator
    {
        public event DisconnectDelegate ServerLost = delegate { };
        protected string m_PlayerName;
        protected string m_ServerAddress;
        protected int m_ServerPort;

        public string PlayerName
        {
            get { return m_PlayerName; }
        }

        public string ServerAddress
        {
            get { return m_ServerAddress; }
        }

        public int ServerPort
        {
            get { return m_ServerPort; }
        }
        protected BlockingQueue<string> m_Incoming = new BlockingQueue<string>();

        public LobbyTCPClient(string serverAddress, int serverPort)
            : base()
        {
            m_ServerAddress = serverAddress;
            m_ServerPort = serverPort;
        }

        public bool Connect()
        {
            return base.Connect(m_ServerAddress, m_ServerPort);
        }

        protected StringTokenizer ReceiveCommand(string expected)
        {
            string s = m_Incoming.Dequeue();
            StringTokenizer token = new StringTokenizer(s, AbstractLobbyCommand.Delimitter);
            string commandName = token.NextToken();
            while (s != null && commandName != expected)
            {
                s = m_Incoming.Dequeue();
                token = new StringTokenizer(s, AbstractLobbyCommand.Delimitter);
                commandName = token.NextToken();
            }
            return token;
        }

        protected string Receive(StreamReader reader)
        {
            string line;
            try
            {
                line = reader.ReadLine();
                LogManager.Log(LogLevel.MessageLow, "LobbyTCPClient.Receive", "{0} RECV [{1}]", m_PlayerName, line);
            }
            catch
            {
                return null;
            }
            return line;
        }
        public override void OnReceiveCrashed(Exception e)
        {
            if (e is IOException)
            {
                LogManager.Log(LogLevel.Error, "LobbyTCPClient.OnReceiveCrashed", "Lobby lost connection with server");
                Disconnect();
            }
            else
                base.OnReceiveCrashed(e);
        }
        public override void OnSendCrashed(Exception e)
        {
            if (e is IOException)
            {
                LogManager.Log(LogLevel.Error, "LobbyTCPClient.OnReceiveCrashed", "Lobby lost connection with server");
                Disconnect();
            }
            else
                base.OnSendCrashed(e);
        }
        public void Send(StreamWriter writer, AbstractCommand command)
        {
            LogManager.Log(LogLevel.MessageLow, "LobbyTCPClient.Send", "{0} SEND [{1}]", m_PlayerName, command.Encode());
            writer.WriteLine(command.Encode());
        }
        public void Send(AbstractCommand command)
        {
            LogManager.Log(LogLevel.MessageLow, "LobbyTCPClient.Send", "{0} SEND [{1}]", m_PlayerName, command.Encode());
            base.Send(command.Encode());
        }
        public void Disconnect()
        {
            if (IsConnected)
            {
                Send(new DisconnectCommand());
                Close();
            }
        }
        protected override void Run()
        {
            while (IsConnected)
            {
                LogManager.Log(LogLevel.MessageVeryLow, "LobbyTCPClient.Run", "{0} IS WAITING", m_PlayerName);
                string line = Receive();
                if (line == null)
                {
                    ServerLost();
                    return;
                }
                LogManager.Log(LogLevel.MessageLow, "LobbyTCPClient.Run", "{0} RECV [{1}]", m_PlayerName, line);
                StringTokenizer token = new StringTokenizer(line, AbstractLobbyCommand.Delimitter);
                String commandName = token.NextToken();
                m_Incoming.Enqueue(line);
            }
        }


        public bool Identify(string name)
        {
            m_PlayerName = name;
            Send(new IdentifyCommand(m_PlayerName));
            StringTokenizer token = ReceiveCommand(IdentifyResponse.COMMAND_NAME);
            if (!token.HasMoreTokens())
                return false;
            IdentifyResponse response = new IdentifyResponse(token);
            return response.OK;
        }


        public bool RequestPassword()
        {
            Send(new RequestPasswordCommand());
            StringTokenizer token = ReceiveCommand(RequestPasswordResponse.COMMAND_NAME);
            if (!token.HasMoreTokens())
                return false;
            RequestPasswordResponse response = new RequestPasswordResponse(token);
            return response.OK;
        }


        public bool Authenticate(string name, string password)
        {
            Send(new AuthenticateCommand(name, password));
            StringTokenizer token = ReceiveCommand(AuthenticateResponse.COMMAND_NAME);
            if (!token.HasMoreTokens())
                return false;
            AuthenticateResponse response = new AuthenticateResponse(token);
            return response.OK;
        }


        public bool ChangePassword(string password)
        {
            Send(new ChangePasswordCommand(password));
            StringTokenizer token = ReceiveCommand(ChangePasswordResponse.COMMAND_NAME);
            if (!token.HasMoreTokens())
                return false;
            ChangePasswordResponse response = new ChangePasswordResponse(token);
            return response.OK;
        }
    }
}
