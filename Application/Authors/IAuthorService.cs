using System.Collections.Generic;

namespace Application.Authors
{
    public interface IAuthorService
    {
        AuthorDto GetAuthor(string authorId);
        IEnumerable<AuthorDto> GetAuthors(AuthorResourceParameters resourceParameters=null);
        bool AuthorExists(string authorId);

        AuthorDto CreateAuthor(AuthorForCreationDto authorForCreationDto, string authorId = null);

        AuthorDto CreateAuthorWithBooks(AuthorForCreationDto authorForCreationDto);
        void UpdateAuthor(AuthorForUpdateDto author);

        void DeleteAuthor(string authorId);

    }
}
