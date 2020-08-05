using System;

namespace Application.Books
{

    public class BookDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishedDate { get; set; }

    }
}
