using Application.Books;
using System.Collections.Generic;

namespace Application.Authors
{
    public class AuthorForCreationDto : AuthorForManipulationDto
    {
        public AuthorForCreationDto()
        {
            Books = new HashSet<BookForCreationDto>();
        }
        public ICollection<BookForCreationDto> Books { get; set; }
    }
}
