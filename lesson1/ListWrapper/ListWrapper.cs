using System;
using System.Collections.Generic;
using System.Text;

namespace ListWrapper
{
    
    public class ListWrapper<T> : List<T>
    {
        private static readonly object _obj = new object();

        new void Add(T item)
        {
            lock (_obj)
            {
                List<T> lst = new List<T>();
                
                lst = this;

                lst.Add(item);

            }
        }

        new bool Remove(T item)
        {
            lock (_obj)
            {
                try
                {
                    List<T> lst = new List<T>();

                    lst = this;

                    lst.Remove(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                return true;
            }
        }

    }
}
