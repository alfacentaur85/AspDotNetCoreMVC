using System;
using System.Threading;
using System.Collections.Generic;

namespace Lesson2
{
    class Program
    {
        private static readonly int _maxThreadCount = 10;

        static void Main(string[] args)
        {
            /*instance of ConfigManagment class*/
            var MyAppSet = new ConfigManagment();

            /*add setting MaxThreadCount*/
            MyAppSet.AddUpdateAppSettings("MaxThreadCount", _maxThreadCount);

            /*get setting MaxThreadCount*/
            var maxThreadCount = MyAppSet.ReadSetting("MaxThreadCount");

            Console.WriteLine("Maximux count of threads is: {0}", maxThreadCount);

            ThreadPool<Thread>.maxThreadCount = int.Parse(maxThreadCount);

            /*start test*/
            var rnd = new Random();
            var n = rnd.Next(10, 20);
            for (int i = 0; i <= n; i++)
            {
                var inst = new Test();
                KeyValuePair<int, Thread> p;
                do
                {
                  p = ThreadPool<Thread>.Get(inst.ActionMethod);
                  inst.ThreadNum = p.Key;
                } while (inst.ThreadNum == 0);
                          
                if (p.Value != null) 
                {
                    Console.WriteLine("Starting Thread #{0}", p.Key);
                    p.Value.Start();
                }
                
            }    

        }

    }

}
