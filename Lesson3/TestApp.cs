using System;
using System.Collections.Generic;
using System.Text;
using Lesson3.AbstractFactory.Models.Babaevsky;
using Lesson3.AbstractFactory.Models.RedOctober;
using Lesson3.AbstractFactory.Interfaces;

namespace Lesson3
{
    public sealed class TestApp
    {
        public IChcolatePaste _chcolatePaste;
        public IChocolateBar _chocolateBar;
        public IChocolateCandies _chocolateCandies;
        private IChocolateFactory _chocolateFactory;

        public TestApp(IChocolateFactory chocolateFactory)
        {
            this._chocolateFactory = chocolateFactory;
            this.CreateChocolateProducts();
        }

        private void CreateChocolateProducts()
        {
            _chcolatePaste = _chocolateFactory.CreateChocolatePaste();
            _chocolateBar = _chocolateFactory.CreateChocolateBar();
            _chocolateCandies = _chocolateFactory.CreateChocolateCandies();
        }

    }
}
