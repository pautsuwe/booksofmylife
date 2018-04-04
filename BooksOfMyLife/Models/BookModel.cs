using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int? PublishingYear { get; set; }
        public int Genre { get; set; }
        public int? PageCount { get; set; }
        public string Country { get; set; } //oikea tyyppi? miten toteuttaisi..        
    }
}