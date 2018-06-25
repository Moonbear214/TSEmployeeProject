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
    public class DataFactory
    {
        private LocalStorageRepository localStorageRepo;
        private APIFactory apiFactory;
        
        public DataFactory(string dbPath)
        {
            localStorageRepo = new LocalStorageRepository(dbPath);
            apiFactory = new APIFactory();
        }


        /// <summary>
        /// Checks if the user is logged in when the app starts up
        /// and assigns the authorizationKey if user is found in local storage
        /// </summary>
        public async Task<bool> LoggedInCheck()
        {
            LoginDetails loginDetails = await localStorageRepo.GetLoginDetails();

            if (loginDetails != null)
            {
                if (!string.IsNullOrWhiteSpace(loginDetails.AuthToken))
                {
                    apiFactory.SetClient(loginDetails.AuthToken);
                    return true;
                }
                else
                {
                    localStorageRepo.ClearLocalStorage();
                    return false;
                }
            }
            else
                return false;
        }


        /// <summary>
        /// Sends username and password to be authenticated and returns true if valid
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        public async Task<bool> UserLogin(LoginDetails loginDetails)
        {
            await apiFactory.LoginUser(loginDetails);
            
            if (!string.IsNullOrWhiteSpace(loginDetails.AuthToken))
            {
                await localStorageRepo.SaveLoginDetails(loginDetails);
                apiFactory.SetClient(loginDetails.AuthToken);

                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// Returns list of all employees on server
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetEmployeeList()
        {
            return await apiFactory.GetEmployeeList();
        }


        /// <summary>
        /// Returns all current user detail on server
        /// </summary>
        /// <returns></returns>
        public async Task<UserDetailed> GetCurrentUser()
        {
            return await apiFactory.GetCurrentUser();
        }
        

        /// <summary>
        /// Clears local storage
        /// </summary>
        public void ResetLocalStorage()
        {
            localStorageRepo.ClearLocalStorage();
            apiFactory.ResetClient();
        }
    }
}
