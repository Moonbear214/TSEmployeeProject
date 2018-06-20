using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    public partial class EmployeeNextOfKin
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("physical_address")]
        public string PhysicalAddress { get; set; }

        [JsonProperty("employee")]
        public long Employee { get; set; }
    }
}
