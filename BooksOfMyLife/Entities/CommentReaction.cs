using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    [Table("CommentReaction")]
    public class CommentReaction
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int Type { get; set; }
        public int CommentId { get; set; }

        //käyttäjä joka lisännyt
        public virtual Comment Comment { get; set; }
    }
}