using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesStore.Auth.Authentication;
using MoviesStore.Filters;
using MoviesStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesStore.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    [NotFoundResultFilter]
    [PerformanceActionFilter]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ITokenFactory _jwt;
        private readonly IMapper _mapper;
        public UsersController(
            IUserService service, 
            ITokenFactory jwt,
            IMapper mapper)
        {
            _jwt = jwt;
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserDto userDto)
        {
            var user = _service.CreateUser(userDto);

            return Ok(new AuthenticateResponce()
            {
                AccessToken = _jwt.CreateAccessToken(user.Id.ToString(), user.Role),
                UserViewModel = _mapper.Map<UserViewModel>(user)
            });
        }

        [Authorize("user:read")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var usersDto = _service.GetUsers();

            return Ok(_mapper.Map<List<UserViewModel>>(usersDto));
        }

        [Authorize("user:write")]
        [HttpPatch]
        public IActionResult EditUser([FromBody] UserDto user, [FromRoute] Guid id)
        {
            return Ok(_service.EditUser(user, id));
        }


        [HttpPost]
        [Route("~/actions/login")]
        public IActionResult ValidateUser([FromBody] AuthenticationRequest userAuthData)
        {
            var user = _service.ValidateUser(_mapper.Map<UserDto>(userAuthData));

            return Ok(new AuthenticateResponce()
            {
                AccessToken = _jwt.CreateAccessToken(user.Id.ToString(), user.Role),
                UserViewModel = _mapper.Map<UserViewModel>(user)
            });
        }
    }
}
