using ConsumingRESTServiceCRUD_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ConsumingRESTServiceCRUD_Client.Controllers
{
    public class BookController : Controller
    {
        BookServiceClient db = new BookServiceClient();

        // GET: Book
        public ActionResult Index()
        {
            return View(db.getAllBook().ToList());
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AddBook(book);
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Book book = db.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Edit(book);
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }
        

        public ActionResult DetailsBook(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Book book = db.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [HttpGet]
        public ActionResult DeleteBook(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Book book = db.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [HttpPost]
        public ActionResult DeleteBook(int? id, Book b)
        {
            try
            {
                Book book = new Book();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    book = db.Find(id);
                    if (book == null)
                        return HttpNotFound();
                    db.DeleteBook(book.BookId);
                    return RedirectToAction("Index");
                }

                return View(book);
            }
            catch
            {
                return View();
            }
        }
    }
}