using AutoMapper;
using AutoMapper.Configuration;
using OdysseyPublishers.Application.Common;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        public BookRepository(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<Book> GetBooks()
        {
            string sql = "SELECT * FROM TITLES";
           var res =  _repository.QueryDatabase<BookDbEntity>(sql, null);
            return _mapper.Map<IEnumerable<Book>>(res);
        }

        public Book GetBook(string BookId)
        {
            string sql = "";
            return _repository.QueryDatabaseSingle<Book>(sql, null);
        }

        public bool BookExists(string BookId)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new BookNotFoundException(BookId, ex);
            }
        }
    }
}
