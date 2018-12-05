using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{

    public class MyGenericArray<T> //where T : class
    {
        public T[] array;

        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }

        public void AddItem(int index, T value)
        {
            array[index] = value;
        }

        public T GetItem(int index)
        {
            return array[index];
        }
    }

    public class Person
    {
        public string Name;
        public string Job;

        public Person(string name, string job)
        {
            this.Name = name;
            this.Job = job;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Person p1 = new Person("Bob", "Dude");
            Person p2 = new Person("Bob2", "Dude2");
            Person p3 = new Person("Bro", "Dawg");
            Person p4 = new Person("Bro7", "Dawg7");

            MyGenericArray<int> myInts = new MyGenericArray<int>(3);

            MyGenericArray<Person> myPersons = new MyGenericArray<Person>(3);

            myInts.AddItem(0, 13);
            myInts.AddItem(1, 46);
            myInts.AddItem(2, 85);
            myInts.AddItem(3, 73);

            myPersons.AddItem(0, p1);
            myPersons.AddItem(1, p2);
            myPersons.AddItem(2, p3);
            myPersons.AddItem(3, p4);

            foreach(int i in myInts.array)
            {
                Console.WriteLine(i);
            }

            foreach (Person p in myPersons.array)
            {
                Console.WriteLine(p.Name + p.Job);
            }




            Console.ReadKey();
        }
    }
}
