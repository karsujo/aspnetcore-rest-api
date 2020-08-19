using Application.Authors;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using TestUtils;
using Xunit;

namespace Infrastructure.Tests
{
    public class AuthorsRepositoryTests
    {

        private readonly AuthorRepository _auRepo;
        private readonly IMapper mapper;

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
            string authorId;
            CreateAuthorHelper(out _, out authorId);           
            var getAuthor = _auRepo.GetAuthor(authorId);
            Assert.IsType<Author>(getAuthor);
            Assert.NotNull(getAuthor);
            DeleteAuthorHelper(authorId);
        }

        [Fact]

        public void DeleteAuthor()
        {
            string authorId;
            CreateAuthorHelper(out _, out authorId);
            _auRepo.DeleteAuthor(authorId);
            var getAuthor = _auRepo.GetAuthor(authorId);
            Assert.Null(getAuthor);
        }

        [Fact]

        public void UpdateAuthor()
        {
            string authorId;
            AuthorForCreationDto author;
            CreateAuthorHelper(out author, out authorId);
            var updateAuthor = ObjectMocks.GetAuthorForUpdate();
           _auRepo.UpdateAuthor(updateAuthor);
            var updatedAuthor = _auRepo.GetAuthor(authorId);
            Assert.Equal(updatedAuthor.LastName, updateAuthor.LastName);
            DeleteAuthorHelper(authorId);

        }

        private void CreateAuthorHelper(out AuthorForCreationDto model, out string authorId)
        {
              authorId = System.Guid.NewGuid().ToString();
            string bookId = Guid.NewGuid().ToString();
            model = ObjectMocks.GetAuthorForCreation(authorId,bookId);
            _auRepo.CreateAuthor(model, authorId);
       
        }

        private void DeleteAuthorHelper(string authorId)
        {
            _auRepo.DeleteAuthor(authorId);
        }


    }
}
