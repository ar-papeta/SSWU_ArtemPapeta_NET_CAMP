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
    public class DirectorService : IDirectorService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public DirectorService(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public DirectorDto CreateDirector(DirectorDto directorDto)
        {
            _ = directorDto ?? throw new ArgumentNullException(nameof(directorDto));

            var director = _mapper.Map<DirectorDto, Director>(directorDto);
            director.Id = Guid.NewGuid();
            _database.Directors.Insert(director);
            _database.Save();

            return directorDto;
        }
    }
}
