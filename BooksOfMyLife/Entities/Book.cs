using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int? PublishingYear { get; set; }
        public int GenreId { get; set; }
        public int? PageCount { get; set; }

        //käyttäjä joka lisäänyt
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}