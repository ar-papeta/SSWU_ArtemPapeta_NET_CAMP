using AutoMapper;
using BLL.Models;
using DAL.Entities;
using MoviesStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenreDto, Genre>();
            CreateMap<DirectorDto, Director>();
            CreateMap<MovieDto, Movie>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Director, DirectorDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserViewModel, UserDto>();
            CreateMap<UserDto, UserViewModel>();

            CreateMap<AuthenticationRequest, UserDto>();
            CreateMap<UserDto, AuthenticationRequest>();
        }
    }
}
