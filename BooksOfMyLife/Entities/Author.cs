using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    [Table("Author")]
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int CountryId { get; set; }

        //public virtual Country Country { get; set; }
    }
}