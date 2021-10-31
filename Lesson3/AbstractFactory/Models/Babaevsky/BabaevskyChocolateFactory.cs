using System;
using System.Collections.Generic;
using System.Text;
using Lesson3.AbstractFactory.Interfaces;

namespace Lesson3.AbstractFactory.Models.Babaevsky
{
    public sealed class BabaevskyChocolateFactory : IChocolateFactory
    {
        public IChocolateBar CreateChocolateBar()
        {
            return new BabaevskyChocolateBar();
        }

        public IChocolateCandies CreateChocolateCandies()
        {
            return new BabaevskyChocolateCandies();
        }

        public IChcolatePaste CreateChocolatePaste()
        {
            return new BabaevskyChocolatePaste();
        }
    }
}
