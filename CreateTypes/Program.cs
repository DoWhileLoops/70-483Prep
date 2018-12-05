using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTypes
{
    //enums
    //class Program
    //{
    //    public enum Days { Monday, Tuesday, Wednesday}

    //    [Flags]
    //    public enum FlaggedDays
    //    {
    //        None = 0x0,
    //        Sunday = 0x1,
    //        Monday = 0x2,
    //        Tuesday = 0x3
    //    }
    //    FlaggedDays readingDays = FlaggedDays.None | FlaggedDays.Sunday;

    //    public static string ReturnDays(Days d)
    //    {
    //        return d.ToString();
    //    }

    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine(Days.Monday);
    //        Console.WriteLine(ReturnDays(Days.Tuesday));

    //        Console.ReadKey();
    //    }
    //}
    //**********************
    class Program
    {

        public struct Point
        {
            public int x, y;
            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
            public int Add(int x, int y)
            {
                return x + y;
            }
        }

        public class StaticClass
        {
            public static int myInt = 44;
        }

        public class Card
        {

        }

        public class Deck
        {
            public ICollection<Card> Cards { get; set; }
        }

        
        static void Main(string[] args)
        {
            Deck d = new Deck();
            Card c = d.Cards.ElementAt(2);

            string s1 = "MyFirstString";
            string s2 = s1;
            s2 = "MySecondString";
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            //Point p = new Point(1, 4);
            //Console.WriteLine(p.Add(p.x, p.y));
            Console.ReadKey();
        }
    }
}
