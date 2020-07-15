using Application.Authors;
using OdysseyPublishers.Domain;
using System.Collections.Generic;

namespace OdysseyPublishers.Application.Authors
{
    public interface IAuthorRepository
    {
        bool AuthorExists(string authorId);
        Author GetAuthor(string authorId);
        IEnumerable<Author> GetAuthors(AuthtorResourceParameters parameters);
        IEnumerable<Author> GetAuthors();
    }
}