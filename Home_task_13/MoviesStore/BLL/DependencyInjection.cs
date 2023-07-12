using BLL.Services;
using BLL.Services.Helpers;
using BLL.Services.Helpers.Interfaces;
using BLL.Services.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMovieServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration);

            services.AddHttpContextAccessor();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHash, PasswordHash>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IDirectorService, DirectorService>();
            return services;
        }
    }
}
