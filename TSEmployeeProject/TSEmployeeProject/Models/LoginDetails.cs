using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    [Table("LoginDetails")]
    public class LoginDetails
    {
        [PrimaryKey, AutoIncrement, JsonIgnore]
        public int Id { get; private set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonIgnore]
        public string AuthToken { get; set; }
    }
}
