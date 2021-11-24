using Lesson4.Classes;
using System;


namespace Lesson4
{
    class Program
    {
        static void Start()
        {
            Console.WriteLine("Тестирование Целевого класса \n");
            var taget = new Target();
            taget.CreateDB();
            taget.CreateTable();
            taget.SaveToDB();
            taget.LoadFromDB();
            taget.Print();

            Console.WriteLine("\n ------------------------------------------------------------------------------------------------ \n");

            Console.WriteLine("Тестирование Адаптера к целевому классу \n");
            var adaptee = new Adapter();
            adaptee.CreateDB();
            adaptee.CreateTable();
            adaptee.SaveToDB();
            adaptee.LoadFromDB();
            adaptee.Print();

            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
