using System;
using System.Collections.Generic;
using System.Text;
using Lesson4.Interfaces;

namespace Lesson4.Models
{

    public class Product : IProduct
    {
        public int ProductID { get; set; }
        public int Article { get; set; }
        public string Name { get; set; }
        public string Notification { get; set; }
        public double Weight { get; set; }
        public double Long { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public decimal Price { get; set; }
        public DateTime DateMade { get; set; }
        public int Count { get; set; }
    }
}
