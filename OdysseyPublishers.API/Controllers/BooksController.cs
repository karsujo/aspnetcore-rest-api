using Application.Books;
using Microsoft.AspNetCore.Mvc;
using OdysseyPublishers.Domain.Exceptions;

namespace OdysseyPublishers.API.Controllers
{
    [ApiController]
    [Route("/api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]

        public ActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public ActionResult GetBook(string id)
        {
            //if (!_bookRepository.BookExists(id))
            //    throw new BookNotFoundException(id, null);

            var res = _bookService.GetBook(id);
            if (res == null)
                throw new BookNotFoundException(id, null);

            return Ok(res);
        }
    }
}
