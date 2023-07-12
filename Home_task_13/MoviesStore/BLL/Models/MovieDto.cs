using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MovieDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("genres")]
        public List<GenreDto> Genres { get; set; } = new();

        [JsonPropertyName("directors")]
        public List<DirectorDto> Directors { get; set; } = new();

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

    }
}
