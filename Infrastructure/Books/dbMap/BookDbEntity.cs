using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Books
{

    //TODO: Convert App Domian models to DbEntity for Repo Methods. 
    public class BookDbEntity
    {
        [Required]
        public string au_id { get; set; }

        [Required]
        public string book_id { get; set; }

        [Required]
        [MaxLength(80)]
        public string title { get; set; }

        public string type { get; set; }

        public decimal price { get; set; }

        public DateTime pubdate { get; set; }
    }
}
