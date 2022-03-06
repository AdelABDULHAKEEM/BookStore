using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace BookStore.Models
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext()
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
