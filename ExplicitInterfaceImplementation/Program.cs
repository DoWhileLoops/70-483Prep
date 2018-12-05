using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaceImplementation
{

    interface IIenterfaceA
    {
        void MyMethod();
    }

    public class Implementation : IIenterfaceA
    {
        void IIenterfaceA.MyMethod() { }
    }
    //************************

    interface ILeft
    {
        void Move();
    }

    interface IRight
    {
        void Move();
    }

    public class MoveableObject: ILeft, IRight
    {
        void ILeft.Move() { }
        void IRight.Move() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Implementation i = new Implementation();
            ((IIenterfaceA)i).MyMethod();
            //i.MyMethod();  -- BREAKS

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
