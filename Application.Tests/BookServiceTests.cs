using Application.Authors;
using Application.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    //TODO: Why are some guids mixed case(bookId) while others are all caps (author id)?
    public class BookServiceTests
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private string authorId;
        public BookServiceTests()
        {
            _bookService = TestUtils.ConstructorUtils.bookService;
            _authorService = TestUtils.ConstructorUtils.authorService;
            authorId = _authorService.GetAuthors(new AuthorResourceParameters { City = "Berkeley", State = "CA" }).First().Id;
        }
        [Fact]
        public void GetBooksForAuthor()
        {
            var res = _bookService.GetBooksForAuthor(authorId);
            Assert.IsType<List<BookDto>>(res);
        }

        [Fact]
        public void GetBookForAuthor()
        {
            string bookId = _bookService.GetBooksForAuthor(authorId).First().Id;
            var res = _bookService.GetBook(bookId);
            Assert.IsType<BookDto>(res);
        }

        [Fact]
        public void GetBooks()
        {
            var res = _bookService.GetBooks();
            Assert.IsType<List<BookDto>>(res);
        }

        [Fact]
        public void GetBooksFiltered()
        {
            var resourceParams = new BookResourceParameters { Genre = "fic_fant" };
            var res = _bookService.GetBooks(resourceParams);
            Assert.IsType<List<BookDto>>(res);
        }


        [Fact]
        public void CreateBooks()
        {

            var bookList = new List<BookForCreationDto>();
            var book = TestUtils.ObjectMocks.GetBookForCreation(authorId);
            bookList.Add(book);
            var res = _bookService.CreateBooks(bookList, book.AuthorId);
            Assert.IsType<List<BookDto>>(res);
        }

        [Fact]

        public void UpdateBook()
        {
            var book = new BookForUpdateDto { AuthorId = authorId, BookId = Guid.NewGuid().ToString(), Price = 20, PublishedDate = DateTime.UtcNow, Title = "The Mon'ks Ferrari", Genre = "nf_self" };
            var res = _bookService.UpdateBook(book);
        }


    }
}
