using Application.Authors;
using Application.Books;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestUtils
{
    public static class ObjectMocks
    {

        public static BookForCreationDto GetBookForCreation()
        {
            return new BookForCreationDto { AuthorId = "10908F6C-3480-4F2E-AB6B-AE3EBD86A45A", BookId = Guid.NewGuid().ToString(), Price = 10, PublishedDate = DateTime.UtcNow, Title = "The Jabberwocky", Type = "fic_fant" };
        }

        public static AuthorForCreationDto GetAuthorForCreation()
        {
            var bookList = new List<BookForCreationDto>();
            bookList.Add(GetBookForCreation());
            return new AuthorForCreationDto
            {
                Address = "Crawley Lane, Manchester Ave",
                Books = bookList,
                City = "Massachussets",
                FirstName = "Bentley",
                LastName = "Morrison",
                State = "MA",
                Phone = "415 658-9930",
                Zip = "94105"
            };
        }
    }
}
