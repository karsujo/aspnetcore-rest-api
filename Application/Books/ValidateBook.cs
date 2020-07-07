using OdysseyPublishers.Domain;
using OdysseyPublishers.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books
{
    public static class ValidateBook
    {

        public static void Validate(this Book book)
        {
            if (book == null) throw new BookNotFoundException(book.BookId, null);
        }
    }
}
