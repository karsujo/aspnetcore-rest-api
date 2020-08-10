using Application.Books;
using Infrastructure.Books;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Infrastructure.Tests
{
    public class BookRepositoryTests
    {
        private readonly BookRepository _bkRepo;
        private readonly AuthorRepository _auRepo;

        public BookRepositoryTests()
        {
            _bkRepo = TestUtils.ConstructorUtils.bookRepo;
            _auRepo = TestUtils.ConstructorUtils.authorRepo;
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
            string bookId = _bkRepo.GetBooks().First().BookId;
            var res = _bkRepo.GetBook(bookId);
            Assert.IsType<Book>(res);
        }

        [Fact]

        public void GetAuthorBook()
        {
            string authorId = "7CE7D8A4-8620-4222-B3C8-CE84DA685C13";
            var res = _bkRepo.GetBooksForAuthor(authorId);
            Assert.IsType<List<Book>>(res);
        }


        [Fact]

        public void BookExists()
        {
            string bookId = "BU1032";
            var res = _bkRepo.BookExists(bookId);
            Assert.IsType<bool>(res);

        }

        [Fact]

        public void CreateBook()
        {
            string authorId = _auRepo.GetAuthors().First().AuthorId;
            var book = new BookForCreationDto { AuthorId = authorId, BookId = Guid.NewGuid().ToString(), Price = 20, PublishedDate = DateTime.UtcNow, Title = "The Mon'ks Ferrari", Genre = "nf_self" };
            _bkRepo.CreateBook(book);
        }
    }
}
