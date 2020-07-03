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

        private SqlRepositoryBase _repo;

        public RepositoryBaseTests()
        {
            var opt = Options.Create(new PersistenceConfigurations());
            opt.Value.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pubs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _repo = new SqlRepositoryBase(opt);
        }
        [Fact]
        public void DbConnectionTest()
        {        
            Assert.IsType<SqlConnection>(_repo.GetDbConnection());
        }

        [Fact]
        public void QueryDatabaseGenericTest()
        {
            string sql = @"SELECT 
              au_id AuthorId,
              au_fname FirstName, 
              au_lname LastName,
              phone,
              address,
              city,
              state,
              zip,
              contract
            FROM
              AUTHORS ";
            var result = _repo.QueryDatabase<Author>(sql);
            Assert.IsType<List<Author>>(result);
            Assert.NotEmpty(result);
        }
    }
}
