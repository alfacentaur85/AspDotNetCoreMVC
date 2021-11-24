using System;
using System.Collections.Generic;
using System.Text;
using Lesson4.Interfaces;

namespace Lesson4.Models
{
    public class ProductNew : IProduct
    {
        public int ProductID { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
        public DateTime DateExpired { get; set; }
        public bool IsMedical { get; set; }
        public int TemperatureKeepFrom { get; set; }
        public int TemperatureKeepTo { get; set; }



    }
}
