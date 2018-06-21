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

            MainPage = new LoginPage();
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
