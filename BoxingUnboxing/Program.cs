using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 42;
            object o = i;
            int x = (int)o;
            i = 73;

            Console.WriteLine(i);
            Console.WriteLine(x);

            //secret boxing
            Console.WriteLine(i.GetType());

            Console.ReadKey();
        }
    }
}
