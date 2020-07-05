using System;

namespace OdysseyPublishers.Domain.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string book, Exception ex) : base($"Book with Id: {book} not found ", ex) { }
    }
}
