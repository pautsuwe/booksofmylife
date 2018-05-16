using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    [Table("BookActivity")]
    public class BookActivity
    {
        public int Id { get; set; }
        public int BookId { get; set; }        
        public string UserId { get; set; }
        public bool IsRead { get; set; }
        public int? ReadingYear { get; set; }
        public int? Score { get; set; }
        public bool OnWishList { get; set; }
        
        //huom. muokkauksessa voi lisätä vuoden ja arvostelun, listauksesta voi klikata luetuksi

        public virtual Book Book { get; set; }
    }
}