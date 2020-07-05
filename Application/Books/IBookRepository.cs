using OdysseyPublishers.Domain;
using System.Collections.Generic;

namespace Application.Books
{
    public interface IBookRepository
    {
        bool BookExists(string BookId);
        Book GetBook(string BookId);
        IEnumerable<Book> GetBooks();
    }
}