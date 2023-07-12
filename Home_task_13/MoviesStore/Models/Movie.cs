using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("directors")]
        public List<Movie> Directors { get; set; } = new();

        [JsonPropertyName("comments")]
        public List<Comment> Comments { get; set; } = new();
    }
}
