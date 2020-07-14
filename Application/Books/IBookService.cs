using System.Collections.Generic;

namespace Application.Books
{
    public interface IBookService
    {
        BookDto GetBookForAuthor(string Id);

        IEnumerable<BookDto> GetBooks();

        IEnumerable<BookDto> GetBooksForAuthor(string authorId);

        IEnumerable<BookDto> GetBooks(IEnumerable<string> Ids);

    }
}
