using BLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviesStore.Auth.Authentication;
using MoviesStore.Auth.Authorization.Handlers;
using MoviesStore.Auth.Authorization.Requirements;
using MoviesStore.Middlewares;
using MoviesStore.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace MoviesStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMovieServices(Configuration);
            services.AddScoped<IAuthorizationHandler, RoleAuthorizationHandler>();
            services.AddScoped<ITokenFactory, TokenFactory>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetJwtIssuer(),
                    ValidAudience = Configuration.GetJwtAudience(),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetJwtKey()))
                };
            });

            services.AddAuthorization(options =>
            {
                foreach (var permission in Configuration.GetJwtPermissions())
                {
                    options.AddPolicy(permission, builder =>
                        builder.AddRequirements(new RoleAuthorizationRequiment(permission)));
                }
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviesStore", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesStore v1"));
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
           
            //app.UseMiddleware<ValidateApiMiddleware>(Configuration.GetApiKey());
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class ConfigExtention
    {
        public static string[] GetJwtPermissionsForRole(this IConfiguration configuration, string role)
        {
            return configuration.GetSection("RolePermissions")
                .Get<List<RolePermissions>>()
                .Find(x => x.Role == role).Permissions;
        }
        public static string GetJwtKey(this IConfiguration configuration) => configuration.GetSection("Jwt:Key").Value;
        public static string GetJwtIssuer(this IConfiguration configuration) => configuration.GetSection("Jwt:Issuer").Value;
        public static string GetJwtAudience(this IConfiguration configuration) => configuration.GetSection("Jwt:Audience").Value;
        public static string[] GetJwtPermissions(this IConfiguration configuration) => configuration.GetSection("JwtPermissions").Get<string[]>();
        public static string GetJwtInternalIssuer(this IConfiguration configuration) => configuration.GetSection("Jwt:InternalIssuer").Value;
        public static string GetApiKey(this IConfiguration configuration) => configuration.GetSection("SecurityConfig:api_key").Value;
        public static string GetDefaultConnectionString(this IConfiguration configuration) => configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
    }
}
