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

        /// <summary>
        /// Checks if username and password is valid and shows toastr if not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoginUser(object sender, EventArgs e)
        {
            bool userValid = false;

            if (!string.IsNullOrWhiteSpace(((LoginDetails)this.BindingContext).Username) || !string.IsNullOrWhiteSpace(((LoginDetails)this.BindingContext).Password))
                using (UserDialogs.Instance.Loading(null, null, null, true, MaskType.Black))
                {
                    userValid = await App.dataFactory.UserLogin((LoginDetails)this.BindingContext);
                }
            else
                DependencyService.Get<IMessage>().ShortAlert("Fields Missing");

            if (userValid)
                Application.Current.MainPage = new MainPage.MainPage();
            else
                DependencyService.Get<IMessage>().ShortAlert("Wrong Credentials");
        }
    }
}