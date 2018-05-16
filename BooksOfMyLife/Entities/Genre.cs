﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Entities
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }        
    }
}