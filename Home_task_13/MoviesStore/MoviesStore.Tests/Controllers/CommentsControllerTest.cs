using BLL.Models;
using BLL.Services.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MoviesStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesStore.Tests.Controllers
{
    public class CommentsControllerTest
    {
        private readonly CommentsController _controller;

        public CommentsControllerTest()
        {
            var mockMovieService = A.Fake<ICommentService>();

            A.CallTo(() => mockMovieService.GetMovieComments(A<Guid>._))
                .Returns(new List<CommentDto>());

            A.CallTo(() => mockMovieService.CreateComment(A<CommentDto>._, A<Guid>._))
               .Returns(new CommentDto());

            _controller = new CommentsController(mockMovieService);

        }

        [Fact]
        public void GetMovieComments_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Get(Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void GetMovieComments_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Get(Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.IsType<List<CommentDto>>(okResult.Value);
        }

        [Fact]
        public void GetMovieComments_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Get(Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void PostComment_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Post(new CommentDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void PostComment_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Post(new CommentDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.IsType<CommentDto>(okResult.Value);
        }

        [Fact]
        public void PostComment_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Post(new CommentDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void DeleteComment_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Delete(Guid.Empty);
            var okResult = result as OkResult;

            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
