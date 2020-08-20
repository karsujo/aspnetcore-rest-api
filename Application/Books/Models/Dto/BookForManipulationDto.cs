using Application.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Books
{
    public abstract class BookForManipulationDto
    {
        public string AuthorId { get; set; }
        public virtual string BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [GenreFormat]
        public virtual string Genre { get; set; }

        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; } = new DateTime().OracleDefault();
    }
}
