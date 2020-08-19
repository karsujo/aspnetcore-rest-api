using Application.Authors;
using Application.Books;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;

namespace OdysseyPublishers.API.Controllers
{

    [ApiController]
    [Route("/api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] AuthorResourceParameters resourceParameters)
        {
            return Ok(_authorService.GetAuthors(resourceParameters));
        }

        [HttpGet("{authorId}", Name = "GetAuthor")]
        public ActionResult<AuthorDto> GetAuthor(string authorId)
        {

            if (string.IsNullOrEmpty(authorId))
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            if (!_authorService.AuthorExists(authorId))
            {
                return NotFound();
            }

            return Ok(_authorService.GetAuthor(authorId));
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        {
            var authorToReturn = _authorService.CreateAuthor(author);
            return CreatedAtRoute("GetAuthor", new { authorId = authorToReturn.Id }, authorToReturn);
        }

        [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Request.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpPut("{authorId}")]
        public ActionResult UpdateAuthor([FromRoute] string authorId, AuthorForUpdateDto author)
        {
            if (!_authorService.AuthorExists(authorId))
                return NotFound();

             author.AuthorId = authorId;
            _authorService.UpdateAuthor(author);

            return NoContent();


        }

        //TODO: Test complex patches (books)

        [HttpPatch("{authorId}")]
        public ActionResult PatchAuthor([FromRoute] string authorId, JsonPatchDocument<AuthorForUpdateDto> patchDocument)
        {
            if (!_authorService.AuthorExists(authorId))
                return NotFound();

            AuthorDto author = _authorService.GetAuthor(authorId);
            var booksForUpdate = new List<BookForUpdateDto>();
            foreach(var book in author.Books)
            {
                booksForUpdate.Add(new BookForUpdateDto
                {
                    AuthorId = authorId,
                    BookId = book.Id,
                    Genre = book.Genre,
                    Price = book.Price,
                    PublishedDate = book.PublishedDate,
                    Title = book.Title
                });
            }

            AuthorForUpdateDto updateAuthor = new AuthorForUpdateDto {
                Address = author.Address,
                FirstName = author.Name,
                LastName = author.Name,
                AuthorId = authorId,
                Books = booksForUpdate,
                State = author.State,
                City = author.City,
                Phone = author.Phone,
                Zip = author.ZipCode
            };
          
            if (!TryValidateModel(updateAuthor))
            {
                return ValidationProblem(ModelState);
            }

            patchDocument.ApplyTo(updateAuthor, ModelState);

            _authorService.UpdateAuthor(updateAuthor);

            return NoContent();

        }

        [HttpDelete("{authorId}")]
        public ActionResult DeleteAuthor([FromRoute] string authorId)
        {
            if (!_authorService.AuthorExists(authorId))
                return NotFound();

            _authorService.DeleteAuthor(authorId);

            return NoContent();
        }

    }


}
