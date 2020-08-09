using Infrastructure.Books;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Authors
{
    public class AuthorDbEntity
    {

        public AuthorDbEntity()
        {
            Books = new HashSet<BookDbEntity>();
        }

        [Required]
        public string au_Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string au_fname { get; set; }

        [Required]
        [MaxLength(40)]
        public string au_lname { get; set; }

        [MaxLength(20)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(5)]
        public string Zip { get; set; }

        public ICollection<BookDbEntity> Books { get; set; }

    }
}
