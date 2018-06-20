using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEmployeeProject.Controls;
using Xamarin.Forms;

using TSEmployeeProject.Models;

namespace TSEmployeeProject.Pages
{
	public partial class MainPage : ContentPage
    {
        //Test
        //================================================================================
        string UserPass = "pravin.gordhan";
        //================================================================================

        public MainPage()
		{
			InitializeComponent();
        }

        //Test
        //================================================================================
        private async void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IMessage>().ShortAlert("Test Success");

            LoginDetails loginDetails = new LoginDetails()
            {
                Username = UserPass,
                Password = UserPass
            };

            var asdf = await App.dataFactory.UserLogin(loginDetails);
        }
        //================================================================================
    }
}
