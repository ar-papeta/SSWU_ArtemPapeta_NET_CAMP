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
    public class GenreServiceTest
    {
        private readonly GenreService _fakeService;
        public GenreServiceTest()
        {
            IUnitOfWork _fakeUow = A.Fake<IUnitOfWork>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var fakeMapper = mockMapper.CreateMapper();

            _fakeService = new(_fakeUow, fakeMapper);
        }

        [Fact]
        public void CreateDirector_WithNullDirectorDto_ShoudThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _fakeService.CreateGenre(null));
        }

        [Theory]
        [MemberData(nameof(CreateGenreTestData))]
        public void CreateDirector_WithValidDirectorDto_ShoudReturnCorrectDto(GenreDto fakeGenreDto)
        {
            var actual = _fakeService.CreateGenre(fakeGenreDto);

            actual.Should().BeEquivalentTo(fakeGenreDto);
        }

        public static IEnumerable<object[]> CreateGenreTestData =>
        new List<object[]>
        {
            new object[]
            {
                new GenreDto()
                {
                    Name = "@#$%^^&*"
                },
            },
            new object[]
            {
                new GenreDto()
                {
                    Name = "Artem"
                }
            },
            new object[]
            {
                new GenreDto()
            },
        };
    }
}
