using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> normList = new List<string>();
            //normList.Take(2);
            //BlockingCollection<string> bc = new BlockingCollection<string>();

            //Task read = Task.Run(() =>
            //{
            //    //while (true)
            //    //    Console.WriteLine(bc.Take());

            //    foreach (string v in bc.GetConsumingEnumerable())
            //        Console.WriteLine(v);
            //});

            //Task write = Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        string s = Console.ReadLine();
            //        if (string.IsNullOrEmpty(s)) break;
            //        else if(s == "writeall")
            //        {
            //            //.Take actually removes items from the collection, unlike normal Lists
            //            //foreach (string s2 in bc)
            //            //    Console.WriteLine(s2);


            //        }

            //        bc.Add(s);
            //    }
            //});

            //write.Wait();
            //****************************

            //ConcurrentBag<int> bag = new ConcurrentBag<int>();

            //bag.Add(42);
            //bag.Add(16);

            //int result;
            //if(bag.TryTake(out result))
            //{
            //    Console.WriteLine(result);
            //}

            //if (bag.TryPeek(out result))
            //{
            //    Console.WriteLine("There is a next item: " + result);
            //}
            //****************************

            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });
            Task.Run(() =>
            {
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();

            Console.ReadKey();
        }
    }
}
