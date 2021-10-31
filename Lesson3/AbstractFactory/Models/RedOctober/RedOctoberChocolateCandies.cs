using System;
using System.Collections.Generic;
using System.Text;
using Lesson3.AbstractFactory.Enums;
using Lesson3.AbstractFactory.Interfaces;

namespace Lesson3.AbstractFactory.Models.RedOctober
{
    public sealed class RedOctoberChocolateCandies : IChocolateCandies
    {
        public uint CountInBox { get; set; }
        public Nuts ContentedNuts { get; set; }
        public decimal Weight { get; set; }
        public decimal CocoaContent { get; set; }
        public MaterialPackage MaterialPackage { get; set; }

        public void Eat()
        {

        }

        public void Make()
        {
   
        }

        public void Present()
        {

        }
    }
}
