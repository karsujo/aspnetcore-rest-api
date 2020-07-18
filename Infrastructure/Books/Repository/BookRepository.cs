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
            string sql = @"SELECT 
        T.title_id,
        T.title,
        T.type,
        T.price,
        T.pub_id,
        T.price,
        T.advance,
        T.royalty,
        T.ytd_sales,
        T.notes,
        T.pubdate,
        TA.au_id
        FROM TITLES T inner join TITLEAUTHOR TA on T.TITLE_ID = TA.TITLE_ID";
            var res = _repository.QueryDatabase<BookDbEntity>(sql, null);
            return _mapper.Map<IEnumerable<Book>>(res);
        }

        public IEnumerable<Book> GetBooks(BookResourceParameters bookResourceParameters)
        {
            if(string.IsNullOrEmpty(bookResourceParameters.Genre))
            {
                return GetBooks();
            }

            string sql = @"SELECT 
        T.title_id,
        T.title,
        T.type,
        T.price,
        T.pub_id,
        T.price,
        T.advance,
        T.royalty,
        T.ytd_sales,
        T.notes,
        T.pubdate,
        TA.au_id
        FROM TITLES T inner join TITLEAUTHOR TA on T.TITLE_ID = TA.TITLE_ID WHERE T.TYPE = @Genre";
            var parameters = new DynamicParameters();
            parameters.Add("@Genre", bookResourceParameters.Genre, DbType.String, ParameterDirection.Input, bookResourceParameters.Genre.Length);
            var res = _repository.QueryDatabase<BookDbEntity>(sql, parameters);
            return _mapper.Map<IEnumerable<Book>>(res);
        }

        public Book GetBookForAuthor(string BookId)
        {
         string sql = @"SELECT 
        T.title_id,
        T.title,
        T.type,
        T.price,
        T.pub_id,
        T.price,
        T.advance,
        T.royalty,
        T.ytd_sales,
        T.notes,
        T.pubdate,
        TA.au_id
        FROM TITLES T inner join TITLEAUTHOR TA on T.TITLE_ID = TA.TITLE_ID where T.title_id = @BookId";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", BookId, DbType.String, ParameterDirection.Input, BookId.Length);
            var res = _repository.QueryDatabaseSingle<BookDbEntity>(sql, parameters);
            return _mapper.Map<Book>(res);
        }

        public bool BookExists(string BookId)
        {
            string sql = @"SELECT 
        T.title_id,
        T.title,
        T.type,
        T.price,
        T.pub_id,
        T.price,
        T.advance,
        T.royalty,
        T.ytd_sales,
        T.notes,
        T.pubdate,
        TA.au_id
        FROM TITLES T inner join TITLEAUTHOR TA on T.TITLE_ID = TA.TITLE_ID where T.title_id = @BookId";
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", BookId, DbType.String, ParameterDirection.Input, BookId.Length);
            var res = _repository.QueryDatabaseSingle<BookDbEntity>(sql, parameters);
            return res == null ? false : true;
        }

        public IEnumerable<Book> GetBooksForAuthor(string authorId)
        {
            string sql = @"SELECT 
        T.title_id,
        T.title,
        T.type,
        T.price,
        T.pub_id,
        T.price,
        T.advance,
        T.royalty,
        T.ytd_sales,
        T.notes,
        T.pubdate,
        TA.au_id
        FROM TITLES T inner join TITLEAUTHOR TA on T.TITLE_ID = TA.TITLE_ID where  TA.au_id = @AuthorId";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", authorId, DbType.String, ParameterDirection.Input, authorId.Length);
            var res = _repository.QueryDatabase<BookDbEntity>(sql, parameters);
            return _mapper.Map<List<Book>>(res);
        }

        public void CreateBook(BookForCreationDto bookForCreationDto, string authorId, int bookOrder, int royalty )
        {
            //TODO: Insert into title and titleAuthor table.
            throw new NotImplementedException();
        }
    }
}
