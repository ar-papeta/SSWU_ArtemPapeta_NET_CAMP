using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options) { }
            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.EMail).IsUnique();
            modelBuilder.Entity<Director>().HasIndex(u => u.FullName).IsUnique();

            var initialGenres = new List<Genre>()
            {
                new Genre
                {
                    Name = "Action",
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                },
                new Genre
                {
                    Name = "Artem Artemov",
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                },
                new Genre
                {
                    Name = "Artem Artemov",
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                }
            };

            var initialMovie = new Movie
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000031"),
                Description = "Test 1 movie",
                ReleaseDate = DateTime.Now,
                Title = "Movie tite 1",
            };

            var initialUserAdmin = new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                EMail = "artem@gmail.com",
                Name = "Artem",
                Role = RoleNames.Admin,
                Password = "Owve1iNLlEKKrO3hQplQLBNN3TfIkzMEXwF8EkikVN4="
            };

            modelBuilder.Entity<User>().HasData(initialUserAdmin);
            modelBuilder.Entity<Movie>().HasData(initialMovie);
            modelBuilder.Entity<Genre>().HasData(initialGenres[0]); 
        }  
    }
}
