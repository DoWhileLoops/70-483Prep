using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        public delegate int Calculate(int x, int y);


        static void Main(string[] args)
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine("Lambda Add: " + calc(3, 4).ToString());

            Calculate mult = (x, y) => x * y;
            Console.WriteLine("Lambda Multiply: " + mult(3, 4).ToString());

            Calculate calc2 =
                (x, y) =>
                {
                    Console.WriteLine("Adding Nums:");
                    return x + y;
                };
            Console.WriteLine("Anonymous Add: " + calc2(3, 4).ToString());


            Console.ReadKey();
        }
    }
}
