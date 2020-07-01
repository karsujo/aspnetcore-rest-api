using System;
using System.Collections.Generic;
using System.Text;

namespace OdysseyPublishers.Domain.Exceptions
{
    public class BookNotFoundException :Exception
    {
        public BookNotFoundException(string book, string author, Exception ex) : base($"Book : {book} not found for author : {author}", ex) { }
    }
}
