using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using OdysseyPublishers.Application.Common;
using OdysseyPublishers.Domain;

namespace OdysseyPublishers.Application.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {

        private readonly IRepository _repository;

        public AuthorsRepository(IRepository repository) 
        {
            _repository = repository;
        }

        public IEnumerable<Author> GetAuthors()
        {

            //Get all authors, and for each author get books
            string sql = @"SELECT 
              au_id AuthorId,
              au_fname FirstName, 
              au_lname LastName,
              phone,
              address,
              city,
              state,
              zip,
              contract
            FROM
              AUTHORS ";
            return _repository.QueryDatabase<Author>(sql, null);
        }

        public Author GetAuthor(string authorId)
        {
            string sql = "select* from authors where au_id = '267-41-2394'";
            return _repository.QueryDatabaseSingle<Author>(sql, null);
        }

        public bool AuthorExists(string authorId)
        {
            string sql = "";
            return true;
        }

    }

}
