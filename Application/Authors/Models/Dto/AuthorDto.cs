using Application.Books;
using System.Collections.Generic;

namespace Application.Authors
{
    public class AuthorDto
    {
        public AuthorDto()
        {
            Books = new HashSet<BookDto>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public ICollection<BookDto> Books { get; set; }
    }
}
