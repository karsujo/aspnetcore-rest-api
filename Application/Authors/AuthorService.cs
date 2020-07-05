using OdysseyPublishers.Application.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public AuthorDto GetAuthor(string authorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorDto> GetAuthors(IEnumerable<string> authors)
        {
            throw new NotImplementedException();
        }
    }
}
