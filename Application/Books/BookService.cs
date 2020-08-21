using AutoMapper;
using System;
using System.Collections.Generic;

namespace Application.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;

        }

        public IEnumerable<BookDto> GetBooksForAuthor(string authorId)
        {
            var res = _bookRepository.GetBooksForAuthor(authorId);
            return _mapper.Map<IEnumerable<BookDto>>(res);
        }

        public BookDto GetBook(string bookId)
        {
            var res = _bookRepository.GetBook(bookId);
            return _mapper.Map<BookDto>(res);
        }


        public bool BookExists(string bookId)
        {
            return _bookRepository.BookExists(bookId);

        }


        public IEnumerable<BookDto> GetBooks(BookResourceParameters bookResourceParameters)
        {
            var res = _bookRepository.GetBooks(bookResourceParameters);
              return _mapper.Map<List<BookDto>>(res);
        }

        //TODO: Make custom Action filters for validation and mapping Ex: DomainMap
        // [DomainMap]
        public IEnumerable<BookDto> GetBooks()
        {
            var res = _bookRepository.GetBooks();
            return _mapper.Map<List<BookDto>>(res);
        }


        public IEnumerable<BookDto> CreateBooks(IEnumerable<BookForCreationDto> bookForCreationDtos, string authorId)
        {
            foreach (var book in bookForCreationDtos)
            {
                book.AuthorId = authorId;
                book.BookId = Guid.NewGuid().ToString();
                _bookRepository.CreateBook(book);
            }

            return _mapper.Map<List<BookDto>>(bookForCreationDtos);
        }

        public BookDto UpdateBook(BookForUpdateDto book)
        {
            _bookRepository.UpdateBook(book);
            return _mapper.Map<BookDto>(book);
        }

        public void DeleteBook(string bookId) => _bookRepository.DeleteBook(bookId);

    }
}
