using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoviesStore.Controllers
{
    [Controller]
    [NotFoundResultFilter]
    [PerformanceActionFilter]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{movieId}")]
        [Authorize("comment:read")]
        public IActionResult Get(Guid movieId)
        {
            var comments = _service.GetMovieComments(movieId);

            return Ok(comments);
        }

        [HttpPost]
        [Route("{movieId}")]
        [Authorize("comment:write")]
        public IActionResult Post([FromBody] CommentDto comment, [FromRoute] Guid movieId)
        {
            _service.CreateComment(comment, movieId);

            return Ok(comment);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize("comment:delete")]
        public IActionResult Delete(Guid id)
        {
            _service.DeleteComment(id);

            return Ok();
        }
    }
}
