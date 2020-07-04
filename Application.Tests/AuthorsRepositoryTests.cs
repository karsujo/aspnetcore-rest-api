using Application.Common;
using Microsoft.Extensions.Options;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Common;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests
{
    public class AuthorsRepositoryTests
    {

        private readonly SqlRepositoryBase _repo;
        private readonly AuthorsRepository _auRepo;

        public AuthorsRepositoryTests()
        {
            var opt = Options.Create(new PersistenceConfigurations());
            opt.Value.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pubs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _repo = new SqlRepositoryBase(opt);
            _auRepo = new AuthorsRepository(_repo);
        }
        [Fact]
        public void GetAuthorsTest()
        {

            var result = _auRepo.GetAuthors();
            Assert.IsType<List<Author>>(result);
            Assert.NotEmpty(result);
        }
    }
}
