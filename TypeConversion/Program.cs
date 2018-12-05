using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversion
{

    public class Money
    {
        public decimal Amount;

        public Money(decimal amount)
        {
            this.Amount = amount;
        }
        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }
        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //implicit conversion
            int i = 42;
            double d = i;

            HttpClient hc = new HttpClient();
            object o = hc;
            IDisposable id = hc;

            //explicit conversion
            double x = 1234.555;
            int a;
            a = (int)x; //data loss here

            //user defined conversion
            Money money = new Money((decimal)55.661123123);

            decimal moneyDec = money;
            int moneyInt = (int)money;

            Console.WriteLine(moneyDec);
            Console.WriteLine(moneyInt);

            //conversions w/ a helper class
            int value1 = Convert.ToInt32("42");
            int value2 = int.Parse("64");
            int tryParsed;
            bool success = int.TryParse("75", out tryParsed);

            Console.WriteLine(value1);
            Console.WriteLine(value2);
            Console.WriteLine(tryParsed);

            // is/as

            try
            {
                throw new ArgumentNullException();
                //throw new IndexOutOfRangeException();
            }
            catch (Exception ex)
            {
                //if(ex is ArgumentNullException)
                //{
                //    Console.WriteLine("ArgumentNull");
                //}
                //else
                //{
                //    Console.WriteLine("NormalException");
                //}
                //**********
                ArgumentNullException ae = ex as ArgumentNullException;
                if(ae != null)
                {
                    Console.WriteLine("ArgumentNull");
                }
                else
                {
                    Console.WriteLine("NormalException");
                }
            }



            Console.ReadKey();
        }
    }
}
