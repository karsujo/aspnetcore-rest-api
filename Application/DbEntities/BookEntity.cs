using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DbEntities
{
   public class BookEntity
    {
        public string TitleId { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }

        public string PubId { get; set; }

        public decimal Price { get; set; }

        public decimal Advance { get; set; }

        public int Royalty { get; set; }

        public int Sales { get; set; }

        public string Nodes { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
