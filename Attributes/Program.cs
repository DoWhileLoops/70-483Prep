using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [Serializable]
    public class Person
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
    }

    
    public class ConditionalClass
    {
        [Conditional("Condition1"), Conditional("Condition2")]
        static void Conditionable()
        {
            string myField = "Stuff";
        }
    }
    
    class Program
    {

        //[Conditional("Condition1"), Conditional("Condition2")]
        //static void Conditionable()
        //{
        //    string myField = "Stuff";
        //}

        static void Main(string[] args)
        {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
            {
                Console.WriteLine("Serializable class");
            }

            //this breaks, but compiler did not like placing Conditional Attribute on the class itself.
            ConditionalAttribute conditionalAttribute =
                (ConditionalAttribute)Attribute.GetCustomAttribute(
                    typeof(ConditionalClass),
                    typeof(ConditionalAttribute));
            string condition = conditionalAttribute.ConditionString;

            Console.WriteLine(condition);

            Console.WriteLine("Hello World!");


            Console.ReadKey();
        }
    }
}
