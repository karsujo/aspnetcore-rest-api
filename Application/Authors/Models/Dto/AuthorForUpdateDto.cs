using Application.Books;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Authors
{
    public class AuthorForUpdateDto : AuthorForManipulationDto
    {
        public AuthorForUpdateDto()
        {
            Books = new HashSet<BookForUpdateDto>();
        }
        public ICollection<BookForUpdateDto> Books { get; set; }
        public string AuthorId { get; set; }

        [Required(ErrorMessage = "Address is required for updation.")]
        public override string Address { get => base.Address; set => base.Address = value; }

        [Required(ErrorMessage = "City is required for updation.")]
        public override string City { get => base.City; set => base.City = value; }

        [Required(ErrorMessage = "State is required for updation.")]
        [MaxLength(2)]
        public override string State { get => base.State; set => base.State = value; }

        [Required(ErrorMessage = "ZipCode is required for updation.")]

        public override string Zip { get => base.Zip; set => base.Zip = value; }

    }
}
