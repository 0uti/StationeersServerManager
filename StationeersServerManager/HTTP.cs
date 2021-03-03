using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace StationeersServerManager
{
    class HTTP
    {
        private HttpClient _client;

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
            catch(Exception e)
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
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
