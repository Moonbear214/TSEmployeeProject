using System;
using System.Collections.Generic;
using System.Text;

namespace TSEmployeeProject.ViewModels
{
    public class StatsDiplayModel
    {
        public int NumOfEmp { get; set; }

        public List<BirthdayDisplayList> BirthdaysList { get; set; }
    }

    public class BirthdayDisplayList
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
