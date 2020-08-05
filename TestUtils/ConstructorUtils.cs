using Application.Authors;
using Application.Books;
using Application.Common;
using AutoMapper;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.Extensions.Options;
using OdysseyPublishers.API.Controllers;
using OdysseyPublishers.Infrastructure.Authors;
using OdysseyPublishers.Infrastructure.Common;
using System;

namespace TestUtils
{
    //TODO: Optimize design for this class
    public static class ConstructorUtils
    {

        public static IMapper mappings { get; set; } = CreateMapperInstance();
        public static IOptions<PersistenceConfigurations> configs { get; set; } = GetPersistenceConfigs();

        private static SqlRepositoryBase baseRepo { get; set; } = new SqlRepositoryBase(configs);

        public static BookRepository bookRepo { get; set; } = CreateBookRepoInstance();

        public static AuthorRepository authorRepo { get; set; } = CreateAuthorRepoInstance();

        public static BookService bookService { get; set; } = CreateBookServiceInstance();

        public static AuthorService authorService { get; set; } = CreateAuthorServiceInstance();

        public static AuthorsController authorsController { get; set; } = CreateAuthorsControllerInstance();
        private static BooksController booksController { get; set; } = CreateBooksControllerInstance();

        private static BooksController CreateBooksControllerInstance()
        {
            return new BooksController(bookService,authorService);
        }

        private static AuthorsController CreateAuthorsControllerInstance()
        {
            return new AuthorsController(authorService);
        }

        public static IMapper CreateMapperInstance()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new BookDbProfile());
                opt.AddProfile(new AuthorDbProfile());
                opt.AddProfile(new BookDtoProfile());
                opt.AddProfile(new AuthorDtoProfile());

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

        public static BookRepository CreateBookRepoInstance() => new BookRepository(baseRepo, mappings);
        public static AuthorRepository CreateAuthorRepoInstance() => new AuthorRepository(baseRepo, mappings);
        public static BookService CreateBookServiceInstance() => new BookService(bookRepo, mappings);
        public static AuthorService CreateAuthorServiceInstance() => new AuthorService(authorRepo, bookService, mappings);
    }
}
