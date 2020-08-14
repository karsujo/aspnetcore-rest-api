using System.Collections.Generic;

namespace Application.Books
{
    public interface IBookService
    {
        BookDto GetBook(string Id);

        IEnumerable<BookDto> GetBooks(BookResourceParameters bookResourceParameters);
        IEnumerable<BookDto> GetBooks();
        IEnumerable<BookDto> GetBooksForAuthor(string authorId);
        bool BookExists(string bookId);

        IEnumerable<BookDto> CreateBooks(IEnumerable<BookForCreationDto> bookForCreationDtos, string authorId);

        BookDto UpdateBook(BookForUpdateDto book, string authorId, string bookId);


    }
}
