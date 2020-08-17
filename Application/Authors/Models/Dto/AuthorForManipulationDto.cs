using Application.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Authors
{
    public abstract class AuthorForManipulationDto
    {
    
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        public virtual string City { get; set; }
        public virtual string Address { get; set; }
        [Required]
        public string Phone { get; set; }

        public virtual string State { get; set; }

        [RegularExpression("^[0-9]{5}$")]
        public virtual string Zip { get; set; }

      

    }
}
