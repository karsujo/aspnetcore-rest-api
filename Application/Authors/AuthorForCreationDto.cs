using Application.Books;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Authors
{
    public class AuthorForCreationDto
    {
        public AuthorForCreationDto()
        {
            Books = new HashSet<BookForCreationDto>();
        }
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }

        public string State { get; set; }

        [RegularExpression("^[0-9]{5}$")]
        public string Zip { get; set; }

        public ICollection<BookForCreationDto> Books { get; set; }
    }
}
