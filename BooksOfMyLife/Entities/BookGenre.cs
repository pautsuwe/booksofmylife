using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    [Table("BookGenre")]
    public class BookGenre
    {
        [Key]
        [Column(Order = 1)]
        public int GenreId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BookId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Book Book { get; set; }
    }
}