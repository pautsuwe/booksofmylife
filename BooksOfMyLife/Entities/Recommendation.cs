using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    public class Recommendation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Target { get; set; } 

        //käyttäjä joka lisännyt
        public virtual Book Book { get; set; }
    }
}