using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    public partial class EmployeeReview
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("salary")]
        public string Salary { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [Ignore, JsonIgnore]
        public string TypeDisplay
        {
            get
            {
                String Value = null;

                switch (this.Type)
                {
                    case "P":
                        Value = "Performance Increase";
                        break;
                    case "S":
                        Value = "Starting Salary";
                        break;
                    case "A":
                        Value = "Annual Increase";
                        break;
                    case "E":
                        Value = "Expectation Review";
                        break;
                }

                return Value;
            }
        }
    }
}
