using System;
using System.Collections.Generic;
using System.Text;
using Lesson3.AbstractFactory.Enums;


namespace Lesson3.AbstractFactory.Interfaces
{
   
    public interface IBaseProduct
    {
        public Nuts ContentedNuts { get; set; }
        public MaterialPackage MaterialPackage{ get; set; }
        public decimal Weight { get; set; }
        public decimal CocoaContent { get; set; }
        public void Make();
        public void Eat();

    }
}
