using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WebRequest2
{
    class Program
    {

        static void WebRequestDemo()
        {
            WebRequest request = WebRequest.Create("http://www.microsoft.com");
            WebResponse response = request.GetResponse();

            StreamReader responseStream = new StreamReader(response.GetResponseStream());
            string responseText = responseStream.ReadToEnd();

            Console.WriteLine(responseText);

            response.Close();

        }

        static void Main(string[] args)
        {
            WebRequestDemo();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
