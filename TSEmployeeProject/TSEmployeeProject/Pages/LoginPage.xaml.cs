using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Models;
using TSEmployeeProject.Controls;
using Acr.UserDialogs;

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
        }

        private async void LoginUser(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading(null, null, null, true, MaskType.Black))
            {
                if (await App.dataFactory.UserLogin((LoginDetails)this.BindingContext))
                    Application.Current.MainPage = new MainPage.MainPage();
                else
                    DependencyService.Get<IMessage>().ShortAlert("Wrong Credentials");
            }
        }
    }
}