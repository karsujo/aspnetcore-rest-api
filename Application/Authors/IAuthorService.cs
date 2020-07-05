using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors
{
    public interface IAuthorService
    {
        AuthorDto GetAuthor(string authorId);
        IEnumerable<AuthorDto> GetAuthors();
        IEnumerable<AuthorDto> GetAuthors(IEnumerable<string> authors);

    }
}
