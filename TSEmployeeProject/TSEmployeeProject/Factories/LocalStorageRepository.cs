using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using TSEmployeeProject.Models;

namespace TSEmployeeProject.Factories
{
    public class LocalStorageRepository
    {
        SQLiteAsyncConnection conn;

        public LocalStorageRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            CreateAllTables();
        }

        /// <summary>
        /// Creates the tables in local storage for login details //and the logged in user//
        /// </summary>
        public async void CreateAllTables()
        {
            await conn.CreateTableAsync<LoginDetails>();
            //await conn.CreateTableAsync<UserDetailed>();
        }


        //Methods for adding data to local storage for all classes (Login, UserDetailed)
        //========================================================================================================================================================================

        //Login
        //==========================================================
        public async Task<LoginDetails> SaveLoginDetails(LoginDetails loginDetails)
        {
            try
            {
                await conn.InsertAsync(loginDetails);
                return loginDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Exception at: {0}. Failed to retrieve data: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================
        //========================================================================================================================================================================


        //Methods for returning all local storage data for given class (Login, UserDetailed)
        //========================================================================================================================================================================

        //Login
        //==========================================================
        public async Task<LoginDetails> GetLoginDetails()
        {
            try
            {
                return await conn.Table<LoginDetails>().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Exception at: {0}. Failed to retrieve data: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================
        //========================================================================================================================================================================


        //Method for deleting all data in local storage
        //========================================================================================================================================================================
        public async void ClearLocalStorage()
        {
            await conn.ExecuteAsync("DELETE FROM LoginDetails");
            //await conn.ExecuteAsync("DELETE FROM UserDetailed");
        }
        //========================================================================================================================================================================
    }
}
