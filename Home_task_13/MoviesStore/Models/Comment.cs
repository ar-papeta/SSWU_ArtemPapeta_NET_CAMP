using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("parent_id")]
        public Guid ParentId { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("movie")]
        public Movie Movie { get; set; } = new();
    }
}
