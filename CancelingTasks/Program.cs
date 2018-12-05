using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //CancellationTokenSource cts = new CancellationTokenSource();
            //CancellationToken token = cts.Token;

            //Task task = Task.Run(() =>
            //{
            //    while (!token.IsCancellationRequested)
            //    {
            //        Console.Write("*");
            //        Thread.Sleep(1000);
            //    }
            //}, token);

            //Console.WriteLine("Press enter to stop.");
            //Console.ReadLine();
            //cts.Cancel();
            //********************

            //CancellationTokenSource cts = new CancellationTokenSource();
            //CancellationToken token = cts.Token;

            //Task task = Task.Run(() =>
            //{
            //    while (!token.IsCancellationRequested)
            //    {
            //        Console.Write("*");
            //        Thread.Sleep(1000);
            //    }
            //    token.ThrowIfCancellationRequested();
            //}, token);

            //try
            //{
            //    Console.WriteLine("Press enter to stop the task.");
            //    Console.ReadLine();

            //    cts.Cancel();
            //    task.Wait();
            //}
            //catch(AggregateException e)
            //{
            //    Console.WriteLine(e.InnerException.Message);
            //}

            //Console.WriteLine("Press enter to stop.");
            //Console.ReadLine();
            //***************

            //CancellationTokenSource cts = new CancellationTokenSource();
            //CancellationToken token = cts.Token;

            //Task task = Task.Run(() =>
            //{
            //    while (!token.IsCancellationRequested)
            //    {
            //        Console.Write("*");
            //        Thread.Sleep(1000);
            //    }
            //    //token.ThrowIfCancellationRequested();
            //}, token).ContinueWith((t) => 
            //{
            //    t.Exception.Handle((e) => true);
            //    Console.WriteLine("You have cancelled the task.");
            //}, TaskContinuationOptions.OnlyOnCanceled);

            //Console.WriteLine("Press enter to stop the task.");
            //Console.ReadLine();

            //cts.Cancel();
            //task.Wait();

            //Console.WriteLine("Press enter to exit.");
            //Console.ReadLine();
            //***************************************

            Task longRunning = Task.Run(() =>
            {
                Thread.Sleep(1000);
            });

            int index = Task.WaitAny(new[] { longRunning }, 1000);

            if (index == -1)
                Console.WriteLine("That timed out.");

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();


            Console.ReadKey();
        }
    }
}
