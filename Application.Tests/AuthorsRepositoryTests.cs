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

namespace Application.Tests
{
    public class AuthorsRepositoryTests
    {

        private readonly SqlRepositoryBase _repo;
        private readonly AuthorRepository _auRepo;

        public AuthorsRepositoryTests()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AuthorDbProfile());
                opt.AddProfile(new BookDbProfile());
            });

            var mapper = config.CreateMapper();

            var test = mapper.Map<Author>(new AuthorDbEntity());

            var opt = Options.Create(new PersistenceConfigurations());

            opt.Value.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pubs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _repo = new SqlRepositoryBase(opt);
            _auRepo = new AuthorRepository(_repo, mapper);
        }
        [Fact]
        public void GetAuthorsTest()
        {

            var result = _auRepo.GetAuthors();
            Assert.IsType<List<Author>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]

        public void GetAuthor()
        {
            var result = _auRepo.GetAuthor("267-41-2394");
            Assert.IsType<Author>(result);
        }
    }
}
