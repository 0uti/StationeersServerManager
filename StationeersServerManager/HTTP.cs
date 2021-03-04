/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * Outi wrote this file. As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return Outi
 * ----------------------------------------------------------------------------
 */

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace StationeersServerManager
{
    class HTTP
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        public HTTP()
        {
            _client = new HttpClient();
            // ToDo: Headers

        }

        /// <summary>
        /// get data from async task
        /// </summary>
        /// <param name="url">Request URL</param>
        /// <returns>Response as String</returns>
        public string Get(string url)
        {
            try
            {
#if DEBUG
                Debug.WriteLine("Query: " + url);
#endif
                Task<string> response = Task.Run(() => GetAsync(url));
                response.Wait();
#if DEBUG
                Debug.WriteLine("Response: " + response.Result);
#endif
                return response.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get async RCON response
        /// </summary>
        /// <param name="url">Request URL</param>
        /// <returns>Task result</returns>
        private async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
