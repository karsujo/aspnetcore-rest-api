using OdysseyPublishers.API.Controllers;
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
