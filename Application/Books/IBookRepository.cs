using OdysseyPublishers.Domain;
using System.Collections.Generic;

namespace Application.Books
{
    public interface IBookRepository
    {
        bool BookExists(string BookId);
        Book GetBookForAuthor(string BookId);
        IEnumerable<Book> GetBooksForAuthor(string authorId);
        IEnumerable<Book> GetBooks(BookResourceParameters bookResourceParameters);
        IEnumerable<Book> GetBooks();
    }
}