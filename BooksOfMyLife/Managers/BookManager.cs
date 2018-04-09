using AutoMapper;
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
            var bookEntity = Mapper.Map<BookModel, Book>(model);
            bookEntity.CreatedAt = DateTime.Now;
            //bookEntity.CreatedBy = sovellusta käyttävä käyttäjä
            var addedEntity = context.Books.Add(bookEntity);
            context.SaveChanges();

            return addedEntity.ID;
        }

        public BookModel GetBoook(int id)
        {
            return new BookModel();
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            BookContext context = new BookContext();
            List<BookModel> models = new List<BookModel>();
            foreach(var book in context.Books)
            {
                var model = new BookModel();
                model.CreatedAt = book.CreatedAt;
                model.CreatedBy = book.CreatedBy;
                model.Id = book.ID;
                model.Name = book.Name;
                model.PageCount = book.PageCount;
                model.PublishingYear = book.PublishingYear;
                models.Add(model);
                //models.Add(Mapper.Map<Book, BookModel>(book));
            }
            return models;
        }

        public IEnumerable<Genre> GetGenres()
        {
            BookContext context = new BookContext();
            return context.Genres;
        }
    }
}