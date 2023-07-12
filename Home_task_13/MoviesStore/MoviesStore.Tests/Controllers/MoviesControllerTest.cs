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
    public class MoviesControllerTest
    {
        private readonly MoviesController _controller;
        
        public MoviesControllerTest()
        {
            var fakeMovieService = A.Fake<IMovieService>();

            A.CallTo(() => fakeMovieService.GetMovie(A<Guid>._))
                .Returns(new MovieDto());

            A.CallTo(() => fakeMovieService.GetMovies())
                .Returns(A.CollectionOfFake<MovieDto>(5));

            A.CallTo(() => fakeMovieService.PatchMovie(A<MovieDto>._, A<Guid>._))
                .Returns(new MovieDto());

            A.CallTo(() => fakeMovieService.CreateMovie(A<MovieDto>._))
               .Returns(new MovieDto());

            A.CallTo(() => fakeMovieService.DeleteMovie(A<Guid>._))
               .Returns(System.Net.HttpStatusCode.OK);

            _controller = new MoviesController(fakeMovieService);
            
        }

        [Fact]
        public void GetMovies_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Get();
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void GetMovies_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Get();
            var okResult = result as OkObjectResult;

            Assert.IsType<List<MovieDto>>(okResult.Value);
        }

        [Fact]
        public void GetMovies_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Get();
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetMovie_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Get(Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void GetMovie_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Get(Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.IsType<MovieDto>(okResult.Value);
        }

        [Fact]
        public void GetMovie_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Get(Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void PostMovie_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Post(new MovieDto());
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void PostMovie_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Post(new MovieDto());
            var okResult = result as OkObjectResult;

            Assert.IsType<MovieDto>(okResult.Value);
        }

        [Fact]
        public void PostMovie_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Post(new MovieDto());
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void PatchMovie_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Patch(new MovieDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void PatchMovie_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Patch(new MovieDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.IsType<MovieDto>(okResult.Value);
        }

        [Fact]
        public void PatchMovie_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Patch(new MovieDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void DeleteMovie_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Delete(Guid.Empty);
            var okResult = result as OkResult;
            
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
