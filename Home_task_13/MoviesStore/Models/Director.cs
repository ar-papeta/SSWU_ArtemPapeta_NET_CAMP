using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Director
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("movies")]
        public List<Movie> Movies { get; set; } = new();
    }
}
