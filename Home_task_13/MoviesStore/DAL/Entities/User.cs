using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public enum RoleNames
    {
        Admin,
        Manager,
        User,
    }
    public class User
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("emai")]
        public string EMail { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonPropertyName("role")]
        public RoleNames Role { get; set; }
    }
}
