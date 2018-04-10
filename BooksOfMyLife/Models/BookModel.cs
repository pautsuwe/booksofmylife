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
        public int CreatedBy { get; set; }

        [Display(Name = "Lisäysaika")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Display(Name = "Nimi")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Kirjailija")]
        public AuthorModel Author { get; set; }

        [Display(Name = "Julkaisuvuosi")]
        public int? PublishingYear { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int SelectedGenreId { get; set; }

        [Display(Name = "Sivumäärä")]
        public int? PageCount { get; set; }

        [Display(Name="Kirjakerhokirja")]
        public bool isKKK { get; set; }

        public List<Genre> PossibleGenres { get; set; }
    }
}