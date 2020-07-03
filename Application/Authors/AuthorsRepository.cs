using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Common;

namespace OdysseyPublishers.Application.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {

        private readonly IRepository _repository;

        public AuthorsRepository(IRepository repository, IConfiguration configuration) 
        {
            _repository = repository;
        }

        public IEnumerable<Author> GetAuthors()
        {
            string sql = "";
            return _repository.QueryDatabase<Author>(sql);
        }

        public Author GetAuthor(string authorId)
        {
            string sql = "";
            return _repository.QueryDatabaseSingle<Author>(sql);
        }

        public bool AuthorExists(string authorId)
        {
            string sql = "";
            return true;
        }

    }

}
