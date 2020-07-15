using System.Collections.Generic;

namespace Application.Authors
{
    public interface IAuthorService
    {
        AuthorDto GetAuthor(string authorId);
        IEnumerable<AuthorDto> GetAuthors(AuthtorResourceParameters resourceParameters);
        bool AuthorExists(string authorId);


    }
}
