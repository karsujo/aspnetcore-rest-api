using Application.Authors;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.Tests
{
    public class AuthorServiceTests
    {
        private readonly IAuthorService _authorService;
        public AuthorServiceTests()
        {
            this._authorService = TestUtils.ConstructorUtils.authorService;
        }


    }
}
