using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MoviesStore.Auth.Authentication;
using MoviesStore.Controllers;
using MoviesStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;

namespace MoviesStore.Tests.Controllers
{
    public class UsersControllerTest
    {
        private readonly UsersController _controller;

        public UsersControllerTest()
        {
            var mockUserService = A.Fake<IUserService>();
            var mockJwtService = A.Fake<ITokenFactory>();
            var mockMapperConf = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mockMapper = mockMapperConf.CreateMapper();

            A.CallTo(() => mockUserService.GetUsers())
                .Returns(A.CollectionOfFake<UserDto>(5));

            A.CallTo(() => mockUserService.EditUser(A<UserDto>._, A<Guid>._))
                .Returns(new UserDto());

            A.CallTo(() => mockUserService.CreateUser(A<UserDto>._))
               .Returns(new UserDto());

            A.CallTo(() => mockUserService.ValidateUser(A<UserDto>._))
               .Returns(new UserDto());

            _controller = new UsersController(mockUserService, mockJwtService, mockMapper);          
        }

        [Fact]
        public void GetUsers_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.GetUsers();
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void GetUsers_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.GetUsers();
            var okResult = result as OkObjectResult;

            Assert.IsType<List<UserViewModel>>(okResult.Value);
        }

        [Fact]
        public void GetUsers_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.GetUsers();
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void EditUser_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.EditUser(new UserDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void EditUser_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.EditUser(new UserDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.IsType<UserDto>(okResult.Value);
        }

        [Fact]
        public void EditUser_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.EditUser(new UserDto(), Guid.Empty);
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void CreateUser_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.CreateUser(new UserDto());
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void CreateUser_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.CreateUser(new UserDto());
            var okResult = result as OkObjectResult;

            Assert.IsType<AuthenticateResponce>(okResult.Value);
        }

        [Fact]
        public void CreateUser_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.CreateUser(new UserDto());
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void ValidateUser_OkResultValue_ShoudNotBeNull()
        {
            var result = _controller.ValidateUser(new AuthenticationRequest());
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void ValidateUser_OkResultValue_ShoudBeCorrectType()
        {
            var result = _controller.ValidateUser(new AuthenticationRequest());
            var okResult = result as OkObjectResult;

            Assert.IsType<AuthenticateResponce>(okResult.Value);
        }

        [Fact]
        public void ValidateUser_OkResultValue_ShoudReturnOkStatusCode()
        {
            var result = _controller.ValidateUser(new AuthenticationRequest());
            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
