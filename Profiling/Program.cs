using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiling
{
    class Program
    {
        const int numberOfIterations = 100000;

        static void Alg1()
        {
            StringBuilder sb = new StringBuilder();
            for(int x = 0; x < numberOfIterations; x++)
            {
                sb.Append('a');
            }

            string result = sb.ToString();
        }

        static void Alg2()
        {
            string result = "";
            for(int x = 0; x < numberOfIterations; x++)
            {
                result += "a";
            }
        }

        static void RunStopWatch()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Alg1();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

            sw.Reset();
            sw.Start();
            Alg2();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("*************");
        }

        static void Main(string[] args)
        {

            RunStopWatch();
            RunStopWatch();
            RunStopWatch();



            Console.ReadKey();
        }
    }
}
