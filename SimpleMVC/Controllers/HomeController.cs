using SimpleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVC.Controllers
{
    [CustomExceptionFilter]
    public class HomeController : Controller
    {
        private UnitOfWork UOW { get; }

        public HomeController()
        {
            UOW = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(UOW.Books.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                UOW.Books.Create(book);
                UOW.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var book = UOW.Books.Get(id.Value);
                if (book != null)
                {
                    return View(book);
                }
            }
            return HttpNotFound();

        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                UOW.Books.Update(book);
                UOW.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                UOW.Books.Delete(id.Value);
                UOW.Save();
                return RedirectToAction(nameof(Index));
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            UOW.Dispose();
            base.Dispose(disposing);
        }
    }
}