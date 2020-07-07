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

        public BookDto GetBook(string Id)
        {
            var res = _bookRepository.GetBook(Id);
            res.Validate();
            return _mapper.Map<BookDto>(res);
        }

        public IEnumerable<BookDto> GetBooks()
        {
            var res = _bookRepository.GetBooks();
            //validate
            return _mapper.Map<List<BookDto>>(res);
        }

        public IEnumerable<BookDto> GetBooks(IEnumerable<string> Ids)
        {
            throw new NotImplementedException();
        }
    }
}
