using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors
{
    public class AuthorForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }

        public bool Contract { get; set; }
    }
}
