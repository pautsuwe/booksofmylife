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
        int AddNewBook(Book model, ApplicationUser user);
        void UpdateBook(Book model);
        Book GetBook(int id);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetKkkBooks();
        IEnumerable<Genre> GetGenres();
        IEnumerable<Book> GetOwnReadBooks(string userId);
        BookActivity GetBookActivity(string userId, int bookId);
        void UpdateBookActivity(BookActivity bookActivity);
        void AddBookGenre(int bookId, int genreId);
    }


    public class BookManager : IBookManager
    {
        private BookContext _bookContext { get; set; }
        public BookManager()
        {
            _bookContext = new BookContext();
        }

        public int AddNewBook(Book bookEntity, ApplicationUser user)
        {            
            bookEntity.CreatedAt = DateTime.Now;
            bookEntity.CreatedBy = user.Id;
            var addedEntity = _bookContext.Books.Add(bookEntity);
            _bookContext.SaveChanges();

            return addedEntity.ID;
        }

        public void UpdateBook(Book bookEntity)
        {            
            var updatable = _bookContext.Books.Find(bookEntity.ID);
            if( updatable != null)
            {
                _bookContext.Entry(updatable).CurrentValues.SetValues(bookEntity);
                _bookContext.SaveChanges();
            }
        }

        public Book GetBook(int id)
        {           
            return _bookContext.Books.Find(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {            
            return _bookContext.Books;
        }

        public IEnumerable<Book> GetKkkBooks()
        {            
            return _bookContext.Books.Where(x => x.isKKK);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _bookContext.Genres;
        }

        public IEnumerable<Book> GetOwnReadBooks(string userId)
        {
            var ownBookActivities = _bookContext.BookActivities.Where(x => x.UserId == userId && x.IsRead);
            var books = new List<Book>();
            foreach (var activity in ownBookActivities)
            {
                var book = _bookContext.Books.Find(activity.BookId);
                if (book != null) books.Add(book);
            }
            return books;
        }

        public BookActivity GetBookActivity(string userId, int bookId)
        {
            return _bookContext.BookActivities.SingleOrDefault(x => x.UserId == userId && x.BookId == bookId);            
        }

        public void UpdateBookActivity(BookActivity bookActivity)
        {
            if( bookActivity.Id > 0)
            {
                var updatable = _bookContext.BookActivities.Find(bookActivity.Id);
                _bookContext.Entry(updatable).CurrentValues.SetValues(bookActivity);
            }
            else
            {
                _bookContext.BookActivities.Add(bookActivity);
            }
            _bookContext.SaveChanges();
        }

        public void AddBookGenre(int bookId, int genreId)
        {
            _bookContext.BookGenres.Add(new BookGenre()
            {
                BookId = bookId,
                GenreId = genreId
            });
            _bookContext.SaveChanges();
        }
    }
}