using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLifeCycle
{
    public class UnmanagedWrapper : IDisposable
    {
        public FileStream Stream { get; private set; }

        public UnmanagedWrapper()
        {
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(Stream != null)
                {
                    Stream.Close();
                }
            }
        }

        ~UnmanagedWrapper()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter stream = File.CreateText("temp.txt");
            stream.Write("some Stuff");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            IDisposable id;

            File.Delete("temp.txt");


            Console.ReadKey();
        }

        static WeakReference data;

        public static void Run()
        {
            object result = GetData();
            GC.Collect();
            result = GetData();
        }

        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }

            if(data.Target == null)
            {
                data.Target = LoadLargeList();
            }
            return data.Target;
        }

        public static List<int> LoadLargeList()
        {
            List<int> myList = new List<int>();
            for(int i = 0; i < 10000; i++)
            {
                myList.Add(i);
            }
            return myList;
        }

    }
}
