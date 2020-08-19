using OdysseyPublishers.Domain;
using System.Collections.Generic;

namespace Application.Books
{
    public interface IBookRepository
    {
        bool BookExists(string BookId);
        Book GetBook(string BookId);
        IEnumerable<Book> GetBooksForAuthor(string authorId);
        IEnumerable<Book> GetBooks(BookResourceParameters bookResourceParameters);
        IEnumerable<Book> GetBooks();
        void CreateBook(BookForCreationDto book);
        void UpdateBook(BookForUpdateDto book);
        void DeleteBook(string bookId);



    }
}