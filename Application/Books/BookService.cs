using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
    }
}
