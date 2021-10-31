using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Lesson2
{
    public static class ThreadPool<Object>
    {
        private static  ConcurrentQueue<KeyValuePair<int, Thread>> _queue = new ConcurrentQueue<KeyValuePair<int,Thread>>();

        private static ConcurrentDictionary<int, Thread> _workingThread = new ConcurrentDictionary<int, Thread>();

        private static  int _maxThreadCount = 0;

        private static  int _countOfCreatedThread = 0;

        public static int maxThreadCount 
        {
            get
            {
                return _maxThreadCount;
            }

            set 
            {
                _maxThreadCount = value;
            } 
        }

        public static KeyValuePair<int, Thread> Get(Action action)
        {
            KeyValuePair<int,Thread> item;
            if (_queue.Count > 0)
            {
                if (!_queue.TryDequeue(out item))
                {
                    throw new Exception("Cannot dequeue thread");
                }
                Console.WriteLine("Allocated thread #{0}", item.Key);
                item = new KeyValuePair<int, Thread>(item.Key, new Thread(new ThreadStart(action))); ;
                return item;
            }
            else
            {
                if (_countOfCreatedThread < _maxThreadCount)
                {
                    var result = new KeyValuePair<int, Thread>(++_countOfCreatedThread, new Thread(new ThreadStart(action)));

                    result.Value.IsBackground = true;

                    if (!_workingThread.TryAdd(result.Key, result.Value))
                    {
                        Console.WriteLine("Cannot save working thread #{0}", result.Key);
                    }

                    Console.WriteLine("Created thread #{0}", _countOfCreatedThread);

                    return result;
                }
                else
                {
                    Console.WriteLine("Size of ThreadPool has reached maximum - {0}", _countOfCreatedThread);
                }
            }
            return default(KeyValuePair<int, Thread>);
        }

        public static void Release(int itemNum)
        {
            Thread item;

            if (!_workingThread.TryRemove(itemNum, out item))
            {
                Console.WriteLine("Cannot returning thread into the ThreadPool or one is not assigned");
            }
            else
            {
                _queue.Enqueue(new KeyValuePair<int, Thread>(itemNum, item));

                Console.WriteLine("Thread #{0} is returned into the ThreadPool", itemNum);
            }  

        }

    }
}
