using Application.Books;
using Infrastructure.Books;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Infrastructure.Tests
{
    public class BookRepositoryTests
    {
        private readonly BookRepository _bkRepo;

        public BookRepositoryTests()
        {
            _bkRepo = TestUtils.ConstructorUtils.bookRepo;
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
            string bookId = "08180BDA-CC8F-4B05-A441-AA2DE0280558";
            var res = _bkRepo.GetBookForAuthor(bookId);
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
            var book = new BookForCreationDto { AuthorId = "10908F6C-3480-4F2E-AB6B-AE3EBD86A45A", BookId = Guid.NewGuid().ToString(), Price = 20, PublishedDate = DateTime.UtcNow, Title = "The Mon'ks Ferrari", Type = "nf_self" };
            _bkRepo.CreateBook(book);

        }
    }
}
