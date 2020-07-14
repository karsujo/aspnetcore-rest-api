using Application.Common;
using AutoMapper;
using Infrastructure.Books;
using Microsoft.Extensions.Options;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Infrastructure.Tests
{
    public class BookRepositoryTests
    {
        private readonly SqlRepositoryBase _repo;
        private readonly BookRepository _bkRepo;

        public BookRepositoryTests()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new BookDbProfile());
                opt.AddProfile(new BookDbProfile());
            });

            var mapper = config.CreateMapper();

            var test = mapper.Map<Book>(new BookDbEntity());

            var opt = Options.Create(new PersistenceConfigurations());

            opt.Value.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pubs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _repo = new SqlRepositoryBase(opt);
            _bkRepo = new BookRepository(_repo, mapper);
        }


        [Fact]
        public void GetBooks()
         {
            var res = _bkRepo.GetBooks();
            Assert.IsType<List<Book>>(res);
        }


        [Fact]
        public void GetBook()
        {
            string bookId = "BU1032";
            var res = _bkRepo.GetBookForAuthor(bookId);
            Assert.IsType<Book>(res);
        }

        [Fact]

        public void GetAuthorBook()
        {
            string authorId = "267-41-2394";
            var res = _bkRepo.GetBooksForAuthor(authorId);
            Assert.IsType<Book>(res);
        }


        [Fact]

        public void BookExists()
        {
            string bookId = "BU1032";
            var res = _bkRepo.BookExists(bookId);
            Assert.IsType<bool>(res);

        }
    }
}
