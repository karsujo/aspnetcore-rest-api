using Microsoft.AspNetCore.Mvc;
using OdysseyPublishers.Application.Authors;

namespace OdysseyPublishers.API.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        public AuthorsController(IAuthorRepository authorsRepository)
        {
            _repository = authorsRepository;
        }

        [HttpGet]
        public ActionResult GetAuthors()
        {
            return Ok(_repository.GetAuthors());
        }

    }


}
