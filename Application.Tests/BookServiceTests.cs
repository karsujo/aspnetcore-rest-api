using Application.Books;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.Tests
{
    //TODO: Why are some guids mixed case(bookId) while others are all caps (author id)?
    public class BookServiceTests
    {
        private readonly IBookService _bookService;
        public BookServiceTests()
        {
            _bookService = TestUtils.ConstructorUtils.bookService;
        }
        [Fact]
        public void GetBooksForAuthor()
        {
            var res = _bookService.GetBooksForAuthor("10908F6C-3480-4F2E-AB6B-AE3EBD86A45A");
            Assert.IsType<List<BookDto>>(res);          
        }

        [Fact]
        public void GetBookForAuthor()
        {
            var res = _bookService.GetBookForAuthor("1b62e232-0625-4b00-a135-f97ff241c052");
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

        }


        [Fact]
        public void CreateBooks()
        {
           
            var bookList = new List<BookForCreationDto>();
            bookList.Add(TestUtils.ObjectMocks.GetBookForCreation());
            var res = _bookService.CreateBooks(bookList, Guid.NewGuid().ToString());
            Assert.IsType<List<BookDto>>(res);
        }

    
    }
}
