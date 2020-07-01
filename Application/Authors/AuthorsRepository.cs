using System;
using System.Collections.Generic;
using System.Text;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Common;

namespace OdysseyPublishers.Application.Authors
{
    public class AuthorsRepository : AbstractRepositoryBase<Author>
    {

        public AuthorsRepository(string connString) : base(connString)
        {

        }

        public IEnumerable<Author> GetAuthors()
        {
            string sql = "";
            return QueryDatabase<Author>(sql);    
        }

        public Author GetAuthor(string authorId)
        {
            string sql = "";
            return QueryDatabaseSingle<Author>(sql);
        }

        public bool AuthorExists(string authorId)
        {
            string sql = "";
            return true;
        }

    }
    
}
