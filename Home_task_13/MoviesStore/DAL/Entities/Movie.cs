using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Genre> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<Director> Directors { get; set; } = new();

        public List<Comment> Comments { get; set; } = new();
    }
}
