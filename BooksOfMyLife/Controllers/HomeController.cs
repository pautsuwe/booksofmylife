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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddBook()
        {
            BookManager bookManager = new BookManager();
            BookModel model = new BookModel();
            //model.PossibleGenres = bookManager.GetGenres();
            return View(model);
        }

        public ActionResult EditBook(int bookId)
        {
            BookManager bookManager = new BookManager();
            BookModel model = bookManager.GetBoook(bookId);
            //model.PossibleGenres = bookManager.GetGenres();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookModel model)
        {
            BookManager bookManager = new BookManager();
            bookManager.AddNewBook(model);

            return RedirectToAction("Index");
        }

        public ActionResult ListAllBooks()
        {
            BookManager bookManager = new BookManager();
            var models = bookManager.GetAllBooks();
            return View(models);
        }

        private void ModelToEntity()
        {

        }
    }
}