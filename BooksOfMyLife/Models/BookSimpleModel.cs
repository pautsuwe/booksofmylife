using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Models
{
    public class BookSimpleModel
    {
        [Display(Name = "Nimi")]
        public string Name { get; set; }

        [Display(Name = "Kirjailija")]
        public AuthorModel Author { get; set; }

        [Display(Name = "Julkaisuvuosi")]
        public int? PublishingYear { get; set; }
    }
}