using System;
using System.Collections.Generic;
using System.Text;

namespace OdysseyPublishers.Domain
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public string AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string  Phone { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }

        public bool Contract { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
