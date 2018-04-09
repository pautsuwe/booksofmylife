using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Display(Name = "Lisääjä")]
        public int CreatedBy { get; set; }

        [Display(Name = "Lisäysaika")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Nimi")]
        public string Name { get; set; }

        [Display(Name = "Kirjailija")]
        public AuthorModel Author { get; set; }

        [Display(Name = "Julkaisuvuosi")]
        public int? PublishingYear { get; set; }

        //public Genre SelectedGenre { get; set; }

        [Display(Name = "Sivumäärä")]
        public int? PageCount { get; set; } 
        
        //public IEnumerable<Genre> PossibleGenres { get; set; }
    }
}