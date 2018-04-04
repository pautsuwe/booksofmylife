using BooksOfMyLife.DAL;
using BooksOfMyLife.Entities;
using BooksOfMyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Managers
{
    public class BookManager
    {
        public int AddNewBook(BookModel model)
        {
            BookContext context = new BookContext();
            context.Books.Add(model);
            context.Books.Find()
        }
    }
}