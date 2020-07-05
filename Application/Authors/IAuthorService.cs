using System.Collections.Generic;

namespace Application.Authors
{
    public interface IAuthorService
    {
        AuthorDto GetAuthor(string authorId);
        IEnumerable<AuthorDto> GetAuthors();
        IEnumerable<AuthorDto> GetAuthors(IEnumerable<string> authors);

    }
}
