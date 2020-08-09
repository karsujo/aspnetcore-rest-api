using Application.Authors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    public class AuthorServiceTests
    {
        private readonly IAuthorService _authorService;

        public AuthorServiceTests()
        {
            this._authorService = TestUtils.ConstructorUtils.authorService;
        }

        [Fact]
        public void GetAuthor()
        {
            var para = new AuthorResourceParameters { City = "Berkeley", State = "CA" };
            var res = _authorService.GetAuthors(para);
            var resp = _authorService.GetAuthor(res.First().Id);
            Assert.IsType<AuthorDto>(resp);
        }

        [Fact]

        public void AuthorExists()
        {
            var para = new AuthorResourceParameters { City = "Berkeley", State = "CA" };
            var res = _authorService.GetAuthors(para);
            var resp = _authorService.AuthorExists(res.First().Id);
            Assert.True(resp);
        }

        [Fact]

        public void GetAuthors()
        {
            var para = new AuthorResourceParameters { City = "Berkeley", State = "CA" };
            var res = _authorService.GetAuthors(para);
            Assert.IsType<List<AuthorDto>>(res);
        }


        [Fact]

        public void CreateAuthor()
        {
            var author = TestUtils.ObjectMocks.GetAuthorForCreation();
            string json = JsonConvert.SerializeObject(author);
            var res = _authorService.CreateAuthor(author, Guid.NewGuid().ToString());
            Assert.IsType<AuthorDto>(res);
        }




    }
}
