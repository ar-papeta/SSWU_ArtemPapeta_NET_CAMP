using DAL;
using DAL.Entities;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MoviesStore.Tests.Repositories.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesStore.Tests.Repositories
{
    public class GenericRepositoryTest
    {
        [Fact]
        public void Get_ShouldReturnCorrectListOfObjects()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase("FakeDatabaseForGet")
                .Options;

            using var context = new StoreContext(options);
            foreach (var comment in SeedComments.Comments)
            {
                context.Comments.Add(comment);
            }
            context.SaveChanges();

            var repository = new GenericRepository<Comment>(context);
            var actual = repository.Get();

            actual.Should().BeEquivalentTo(SeedComments.Comments);
        }

        [Theory]
        [MemberData(nameof(GetByIDTestData))]
        public void GetByID_ShouldReturnCorrectObjects(Guid guid)
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase("FakeDatabaseForGetById")
                .Options;

            using var context = new StoreContext(options);
            foreach (var comment in SeedComments.Comments)
            {
                context.Comments.Add(comment);
            }

            var repository = new GenericRepository<Comment>(context);
            var actual = repository.GetByID(guid);

            actual.Should().BeEquivalentTo(SeedComments.Comments.Find(g => g.Id == guid));
        }

        [Fact]
        public void DeleteByID_ShouldReturnCorrectListOfObjects()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase("FakeDatabaseForDelete")
                .Options;

            using var context = new StoreContext(options);

            foreach (var comment in SeedComments.Comments)
            {
                context.Comments.Add(comment);
            }
            var guidToDelete = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var repository = new GenericRepository<Comment>(context);

            repository.Delete(guidToDelete);
            context.SaveChanges();
            

            var actual = repository.Get();
            var expected = SeedComments.Comments.Except(SeedComments.Comments.Where(g => g.Id == guidToDelete));
            
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Update_ShouldReturnCorrectListOfObjects()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase("FakeDatabaseForUpdate")
                .Options;

            using var context = new StoreContext(options);

            foreach (var comment in SeedComments.Comments)
            {
                context.Comments.Add(comment);
            }
            context.SaveChanges();

            var repository = new GenericRepository<Comment>(context);

            Comment commentToUpdate = repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));
            commentToUpdate.Body = "NEW COMMENT BODY";
            repository.Update(commentToUpdate);

            context.SaveChanges();

            var actual = repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

            var expected = "NEW COMMENT BODY";

            actual.Body.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> GetByIDTestData =>
        new List<object[]>
        {
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000001") },
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000002") },
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000003") },
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000004") },
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000005") },
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000006") },
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000007") },
            new object[] { Guid.Parse("00000000-0000-0000-0000-000000000008") },
        };
    }  
}
