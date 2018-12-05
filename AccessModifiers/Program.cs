using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Accessibility
    {
        private string MyString;

        public Accessibility(string s)
        {
            MyString = s;
        }

        public string MyStringGetter
        {
            get { return MyString; }
            set { MyString = value; }
        }
    }

    public class AccessibilityArray
    {
        private string[] MyArray;

        public string MyArrAccessor//(int index)
        {
            get { return MyArray[0]; }
            set { MyArray[0] = value; }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Accessibility a = new Accessibility("thisString");

            Console.WriteLine(a.MyStringGetter);

            a.MyStringGetter = "thisnewstring";

            Console.WriteLine(a.MyStringGetter);

            Console.ReadKey();
        }
    }
}
