using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    [Table("UserDetailed")]
    public partial class UserDetailed
    {
        [PrimaryKey, JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("employee_next_of_kin")]
        public List<EmployeeNextOfKin> EmployeeNextOfKin { get; set; }

        [JsonProperty("employee_review")]
        public List<EmployeeReview> EmployeeReview { get; set; }

        [JsonProperty("id_number")]
        public string IdNumber { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("physical_address")]
        public string PhysicalAddress { get; set; }

        [JsonProperty("tax_number")]
        public string TaxNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("personal_email")]
        public string PersonalEmail { get; set; }

        [JsonProperty("github_user")]
        public string GithubUser { get; set; }

        [JsonProperty("birth_date")]
        public DateTimeOffset BirthDate { get; set; }

        [JsonProperty("start_date")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("end_date")]
        public object EndDate { get; set; }

        [JsonProperty("id_document")]
        public object IdDocument { get; set; }

        [JsonProperty("visa_document")]
        public object VisaDocument { get; set; }

        [JsonProperty("is_employed")]
        public bool IsEmployed { get; set; }

        [JsonProperty("is_foreigner")]
        public bool IsForeigner { get; set; }

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

        [JsonProperty("next_review")]
        public DateTimeOffset NextReview { get; set; }

        [JsonProperty("days_to_birthday")]
        public int DaysToBirthday { get; set; }

        [JsonProperty("leave_remaining")]
        public string LeaveRemaining { get; set; }
    }
}
