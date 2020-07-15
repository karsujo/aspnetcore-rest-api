using Application.Authors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace OdysseyPublishers.API.Controllers
{
    //TODO: Searching and Filtering
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
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery]AuthtorResourceParameters resourceParameters)
        {
            return Ok(_authorService.GetAuthors(resourceParameters));
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDto> GetAuthor(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (!_authorService.AuthorExists(id))
            {
                return NotFound();
            }
       
            return Ok(_authorService.GetAuthor(id));
        }

    }


}
