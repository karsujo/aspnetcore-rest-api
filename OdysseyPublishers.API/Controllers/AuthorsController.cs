using Application.Authors;
using Microsoft.AspNetCore.Mvc;
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

    }


}
