﻿using System.ComponentModel.DataAnnotations;

namespace Application.Authors
{
    public abstract class AuthorForManipulationDto
    {

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
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
