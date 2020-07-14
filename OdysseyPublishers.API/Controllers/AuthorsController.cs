using Application.Authors;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public ActionResult GetAuthors()
        {
            return Ok(_authorService.GetAuthors());
        }

        [HttpGet("{id}")]
        public ActionResult GetAuthor(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return Ok(_authorService.GetAuthor(id));
        }

    }


}
