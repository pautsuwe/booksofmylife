using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Display(Name="Etunimi")]
        public string FirstName { get; set; }
        [Display(Name = "Sukunimi")]
        public string LastName { get; set; }

        public string WholeName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        //public Country SelectedCountry { get; set; }

        //public IEnumerable<Country> PossibleCountries { get; set; }
    }
}