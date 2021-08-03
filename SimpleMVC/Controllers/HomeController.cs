using SimpleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork uow;

        public HomeController()
        {
            uow = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(uow.Books.GetAll());
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
                uow.Books.Create(book);
                uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var book = uow.Books.Get(id.Value);
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
                uow.Books.Update(book);
                uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                uow.Books.Delete(id.Value);
                uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();
            base.Dispose(disposing);
        }
    }
}