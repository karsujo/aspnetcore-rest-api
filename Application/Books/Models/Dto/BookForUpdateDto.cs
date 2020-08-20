using System.ComponentModel.DataAnnotations;

namespace Application.Books
{
    public class BookForUpdateDto : BookForManipulationDto
    {

        public override string BookId { get => base.BookId; set => base.BookId = value; }
        [Required(ErrorMessage = "Genre is required during updation.")]
        public override string Genre { get => base.Genre; set => base.Genre = value; }

    }
}
