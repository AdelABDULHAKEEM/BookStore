using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers.API
{
    //Routing System
    public class BookStoreController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Archive(string Title, int NumberOfPages, string author)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //Get All Books
        public IHttpActionResult GetAllBooks()
        {
            IList<Book> books = null;

            using (var ctx = new BookStoreDBContext())
            {
                books = ctx.Books.Include("Book")
                            .Select(s => new Book()
                            {
                                Title = s.Title,
                                Pages = s.Pages,
                                Author = s.Author
                            }).ToList<Book>();
            }

            if (books.Count == 0)
            {
                return NotFound();
            }

            return Ok(books);
        }

        //api/BookStore/AddBook?book=Java
        [Route("api/data/AddBook")]
        [HttpPost]
        public IHttpActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BookStoreDBContext())
            {
                ctx.Books.Add(new Book()
                {
                    Title = book.Title,
                    Pages = book.Pages,
                    Author = book.Author
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new BookStoreDBContext())
            {
                var existingBook = ctx.Books.Where(s => s.ID == book.ID)
                                                        .FirstOrDefault<Book>();

                if (existingBook != null)
                {
                    existingBook.Pages = book.Pages;
                    existingBook.Author = book.Author;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Book id");

            using (var ctx = new BookStoreDBContext())
            {
                var student = ctx.Books
                    .Where(s => s.ID == id)
                    .FirstOrDefault();

                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

       
       

    }
}
