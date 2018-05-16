using BooksOfMyLife.Managers;
using BooksOfMyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksOfMyLife.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorManager _authorManager { get; set; }
        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public int Save(AuthorModel model)
        {
            //if (ModelState.IsValid)
            //{
                int? authorId = model.Id;
                if (model.Id > 0)
                {
                    _authorManager.UpdateAuthor(model);
                }
                else
                {
                    authorId = _authorManager.AddNewAuthor(model);
                }
                return authorId.Value;
            //}
            //return 0;
        }

        public ActionResult AddAuthor()
        {
            return PartialView("_EditAuthorPartial");
        }

        public JsonResult GetAllAuthors()
        {
            var authors = _authorManager.GetAllAuthors();
            return Json(authors, JsonRequestBehavior.AllowGet); 
        }
    }
}