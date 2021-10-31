using System;
using System.Collections.Generic;
using System.Text;
using Lesson3.AbstractFactory.Interfaces;

namespace Lesson3.AbstractFactory.Models.RedOctober
{
    public sealed class RedOctoberChocolateFactory : IChocolateFactory
    {
        public IChocolateBar CreateChocolateBar()
        {
            return new RedOctoberChocolateBar();
        }

        public IChocolateCandies CreateChocolateCandies()
        {
            return new RedOctoberChocolateCandies();
        }

        public IChcolatePaste CreateChocolatePaste()
        {
            return new RedOctoberChocolatePaste();
        }
    }
}
