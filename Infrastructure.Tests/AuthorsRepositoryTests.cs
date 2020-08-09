using Application.Authors;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Authors;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Infrastructure.Tests
{
    public class AuthorsRepositoryTests
    {

        private readonly AuthorRepository _auRepo;

        public AuthorsRepositoryTests()
        {
            _auRepo = TestUtils.ConstructorUtils.authorRepo;
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
            string authorId = _auRepo.GetAuthors().First().AuthorId;
            var result = _auRepo.GetAuthor(authorId);
            Assert.IsType<Author>(result);
        }

        [Fact]

        public void AuthorExists()
        {
            string authorId = _auRepo.GetAuthors().First().AuthorId;
            var result = _auRepo.AuthorExists(authorId);
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
