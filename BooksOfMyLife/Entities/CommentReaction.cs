using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
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