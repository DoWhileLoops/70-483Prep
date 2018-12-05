using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Hashing
{
    class NaiiveSet<T>
    {
        //this method does not scale well, as you have to loop through all existing items each time.
        //this is where hashing comes in.
        private List<T> list = new List<T>();
        public void Insert(T item)
        {
            if (!Contains(item))
            {
                list.Add(item);
            }
        }
        public bool Contains(T item)
        {
            foreach(T member in list)
            {
                if (member.Equals(item))
                    return true;
            }
            return false;
        }
    }

    class Set<T>
    {
        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket))
                return;
            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            buckets[bucket].Add(item);
        }

        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
            {
                foreach (T member in buckets[bucket])
                    if (member.Equals(item))
                        return true;
            }
            return false;
        }

        private int GetBucket(int hashcode)
        {
            unchecked
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }

        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }
    }

    public class Person
    {
        public string _firstName { get; set; }
    }

    class Program
    {
        //SHA256 hash code
        public static void SHA256Hashing()
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

            string data = "A piece of text.";
            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A piece of changed text.";
            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A piece of text.";
            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));

            Console.WriteLine("hashA : {0}", Encoding.Default.GetString(hashA));
            Console.WriteLine("hashB : {0}", Encoding.Default.GetString(hashB));
            Console.WriteLine("hashC : {0}", Encoding.Default.GetString(hashC));

            Console.WriteLine(hashA.SequenceEqual(hashB));
            Console.WriteLine(hashA.SequenceEqual(hashC));

        }

        static void Main(string[] args)
        {
            Person p = new Person();
            p._firstName = "Dude3";
            Console.WriteLine(p.GetHashCode().ToString());

            Person p2 = new Person();
            p2._firstName = "Dude2";
            Console.WriteLine(p2.GetHashCode().ToString());

            SHA256Hashing();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
