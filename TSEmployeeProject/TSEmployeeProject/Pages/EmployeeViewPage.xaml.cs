using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Models;

namespace TSEmployeeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeViewPage : ContentPage
	{
		public EmployeeViewPage (Employee employee)
		{
			InitializeComponent ();

            this.BindingContext = employee;
		}
	}
}