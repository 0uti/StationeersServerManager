﻿/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * Outi wrote this file. As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return Outi
 * ----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace StationeersServerManager
{
    class RemoteConsole
    {
        private readonly HTTP _client;
        private readonly IPAddress _address;
        private readonly int _port;
        private readonly string _password;
        private const string _query = "http://{0}:{1}/console/run?command={2}";

        // general
        private const string err_invalid_command = "Invalid command";
        private const string err_no_login = "<color=red>Invalid connection. Please login first.</color>";

        // login
        private const string login_invalid_password = "Invalid password";
        private const string login_invalid_parameters = "Invalid command : login command needs 2 parameters";
        private const string login_success = "Login succeeded";


        // Notice
        private const string notice_success = "$Sent \" {NoticeMessege} \".";
        private const string notice_invalid_parameters = "Invalid command :notice command requires at least 2 parameters";


        /// <summary>
        /// Contructor / Create new instance of class, connect and Login.
        /// </summary>
        /// <param name="address">Server ip address</param>
        /// <param name="port">Server port</param>
        /// <param name="password">Login password</param>
        public RemoteConsole(IPAddress address, int port, string password)
        {
            _address = address;
            _port = port;
            _password = password;

            try
            {
                _client = new HTTP();
                Login();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Login into RCON
        /// </summary>
        private void Login()
        {
            try
            {
                string response = QueryRcon("login " + _password);

                switch (response)
                {
                    case login_success:
                        {
                            return;
                        }
                    case err_invalid_command:
                        {
                            throw new InvalidCommandException(err_invalid_command);
                        }
                    case login_invalid_password:
                        {
                            throw new RconException(login_invalid_password);
                        }
                    case login_invalid_parameters:
                        {
                            throw new RconException(login_invalid_parameters);
                        }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get server status with player list
        /// </summary>
        /// <returns>ServerStatus</returns>
        public ServerStatus GetStatus()
        {
            try
            {
                string response = QueryRcon("status");

                if (response.Equals(err_no_login))
                {
                    throw new RconException(err_no_login);
                }

                // parse status
                return new ServerStatus(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Notice(string message)
        {
            try
            {
                string response = _client.Get(string.Format(_query, _address.ToString(), _port, string.Format("notice \"{0}\"", message)));

                switch (response)
                {
                    case notice_invalid_parameters:
                        {
                            throw new RconException(notice_invalid_parameters);
                        }
                    case notice_success:
                        {
                            return;
                        }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string QueryRcon(string command)
        {
            try
            {
                return _client.Get(string.Format(_query, _address.ToString(), _port, HttpUtility.UrlPathEncode(command)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class ServerStatus
    {
        /// <summary>
        /// Constructor with "parser"
        /// </summary>
        /// <param name="raw"></param>
        public ServerStatus(string raw)
        {
            try
            {
                // split into string lines
                string[] rawSplit = raw.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // split "headers"
                string[] headers = rawSplit[0].Split(new string[] { "<br>" }, StringSplitOptions.None);

                GameVersion = headers[0].Replace("GameVersion : ", "").Trim();
                GameStatus = headers[1].Replace("GameStatus : ", "").Trim();

                if (headers[2].Equals("No Players"))
                {
                    Players = 0;
                }
                else
                {
                    Players = int.Parse(headers[2].Replace(" Player(s) connected.", "").Trim());
                }
                PlayerList = new List<Player>();

                if (Players > 0)
                {
                    for (int i = 0; i < Players; i++)
                    {
                        int j = i * 5;
                        Player player = new Player
                        {
                            Name = rawSplit[j + 1],
                            SteamId = long.Parse(rawSplit[j + 2]),
                            Score = int.Parse(rawSplit[j + 3]),
                            PlayTime = rawSplit[j + 4],
                            Ping = rawSplit[j + 5]
                        };
                        PlayerList.Add(player);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GameVersion { get; }
        public string GameStatus { get; }
        public int Players { get; }

        /// <summary>
        /// list of all players
        /// </summary>
        public List<Player> PlayerList { get; }
    }

    public class Player
    {
        public string Name { get; set; }
        public long SteamId { get; set; }
        public int Score { get; set; }
        public string PlayTime { get; set; }
        public string Ping { get; set; }
    }

    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {
        }

        public InvalidCommandException(string message) : base(message)
        {
        }

        public InvalidCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class RconException : Exception
    {
        public RconException()
        {
        }

        public RconException(string message) : base(message)
        {
        }

        public RconException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
