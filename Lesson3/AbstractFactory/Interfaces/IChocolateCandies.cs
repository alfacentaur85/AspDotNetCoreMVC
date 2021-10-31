using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3.AbstractFactory.Interfaces
{
    public interface IChocolateCandies : IBaseProduct, IPresentableProduct
    {
        public uint CountInBox { get; set; }
    }
}
