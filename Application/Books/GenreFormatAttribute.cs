using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Books
{
    public class GenreFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            dynamic book = validationContext.ObjectInstance;
            string genre = book.Genre;
            if (!genre.Contains('_'))
            {
                return new ValidationResult("The provided genre is not in the correct format", new[] { nameof(BookForCreationDto) });
            }
            string[] genreSubtypes = genre.Split('_');
            if (genreSubtypes[0] != "fic" && genreSubtypes[0] != "nfic")
            {

                return new ValidationResult("The provided genre subtype is invalid. It can be either 'fic' or 'nfic'", new[] { nameof(BookForCreationDto) });

            }
            return ValidationResult.Success;
        }
    }
}
