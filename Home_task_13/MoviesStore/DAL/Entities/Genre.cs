using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public Guid? ParentGenreId { get; set; }

        public List<Movie> Movies { get; set; } = new();
    }
}
