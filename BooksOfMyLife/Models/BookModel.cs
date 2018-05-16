using BooksOfMyLife.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksOfMyLife.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Display(Name = "Lisääjä")]
        public string CreatedBy { get; set; }

        [Display(Name = "Lisääjä")]
        public string CreatedByName { get; set; }

        [Display(Name = "Lisäysaika")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Display(Name = "Nimi")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Kirjailija")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Display(Name = "Julkaisuvuosi")]
        public int? PublishingYear { get; set; }

        //[Required]
        //[Display(Name = "Genre")]
        //public int GenreId { get; set; }
        
        //[Display(Name = "Genret")]
        //public List<int> GenreIds { get; set; }

        [Display(Name = "Sivumäärä")]
        public int? PageCount { get; set; }

        [Display(Name="Kirjakerhokirja")]
        public bool IsKKK { get; set; }

        [Display(Name="On luettu")]
        public bool IsRead { get; set; }

        public List<Genre> Genres { get; set; }
        public List<AuthorModel> AllAuthors { get; set; }
        public List<SelectListItem> PossibleGenres { get; set; }
    }
}