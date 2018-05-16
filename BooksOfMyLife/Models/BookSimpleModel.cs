using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Models
{
    public class BookSimpleModel
    {
        public int Id { get; set; }
        [Display(Name = "Nimi")]
        public string Name { get; set; }

        [Display(Name = "Kirjailija")]
        public AuthorModel Author { get; set; }
        public bool IsRead { get; set; }
    }
}