using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _70_483Prep
{
    //ThreadClass
    class Program
    {
        public static void ThreadMethod(object x)
        {
            for(int i = 0; i<(int)x; i++)
            {
                Console.WriteLine($"ThreadProc {i}");
                Thread.Sleep(1);
            }
        }

        //static void Main(string[] args)
        //{
        //    bool stopped = false;
        //    Thread t = new Thread(new ThreadStart(() =>
        //    {
        //        while (!stopped)
        //        {
        //            Console.WriteLine("Running...");
        //            Thread.Sleep(1000);
        //        }
        //    }));

        //    t.Start();

        //    Console.WriteLine("Press any key to exit");

        //    Console.ReadKey();

        //    stopped = true;

        //    t.Join();
        //}
        //*********************
        //[ThreadStatic]
        //public static int _field;

        //public static ThreadLocal<int> _field =
        //    new ThreadLocal<int>(() =>
        //    {
        //        return Thread.CurrentThread.ManagedThreadId;
        //    });

        //static void Main(string[] args)
        //{
        //    new Thread(() =>
        //    {
        //        for(int x = 0; x < _field.Value; x++)
        //        {
        //            Console.WriteLine($"Thread A: {x}");
        //            //_field++;
        //        }
        //    }).Start();

        //    new Thread(() =>
        //    {
        //        for (int x = 0; x < _field.Value; x++)
        //        {
        //            Console.WriteLine($"Thread B: {x}");
        //            //_field++;
        //        }
        //    }).Start();

        //    Console.ReadKey();

        //}
        //*********************
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working from pool.");
            });

            Console.ReadKey();

        }

    }
}
