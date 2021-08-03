using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleMVC.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            context.Books.AddRange(new Book[]
            {
                new Book
                {
                    Name = "Война и мир",
                    Author = "Л. Толстой",
                    Price = 220,
                },
                new Book
                {
                    Name = "О чем я говорю, когда говорю о беге",
                    Author = "Х. Мураками",
                    Price = 200
                }
            });

            base.Seed(context);
        }
    }
}