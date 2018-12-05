using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        //public delegate int Calculate(int x, int y);

        //public static int Add(int x, int y) { return x + y; }
        //public static int Multiply(int x, int y) { return x * y; }

        //public static void UseDelegate()
        //{
        //    Calculate calc = Add;
        //    Console.WriteLine(calc(3, 4));

        //    calc = Multiply;
        //    Console.WriteLine(calc(3, 4));
        //}

        //static void Main(string[] args)
        //{

        //    UseDelegate();

        //    Console.ReadKey();
        //}

        //***********************

        //public static void MethodOne()
        //{
        //    Console.WriteLine("MethodOne");
        //}
        //public static void MethodTwo()
        //{
        //    Console.WriteLine("MethodTwo");
        //}

        //public delegate void Del();

        //public static void MultiCast()
        //{
        //    Del d = MethodOne;
        //    d += MethodTwo;
        //    Console.WriteLine("Nmber of methods: " + d.GetInvocationList().GetLength(0));
        //    d();
        //}

        //static void Main(string[] args)
        //{
        //    MultiCast();

        //    Console.ReadKey();
        //}

        //*************************
        //covariance / contravariance:

        //public delegate TextWriter CovarianceDel();

        //public static StreamWriter MethodStream() { return null; }
        //public static StringWriter MethodString() { return null; }

        //CovarianceDel del = MethodStream;
        //CovarianceDel del2 = MethodStream;

        //public static void DoSomething(TextWriter tw) { }
        //public delegate void ContravarianceDel(StreamWriter tw);
        //ContravarianceDel cdel = DoSomething;
        //**************************
        //func, action, pred practice

        public static Func<int> funcJustReturnsInt;
        public static Func<int, string> funcInIntOutString;

        public static int returnInt()
        {
            return 53;
        }

        public static string inIntOutString(int x)
        {
            return "Gotcha";
        }

        public static string inIntOutDifferentString(int x)
        {
            return "Gotcha2";
        }

        public static string passedCorrectly(Func<int, string> myFunc)
        {
            return myFunc.Method.Name;//.GetInvocationList().Count().ToString();            
        }

        public static void NoInputAction()
        {
            Console.WriteLine("You called NoInputAction");
        }

        public static void OneInputAction(int x)
        {
            Console.WriteLine("You called OneInputAction and passed " + x.ToString());
        }

        public static bool IsNumeric(string s)
        {
            int result;
            return int.TryParse(s, out result);
        }

        public delegate string GenericDelegate<T1>(T1 a);

        static void Main(string[] args)
        {
            //funcs
            Func<int> myFunc1 = returnInt;
            Console.WriteLine(myFunc1());

            Func<int, string> myFunc2 = inIntOutString;
            Console.WriteLine(myFunc2(2));

            Func<int, string> myFunc3 = inIntOutDifferentString;

            Console.WriteLine(passedCorrectly(myFunc2));

            Console.WriteLine(passedCorrectly(myFunc3));

            Func<int, string> anonFunc = (x) =>
            {
                return x.ToString() + " anonFunc";
            };

            Console.WriteLine(passedCorrectly(anonFunc));

            Console.WriteLine(anonFunc(2));

            //actions

            Action noInputAction = NoInputAction;
            noInputAction.Invoke();

            Action<int> intInputAction = OneInputAction;
            intInputAction(3);
            intInputAction.Invoke(43);

            Action<int> AnonAction = (x) =>
            {
                //Console.WriteLine("You called AnonAction");
                Console.WriteLine("You called AnonAction and passed " + x.ToString());
            };

            AnonAction(421);

            //predicates
            //Predicate<int> noInputPred = (x) =>
            //{
            //    return true;
            //};

            //Console.WriteLine(noInputPred(2));

            //Predicate<string> myPred;
            //myPred = IsNumeric;

            //Console.WriteLine(myPred("nay"));
            //Console.WriteLine(myPred("4"));

            GenericDelegate<string> myGenDel = (x) =>
            {
                return x.ToString();
            };

            GenericDelegate<int> myIntGenDel = (x) =>
            {
                return (x * x).ToString();
            };

            Console.WriteLine(myGenDel("39"));

            Console.ReadKey();
        }
    }
}
