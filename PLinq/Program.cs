using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace PLinq
{
    class Program
    {
        public static void ConsoleWriter(object x)
        {
            if(x is int[])
            {
                foreach(int i in (int[])x)
                {
                    Console.Write(" " + i.ToString());
                }
            }
            else if(x is List<int>)
            {
                foreach (int i in (List<int>)x)
                {
                    Console.Write(" " + i.ToString());
                }
            }
            else
            {
                Console.Write(x.ToString());
            }

        }

        static void Main(string[] args)
        {
            //var numbers = Enumerable.Range(0, 100000);
            //var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

            //ConsoleWriter(parallelResult);
            //*********************

            //Timer normalTimer = new Timer();
            //Timer parallelTimer = new Timer();

            //Stopwatch normalStopwatch = new Stopwatch();
            //Stopwatch parallelStopwatch = new Stopwatch();

            //var numbers = Enumerable.Range(0, 1000000);

            //normalStopwatch.Start();
            //var normalResult = numbers.Where(i => i % 2 == 0).ToArray();
            //normalStopwatch.Stop();

            //parallelStopwatch.Start();
            //var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();
            //parallelStopwatch.Stop();


            //ConsoleWriter(normalResult);
            //ConsoleWriter("\n**************\n");
            //ConsoleWriter(parallelResult);

            //Console.WriteLine("Normal elapsed = " + normalStopwatch.ElapsedMilliseconds);
            //Console.WriteLine("Parallel elapsed = " + parallelStopwatch.ElapsedMilliseconds);

            //*************************
            //var numbers = Enumerable.Range(0, 100);
            //var parallelUnorderedResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();
            //var parallelOrderedResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 == 0).ToArray();

            //ConsoleWriter(parallelUnorderedResult);
            //ConsoleWriter("\n**************\n");
            //ConsoleWriter(parallelOrderedResult);

            //**************************
            //List<int> numbers = Enumerable.Range(0, 100).ToList();
            //ConsoleWriter(numbers);
            //ConsoleWriter("\n**************\n");

            //List<int> firstTen = numbers.Take(10).ToList();
            //ConsoleWriter(firstTen);
            //ConsoleWriter("\n**************\n");
            //List<int> firstTenOdds = numbers.TakeWhile(i => i % 2 != 0).ToList();
            //ConsoleWriter(firstTenOdds);
            //ConsoleWriter("\n**************\n");
            //ConsoleWriter(numbers);

            //**************************
            //var numbers = Enumerable.Range(0, 20);
            //var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0);

            //parallelResult.ForAll(e => Console.WriteLine(e));

            //**************************
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException ae)
            {
                Console.WriteLine($"There were {ae.InnerExceptions.Count} exceptions.");
                foreach(Exception e in ae.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadKey();
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("you suuuuck");
            return i % 2 == 0;
        }
    }
}
