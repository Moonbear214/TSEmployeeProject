using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Models;
using TSEmployeeProject.Controls;

namespace TSEmployeeProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginDetails loginDetails = new LoginDetails() { Username = "pravin.gordhan", Password = "pravin.gordhan" };

        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = loginDetails;

            LoggedInCheck();
        }

        /// <summary>
        /// Checks if a user is saved in local storage and navigates to the main page if true
        /// </summary>
        private async void LoggedInCheck()
        {
            this.IsBusy = true;
            if (await App.dataFactory.LoggedInCheck())
                App.Current.MainPage = new NavigationPage(new MainPage());
            this.IsBusy = false;
        }

        private async void LoginUser(object sender, EventArgs e)
        {
            if (await App.dataFactory.UserLogin((LoginDetails)this.BindingContext))
                App.Current.MainPage = new NavigationPage(new MainPage());
            //await Navigation.PushAsync(new MainPage());
            else
                DependencyService.Get<IMessage>().ShortAlert("Wrong Credentials");
        }
    }
}