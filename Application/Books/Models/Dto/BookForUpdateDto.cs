using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Books
{
    public class BookForUpdateDto: BookForManipulationDto
    {
        [Required(ErrorMessage ="Genre is required during updation.")]
        public override string Genre { get => base.Genre; set => base.Genre = value; }

    }
}
