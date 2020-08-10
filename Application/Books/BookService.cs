using AutoMapper;
using OdysseyPublishers.Domain;
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
            //res.Validate();
            return _mapper.Map<BookDto>(res);
        }

        public bool BookExists(string bookId)
        {
            return _bookRepository.BookExists(bookId);

        }


        public IEnumerable<BookDto> GetBooks(BookResourceParameters bookResourceParameters)
        {
            var res = _bookRepository.GetBooks(bookResourceParameters);
            //validate
            return _mapper.Map<List<BookDto>>(res);
        }

        public IEnumerable<BookDto> GetBooks()
        {
            var res = _bookRepository.GetBooks();
            //validate
            return _mapper.Map<List<BookDto>>(res);
        }


        // TODO: Should there be a Create book and Create Books API separately?
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

        public BookDto UpdateBook(BookForUpdateDto book, string authorId, string bookId)
        {
            book.SetIds(authorId, bookId);
            _bookRepository.UpdateBook(book);
            return _mapper.Map<BookDto>(book);
        }

  
    }
}
