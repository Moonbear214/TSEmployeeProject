using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Models;

namespace TSEmployeeProject.Pages.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        public MainPageDetail()
        {
            InitializeComponent();

            PageSetup();
        }

        async void PageSetup()
        {
            IsBusy = true;

            EmployeeList employees = new EmployeeList
            {
                Employees = await App.dataFactory.GetEmployeeList()
            };

            BindingContext = employees;

            IsBusy = false;
        }

        private async void ViewEmployee(object sender, SelectedItemChangedEventArgs e)
        {
            Employee employee = ((ListView)sender).SelectedItem as Employee;

            await Navigation.PushModalAsync(new EmployeeViewPage(employee));
        }
    }
}