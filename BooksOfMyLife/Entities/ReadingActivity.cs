using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    public class ReadingActivity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int? ReadingYear { get; set; }
        public int? Score { get; set; }

        public virtual Book Book { get; set; }
    }
}