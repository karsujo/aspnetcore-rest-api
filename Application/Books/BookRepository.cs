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

        public BookRepository(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Book> GetBooks()
        {
            string sql = "";
            return _repository.QueryDatabase<Book>(sql);
        }

        public Book GetBook(string BookId)
        {
            string sql = "";
            return _repository.QueryDatabaseSingle<Book>(sql);
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
