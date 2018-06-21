﻿using System;
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
        APIFactory apiFactory;
        LocalStorageRepository localStorageRepo;

        //private string authorizationKey; //= "token 2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678";

        public DataFactory(string dbPath)
        {
            apiFactory = new APIFactory();
            localStorageRepo = new LocalStorageRepository(dbPath);
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
        public async Task<bool> LoginUser(LoginDetails loginDetails)
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
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetEmployeeList()
        {
            return await apiFactory.GetEmployeeList();
        }
    }
}
