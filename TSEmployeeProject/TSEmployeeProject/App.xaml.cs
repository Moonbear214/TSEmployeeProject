using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Factories;
using TSEmployeeProject.Pages;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TSEmployeeProject
{
	public partial class App : Application
    {
        // Creates a static datafactory here that can be referenced through entire app.
        // App.dataFactory...
        public static DataFactory dataFactory;

        public App (string dbPath)
		{
			InitializeComponent();

            dataFactory = new DataFactory(dbPath);

            LoggedInCheck();
		}

        /// <summary>
        /// Checks if a user is saved in local storage and logs the user in if true,
        /// diverts to login page if false.
        /// </summary>
        private async void LoggedInCheck()
        {
            if (await dataFactory.LoggedInCheck())
                MainPage = new MainPage();
            else
                MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
