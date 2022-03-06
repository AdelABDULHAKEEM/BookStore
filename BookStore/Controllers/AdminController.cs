using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class AdminController : Controller
    {
        BookStoreDBContext db = new BookStoreDBContext();

        public ActionResult InsertBook()
        {   
            return View();

        }

        [HttpPost]
        public ActionResult InsertBook(Book b)
        {   
           if (ModelState.IsValid)
            {
                db.Books.Add(b);
                db.SaveChanges();
            }
            return View();
        }

      
        public ActionResult ShowDB_Book()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Edit(int id)
        {
            var emp = db.Books.Find(id);
            return View(emp);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book b)
        {
            var data = db.Books.Find(b.ID);
            if (data != null)
            {
                data.Title = b.Title;
                data.Pages = b.Pages;
                data.Author = b.Author;
               
            }
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("ShowDB_Book");
            }
           
            return View();
        }




    }
}