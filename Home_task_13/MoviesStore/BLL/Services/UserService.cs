using AutoMapper;
using BLL.Models;
using BLL.Services.Helpers;
using BLL.Services.Helpers.CustomExceptions;
using BLL.Services.Helpers.Interfaces;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        private readonly IPasswordHash _passwordHash;

        public UserService(
            IUnitOfWork database, 
            IMapper mapper, 
            IPasswordHash passwordHash)
        {
            _database = database;
            _mapper = mapper;
            _passwordHash = passwordHash;
        }

        public UserDto ValidateUser(UserDto userDto)
        {
            if (userDto is null)
            {
                throw new UserValidationException("Access denied. Unresolved user from request body.");
            }

            User user = _database.Users.Get(user =>
                user.EMail == userDto.EMail)
                ?.First()
                ?? throw new UserValidationException("Access denied. Unresolved email.");

            var incomingPasswordHash = _passwordHash.EncryptPassword(userDto.Password, user.Id.ToByteArray());

            if (incomingPasswordHash != user.Password)
            {
                throw new UserValidationException("Access denied. Incorrect password.");
            }

            return _mapper.Map<User, UserDto>(user);
        }

        public UserDto CreateUser(UserDto userDto)
        {
            if (userDto is null)
            {
                throw new UserValidationException("Access denied. Unresolved user from request body.");
            }

            var user = _mapper.Map<UserDto, User>(userDto);

            user.Id = Guid.NewGuid();
            user.Password = _passwordHash.EncryptPassword(user.Password, user.Id.ToByteArray());
            user.Role = RoleNames.User;

            _database.Users.Insert(user);
            _database.Save();

            return _mapper.Map<User, UserDto>(user);
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _database.Users.Get().ToList();
            var usersDto = _mapper.Map<List<User>, List<UserDto>>(users);
            return usersDto;
        }

        public UserDto EditUser(UserDto userDto, Guid id)
        {
            var user = _mapper.Map<UserDto, User>(userDto);
            var patchUser = _database.Users.GetByID(id);

            patchUser.EMail = user.EMail;
            patchUser.Name = user.Name;
            patchUser.Password = _passwordHash.EncryptPassword(user.Password, id.ToByteArray());
            patchUser.Role = user.Role;

            _database.Users.Update(patchUser);
            _database.Save();

            return _mapper.Map<User, UserDto>(patchUser); 
        }
    }
}
