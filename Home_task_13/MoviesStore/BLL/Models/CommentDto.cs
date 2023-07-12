using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CommentDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid? ParentCommentId { get; set; }

        [JsonPropertyName("parent_comment")]
        public CommentDto ParentComment { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

    }
}
