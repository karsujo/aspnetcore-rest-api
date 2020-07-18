﻿using AutoMapper;
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

        public BookDto GetBookForAuthor(string Id)
        {
            var res = _bookRepository.GetBookForAuthor(Id);
            //res.Validate();
            return _mapper.Map<BookDto>(res);
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

        public string GenerateBookId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> CreateBooks(IEnumerable<BookForCreationDto> bookForCreationDtos, string authorId)
        {
            int bookOrder = 0;
            const int royalty = 50;
            foreach( var book in bookForCreationDtos )
            {
                bookOrder++;
                _bookRepository.CreateBook(book, authorId, bookOrder, royalty);
            }
            //TODO: Setup Mapping first.
            return _mapper.Map<List<BookDto>>(bookForCreationDtos);
        }
    }
}
