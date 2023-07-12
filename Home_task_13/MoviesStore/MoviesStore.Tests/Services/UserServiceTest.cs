using AutoMapper;
using BLL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Helpers.CustomExceptions;
using BLL.Services.Helpers.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using MoviesStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesStore.Tests.Services
{
    public class UserServiceTest
    {
        private readonly UserService _fakeService;
        private readonly IPasswordHash _fakeHasher;
        public UserServiceTest()
        {
            var fakeUow = A.Fake<IUnitOfWork>();
            _fakeHasher = A.Fake<IPasswordHash>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var fakeMapper = mockMapper.CreateMapper();

            _fakeService = new(
                fakeUow,
                fakeMapper,
                _fakeHasher
                );

            A.CallTo(() => fakeUow.Users.Get(A<Expression<Func<User, bool>>>._))
                 .Returns(new List<User>()
                 {
                     new User()
                     {
                         Password = "12345",
                     },
                     new User(),
                     new User(),
                     new User(),
                     new User(),
                 });
        }

        [Fact]
        public void GetUsers_ShouldReturnCorrectUsersCount()
        {
            var actual = _fakeService.GetUsers();

            Assert.Equal(5, actual.Count());
        }

        [Theory]
        [MemberData(nameof(UsersTestData))]
        public void CreateUser_ShouldReturnCorrectUserName(UserDto userDto)
        {
            var actual = _fakeService.CreateUser(userDto);

            Assert.Equal(userDto.Name, actual.Name);
        }

        [Theory]
        [MemberData(nameof(UsersTestData))]
        public void CreateUser_ShouldReturnOnlyUserRole(UserDto userDto)
        {
            var actual = _fakeService.CreateUser(userDto);

            Assert.Equal("User", actual.Role.ToString());
        }

        [Fact]
        public void CreateUser_ShoudReturnCorrectType()
        {
            var actual = _fakeService.CreateUser(new UserDto());

            Assert.IsType<UserDto>(actual);
        }

        [Fact]
        public void ValidateUser_WithWrongPassword_ShouldThrowNewPasswordIncorrectException()
        {
            Assert.Throws<UserValidationException>(() => _fakeService.ValidateUser(new UserDto()));
        }

        [Theory]
        [MemberData(nameof(UsersTestData))]
        public void ValidateUser_WithCorrectPassword_ShoudReturnCorrectType(UserDto userDto)
        {
            FakeEncryptPasswordCorrectCall();
            var actual = _fakeService.ValidateUser(userDto);

            Assert.IsType<UserDto>(actual);
        }

        [Theory]
        [MemberData(nameof(UsersTestData))]
        public void EditUser_ShoudReturnCorrectUserDto(UserDto userDto)
        {
            FakeEncryptPasswordCorrectCall();
            var actual = _fakeService.EditUser(userDto, Guid.Empty);

            using (new AssertionScope())
            {
                actual.Name.Should().Be(userDto.Name);
                actual.Password.Should().Be(userDto.Password);
                actual.Role.Should().Be(userDto.Role);
                actual.EMail.Should().Be(userDto.EMail);
            }
        }

        public static IEnumerable<object[]> UsersTestData =>
        new List<object[]>
        {
            new object[] 
            { 
                new UserDto() 
                { 
                    Name = "Artem", 
                    Role = "Admin",
                    EMail ="asd",
                    Password = "12345"
                }
            },
            new object[] 
            { 
                new UserDto() 
                { 
                    Name = "Petro 1234",
                    Role = "Manager",
                    EMail = "sda",
                    Password = "12345"
                }
            },
            new object[] 
            { 
                new UserDto() 
                { 
                    Name = "12", 
                    Role = "User",
                    EMail = "asdsadf",
                    Password = "12345"
                }
            },
        };

        private void FakeEncryptPasswordCorrectCall()
        {
            A.CallTo(() => _fakeHasher.EncryptPassword(A<string>._, A<byte[]>._))
                .Returns("12345");
        }
    }
}
