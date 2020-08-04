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
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        public AuthorService(IAuthorRepository authorRepository, IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public AuthorDto GetAuthor(string authorId)
        {
            var authorResult = _authorRepository.GetAuthor(authorId);
            authorResult.Validate(authorId);
            return _mapper.Map<AuthorDto>(authorResult);
        }

        public IEnumerable<AuthorDto> GetAuthors(AuthorResourceParameters resourceParameters)
        {
            var authorResult = _mapper.Map<List<AuthorDto>>(_authorRepository.GetAuthors(resourceParameters));
            var bookResult = _bookService.GetBooks();
            //Convert tot Linq
            foreach (var author in authorResult)
            {
                author.Books = bookResult.Where(b => b.Id == author.Id).ToList();
            }

            return authorResult;
        }

        public bool AuthorExists(string authorId)
        {
            return _authorRepository.AuthorExists(authorId);
        }

        public AuthorDto CreateAuthor(AuthorForCreationDto authorForCreationDto, string authorId = null)
        {

            if (string.IsNullOrEmpty(authorId))
            {
                authorId = GenerateAuthorId();
            }
            if (authorForCreationDto.Books.Count > 0)
            {

                _bookService.CreateBooks(authorForCreationDto.Books, authorId);


            }
            _authorRepository.CreateAuthor(authorForCreationDto, authorId);
            var authorToReturn = _mapper.Map<AuthorDto>(authorForCreationDto);
            authorToReturn.Id = authorId;
            return authorToReturn;
        }

        public AuthorDto CreateAuthorWithBooks(AuthorForCreationDto authorForCreationDto)
        {
            string authorId = GenerateAuthorId();
            var author = CreateAuthor(authorForCreationDto, authorId);

            _bookService.CreateBooks(authorForCreationDto.Books, authorId);


            return author;
        }

        public string GenerateAuthorId()
        {
            Random rand = new Random();
            string prefix = "000-00-";
            string suffix = rand.Next(1000, 9999).ToString();
            return prefix + suffix;
        }

    }
}
