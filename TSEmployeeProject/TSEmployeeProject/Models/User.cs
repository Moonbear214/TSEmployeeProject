using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    public partial class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }
    }
}
