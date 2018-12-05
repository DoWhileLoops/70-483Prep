using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            //while (true)
            //{
            //    string s = Console.ReadLine();

            //    try
            //    {
            //        int i = int.Parse(s);
            //        break;
            //    }
            //    catch(FormatException fe)
            //    {
            //        Console.WriteLine($"{s} is not valid.");
            //        Console.WriteLine(fe.Message);
            //    }
            //}
            //*********************

            //string s = Console.ReadLine();

            //try
            //{
            //    int i = int.Parse(s);
            //}
            //catch (ArgumentNullException ae)
            //{
            //    Console.WriteLine($"Please enter something");
            //    Console.WriteLine(ae.Message);
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine($"{s} is not valid.");
            //    Console.WriteLine("Message:" + fe.Message);
            //    Console.WriteLine("StackTrace" + fe.StackTrace);
            //    Console.WriteLine("HelpLink " + fe.HelpLink);
            //    Console.WriteLine("HResult " + fe.HResult);
            //    Console.WriteLine("Source " + fe.Source);
            //    Console.WriteLine("TargetSite " + fe.TargetSite);
            //    Console.WriteLine("InnerException " + fe.InnerException);
            //}
            //finally
            //{
            //    Console.WriteLine("You have beaten the game.");
            //}
            //*********************
            //try
            //{
            //    int.Parse("nay");
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine("Original");
            //    Console.WriteLine(fe.Message);
            //    Console.WriteLine(fe.InnerException);
            //    Console.WriteLine("####################");
            //    //throw new ArgumentException("No", fe);
            //    Console.WriteLine(new ArgumentException("No", fe).InnerException);
            //    Console.WriteLine("####################");
            //}
            //catch (ArgumentException ae)
            //{
            //    Console.WriteLine("Second");
            //    Console.WriteLine(ae.InnerException);
            //}
            //***************************

            ExceptionDispatchInfo possibleException = null;
            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch(FormatException fe)
            {
                possibleException = ExceptionDispatchInfo.Capture(fe);
            }

            if (possibleException != null)
            {
                Console.WriteLine(possibleException.SourceException.Message);
                possibleException.Throw();
            }

            Console.ReadKey();
        }
    }
}
