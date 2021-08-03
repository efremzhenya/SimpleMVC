using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleMVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [StringLength(maximumLength:100)]
        public string Author { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}