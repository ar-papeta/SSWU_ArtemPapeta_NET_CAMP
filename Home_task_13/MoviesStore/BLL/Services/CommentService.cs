using AutoMapper;
using BLL.Models;
using BLL.Services.Helpers;
using BLL.Services.Helpers.CustomExceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public CommentDto CreateComment(CommentDto commentDto, Guid movieId)
        {
            _ = commentDto ?? throw new ArgumentNullException(nameof(commentDto));

            Comment comment = _mapper.Map<CommentDto, Comment>(commentDto);
            comment.Id = Guid.NewGuid();
            commentDto.Id = comment.Id;
            comment.Movie = _database.Movies.GetByID(movieId);
            var parentComment = _database.Comments.GetByID(comment.ParentCommentId);
            if (parentComment is not null)
            {
                comment.Body = comment.Body.Insert(0, $"[{parentComment?.Username}], ");
                commentDto.Body = comment.Body;
            }
            _database.Comments.Insert(comment);
            _database.Save();

            return commentDto;
        }

        public void DeleteComment(Guid id)
        {
            var comment = _database.Comments.GetByID(id);
            if (comment is null)
            {
                throw new NotFoundException("Comment to delete not found, maybe wrong guid");
            }
            _database.Comments.Delete(id);
            _database.Save();
        }

        public IEnumerable<CommentDto> GetMovieComments(Guid movieId)
        {
            List<Comment> comments = _database.Comments.Get(comment => comment.Movie.Id == movieId).ToList();
            List<CommentDto> commentsDTO = _mapper.Map<List<Comment>, List<CommentDto>>(comments);

            foreach (var comment in commentsDTO)
            {
                comment.ParentComment = (commentsDTO.Find(x => x.Id == comment.ParentCommentId));
            }
            var treeCommentsDTO = commentsDTO
                .Where(x => commentsDTO.All(comment => x.Id != comment.ParentCommentId))
                .ToList();

            return treeCommentsDTO;
        }
    }
}
