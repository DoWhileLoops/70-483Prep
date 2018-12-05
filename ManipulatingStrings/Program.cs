using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace ManipulatingStrings
{

    public class Person
    {
        public string _firstName;
        public string _lastName;

        public Person(string first, string last)
        {
            _firstName = first;
            _lastName = last;
        }

        public string ToString(string format)
        {
            if (string.IsNullOrWhiteSpace(format) || format == "G") format = "FL";
            format = format.Trim().ToUpperInvariant();

            switch (format)
            {
                case "FL":
                    return _firstName + " " + _lastName;
                case "LF":
                    return _lastName + " " + _firstName;
                case "FSL":
                    return _firstName + ", " + _lastName;
                case "LSF":
                    return _lastName + ", " + _firstName;
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string s1 = "FirstString";
            string s2 = s1;
            s1 = "SecondString";

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            //*************
            StringBuilder sb = new StringBuilder("A Initial Value");
            sb[0] = 'B';

            Console.WriteLine(sb);

            sb.Clear();
            //*************
            for (int i = 0; i < 10000; i++)
            {
                sb.Append("x");
            }

            Console.WriteLine(sb);
            //*************
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }
            string xml = stringWriter.ToString();

            Console.WriteLine(xml);
            //*************
            var stringReader = new StringReader(xml);
            using(XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml(), new CultureInfo("en-US"));
            }
            //*************
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels","Abraham Adams", "Ms. Nicole Norris" };

            foreach (string name in names)
            {
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
            }
            //*************
            double cost = 1234.56;
            Console.WriteLine(cost.ToString("C", new CultureInfo("en-US")));

            DateTime d = new DateTime(2013, 4, 22);
            CultureInfo provider = new CultureInfo("en-US");
            Console.WriteLine(d.ToString("d", provider));
            Console.WriteLine(d.ToString("D", provider));
            Console.WriteLine(d.ToString("M", provider));
            //******************
            Person p = new Person("Bob", "Dylan");
            Console.WriteLine(p.ToString("FL"));
            Console.WriteLine(p.ToString("LSF"));

            Console.ReadKey();
        }
    }
}
