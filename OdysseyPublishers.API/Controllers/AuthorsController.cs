using Application.Authors;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult GetAuthors()
        {
            return Ok(_authorService.GetAuthors());
        }

    }


}
