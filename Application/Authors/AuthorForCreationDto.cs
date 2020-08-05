using Application.Books;
using System.Collections.Generic;

namespace Application.Authors
{
    public class AuthorForCreationDto
    {
        public AuthorForCreationDto()
        {
            Books = new HashSet<BookForCreationDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }

        public ICollection<BookForCreationDto> Books { get; set; }
    }
}
