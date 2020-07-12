using Application.Books;
using AutoMapper;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }
        //TODO: Add Mappings
        public AuthorDto GetAuthor(string authorId)
        {
            var authorResult = _authorRepository.GetAuthor(authorId);
            authorResult.Validate();
     
            return _mapper.Map<AuthorDto>(authorResult);
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            var authorDtos = new List<AuthorDto>();
            var authorResult = _authorRepository.GetAuthors();
            var bookResult = _bookRepository.GetBooks();
             //Convert tot Linq
            foreach(var author in authorResult)
            {
                author.Books = bookResult.Where(b => b.AuthorId == author.AuthorId).ToList();
                authorDtos.Add(_mapper.Map<AuthorDto>(author));
          
            }
            return authorDtos;
        }

        public IEnumerable<AuthorDto> GetAuthors(IEnumerable<string> authors)
        {
            throw new NotImplementedException();
        }
    }
}
