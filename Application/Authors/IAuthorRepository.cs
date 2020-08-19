using Application.Authors;
using OdysseyPublishers.Domain;
using System.Collections.Generic;

namespace OdysseyPublishers.Application.Authors
{
    public interface IAuthorRepository
    {
        bool AuthorExists(string authorId);
        Author GetAuthor(string authorId);
        IEnumerable<Author> GetAuthors(AuthorResourceParameters parameters);
        IEnumerable<Author> GetAuthors();
        void CreateAuthor(AuthorForCreationDto authorForCreationDto, string auhtorId);
        void UpdateAuthor(AuthorForUpdateDto author);
        void DeleteAuthor(string authorId);
    }
}