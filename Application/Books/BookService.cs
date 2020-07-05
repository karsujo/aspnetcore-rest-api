using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }

        public BookDto GetBook(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetBooks(IEnumerable<string> Ids)
        {
            throw new NotImplementedException();
        }
    }
}
