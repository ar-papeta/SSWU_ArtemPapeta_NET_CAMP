using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Tests.Repositories.SeedData
{
    internal static class SeedComments
    {
        internal static Comment comment1 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Username = "1",
            ParentCommentId = null
        };
        internal static Comment comment2 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Username = "2",
            ParentCommentId = comment1.Id,
        };
        internal static Comment comment3 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Username = "3",
            ParentCommentId = comment1.Id
        };
        internal static Comment comment4 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            Username = "4",
            ParentCommentId = comment1.Id
        };
        internal static Comment comment5 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            Username = "5",
            ParentCommentId = comment3.Id
        };
        internal static Comment comment6 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            Username = "6",
            ParentCommentId = comment3.Id
        };
        internal static Comment comment7 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
            Username = "7",
            ParentCommentId = null
        };
        internal static Comment comment8 = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
            Username = "8",
            ParentCommentId = null
        };

        internal static List<Comment> Comments => new()
        {
            comment1,
            comment2,
            comment3,
            comment4,
            comment5,
            comment6,
            comment7,
            comment8
        };
    }
}
