using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Country SelectedCountry { get; set; }

        //public IEnumerable<Country> PossibleCountries { get; set; }
    }
}