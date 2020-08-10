using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Books
{
    public class BookForCreationDto
    {
        public string AuthorId { get; set; }
        public string BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [GenreFormat]
        public string Genre { get; set; }

         public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
