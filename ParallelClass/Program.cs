using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace ParallelClass
{
    //ParallelClass.cs
    class Program
    {
        static void Main(string[] args)
        {

            //Parallel.For(0, 10, i =>
            //{
            //    Thread.Sleep(1000);
            //});

            //var numbers = Enumerable.Range(0, 10);

            //Parallel.ForEach(numbers, i =>
            //{
            //    Thread.Sleep(1000);
            //});


            //Console.WriteLine("Done");
            //**********************

            //ParallelLoopResult result = Parallel
            //    .For(0, 1000, (int i, ParallelLoopState loopState) =>
            //    {
            //        if (i == 500)
            //        {
            //            Console.WriteLine("Breaking Loop");
            //            loopState.Break();
            //        }
            //        return;
            //    });

            //Console.WriteLine(result.LowestBreakIteration.ToString());

            //***************************

            //string[] ints = new string[100];

            //for (int i = 0; i < 100; i++)
            //{
            //    ints[i] = i.ToString();
            //}
            Console.WriteLine("Main before call");
            string result = DownloadContent().Result;
            Console.WriteLine("Main after call");
            //foreach (string i in ints)
            //{
            //    Console.Write($" {i}");
            //}
            
            Console.WriteLine(result);
            Console.WriteLine("Main after writing result");
            //***************************

            Console.ReadKey();
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("before call");
                string result = await client.GetStringAsync("http://www.microsoft.com");
                Console.WriteLine("after call");
                return result;
            }
        }
    }
}
