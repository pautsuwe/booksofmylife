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
    public interface IBookManager
    {
        int AddNewBook(BookModel model);
        BookModel GetBoook(int id);
        IEnumerable<BookModel> GetAllBooks();
        IEnumerable<Genre> GetGenres();
    }


    public class BookManager : IBookManager
    {
        private BookContext _bookContext { get; set; }
        public BookManager()
        {
            _bookContext = new BookContext();
        }

        public int AddNewBook(BookModel model)
        {
            var bookEntity = Mapper.Map<BookModel, Book>(model);
            bookEntity.CreatedAt = DateTime.Now;
            //bookEntity.CreatedBy = sovellusta käyttävä käyttäjä
            var addedEntity = _bookContext.Books.Add(bookEntity);
            _bookContext.SaveChanges();

            return addedEntity.ID;
        }

        public BookModel GetBoook(int id)
        {
            return new BookModel();
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            List<BookModel> models = new List<BookModel>();
            foreach(var book in _bookContext.Books)
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
            return _bookContext.Genres;
        }
    }
}