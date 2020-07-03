using Microsoft.AspNetCore.Mvc;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdysseyPublishers.API.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository _repository;
        public AuthorsController(IAuthorsRepository authorsRepository)
        {
            _repository = authorsRepository;
        }

    }
}
