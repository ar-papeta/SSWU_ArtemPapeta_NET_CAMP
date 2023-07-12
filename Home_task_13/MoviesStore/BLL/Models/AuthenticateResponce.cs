using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AuthenticateResponce
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("user_role")]
        public string UserRole { get; set; }
    }
}
