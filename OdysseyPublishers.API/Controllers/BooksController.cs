using Application.Authors;
using Application.Books;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<BookDto>> GetBooks([FromQuery] BookResourceParameters bookResourceParameters)
        {
            return Ok(_bookService.GetBooks(bookResourceParameters));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooksForAuthor([FromRoute] string authorId)
        {
            if (string.IsNullOrEmpty(authorId))
            {
                throw new ArgumentNullException(nameof(authorId));
            }
            if (!_authorService.AuthorExists(authorId))
            {
                return NotFound(new AuthorNotFoundException(authorId, null));
            }

            var res = _bookService.GetBooksForAuthor(authorId);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        [HttpGet("{bookId}")]
        public ActionResult<BookDto> GetBookForAuthor(string bookId)
        {
            if (string.IsNullOrEmpty(bookId))
            {
                throw new ArgumentNullException(nameof(bookId));
            }
            var res = _bookService.GetBookForAuthor(bookId);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public ActionResult<BookDto> CreateBooksForAuthor([FromRoute] string authorId,List<BookForCreationDto> books )
        {
            var result = _bookService.CreateBooks(books, authorId);
            return Ok(result);
        }

        [HttpOptions]
        public IActionResult GetBooksOptions()
        {
            Request.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
