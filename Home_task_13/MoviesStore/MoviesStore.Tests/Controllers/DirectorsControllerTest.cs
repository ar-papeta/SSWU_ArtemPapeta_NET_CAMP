using BLL.Models;
using BLL.Services.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MoviesStore.Controllers;
using System.Collections.Generic;
using Xunit;

namespace MoviesStore.Tests.Controllers
{
    public class DirectorsControllerTest
    {
        private readonly DirectorsController _controller;
        public DirectorsControllerTest()
        {
            var fakeDirectorService = A.Fake<IDirectorService>();

            A.CallTo(() => fakeDirectorService.CreateDirector(A<DirectorDto>._))
               .Returns(A.Fake<DirectorDto>());

            _controller = new DirectorsController(fakeDirectorService);
        }

        [Fact]
        public void PostDirector_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.Post(new DirectorDto());
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void PostDirector_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.Post(new DirectorDto());
            var okResult = result as OkObjectResult;

            Assert.IsType<DirectorDto>(okResult.Value);
        }

        [Fact]
        public void PostDirector_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.Post(new DirectorDto());
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
