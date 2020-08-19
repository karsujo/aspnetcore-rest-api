using Application.Authors;
using Application.Books;
using Domain.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var res = _bookService.GetBook(bookId);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public ActionResult<BookDto> CreateBooksForAuthor([FromRoute] string authorId, List<BookForCreationDto> books)
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

        [HttpPut("{bookId}")]
        public ActionResult UpdateBookForAuthor([FromRoute] string authorId, [FromRoute] string bookId, BookForUpdateDto book)
        {
            if (!_authorService.AuthorExists(authorId))
                return NotFound();

            if (!_bookService.BookExists(bookId))
                return NotFound();

            book.BookId = bookId;
            book.AuthorId = authorId;

            _bookService.UpdateBook(book);

            return NoContent();
        }

        [HttpPatch("{bookId}")]
        public ActionResult PatchBookForAuthor([FromRoute] string authorId, [FromRoute] string bookId, JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            if (!_authorService.AuthorExists(authorId))
                return NotFound();

            if (!_bookService.BookExists(bookId))
                return NotFound();

            BookDto book = _bookService.GetBooksForAuthor(authorId).Where(b => b.Id == bookId).FirstOrDefault();

            BookForUpdateDto bookForUpdate = new BookForUpdateDto
            {
              AuthorId = authorId,
             BookId = bookId,
             Genre = book.Genre,
             Price = book.Price,
             PublishedDate = book.PublishedDate,
             Title = book.Title

            };

            if(!TryValidateModel(bookForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            patchDocument.ApplyTo(bookForUpdate, ModelState);

            _bookService.UpdateBook(bookForUpdate);

            return NoContent();

        }

        [HttpDelete("{bookId}")]
        public ActionResult DeleteBookForAuthor([FromRoute] string authorId, [FromRoute] string bookId)
        {
            if (!_authorService.AuthorExists(authorId))
                return NotFound();
            if (!_bookService.BookExists(bookId))
                return NotFound();
            _bookService.DeleteBook(bookId);
            return NoContent();
        }



        public override ActionResult ValidationProblem(ModelStateDictionary modelState)
        {
            return base.ValidationProblem(modelState);
        }
    }
}
