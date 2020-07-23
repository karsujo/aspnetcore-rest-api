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
    // Change to reflect new structure
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
            string sql = @"select 
            b.au_id,
            b.book_id,
            b.type,
            b.price,
            b.title
            from books b ";
            var res = _repository.QueryDatabase<BookDbEntity>(sql, null);
            return _mapper.Map<IEnumerable<Book>>(res);
        }

        public IEnumerable<Book> GetBooks(BookResourceParameters bookResourceParameters)
        {
            if(string.IsNullOrEmpty(bookResourceParameters.Genre))
            {
                return GetBooks();
            }

            string sql = @"select 
            b.au_id,
            b.book_id,
            b.type,
            b.price,
            b.title
            from books b where b.type = @Genre";
            var parameters = new DynamicParameters();
            parameters.Add("@Genre", bookResourceParameters.Genre, DbType.String, ParameterDirection.Input, bookResourceParameters.Genre.Length);
            var res = _repository.QueryDatabase<BookDbEntity>(sql, parameters);
            return _mapper.Map<IEnumerable<Book>>(res);
        }

        public Book GetBookForAuthor(string BookId)
        {
         string sql = @"select 
            b.au_id,
            b.book_id,
            b.type,
            b.price,
            b.title
            from books b where b.book_id = @BookId";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", BookId, DbType.String, ParameterDirection.Input, BookId.Length);
            var res = _repository.QueryDatabaseSingle<BookDbEntity>(sql, parameters);
            return _mapper.Map<Book>(res);
        }

        public bool BookExists(string BookId)
        {
            string sql = @"select
            b.au_id,
            b.book_id,
            b.type,
            b.price,
            b.title
            from books b where b.book_id = @BookId";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", BookId, DbType.String, ParameterDirection.Input, BookId.Length);
            var res = _repository.QueryDatabaseSingle<BookDbEntity>(sql, parameters);
            return res == null ? false : true;
        }

        public IEnumerable<Book> GetBooksForAuthor(string authorId)
        {
            string sql = @"select
            b.au_id,
            b.book_id,
            b.type,
            b.price,
            b.title
            from books b where b.au_id = @AuthorId";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", authorId, DbType.String, ParameterDirection.Input, authorId.Length);
            var res = _repository.QueryDatabase<BookDbEntity>(sql, parameters);
            return _mapper.Map<List<Book>>(res);
        }

        public void CreateBook(BookForCreationDto bookForCreationDto, string authorId, int bookOrder, int royalty )
        {
            //TODO: Insert into title and titleAuthor table.
            //into title

            string titleSql = @"iinsert books values (@au_guid ,NEWID(), 'The Clone Wars Reloaded', 'fic_sci', $20.00, '09/12/99')";


            //into titleauthor

            string titleAuthorSql = @"insert titleauthor values('409-56-7008', 'BU1032', 1, 60)";


            throw new NotImplementedException();
        }
    }
}
