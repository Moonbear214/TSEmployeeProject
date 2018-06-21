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
        public string authorizationKey; //= "token 2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678";

        public APIFactory()
        { }

        public void SetClient(string authKey)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", authKey);
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

        /// <summary>
        /// Returns a list of all the employees and their details
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetEmployeeList()
        {
            var result = await httpClient.GetStringAsync(url + "employee/");

            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(result);

            return employees;
        }

        /// <summary>
        /// Returns a detailed class of the current user with all the information they can view about themselves
        /// </summary>
        /// <returns></returns>
        public async Task<UserDetailed> GetCurrentUser()
        {
            var result = await httpClient.GetStringAsync(url + "employee/me/");

            UserDetailed currentUser = JsonConvert.DeserializeObject<UserDetailed>(result);

            return currentUser;
        }
    }
}
