using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Factories;
using TSEmployeeProject.Pages;
using TSEmployeeProject.Pages.MainPage;
using System.Threading.Tasks;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TSEmployeeProject
{
	public partial class App : Application
    {
        // Creates a static datafactory here that can be referenced through entire app.
        // App.dataFactory...
        public static DataFactory dataFactory { get; private set; }

        public App (string dbPath)
		{
			InitializeComponent();

            dataFactory = new DataFactory(dbPath);

            if (CheckLogin())
                MainPage = new MainPage();
            else
                MainPage = new LoginPage();

            //CheckLogin();
		}

        public bool CheckLogin()
        {
            Task<bool> task = Task.Run<bool>(async () => await dataFactory.LoggedInCheck());
            if (task.Result)
                return true;
            else
                return false;
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
