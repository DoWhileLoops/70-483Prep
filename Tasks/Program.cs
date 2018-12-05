using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
    //Tasks.cs
    class Program
    {
        static void Main(string[] args)
        {

            //Task t = Task.Run(() =>
            //{
            //    for(int x = 0; x< 100; x++)
            //    {
            //        Console.Write("*");
            //    }
            //});

            //Task t2 = Task.Run(() =>
            //{
            //    for(int x = 0; x < 100; x++)
            //    {
            //        Console.Write("!");
            //    }
            //});

            ////t.Wait();
            //Console.WriteLine(t.IsCompleted);

            //Console.WriteLine("FREEEEEEEEDOOM");

            //Console.ReadKey();
            //*********************
            //Task<int> t = Task.Run(() =>
            //{

            //    return 42;
            //}).ContinueWith((i) => {
            //    return i.Result * 2;
            //});

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Cancelled");
            //}, TaskContinuationOptions.OnlyOnCanceled);

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("DERP");
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);

            //Console.WriteLine(t.Result);
            //*********************

            //Task<Int32[]> parent = Task.Run(() =>
            //{
            //    var results = new Int32[3];
            //    new Task(() => results[0] = 14, TaskCreationOptions.AttachedToParent).Start();
            //    Thread.Sleep(2000);
            //    return results;
            //});

            //var finalTask = parent.ContinueWith(
            //    parentTask =>
            //    {
            //        foreach (int i in parentTask.Result)
            //            Console.WriteLine(i);
            //    });

            //finalTask.Wait();
            //*********************

            //Task<int[]> parent = Task.Run(() =>
            //{
            //    var results = new int[3];

            //    TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

            //    tf.StartNew(() => results[0] = 1);
            //    tf.StartNew(() => results[1] = 14);
            //    tf.StartNew(() => results[2] = 75);
            //    return results;
            //});

            //var finalTask = parent.ContinueWith(
            //    parentTask =>
            //    {
            //        foreach (int i in parentTask.Result)
            //            Console.WriteLine($"stuff {i}");
            //    });

            //finalTask.Wait();
            //*********************

            //Task[] tasks = new Task[3];

            //tasks[0] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("1");
            //    //return 1;
            //});
            //tasks[1] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("2");
            //    //return 1;
            //});
            //tasks[2] = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("3");
            //    //return 1;
            //});

            //Task.WaitAll(tasks);

            //Console.WriteLine("turds");
            //*********************

            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                //return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("2");
                //return 1;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("3");
                //return 1;
            });

            while(tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Console.WriteLine(i.ToString() + " is now done.");

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
            //*********************


            Console.ReadKey();

        }
    }
}
