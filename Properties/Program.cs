using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    public class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();
                else
                    _name = value;
            }
        }

        public string _myAutoName { get; private set; }

        public Person(string autoName)
        {
            _myAutoName = autoName;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            //IEnumerable<int> ie = new IEnumerable<int>;

            Person p = new Person("ThisAutoName");
            Console.WriteLine("Name: " + p.Name);
            p.Name = "Bob";
            Console.WriteLine("Name: " + p.Name);

            Console.WriteLine("AutoName: " + p._myAutoName);
            
            Console.WriteLine("AutoName: " + p._myAutoName);

            Console.ReadKey();
        }
    }
}
