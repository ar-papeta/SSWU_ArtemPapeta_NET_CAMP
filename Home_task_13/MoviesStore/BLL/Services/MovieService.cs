using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public MovieDto GetMovie(Guid id)
        {
            var movie = _database.Movies.GetByID(id);
            MovieDto movieDTO = new()
            {
                Description = movie.Description,
            };
            return movieDTO;
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _database.Movies.Get().ToList();
            IEnumerable<MovieDto> moviesDto = _mapper.Map<List<Movie>, List<MovieDto>>(movies);
            return moviesDto;
        }
    

        public MovieDto CreateMovie(MovieDto movieDto)
        {
            _ = movieDto ?? throw new ArgumentNullException(nameof(movieDto));
            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            movie.Id = Guid.NewGuid();
            _database.Movies.Insert(movie);
            _database.Save();

            return movieDto;
        }

        public MovieDto PatchMovie(MovieDto movieDto, Guid id)
        {
            _ = movieDto ?? throw new ArgumentNullException(nameof(movieDto));

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            var patchMovie = _database.Movies.GetByID(id);
            
            patchMovie.ReleaseDate = movie.ReleaseDate;
            patchMovie.Directors = movie.Directors;
            patchMovie.Description = movie.Description;
            patchMovie.Comments = movie.Comments;
            patchMovie.Title = movie.Title;
            patchMovie.Genres = movie.Genres;

            _database.Movies.Update(patchMovie);
            _database.Save();
            return movieDto;
              
        }

        public HttpStatusCode DeleteMovie(Guid id)
        {
            if (GetMovie(id) is not null)
            {
                _database.Movies.Delete(id);
                _database.Save();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotFound;
        }
    }
}
