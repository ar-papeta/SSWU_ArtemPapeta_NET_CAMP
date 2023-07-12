using BLL.Models;
using BLL.Services.Interfaces;
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
    public class DirectorsController : ControllerBase                                                                        
    {
        private readonly IDirectorService _service;
        public DirectorsController(IDirectorService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody]DirectorDto directorDto)
        {
            _service.CreateDirector(directorDto);

            return Ok(directorDto);
        }
    }
}
