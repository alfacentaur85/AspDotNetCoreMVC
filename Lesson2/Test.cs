using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lesson2
{
    public class Test
    {

        public int ThreadNum = 0;
        
        public void ActionMethod()
        { 
            var rnd = new Random();
            var n = rnd.Next(10, 30);
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("Working thread #{0}: {1}", this.ThreadNum, i);
                Thread.Sleep(n);
            }
            ThreadPool<Thread>.Release(ThreadNum);
        }
    }
}
