using AutoMapper;
using BLL;
using BLL.Models;
using BLL.Services;
using DAL.Interfaces;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesStore.Tests.Services
{
    public class DirectorServiceTest
    {
        private readonly DirectorService _fakeService;
        public DirectorServiceTest()
        {
            IUnitOfWork _fakeUow = A.Fake<IUnitOfWork>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var fakeMapper = mockMapper.CreateMapper();

            _fakeService = new (_fakeUow, fakeMapper);
        }

        [Fact]
        public void CreateDirector_WithNullDirectorDto_ShoudThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _fakeService.CreateDirector(null));
        }

        [Theory]
        [MemberData(nameof(CreateDirectorTestData))]
        public void CreateDirector_WithValidDirectorDto_ShoudReturnCorrectDto(DirectorDto fakeDirectorDto)
        {
            var actual = _fakeService.CreateDirector(fakeDirectorDto);

            actual.Should().BeEquivalentTo(fakeDirectorDto);
        }

        public static IEnumerable<object[]> CreateDirectorTestData =>
        new List<object[]>
        {
            new object[]
            {
                new DirectorDto()
                {
                    FullName = "@#$%^^&*"
                }, 
            },
            new object[]
            {
                new DirectorDto()
                {
                    FullName = "Artem"
                }
            },
            new object[]
            {
                new DirectorDto()
            },
        };
    }
}
