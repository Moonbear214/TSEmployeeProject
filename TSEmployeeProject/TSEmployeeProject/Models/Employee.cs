using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using SQLite;

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

        [Ignore, JsonIgnore]
        public String GenderDisplay
        {
            get
            {
                String Value = null;

                switch (this.Gender)
                {
                    case "M":
                        Value = "Male";
                        break;
                    case "F":
                        Value = "Female";
                        break;
                }

                return Value;
            }
        }

        [JsonProperty("race")]
        public string Race { get; set; }

        [Ignore, JsonIgnore]
        public string RaceDisplay
        {
            get
            {
                String Value = null;

                switch (this.Race)
                {
                    case "B":
                        Value = "Black African";
                        break;
                    case "C":
                        Value = "Coloured";
                        break;
                    case "I":
                        Value = "Indian or Asian";
                        break;
                    case "W":
                        Value = "White";
                        break;
                    case "N":
                        Value = "None Document";
                        break;
                }

                return Value;
            }
        }

        [JsonProperty("years_worked")]
        public int YearsWorked { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("days_to_birthday")]
        public int DaysToBirthday { get; set; }
    }

    public class EmployeeList
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
