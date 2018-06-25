using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Models;
using TSEmployeeProject.ViewModels;

namespace TSEmployeeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeStats : ContentPage
	{
        StatsDiplayModel StatsDiplay = new StatsDiplayModel();

		public EmployeeStats (List<Employee> employees)
		{
			InitializeComponent ();
            
            StatsDiplay.NumOfEmp = employees.Count;
            StatsDiplay.NumOfAverngers = employees.Where(empl => StatsDiplay.AverngersList.Contains(empl.User.FullNameDisplay)).Count();
            StatsDiplay.BirthdaysList = CurrentMonthBirthdays(employees);
            if (StatsDiplay.BirthdaysList.Count == 0)
                StatsDiplay.BirthdaysList.Add(new BirthdayDisplayList()
                {
                    Name = "No birthdays this month",
                    Date = DateTime.Now
                });

            this.BindingContext = StatsDiplay;
		}

        List<BirthdayDisplayList> CurrentMonthBirthdays(List<Employee> employees)
        {
            List<BirthdayDisplayList> monthBirthdays = new List<BirthdayDisplayList>();

            List<Employee> tmpList = employees.FindAll(empl => empl.BirthDate.Month == DateTime.Now.Month);

            foreach (Employee empl in tmpList)
            {
                monthBirthdays.Add(new BirthdayDisplayList()
                {
                    Name = empl.User.FirstName,
                    Date = empl.BirthDate
                });
            }

            return monthBirthdays;
        }
    }
}