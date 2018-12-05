using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFiles
{
    class Program
    {

        public static async Task CreateAndWriteAsyncToFile()
        {
            using (FileStream stream = new FileStream("test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);
                Console.WriteLine("method started.");
                await stream.WriteAsync(data, 0, data.Length);
                Console.WriteLine("method done.");
            }
        }

        public static async Task<string> ReadAsyncHttpRequest()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("http://www.microsoft.com");
            return result;
        }

        public async Task ExecuteMultipleRequests()
        {
            HttpClient client = new HttpClient();
            //each request here starts when the previous one is finished. "synchronous" async code.
            string microsoft = await client.GetStringAsync("http://www.micorosoft.com");
            string msdn = await client.GetStringAsync("http://msdn.microsoft.com");
            string blogs = await client.GetStringAsync("http://blogs.msdn.com/");
        }

        public async Task ExecuteMultipleRequestsInParallel()
        {
            //this is how you execute all these in parallel
            HttpClient client = new HttpClient();
            
            Task microsoft = client.GetStringAsync("http://www.micorosoft.com");
            Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task blogs = client.GetStringAsync("http://blogs.msdn.com/");

            await Task.WhenAll(microsoft, msdn, blogs);
        }

        static void Main(string[] args)
        {
            Task t = CreateAndWriteAsyncToFile();

            Task<string> t2 = ReadAsyncHttpRequest();
            Console.WriteLine(t2.Result);
            //t2.ContinueWith(x => Console.WriteLine(x));

            Console.WriteLine("Task done");

            Console.ReadKey();
        }
    }
}
