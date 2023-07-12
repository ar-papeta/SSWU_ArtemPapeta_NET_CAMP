using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IMovieService
    {
        public MovieDto GetMovie(Guid id);
        public IEnumerable<MovieDto> GetMovies();
        public MovieDto CreateMovie(MovieDto movieDto);
        public MovieDto PatchMovie(MovieDto movieDto, Guid id);
        public HttpStatusCode DeleteMovie(Guid id);
    }
}
