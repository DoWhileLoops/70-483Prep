using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfCounterCollection
{
    class Program
    {

        static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData("# operations executed", "Total number of operations executed", PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData("# operations / sec", "Number of operations executed per second", PerformanceCounterType.RateOfCountsPerSecond32)
                };

                PerformanceCounterCategory.Create("MyCategory", "Sample Category for Codeproject", counters);

                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created Performance Counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            var totalOperationsCounter = new PerformanceCounter("MyCategory", "# operations executed", "", false);
            var operationsPerSecond = new PerformanceCounter("MyCategory", "# operations / sec", "", false);

            totalOperationsCounter.Increment();
            operationsPerSecond.Increment();

            Console.ReadKey();
        }
    }
}
