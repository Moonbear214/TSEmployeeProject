﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    public partial class UserDetailed
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("employee_next_of_kin")]
        public EmployeeNextOfKin[] EmployeeNextOfKin { get; set; }

        [JsonProperty("employee_review")]
        public EmployeeReview[] EmployeeReview { get; set; }

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

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("years_worked")]
        public long YearsWorked { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("next_review")]
        public DateTimeOffset NextReview { get; set; }

        [JsonProperty("days_to_birthday")]
        public long DaysToBirthday { get; set; }

        [JsonProperty("leave_remaining")]
        public string LeaveRemaining { get; set; }
    }
}
