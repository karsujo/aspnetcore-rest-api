using System.Collections.Generic;

namespace Application.Books
{
    public interface IBookService
    {
        BookDto GetBookForAuthor(string Id);

        IEnumerable<BookDto> GetBooks(BookResourceParameters bookResourceParameters);
        IEnumerable<BookDto> GetBooks();
        IEnumerable<BookDto> GetBooksForAuthor(string authorId);
        string GenerateBookId();

        public IEnumerable<BookDto> CreateBooks(IEnumerable<BookForCreationDto> bookForCreationDtos, string authorId);


    }
}
