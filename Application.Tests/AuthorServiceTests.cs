using Application.Authors;
using Application.Books;
using System;
using System.Collections.Generic;
using System.Text;
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
            var res = _authorService.GetAuthor("10908F6C-3480-4F2E-AB6B-AE3EBD86A45A");
            Assert.IsType<AuthorDto>(res);
        }

        [Fact]

        public void AuthorExists()
        {
            var res = _authorService.AuthorExists("10908F6C-3480-4F2E-AB6B-AE3EBD86A45A");
            Assert.True(res);
        }

        [Fact]

        public void GetAuthors()
        {
            var para = new AuthorResourceParameters{ City = "Berkeley", State="CA" };
            var res = _authorService.GetAuthors(para);
            Assert.IsType<List<AuthorDto>>(res);
        }


        [Fact]

        public void CreateAuthor()
        {
            var author = TestUtils.ObjectMocks.GetAuthorForCreation();
            var res = _authorService.CreateAuthor(author, Guid.NewGuid().ToString());
        }




    }
}
