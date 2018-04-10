using BooksOfMyLife.Managers;
using BooksOfMyLife.Models;
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
        public HomeController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddBook()
        {
            BookModel model = new BookModel();
            model.PossibleGenres = _bookManager.GetGenres().ToList();
            model.PossibleGenres.OrderBy(x => x.Name);
            return View(model);
        }

        public ActionResult EditBook(int id)
        {
            BookModel model = _bookManager.GetBook(id);
            model.PossibleGenres = _bookManager.GetGenres().ToList();
            model.PossibleGenres.OrderBy(x => x.Name);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookModel model)
        {
            if( model.Id > 0)
            {
                _bookManager.UpdateBook(model);
            }
            else
            {
                _bookManager.AddNewBook(model);
            }            

            return RedirectToAction("Index");
        }

        public ActionResult ListAllBooks()
        {
            var models = _bookManager.GetAllBooks();
            return View("ListBooks", models);
        }

        public ActionResult ListKkkBooks()
        {
            var models = _bookManager.GetKkkBooks();
            return View("ListBooks", models);
        }

        public ActionResult ShowBookDetails(int id)
        {
            BookModel model = _bookManager.GetBook(id);
            return View("BookDetails", model);
        }

        private void ModelToEntity()
        {

        }
    }
}