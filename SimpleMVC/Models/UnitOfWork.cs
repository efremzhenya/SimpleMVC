using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC.Models
{
    public class UnitOfWork : IDisposable
    {
        private BookContext db = new BookContext();
        private BookRepository bookRepository;
        private bool disposed = false;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public void Save() => db.SaveChanges();

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}