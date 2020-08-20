using Application.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using TestUtils;
using Xunit;

namespace Application.Tests
{
    public class AuthorServiceTests
    {
        private readonly IAuthorService _authorService;

        public AuthorServiceTests()
        {
            _authorService = ConstructorUtils.authorService;
        }

        [Fact]
        public void GetAuthor()
        {

            var res = _authorService.GetAuthors();
            var resp = _authorService.GetAuthor(res.First().Id);
            Assert.IsType<AuthorDto>(resp);
        }

        [Fact]
        public void GetAuthorFiltered()
        {
            var para = new AuthorResourceParameters { City = "Massachussets", State = "MA" };
            var res = _authorService.GetAuthors(para);
            var resp = _authorService.GetAuthor(res.First().Id);
            Assert.IsType<AuthorDto>(resp);
        }

        [Fact]

        public void AuthorExists()
        {
            var para = new AuthorResourceParameters { City = "Massachussets", State = "MA" };
            var res = _authorService.GetAuthors(para);
            var resp = _authorService.AuthorExists(res.First().Id);
            Assert.True(resp);
        }

        [Fact]

        public void GetAuthors()
        {
            var para = new AuthorResourceParameters { City = "Massachussets", State = "MA" };
            var res = _authorService.GetAuthors(para);
            Assert.IsType<List<AuthorDto>>(res);
        }


        [Fact]

        public void CreateAuthor()
        {
            string authorId;
            dynamic author;
            CreateAuthorHelper(out authorId, out author);
            Assert.IsType<AuthorForCreationDto>(author);
            var createdAuthor = _authorService.GetAuthor(authorId);
            Assert.Equal(author.Address, createdAuthor.Address);
            DeleteAuthorHelper(authorId);
        }

        [Fact]
        public void UpdateAuthor()
        {
            string authorId;
            CreateAuthorHelper(out authorId, out _);
            string bookId = _authorService.GetAuthor(authorId).Books.First().Id;
            var updateAuthor = ObjectMocks.GetAuthorForUpdate(authorId, bookId);
            _authorService.UpdateAuthor(updateAuthor);
            var updatedAuthor = _authorService.GetAuthor(authorId);
            Assert.Contains(updateAuthor.LastName, updatedAuthor.Name);
            DeleteAuthorHelper(authorId);

        }
        [Fact]

        public void DeleteAuthor()
        {
            string authorId;
            CreateAuthorHelper(out authorId, out _);
            _authorService.DeleteAuthor(authorId);
            Assert.Null(_authorService.GetAuthor(authorId));
        }

        private void CreateAuthorHelper(out string authorId, out dynamic author)
        {
            authorId = Guid.NewGuid().ToString();
            author = ObjectMocks.GetAuthorForCreation(authorId);
            _authorService.CreateAuthor(author, authorId);
        }

        private void DeleteAuthorHelper(string authorId)
        {
            _authorService.DeleteAuthor(authorId);
        }


    }
}
