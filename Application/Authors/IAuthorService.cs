using OdysseyPublishers.Domain;
using System.Collections.Generic;

namespace Application.Authors
{
    public interface IAuthorService
    {
        AuthorDto GetAuthor(string authorId);
        IEnumerable<AuthorDto> GetAuthors(AuthorResourceParameters resourceParameters);
        bool AuthorExists(string authorId);

        AuthorDto CreateAuthor(AuthorForCreationDto authorForCreationDto);

        AuthorDto CreateAuthorWithBooks(AuthorForCreationDto authorForCreationDto);

        string GenerateAuthorId();
      

    }
}
