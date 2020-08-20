using Application.Books;
using Infrastructure.Books;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using TestUtils;
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
            string authorId = _auRepo.GetAuthors().First().AuthorId;
            var res = _bkRepo.GetBooksForAuthor(authorId);
            Assert.IsType<List<Book>>(res);
        }


        [Fact]

        public void BookExists()
        {
            string bookId = _bkRepo.GetBooks().First().BookId;
            var res = _bkRepo.BookExists(bookId);
            Assert.IsType<bool>(res);

        }

        [Fact]

        public void CreateBook()
        {
            string authorId = _auRepo.GetAuthors().First().AuthorId;
            string bookId = Guid.NewGuid().ToString();
            var book = new BookForCreationDto { AuthorId = authorId, BookId = bookId, Price = 20, PublishedDate = DateTime.UtcNow, Title = "The Mon'ks Ferrari", Genre = "nf_self" };
            _bkRepo.CreateBook(book);
            var createdBook = _bkRepo.GetBook(bookId);
            Assert.NotNull(createdBook);
            DeleteBookHelper(bookId);
        }

        [Fact]
        public void UpdateBook()
        {
            string authorId = _auRepo.GetAuthors().First().AuthorId;
            dynamic book = null;
            string bookId = null;

            CreateBookHelper(out book, out bookId, authorId);
            var updateBook = ObjectMocks.GetBookForUpdate(authorId, bookId);

            _bkRepo.UpdateBook(updateBook);

            var updatedBook = _bkRepo.GetBook(bookId);
            Assert.Equal(updatedBook.Title, updateBook.Title);

            DeleteBookHelper(bookId);
        }

        [Fact]
        public void DeleteBook()
        {
            string bookId = _bkRepo.GetBooks().First().BookId;
            _bkRepo.DeleteBook(bookId);
            Assert.Null(_bkRepo.GetBook(bookId));
        }

        private void CreateBookHelper(out dynamic book, out string bookId, string authorId)
        {
            bookId = Guid.NewGuid().ToString();
            book = ObjectMocks.GetBookForCreation(authorId, bookId);
            _bkRepo.CreateBook(book);
        }

        private void DeleteBookHelper(string bookId)
        {
            _bkRepo.DeleteBook(bookId);
        }


    }
}
