using Application.Books;
using AutoMapper;
using OdysseyPublishers.Application.Authors;
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
        private readonly IBookRepository _bookRepository;
        public AuthorService(IAuthorRepository authorRepository, IBookService bookService, IBookRepository bookRepository, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public AuthorDto GetAuthor(string authorId)
        {
            var authorResult = _authorRepository.GetAuthor(authorId);
            var bookResult = _bookRepository.GetBooksForAuthor(authorId);
            foreach (var book in bookResult)
            {
                authorResult.Books.Add(book);
            }
            return _mapper.Map<AuthorDto>(authorResult);
        }

        public IEnumerable<AuthorDto> GetAuthors(AuthorResourceParameters resourceParameters = null)
        {
            if (resourceParameters == null)
            {
                return GetAuthors();
            }
            var authorResult = _authorRepository.GetAuthors(resourceParameters);
            var bookResult = _bookRepository.GetBooks();
            //Convert tot Linq
            foreach (var author in authorResult)
            {
                author.Books = bookResult.Where(b => b.AuthorId == author.AuthorId).ToList();
            }

            return _mapper.Map<List<AuthorDto>>(authorResult);
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            var authorResult = _authorRepository.GetAuthors();
            var bookResult = _bookRepository.GetBooks();
            foreach (var author in authorResult)
            {
                author.Books = bookResult.Where(b => b.AuthorId == author.AuthorId).ToList();
            }

            return _mapper.Map<List<AuthorDto>>(authorResult);
        }

        public bool AuthorExists(string authorId)
        {
            return _authorRepository.AuthorExists(authorId);
        }

        public AuthorDto CreateAuthor(AuthorForCreationDto authorForCreationDto, string authorId = null)
        {

            if (string.IsNullOrEmpty(authorId))
            {
                authorId = Guid.NewGuid().ToString();

            }
            _authorRepository.CreateAuthor(authorForCreationDto, authorId);

            if (authorForCreationDto.Books.Count > 0)
            {

                _bookService.CreateBooks(authorForCreationDto.Books, authorId);


            }

            var authorToReturn = _mapper.Map<AuthorDto>(authorForCreationDto);
            authorToReturn.Id = authorId;
            return authorToReturn;
        }

        public AuthorDto CreateAuthorWithBooks(AuthorForCreationDto authorForCreationDto)
        {
            string authorId = Guid.NewGuid().ToString();
            var author = CreateAuthor(authorForCreationDto, authorId);

            _bookService.CreateBooks(authorForCreationDto.Books, authorId);


            return author;
        }

        public void UpdateAuthor(AuthorForUpdateDto author)
        {
            if (author.Books.Count > 0)
            {
                var books = author.Books;
                foreach (var book in books)
                {
                    if (!_bookService.BookExists(book.BookId))
                        throw new ArgumentException($"Book with id {book.BookId} not found");

                    _bookService.UpdateBook(book);
                }

            }
            _authorRepository.UpdateAuthor(author);
        }

        public void DeleteAuthor(string authorId)
        {
            var author = GetAuthor(authorId);
            if (author.Books.Count > 0)
            {
                foreach (var book in author.Books)
                {
                    _bookRepository.DeleteBook(book.Id);
                }
            }
            _authorRepository.DeleteAuthor(authorId);
        }

    }
}
