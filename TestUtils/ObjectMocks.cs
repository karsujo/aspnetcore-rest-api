using Application.Authors;
using Application.Books;
using System;
using System.Collections.Generic;

namespace TestUtils
{
    public static class ObjectMocks
    {

        public static BookForCreationDto GetBookForCreation(string authorId)
        {
            return new BookForCreationDto { AuthorId = authorId, BookId = Guid.NewGuid().ToString(), Price = 10, PublishedDate = DateTime.UtcNow, Title = "The Jabberwocky", Genre = "fic_fant" };
        }

        public static AuthorForCreationDto GetAuthorForCreation()
        {
            var bookList = new List<BookForCreationDto>();
            bookList.Add(GetBookForCreation(Guid.NewGuid().ToString()));
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
