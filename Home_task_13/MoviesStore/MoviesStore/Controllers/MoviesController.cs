using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MoviesStore.Controllers
{
    [Controller]
    [NotFoundResultFilter]
    [PerformanceActionFilter]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize("movie:read")]
        public IActionResult Get(Guid id)
        {
            var movie = _service.GetMovie(id);

            return Ok(movie);
        }

        [HttpGet]
        [Authorize("movie:read")]
        public IActionResult Get()
        {
            var movies = _service.GetMovies();

            return Ok(movies);
        }

        [HttpPost]
        //[Authorize("movie:write")]
        public IActionResult Post([FromBody]MovieDto movie)
        {
            _service.CreateMovie(movie);
            
            return Ok(movie);
        }

        [HttpPatch]
        [Route("{id}")]
        [Authorize("movie:write")]
        public IActionResult Patch([FromBody] MovieDto movie, [FromRoute] Guid id)
        {
            var patchMovie = _service.PatchMovie(movie, id);

            return Ok(patchMovie);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize("movie:write")]
        public IActionResult Delete(Guid id)
        {
            var code = _service.DeleteMovie(id);

            return code == HttpStatusCode.OK ? Ok() : NotFound();
        }
    }
}
