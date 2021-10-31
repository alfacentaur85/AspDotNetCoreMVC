using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3.AbstractFactory.Interfaces
{
    public interface IChocolateFactory
    {
        public IChcolatePaste CreateChocolatePaste();
        public IChocolateCandies CreateChocolateCandies();
        public IChocolateBar CreateChocolateBar();

    }
}
