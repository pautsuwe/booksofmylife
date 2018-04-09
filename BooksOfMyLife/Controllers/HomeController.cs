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
            BookModel model = new BookModel();
            //model.PossibleGenres = _bookManager.GetGenres();
            return View(model);
        }

        public ActionResult EditBook(int bookId)
        {
            BookModel model = _bookManager.GetBoook(bookId);
            //model.PossibleGenres = bookManager.GetGenres();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookModel model)
        {
            _bookManager.AddNewBook(model);

            return RedirectToAction("Index");
        }

        public ActionResult ListAllBooks()
        {
            var models = _bookManager.GetAllBooks();
            return View(models);
        }

        private void ModelToEntity()
        {

        }
    }
}