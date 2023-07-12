using AutoMapper;
using BLL;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesStore.Tests.Services
{
    public class MovieServiceTest
    {
        private readonly MovieService _fakeService;
        private readonly IUnitOfWork _fakeUow;
        private readonly IMapper _fakeMapper;
        public MovieServiceTest()
        {
            _fakeUow = A.Fake<IUnitOfWork>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
             _fakeMapper = mockMapper.CreateMapper();

            _fakeService = new(_fakeUow, _fakeMapper);
        }

        [Theory]
        [MemberData(nameof(GetMoviesTestData))]
        public void GetMovies_ShouldReturnCorrectMoviesList(List<Movie> fakeMoviesList)
        {
            A.CallTo(() => _fakeUow.Movies.Get(A<Expression<Func<Movie, bool>>>._))
                .Returns(fakeMoviesList);

            var expected = _fakeMapper.Map<List<Movie>, List<MovieDto>>(fakeMoviesList);
            var actual = _fakeService.GetMovies();

            actual.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> GetMoviesTestData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Movie>()
                {
                     new Movie()
                     {
                         Description = "Test description 1",
                         Id = Guid.Parse("00000000-ffff-0000-0000-000000000001"),
                         ReleaseDate = DateTime.MinValue,
                         Title = "Test title 1"

                     },
                     new Movie()
                     {
                         Description = "Test description 2 ",
                         Id = Guid.Parse("00000000-ffff-0000-0000-000000000002"),
                         ReleaseDate = DateTime.MaxValue,
                         Title = "Test title 2"

                     },
                     new Movie()
                     {
                         Description = "Test description 3",
                         Id = Guid.Parse("00000000-ffff-0000-0000-000000000003"),
                         ReleaseDate = DateTime.Now,
                         Title = "Test title 3"

                     },
                     new Movie(),
                }
            },
            new object[]
            {
                new List<Movie>()
                {
                     new Movie(),
                     new Movie(),
                     new Movie(),
                     new Movie(),
                     new Movie(),
                }
            },
        };
    }
}
