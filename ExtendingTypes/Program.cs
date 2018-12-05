using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendingTypes
{
    public class Product
    {
        public decimal Price { get; set; }

        public string MyString()
        {
            return "This things";
        }
    }

    public static class MyExtensions
    {
        public static decimal Discount(this Product p)
        {
            return p.Price * .9M;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Product myProd = new Product();
            myProd.Price = 199;
            Console.WriteLine(myProd.Price);

            Console.WriteLine(myProd.Discount());

            Console.ReadKey();
        }
    }
}
