using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace TSEmployeeProject.Models
{
    public partial class Position
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("sort")]
        public long Sort { get; set; }
    }
}
