using System;
using System.Threading;

namespace ListWrapper
{

    class Program
    {
        private static readonly int _countOfListItems = 10;

        private static ListWrapper<int> lst = new ListWrapper<int>();

        static void Main(string[] args)
        {

            Thread threadAdd = new Thread(new ThreadStart(() => TestAdd(_countOfListItems)));

            Thread threadRemove = new Thread(new ThreadStart(() => TestRemove(_countOfListItems)));

            threadAdd.Start();

            threadRemove.Start();

            Thread.Sleep(2000);

            Random r = new Random();

            int rndValue = 0;

            for (int i = 0; i < _countOfListItems; i++)
            {
                lst.Add(i);

                Console.WriteLine("Поток Main добавил элемент: {0}", i);

                PrintList();

                rndValue = r.Next(10);

                lst.Remove(rndValue);

                Console.WriteLine("Поток Main пытался удалить элемент: {0}", rndValue);

                PrintList();

                Thread.Sleep(400);
            }

        }

        private static void TestAdd(int countOfListItems)
        {
            for (int i = 0; i < countOfListItems; i++)
            {
                lst.Add(i);

                Console.WriteLine("Поток TestAdd добавил элемент: {0}", i);

                PrintList();

                Thread.Sleep(400);
            }
        }

        private static void TestRemove(int otem)
        {
            Random r = new Random();
            int rndValue = 0;
            for (int i = 0; i < _countOfListItems; i++)
            {
                Thread.Sleep(400);

                rndValue = r.Next(10);

                lst.Remove(rndValue);

                Console.WriteLine("Поток TestRemove пытался удалить  элемент: {0}", rndValue);

                PrintList();          
            }                                      
        }

        private static void PrintList()
        {
            Console.WriteLine();

            Console.WriteLine("Список: ");

            for (int i = 0; i < lst.Count; i++)
            {
                Console.Write(String.Concat(lst[i], " "));
            }

            Console.WriteLine("\n");
        }
    }
}
