using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICommentService
    {
        public CommentDto CreateComment(CommentDto commentDto, Guid movieId);
        public IEnumerable<CommentDto> GetMovieComments(Guid movieId);
        public void DeleteComment(Guid id);
    }
}
