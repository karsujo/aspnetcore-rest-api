using Application.Books;
using AutoMapper;
using Dapper;
using OdysseyPublishers.Application.Common;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Books
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
            var res = _repository.QueryDatabase<BookDbEntity>(sql, null);
            return _mapper.Map<IEnumerable<Book>>(res);
        }

        public Book GetBook(string BookId)
        {
            string sql = "select* from titles where title_id = @BookId";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", BookId, DbType.String, ParameterDirection.Input, BookId.Length);
            var res = _repository.QueryDatabaseSingle<BookDbEntity>(sql, parameters);
            return _mapper.Map<Book>(res);
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
