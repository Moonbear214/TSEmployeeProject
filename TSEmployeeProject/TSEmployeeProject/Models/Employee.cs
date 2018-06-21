using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    public partial class Employee
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("github_user")]
        public string GithubUser { get; set; }

        [JsonProperty("birth_date")]
        public DateTimeOffset BirthDate { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("years_worked")]
        public int YearsWorked { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("days_to_birthday")]
        public int DaysToBirthday { get; set; }
    }

    public class EmployeeList
    {
        public List<Employee> Employees { get; set; }
    }
}
