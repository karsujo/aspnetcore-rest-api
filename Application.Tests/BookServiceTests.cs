using Application.Authors;
using Application.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using TestUtils;
using Xunit;

namespace Application.Tests
{
    //TODO: Why are some guids mixed case(bookId) while others are all caps (author id)?
    public class BookServiceTests
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly string authorId;
        public BookServiceTests()
        {
            _bookService = TestUtils.ConstructorUtils.bookService;
            _authorService = TestUtils.ConstructorUtils.authorService;
            authorId = _authorService.GetAuthors(new AuthorResourceParameters { City = "Salt Lake City", State = "UT" }).First().Id;
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
            var resourceParams = new BookResourceParameters { Genre = "fic_fantasy" };
            var res = _bookService.GetBooks(resourceParams);
            Assert.IsType<List<BookDto>>(res);
        }


        [Fact]
        public void CreateBooks()
        {

            var bookList = new List<BookForCreationDto>();
            var book = TestUtils.ObjectMocks.GetBookForCreation(authorId, Guid.NewGuid().ToString());
            bookList.Add(book);
            var res = _bookService.CreateBooks(bookList, book.AuthorId);
            Assert.IsType<List<BookDto>>(res);
        }

        [Fact]

        public void UpdateBook()
        {
            dynamic books;
            string bookId;
            CreateBookHelper(out books, out bookId, authorId);
            var updateBook = ObjectMocks.GetBookForUpdate(authorId, bookId);
            _bookService.UpdateBook(updateBook);
            var updatedBook = _bookService.GetBook(bookId);
            Assert.Equal(updateBook.Title, updateBook.Title);
            DeleteBookHelper(bookId);


        }

        [Fact]

        public void DeleteBook()
        {
            dynamic books;
            string bookId;
            CreateBookHelper(out books, out bookId, authorId);
            _bookService.DeleteBook(bookId);
            Assert.Null(_bookService.GetBook(bookId));
        }

        private void CreateBookHelper(out dynamic books, out string bookId, string authorId)
        {

            books = new List<BookForCreationDto>();
            bookId = Guid.NewGuid().ToString();
            var book = TestUtils.ObjectMocks.GetBookForCreation(authorId, bookId);
            books.Add(book);
            _bookService.CreateBooks(books, authorId);
        }

        private void DeleteBookHelper(string bookId)
        {
            _bookService.DeleteBook(bookId);
        }


    }
}
