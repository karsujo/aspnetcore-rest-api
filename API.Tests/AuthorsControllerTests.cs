using Application.Common;
using AutoMapper;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.Extensions.Options;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Authors;
using OdysseyPublishers.Infrastructure.Common;
using System.Collections.Generic;
using Xunit;

namespace API.Tests
{
    public class AuthorsControllerTests
    {
        private readonly IAuthorRepository authorsRepository;
        public AuthorsControllerTests()
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

            authorsRepository = new AuthorRepository(new SqlRepositoryBase(opt), mapper);
        }

        [Fact]
        public void GetAuthorsTest()
        {
            var res = authorsRepository.GetAuthors();

            Assert.IsType<List<Author>>(res);

        }
    }
}
