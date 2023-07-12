using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesStore.Controllers
{
    [Controller]
    [NotFoundResultFilter]
    [PerformanceActionFilter]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _service;
        public GenresController(IGenreService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] GenreDto genreDto)
        {
            _service.CreateGenre(genreDto);

            return Ok(genreDto);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllGenres());
        }
    }
}
