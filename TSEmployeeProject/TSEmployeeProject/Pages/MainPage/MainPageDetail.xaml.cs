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
            EmployeeList employees = new EmployeeList
            {
                Employees = await App.dataFactory.GetEmployeeList()
            };

            BindingContext = employees;
        }
    }
}