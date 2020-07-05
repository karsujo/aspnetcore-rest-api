using AutoMapper;
using OdysseyPublishers.Application.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }
        //TODO: Add Mappings
        public AuthorDto GetAuthor(string authorId)
        {
            var result = _authorRepository.GetAuthor(authorId);
            result.Validate();
           return _mapper.Map<AuthorDto>(result);
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
