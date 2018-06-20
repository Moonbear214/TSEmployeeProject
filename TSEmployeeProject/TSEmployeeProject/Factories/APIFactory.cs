using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using TSEmployeeProject.Models;

namespace TSEmployeeProject.Factories
{
    public class APIFactory
    {
        HttpClient httpClient;
        const string url = "http://staging.tangent.tngnt.co/api/";

        public APIFactory()
        {
            httpClient = new HttpClient();
        }

        private HttpClient GetClient(string authKey)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", authKey);
            return client;
        }

        /// <summary>
        /// Sends user login details to server to see if valid and obtain authentication token
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        public async Task<LoginDetails> LoginUser(LoginDetails loginDetails)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(loginDetails),
                Encoding.UTF8,
                "application/json");

            HttpClient client = new HttpClient();

            var result = await client.PostAsync("http://staging.tangent.tngnt.co/api-token-auth/", content);

            if (result.IsSuccessStatusCode)
            {
                Dictionary<string, string> tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(await result.Content.ReadAsStringAsync());
                loginDetails.AuthToken = string.Format("{0} {1}", tokenDetails.FirstOrDefault().Key, tokenDetails.FirstOrDefault().Value);

                return loginDetails;
            }
            else
            {
                return loginDetails;
            }
        }
    }
}
