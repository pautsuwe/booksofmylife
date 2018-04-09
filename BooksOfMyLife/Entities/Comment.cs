using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }

        //käyttäjä joka lisännyt
        public virtual Book Book { get; set; }
        public virtual ICollection<CommentReaction> Reactions { get; set; }
    }
}