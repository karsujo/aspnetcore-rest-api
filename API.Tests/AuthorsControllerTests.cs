using Application.Common;
using AutoMapper;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.Extensions.Options;
using OdysseyPublishers.API.Controllers;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Domain;
using OdysseyPublishers.Infrastructure.Authors;
using OdysseyPublishers.Infrastructure.Common;
using System.Collections.Generic;
using Xunit;

namespace API.Tests
{
    public class AuthorsControllerTests
    {
        private readonly AuthorsController authorsController;
        public AuthorsControllerTests()
        {
          authorsController = TestUtils.ConstructorUtils.authorsController;
        }

        [Fact]
        public void GetAuthorsTest()
        {
       

        }
    }
}
