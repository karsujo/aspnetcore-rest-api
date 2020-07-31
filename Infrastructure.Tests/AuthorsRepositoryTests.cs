using Application.Authors;
using Application.Common;
using AutoMapper;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.Extensions.Options;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Authors;
using OdysseyPublishers.Infrastructure.Common;
using System.Collections.Generic;
using Xunit;

namespace Infrastructure.Tests
{
    public class AuthorsRepositoryTests
    {

        private readonly AuthorRepository _auRepo;

        public AuthorsRepositoryTests()
        {
            _auRepo = TestUtils.ConstructorUtils.CreateAuthorInstance();
        }
         
        [Fact]
        public void GetAuthors()
        {

            var result = _auRepo.GetAuthors();
            Assert.IsType<List<Author>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]

        public void GetAuthorsFiltered()
        {
            AuthorResourceParameters resourceParameters = new AuthorResourceParameters { State = "CA", City = "Oakland" };
            var result = _auRepo.GetAuthors(resourceParameters);
            Assert.IsType<List<Author>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]

        public void GetAuthor()
        {
            var result = _auRepo.GetAuthor("10908F6C-3480-4F2E-AB6B-AE3EBD86A45A");
            Assert.IsType<Author>(result);
        }

        [Fact]

        public void AuthorExists()
        {
            var result = _auRepo.AuthorExists("10908F6C-3480-4F2E-AB6B-AE3EBD86A45A");
            Assert.IsType<bool>(result);
        }

        [Fact]

        public void CreateAuthor()
        {
            var model = new AuthorForCreationDto { Address = "Taxi Drive", City = "Bangalore", FirstName = "Randi", LastName = "Ortan", Phone = "1542589", State = "KA", Zip = "50681" };
           _auRepo.CreateAuthor(model, System.Guid.NewGuid().ToString());
        }

    
    }
}
