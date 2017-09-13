using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQExamples.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual Category Category { get; set; }

        public DateTime Publish { get; set; }

        public virtual Author Author { get; set; }
    }
}