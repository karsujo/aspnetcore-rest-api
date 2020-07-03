using Application.Common;
using Microsoft.Extensions.Options;
using Moq;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Xunit;
using Xunit.Abstractions;

namespace Infrastructure.Tests
{
    public class RepositoryBaseTests
    {

        private RepositoryBase _repo;

        public RepositoryBaseTests()
        {
            var opt = Options.Create(new PersistenceConfigurations());
            opt.Value.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pubs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _repo = new RepositoryBase(opt);
        }
        [Fact]
        public void DbConnectionTest()
        {        
            Assert.IsType<SqlConnection>(_repo.GetDbConnection());
        }

        [Fact]
        public void QueryDatabaseGenericTest()
        {
            string sql = "SELECT * FROM AUTHORS";
            var result = _repo.QueryDatabase<Author>(sql);
            Assert.IsType<List<Author>>(result);
            Assert.NotEmpty(result);
        }
    }
}
