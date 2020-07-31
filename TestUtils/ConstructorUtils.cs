using Application.Common;
using AutoMapper;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.Extensions.Options;
using OdysseyPublishers.Infrastructure.Authors;
using OdysseyPublishers.Infrastructure.Common;
using System;
using Xunit;

namespace TestUtils
{
    public static class ConstructorUtils
    {
        public static IMapper CreateMapperInstance()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new BookDbProfile());
                opt.AddProfile(new AuthorDbProfile());

            });

            return config.CreateMapper();
        }

        public static IOptions<PersistenceConfigurations> GetPersistenceConfigs(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Odyssey;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }

            var opt = Options.Create(new PersistenceConfigurations());

            opt.Value.ConnectionString = connectionString;

            return opt;

        }

        public static BookRepository CreateBookRepoInstance()
        {
            var _repo = new SqlRepositoryBase(GetPersistenceConfigs());
           return new BookRepository(_repo, CreateMapperInstance());
        }

        public static AuthorRepository CreateAuthorInstance()
        {

            var _repo = new SqlRepositoryBase(GetPersistenceConfigs());
            return new AuthorRepository(_repo, CreateMapperInstance());

        }
    }
    }
