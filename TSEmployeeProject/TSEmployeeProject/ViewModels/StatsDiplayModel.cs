using System;
using System.Collections.Generic;
using System.Text;

namespace TSEmployeeProject.ViewModels
{
    public class StatsDiplayModel
    {
        public int NumOfEmp { get; set; }

        public int NumOfAverngers { get; set; }

        public List<BirthdayDisplayList> BirthdaysList { get; set; }

        public List<string> AverngersList { get; set; }

        public StatsDiplayModel()
        {
            AverngersList = new List<string>()
            {
                "Thor",
                "Captain America",
                "Iron Man",
                "Hulk",
                "Doctor Strange",
                "Black Panther",
                "Gary Player", // Would have been accepted if applied
                "Black Panther"
            };
        }
    }

    public class BirthdayDisplayList
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
