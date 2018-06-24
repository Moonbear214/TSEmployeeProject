using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

using TSEmployeeProject.Models;

namespace TSEmployeeProject.Pages.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        public EmployeeList employees = new EmployeeList();

        public MainPageDetail()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (employees.Employees.Count == 0)
            {
                RefreshEmployeeList();
            }
        }

        async void RefreshEmployeeList()
        {
            using (UserDialogs.Instance.Loading(null, null, null, true, MaskType.Black))
            {
                employees.Employees = await App.dataFactory.GetEmployeeList();

                BindingContext = employees;
            }
        }

        async void ViewEmployee(object sender, SelectedItemChangedEventArgs e)
        {
            Employee employee = ((ListView)sender).SelectedItem as Employee;

            await Navigation.PushModalAsync(new EmployeeViewPage(employee));

            ((ListView)sender).SelectedItem = null;
        }

    }
}