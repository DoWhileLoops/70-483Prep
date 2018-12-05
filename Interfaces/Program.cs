using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{

    public class Order : IComparable
    {
        public DateTime Created { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Order o = obj as Order;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order.");
            }

            return this.Created.CompareTo(o.Created);
        }

        //explicit implementation
        //int IComparable.CompareTo(object obj)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class Person
    {
        public string _firstName;
        public string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
    }

    class People : IEnumerable<Person>
    {

        Person[] people;

        public People(Person[] people)
        {
            this.people = people;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for(int index = 0; index < people.Length; index++)
            {
                yield return people[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //IComparable
            Console.WriteLine($"IComparable");
            List<Order> orders = new List<Order>
            {
                new Order{Created = new DateTime(2018, 10, 15)},
                new Order{Created = new DateTime(2017, 10, 15)},
                new Order{Created = new DateTime(2018, 10, 16)},
                new Order{Created = new DateTime(2018, 09, 15)},
            };

            foreach(Order o in orders)
            {
                Console.WriteLine($"{orders.IndexOf(o)}: {o.Created.ToShortDateString()}");
            }
            Console.WriteLine($"*******************");
            orders.Sort();

            foreach (Order o in orders)
            {
                Console.WriteLine($"{orders.IndexOf(o)}: {o.Created.ToShortDateString()}");
            }

            Console.WriteLine($"*******************");
            Console.WriteLine($"IEnumerable");

            List<int> numbers = new List<int> { 1, 2, 4, 6, 54 };
            
            using (List<int>.Enumerator enmerator = numbers.GetEnumerator())
            {
                while (enmerator.MoveNext()) Console.WriteLine(enmerator.Current);
            }




            Console.ReadKey();
        }
    }
}
