using AutoMapper;
using BooksOfMyLife.Entities;
using BooksOfMyLife.Managers;
using BooksOfMyLife.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksOfMyLife.Controllers
{
    public class HomeController : Controller
    {
        private IBookManager _bookManager { get; set; }
        private IAuthorManager _authorManager { get; set; }
        private ApplicationUserManager _userManager { get; set; }
        public HomeController(IBookManager bookManager, IAuthorManager authorManager, IUserStore<ApplicationUser> userStore)
        {
            _bookManager = bookManager;
            _authorManager = authorManager;
        }

        
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddBook()
        {
            BookModel model = new BookModel();
            model.Genres = new List<Genre>();          
            var genres = _bookManager.GetGenres().ToList();
            model.PossibleGenres = new List<SelectListItem>();
            foreach(var genre in genres)
            {
                model.PossibleGenres.Add(new SelectListItem()
                {
                    Value = genre.Id.ToString(),
                    Text = genre.Name,
                    Selected = false,
                });
            }
            model.PossibleGenres.OrderBy(x => x.Text);
            model.AllAuthors = _authorManager.GetAllAuthors();
            return View(model);
        }

        public ActionResult EditBook(int id)
        {
            Book bookEntity = _bookManager.GetBook(id);
            var user = UserManager.FindById(bookEntity.CreatedBy);
            BookActivity bookActivityEntity = _bookManager.GetBookActivity(user.Id, id);
            BookModel model = Mapper.Map<Book, BookModel>(bookEntity);
            if( bookActivityEntity != null) model.IsRead = bookActivityEntity.IsRead;
            var genres = _bookManager.GetGenres().ToList();
            model.PossibleGenres = new List<SelectListItem>();
            foreach (var genre in genres)
            {
                model.PossibleGenres.Add(new SelectListItem()
                {
                    Value = genre.Id.ToString(),
                    Text = genre.Name,
                    Selected = bookEntity.BookGenres.Where(x => x.GenreId == genre.Id).Any(),
                });
            }
            model.PossibleGenres.OrderBy(x => x.Text);
            model.AllAuthors = _authorManager.GetAllAuthors();            
            model.CreatedByName = user.FirstName + " " + user.LastName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookModel model)
        {
            var bookId = model.Id;           
            
            if ( bookId > 0)
            {
                List<BookGenre> genres = new List<BookGenre>();
                foreach (var selectedGenre in model.PossibleGenres.Where(x => x.Selected))
                {
                    genres.Add(new BookGenre()
                    {
                        BookId = bookId,
                        GenreId = Int32.Parse(selectedGenre.Value)
                    });                    
                }
                
                var bookEntity = Mapper.Map<BookModel, Book>(model);
                _bookManager.UpdateBook(bookEntity);

                var bookActivityEntity = _bookManager.GetBookActivity(model.CreatedBy, model.Id);
                if (bookActivityEntity != null)
                {
                    bookActivityEntity.IsRead = model.IsRead;
                    _bookManager.UpdateBookActivity(bookActivityEntity);
                }               

            }
            else
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                var bookEntity = Mapper.Map<BookModel, Book>(model);
                bookId = _bookManager.AddNewBook(bookEntity, user);

                if( model.IsRead)
                {
                    var bookActivity = new BookActivity();
                    bookActivity.UserId = user.Id;
                    bookActivity.BookId = bookId;
                    bookActivity.IsRead = model.IsRead;
                    _bookManager.UpdateBookActivity(bookActivity);                    
                }
                foreach (var selectedGenre in model.PossibleGenres.Where(x => x.Selected))
                {
                    _bookManager.AddBookGenre(bookId, Int32.Parse(selectedGenre.Value));
                }
            }         
            

            return RedirectToAction("Index");
        }

        public ActionResult ListAllBooks()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());            
            var bookEntities = _bookManager.GetAllBooks();
            List<BookSimpleModel> models = BuildSimpleBookModels(bookEntities, user.Id);
            
            return View("AllBooks", models);
        }

        public ActionResult ListKkkBooks()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var bookEntities = _bookManager.GetKkkBooks();
            List<BookSimpleModel> models = BuildSimpleBookModels(bookEntities, user.Id); 
            return View("KkkBooks", models);
        }

        public ActionResult ListOwnBooks()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var ownBookEntities = _bookManager.GetOwnReadBooks(user.Id);
            List<BookSimpleModel> models = new List<BookSimpleModel>();
            foreach (var bookEntity in ownBookEntities)
            {
                var model = new BookSimpleModel();
                model.Author = Mapper.Map<Author, AuthorModel>(bookEntity.Author);
                model.Id = bookEntity.ID;
                model.Name = bookEntity.Name;
                model.IsRead = true;
                models.Add(model);
            }            
            
            return View("OwnBooks", models);
        }

        [HttpPost]
        public void MarkBookAsRead(int bookId)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var bookActivity = _bookManager.GetBookActivity(user.Id, bookId);
            if( bookActivity == null)
            {
                bookActivity = new BookActivity();
                bookActivity.UserId = user.Id;
                bookActivity.BookId = bookId;                                
            }
            bookActivity.IsRead = true;
            _bookManager.UpdateBookActivity(bookActivity);
        }

        public ActionResult ShowBookDetails(int id)
        {                       
            var book = _bookManager.GetBook(id);
            var user = UserManager.FindById(book.CreatedBy);
            BookModel model = Mapper.Map<Book, BookModel>(book);
            var genres = _bookManager.GetGenres();
            model.Genres = new List<Genre>();
            foreach (var bookGenre in book.BookGenres)
            {
                model.Genres.Add(genres.Single(x => x.Id == bookGenre.GenreId));
            }
            
            model.CreatedByName = user.FirstName + " " + user.LastName;
            return View("BookDetails", model);
        }

        private List<BookSimpleModel> BuildSimpleBookModels(IEnumerable<Book> books, string userId)
        {
            var models = new List<BookSimpleModel>();
            foreach (var book in books)
            {
                var model = new BookSimpleModel();
                model.Author = Mapper.Map<Author, AuthorModel>(book.Author);
                model.Name = book.Name;
                model.Id = book.ID;
                var bookActivity = _bookManager.GetBookActivity(userId, book.ID);
                if( bookActivity != null)
                {
                    model.IsRead = bookActivity.IsRead;
                }                
                models.Add(model);
            }
            return models;
        }
    }
}