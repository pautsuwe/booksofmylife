using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    [Table("Book")]
    public class Book
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int? PublishingYear { get; set; }
        public int? PageCount { get; set; }
        public bool isKKK { get; set; }
            
        //TODO: pois kun tätä ei käytetä?
        public virtual List<BookGenre> BookGenres { get; set; }
        public virtual Author Author { get; set; }        
        public virtual ICollection<Comment> Comments { get; set; }
    }
}