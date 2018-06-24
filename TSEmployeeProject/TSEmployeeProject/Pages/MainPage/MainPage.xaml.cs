using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Models;
using Acr.UserDialogs;

namespace TSEmployeeProject.Pages.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        UserDetailed user;
        
        public MainPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainPageMenuItem;
            if (item == null)
                return;
            
            if (item.Id == 0)
            {
                if (user == null)
                {
                    using (UserDialogs.Instance.Loading(null, null, null, true, MaskType.Black))
                    {
                        user = await App.dataFactory.GetCurrentUser();
                    }
                }

                await Navigation.PushModalAsync(new UserDetailsPage(user));
            }
            else if (item.Id == 1)
            {
                await Navigation.PushModalAsync(new EmployeeStats(DetailPage.employees.Employees));
            }

            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}