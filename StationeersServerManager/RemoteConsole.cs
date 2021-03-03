using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private const string err_invalid_password = "Invalid password";
        private const string err_invalid_login_parameters = "Invalid command : login command needs 2 parameters";
        private const string succ_login = "Login succeeded";

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
            catch(Exception e)
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
                string response = _client.Get(string.Format(_query, _address.ToString(), _port, HttpUtility.UrlPathEncode("login " + _password)));

                switch (response)
                {
                    case succ_login:
                        {
                            return;
                        }
                    case err_invalid_command:
                        {
                            throw new InvalidCommandException(err_invalid_command);
                        }
                    case err_invalid_password:
                        {
                            throw new LoginException(err_invalid_password);
                        }
                    case err_invalid_login_parameters:
                        {
                            throw new LoginException(err_invalid_login_parameters);
                        }
                }
            }
            catch(Exception e)
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
                string response = _client.Get(string.Format(_query, _address.ToString(), _port, "status"));

                if (response.Equals(err_no_login))
                {
                    throw new LoginException(err_no_login);
                }

                // parse status
                return new ServerStatus(response);
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
            /*
             * Response: GameVersion : 0.2.2768.13597<br>GameStatus : Running<br>1 Player(s) connected.<br><table><tr><th>display name</th><th>steamId</th><th>score</th><th>playtime</th><th>ping</th>
             * Smodd
             * 76561197985145270
             * 1671
             * 10:11:19
             * 28 ms
             * </tr></table>
             */

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
            catch(Exception e)
            {
                throw e;
            }
        }

        public string GameVersion { get;}
        public string GameStatus { get;}
        public int Players { get;}

        /// <summary>
        /// list of all players
        /// </summary>
        public List<Player> PlayerList { get;}
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

    public class LoginException : Exception
    {
        public LoginException()
        {
        }
     
        public LoginException(string message) : base(message)
        {
        }

        public LoginException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
