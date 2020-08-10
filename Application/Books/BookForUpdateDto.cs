using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Books
{
    public class BookForUpdateDto
    {
    
        private string AuthorId { get; set; }
        private string BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [GenreFormat]
        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishedDate { get; set; }

        public void SetIds(string authorId, string bookId)
        {
            AuthorId = authorId;
            BookId = bookId;
        }

    }
}
