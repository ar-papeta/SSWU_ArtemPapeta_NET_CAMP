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
    public class GenresControllerTest
    {
        private readonly GenresController _controller;
        public GenresControllerTest()
        {
            var mockGenreService = A.Fake<IGenreService>();

            A.CallTo(() => mockGenreService.GetAllGenres())
                .Returns(A.CollectionOfFake<GenreDto>(5));

            A.CallTo(() => mockGenreService.CreateGenre(A<GenreDto>._))
               .Returns(new GenreDto());

            _controller = new GenresController(mockGenreService);
        }

        [Fact]
        public void GetGenres_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Get();
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void GetGenres_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Get();
            var okResult = result as OkObjectResult;

            Assert.IsType<List<GenreDto>>(okResult.Value);
        }

        [Fact]
        public void GetGenres_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Get();
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void PostGenre_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Post(new GenreDto());
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void PostGenre_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Post(new GenreDto());
            var okResult = result as OkObjectResult;

            Assert.IsType<GenreDto>(okResult.Value);
        }

        [Fact]
        public void PostGenre_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Post(new GenreDto());
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
