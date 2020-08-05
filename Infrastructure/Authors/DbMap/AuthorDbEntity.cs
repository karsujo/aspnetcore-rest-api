using Infrastructure.Books;
using System.Collections.Generic;

namespace Infrastructure.Authors
{
    public class AuthorDbEntity
    {

        public AuthorDbEntity()
        {
            Books = new HashSet<BookDbEntity>();
        }
        public string au_Id { get; set; }
        public string au_fname { get; set; }
        public string au_lname { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }
        public ICollection<BookDbEntity> Books { get; set; }

    }
}
