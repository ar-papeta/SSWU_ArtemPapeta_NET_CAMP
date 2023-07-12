using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public GenreService(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public GenreDto CreateGenre(GenreDto genreDto)
        {
            _ = genreDto ?? throw new ArgumentNullException(nameof(genreDto));

            var genre = _mapper.Map<GenreDto, Genre>(genreDto);
            genre.Id = Guid.NewGuid();
            _database.Genres.Insert(genre);
            _database.Save();

            return genreDto;
        }

        public IEnumerable<GenreDto> GetAllGenres()
        {
            var genres = _database.Genres.Get().ToList();
            IEnumerable<GenreDto> genresDto = _mapper.Map<List<Genre>, List<GenreDto>>(genres);
            return genresDto;
        }
    }
}
