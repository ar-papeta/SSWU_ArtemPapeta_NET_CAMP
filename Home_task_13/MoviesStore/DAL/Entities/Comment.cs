using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid? ParentCommentId { get; set; }

        public string Username { get; set; }
        
        public string Body { get; set; }

        public Movie Movie { get; set; } 
    }
}
