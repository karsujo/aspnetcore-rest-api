using System;

namespace Infrastructure.Books
{
    public class BookDbEntity
    {
        public string au_id { get; set; }
        public string book_id { get; set; }
        public string title { get; set; }

        public string type { get; set; }

        public decimal price { get; set; }

        public DateTime pubdate { get; set; }
    }
}
