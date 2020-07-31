using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books
{
    public class BookForCreationDto
    {
        public string AuthorId { get; set; }
        public string BookId { get; set; }

        public string  Title { get; set; }
        public string Type { get; set; }

        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
