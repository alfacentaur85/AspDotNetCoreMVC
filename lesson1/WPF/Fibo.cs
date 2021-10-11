using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Threading;

namespace lesson1
{
    public class Fibo
    {
        public static int fib(int n)
        {
            return n > 1 ? fib(n - 1) + fib(n - 2) : n;
        }
    }
}
