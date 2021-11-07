using System;
using Lesson3.AbstractFactory.Models.Babaevsky;
using Lesson3.AbstractFactory.Models.RedOctober;
using Lesson3.AbstractFactory.Enums;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test RedOctober
            try
            {
                TestApp testAppRedOctober = new TestApp(new RedOctoberChocolateFactory());
                //RedOctober _chcolatePaste
                testAppRedOctober._chcolatePaste.CocoaContent = 50M;
                testAppRedOctober._chcolatePaste.ContentedNuts = Nuts.HAZELNUTS;
                testAppRedOctober._chcolatePaste.MaterialPackage = MaterialPackage.GLASS;
                testAppRedOctober._chcolatePaste.Volume = 350.0M;
                testAppRedOctober._chcolatePaste.Weight = 400.00M;
                testAppRedOctober._chcolatePaste.Make();
                testAppRedOctober._chcolatePaste.Eat();

                //RedOctober _chocolateBar
                testAppRedOctober._chocolateBar.CocoaContent = 25M;
                testAppRedOctober._chocolateBar.ContentedNuts = Nuts.NONE;
                testAppRedOctober._chocolateBar.MaterialPackage = MaterialPackage.PLASTIC;
                testAppRedOctober._chocolateBar.Make();
                testAppRedOctober._chocolateBar.Eat();
                testAppRedOctober._chocolateBar.Present();

                //RedOctober _chocolateCandies
                testAppRedOctober._chocolateCandies.Weight = 400M;
                testAppRedOctober._chocolateCandies.MaterialPackage = MaterialPackage.PAPER;
                testAppRedOctober._chocolateCandies.Make();
                testAppRedOctober._chocolateCandies.CocoaContent = 40M;
                testAppRedOctober._chocolateCandies.ContentedNuts = Nuts.ALMONDS;
                testAppRedOctober._chocolateCandies.CountInBox = 40;
                testAppRedOctober._chocolateCandies.Make();
                testAppRedOctober._chocolateCandies.Eat();
                testAppRedOctober._chocolateCandies.Present();

                Console.WriteLine("Test RedOctoberChocolateFactory is OK");
            }
            catch
            {
                Console.WriteLine("Test RedOctoberChocolateFactory is FAILED");
            }

            //Test Babaevsky
            try
            {
                TestApp testAppBabaevsky = new TestApp(new BabaevskyChocolateFactory());
                //RedOctober _chcolatePaste
                testAppBabaevsky._chcolatePaste.CocoaContent = 50M;
                testAppBabaevsky._chcolatePaste.ContentedNuts = Nuts.HAZELNUTS;
                testAppBabaevsky._chcolatePaste.MaterialPackage = MaterialPackage.GLASS;
                testAppBabaevsky._chcolatePaste.Volume = 350.0M;
                testAppBabaevsky._chcolatePaste.Weight = 400.00M;
                testAppBabaevsky._chcolatePaste.Make();
                testAppBabaevsky._chcolatePaste.Eat();

                //RedOctober _chocolateBar
                testAppBabaevsky._chocolateBar.CocoaContent = 25M;
                testAppBabaevsky._chocolateBar.ContentedNuts = Nuts.NONE;
                testAppBabaevsky._chocolateBar.MaterialPackage = MaterialPackage.PLASTIC;
                testAppBabaevsky._chocolateBar.Make();
                testAppBabaevsky._chocolateBar.Eat();
                testAppBabaevsky._chocolateBar.Present();

                //RedOctober _chocolateCandies
                testAppBabaevsky._chocolateCandies.Weight = 400M;
                testAppBabaevsky._chocolateCandies.MaterialPackage = MaterialPackage.PAPER;
                testAppBabaevsky._chocolateCandies.Make();
                testAppBabaevsky._chocolateCandies.CocoaContent = 40M;
                testAppBabaevsky._chocolateCandies.ContentedNuts = Nuts.ALMONDS;
                testAppBabaevsky._chocolateCandies.CountInBox = 40;
                testAppBabaevsky._chocolateCandies.Make();
                testAppBabaevsky._chocolateCandies.Eat();
                testAppBabaevsky._chocolateCandies.Present();

                Console.WriteLine("Test BabaevskyChocolateFactory is OK");
            }
            catch
            {
                Console.WriteLine("Test  BabaevskyChocolateFactory is FAILED");
            }

        }
    }
}
