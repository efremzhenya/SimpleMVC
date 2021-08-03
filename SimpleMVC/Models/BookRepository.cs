using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleMVC.Models
{
    public class BookRepository : IRepository<Book>
    {
        private BookContext db;
        public BookRepository(BookContext bookContext)
        {
            db = bookContext;
        }

        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
            }
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}