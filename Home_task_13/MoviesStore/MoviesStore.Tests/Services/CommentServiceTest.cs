using AutoMapper;
using BLL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Helpers.CustomExceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace MoviesStore.Tests.Services
{
    public class CommentServiceTest
    {
        private readonly CommentService _service;
        private readonly IUnitOfWork _uowMock;
        public CommentServiceTest()
        {
            _uowMock = A.Fake<IUnitOfWork>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var fakeMapper = mockMapper.CreateMapper();

            _service = new(_uowMock, fakeMapper);

        }



        [Fact]
        public void DeleteComment_WithNullCommentDto_ShoudThrowException()
        {
            A.CallTo(() => _uowMock.Comments.GetByID(A<Guid?>._))
           .Returns(null);

            Assert.Throws<NotFoundException>(() => _service.DeleteComment(Guid.Empty));
        }

        [Theory]
        [MemberData(nameof(CreateCommentTestData))]
        public void CreateComment_WithParent_ShoudContainParentNameInBody(CommentDto fakeComment, Comment fakeParentComment)
        {
            A.CallTo(() => _uowMock.Comments.GetByID(A<Guid?>._))
            .Returns(fakeParentComment);

            var expectedCommentBody = fakeComment.Body.Insert(0, $"[{fakeParentComment?.Username}], ");

            var actualComment = _service.CreateComment(fakeComment, Guid.Empty);
            
            Assert.Equal(expectedCommentBody, actualComment.Body);
        }

        [Theory]
        [MemberData(nameof(GetMovieCommentTestData))]
        public void GetMovieComments_ShoudReturnTreeBasedList(List<Comment> fakeMovieComments, List<CommentDto> expectedCommentsDtoTree)
        {
            A.CallTo(() => _uowMock.Comments.Get(A<Expression<Func<Comment, bool>>>._))
            .Returns(fakeMovieComments);

            var actualCommentsDtoTree = _service.GetMovieComments(Guid.Empty);

            actualCommentsDtoTree.Should().BeEquivalentTo(expectedCommentsDtoTree);
        }

        public static IEnumerable<object[]> DeleteCommentTestData =>
        new List<object[]>
        {
            new object[]
            {
                null,
            },
        };

        public static IEnumerable<object[]> CreateCommentTestData =>
        new List<object[]>
        {
            new object[]
            {
                new CommentDto()
                {
                    Body = "comment body"
                },
                new Comment()
                {
                    Username ="Parent username"
                }
            },
        };

        public static IEnumerable<object[]> GetMovieCommentTestData()
        {
            Comment c1 = new ()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Username = "1",
                ParentCommentId = null
            };
            Comment c2 = new ()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Username = "2",
                ParentCommentId = c1.Id,
            };
            Comment c3 = new ()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Username = "3",
                ParentCommentId = c1.Id
            };
            Comment c4 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Username = "4",
                ParentCommentId = c1.Id
            };
            Comment c5 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Username = "5",
                ParentCommentId = c3.Id
            };
            Comment c6 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Username = "6",
                ParentCommentId = c3.Id
            };
            Comment c7 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Username = "7",
                ParentCommentId = null
            };
            Comment c8 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Username = "8",
                ParentCommentId = null
            };

            

            CommentDto cDto1 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Username = "1",
                ParentCommentId = null
            };
            CommentDto cDto2 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Username = "2",
                ParentCommentId = c1.Id,
                ParentComment = cDto1
            };
            CommentDto cDto3 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Username = "3",
                ParentCommentId = c1.Id,
                ParentComment = cDto1
            };
            CommentDto cDto4 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Username = "4",
                ParentCommentId = c1.Id,
                ParentComment = cDto1
            };
            CommentDto cDto5 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Username = "5",
                ParentCommentId = c3.Id,
                ParentComment = cDto3
            };
            CommentDto cDto6 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Username = "6",
                ParentCommentId = c3.Id,
                ParentComment = cDto3
            };
            CommentDto cDto7 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Username = "7",
                ParentCommentId = null
            };
            CommentDto cDto8 = new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Username = "8",
                ParentCommentId = null
            };

            List<Comment> comments = new() { c1, c2, c3, c4, c5, c6, c7, c8 };

            List<CommentDto> commentsDto = new() {  cDto2, cDto4, cDto5, cDto6, cDto7, cDto8 };

            return new List<object[]>
            {
                new object[]
                {
                    comments,
                    commentsDto
                },
            };
        }
        
    }
}
