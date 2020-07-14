using Application.Authors;
using Application.Books;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using OdysseyPublishers.Domain.Exceptions;
using System;

namespace OdysseyPublishers.API.Controllers
{
    [ApiController]
    [Route("/api/authors/{authorId}/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly IAuthorService _authorService;
        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpGet]
        [Route("/api/allbooks")]
        public ActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet]
        public ActionResult GetBooksForAuthor([FromRoute] string authorId)
        {
            if(string.IsNullOrEmpty(authorId))
            {
                throw new ArgumentNullException(nameof(authorId));
            }
            if(!_authorService.AuthorExists(authorId))
            {
                return NotFound(new AuthorNotFoundException(authorId, null));
            }

            return Ok(_bookService.GetBooksForAuthor(authorId));

        }

        [HttpGet("{bookId}")]
        public ActionResult GetBookForAuthor(string bookId)
        {
            if (string.IsNullOrEmpty(bookId))
            {
                throw new ArgumentNullException(nameof(bookId));
            }
            return Ok(_bookService.GetBookForAuthor(bookId));
        }
    }
}
