using Application.Books;
using Microsoft.AspNetCore.Mvc;
using OdysseyPublishers.Domain.Exceptions;

namespace OdysseyPublishers.API.Controllers
{
    [ApiController]
    [Route("/api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]

        public ActionResult GetBooks()
        {
            return Ok(_bookRepository.GetBooks());
        }

        [HttpGet("{id}")]
        public ActionResult GetBook(string id)
        {
            //if (!_bookRepository.BookExists(id))
            //    throw new BookNotFoundException(id, null);

            var res = _bookRepository.GetBook(id);
            if (res == null)
                throw new BookNotFoundException(id, null);

            return Ok(res);
        }
    }
}
