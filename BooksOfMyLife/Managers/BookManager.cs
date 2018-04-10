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
        void UpdateBook(BookModel model);
        BookModel GetBook(int id);
        IEnumerable<BookModel> GetAllBooks();
        IEnumerable<BookModel> GetKkkBooks();
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

        public void UpdateBook(BookModel model)
        {
            var bookEntity = Mapper.Map<BookModel, Book>(model);
            var updatable = _bookContext.Books.Find(model.Id);
            _bookContext.Entry(updatable).CurrentValues.SetValues(bookEntity);
            _bookContext.SaveChanges();
        }

        public BookModel GetBook(int id)
        {           
            var bookEntity = _bookContext.Books.Find(id);
            var model = Mapper.Map<Book, BookModel>(bookEntity);
            return model;
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            List<BookModel> models = new List<BookModel>();
            foreach(var book in _bookContext.Books)
            {
                var model = Mapper.Map<Book, BookModel>(book);
                models.Add(model);
            }
            return models;
        }

        public IEnumerable<BookModel> GetKkkBooks()
        {
            List<BookModel> models = new List<BookModel>();
            foreach (var book in _bookContext.Books.Where(x => x.isKKK))
            {
                var model = Mapper.Map<Book, BookModel>(book);
                models.Add(model);
            }
            return models;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _bookContext.Genres;
        }
    }
}