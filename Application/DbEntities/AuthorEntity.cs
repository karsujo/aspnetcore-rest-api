using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace Application.DbEntities
{
    public class AuthorEntity
    {

        public AuthorEntity()
        {
            Books = new HashSet<BookEntity>();
        }

        public string au_Id { get; set; }
        public string au_fname { get; set; }
        public string au_lname { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }

        public bool Contract { get; set; }

        public ICollection<BookEntity> Books { get; set; }

    }
}
