using Application.Authors;
using Application.Books;
using Microsoft.AspNetCore.Http;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;

namespace TestUtils
{
    public static class ObjectMocks
    {
        public static string AuthorCreationId { get; set; }
        public static string BookCreationId { get; set; }


        public static BookForCreationDto GetBookForCreation(string authorId, string bookId)
        {
            BookCreationId = bookId;
            return new BookForCreationDto { AuthorId = authorId, BookId = BookCreationId, Price = 10, PublishedDate = DateTime.UtcNow, Title = "The Jabberwocky", Genre = "fic_fant" };
        }

        public static AuthorForCreationDto GetAuthorForCreation(string authorId, string bookId)
        {
            AuthorCreationId = authorId;
            var bookList = new List<BookForCreationDto>();
            bookList.Add(GetBookForCreation(authorId, bookId));
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

        public static BookForUpdateDto GetBookForUpdate(string authorId = null, string bookId=null)
        {
            if (authorId == null)
            {
                authorId = AuthorCreationId;
            }
            if(bookId == null)
            {
                bookId = BookCreationId;
            }
            return new BookForUpdateDto { AuthorId = authorId, BookId = bookId, Price = 10, PublishedDate = DateTime.UtcNow, Title = "The Jabberwocky", Genre = "fic_fant" };

        }
        public static AuthorForUpdateDto GetAuthorForUpdate(string authorId = null, string bookId = null)
        {
            if(authorId==null)
            {
                authorId = AuthorCreationId;
            }
            var bookList = new List<BookForUpdateDto>();
            bookList.Add(GetBookForUpdate(authorId, bookId));
            return new AuthorForUpdateDto
            {
                AuthorId = authorId,
                Address = "Crawley Lane, Manchester Ave",
                Books = bookList,
                City = "Massachussets",
                FirstName = "Bentley",
                LastName = "UpdatedMorrison",
                State = "MA",
                Phone = "415 658-9930",
                Zip = "94105"
            };

        }
    }
}
