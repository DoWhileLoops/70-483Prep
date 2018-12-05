using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    //public class Pub
    //{
    //    //public Action OnChange { get; set; }
    //    public event Action OnChange = delegate{};

    //    public void Raise()
    //    {
    //        if(OnChange != null)
    //        {
    //            OnChange();
    //        }
    //    }
    //}

    //class Program
    //{

    //    public static void CreateAndRaise()
    //    {
    //        Pub p = new Pub();
    //        p.OnChange += () => Console.WriteLine("Event raised to method 1");
    //        p.OnChange += () => Console.WriteLine("Event raised to method 2");
    //        p.Raise();
    //    }

    //    static void Main(string[] args)
    //    {
    //        CreateAndRaise();

    //        Console.ReadKey();
    //    }
    //}
    //********************

    //public class MyArgs : EventArgs
    //{
    //    public int Value { get; set; }
    //    public MyArgs(int value)
    //    {
    //        Value = value;
    //    }
    //}

    //public class Pub
    //{
    //    public event EventHandler<MyArgs> OnChange = delegate { };

    //    public void Raise()
    //    {
    //        OnChange(this, new MyArgs(42));
    //    }
    //}

    //class Program
    //{

    //    public static void CreateAndRaise()
    //    {
    //        Pub p = new Pub();
    //        p.OnChange += (sender, e) => Console.WriteLine("Event raised: {0} {1}", e.Value, sender);

    //        p.Raise();
    //    }

    //    static void Main(string[] args)
    //    {
    //        CreateAndRaise();

    //        Console.ReadKey();
    //    }
    //}

    //public class MyArgs : EventArgs
    //{
    //    public int Value { get; set; }
    //    public MyArgs(int value)
    //    {
    //        Value = value;
    //    }
    //}

    //public class Pub
    //{
    //    public event EventHandler<MyArgs> onChange = delegate { };

    //    public event EventHandler<MyArgs> OnChange
    //    {
    //        add
    //        {
    //            lock (onChange)
    //            {
    //                onChange += value;
    //            }
    //        }
    //        remove
    //        {
    //            lock (onChange)
    //            {
    //                onChange -= value;
    //            }
    //        }
    //    }

    //    public void Raise()
    //    {
    //        onChange(this, new MyArgs(42));
    //    }
    //}

    //class Program
    //{

    //    public static void CreateAndRaise()
    //    {
    //        Pub p = new Pub();
    //        p.OnChange += (sender, e) => Console.WriteLine("Event raised: {0} {1}", e.Value, sender);

    //        p.Raise();
    //    }

    //    static void Main(string[] args)
    //    {
    //        CreateAndRaise();

    //        Console.ReadKey();
    //    }
    //}

    //public class MyArgs : EventArgs
    //{
    //    public int Value { get; set; }
    //    public MyArgs(int value)
    //    {
    //        Value = value;
    //    }
    //}

    //public class Pub
    //{
    //    public event EventHandler OnChange = delegate { };

    //    public void Raise()
    //    {
    //        OnChange(this, EventArgs.Empty);
    //    }
    //}

    //class Program
    //{
    //    public static void CreateAndRaise()
    //    {
    //        Pub p = new Pub();
    //        p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
    //        p.OnChange += (sender, e) => throw new Exception();
    //        p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");

    //        p.Raise();
    //    }

    //    static void Main(string[] args)
    //    {
    //        CreateAndRaise();

    //        Console.ReadKey();
    //    }
    //}

    public class MyArgs : EventArgs
    {
        public int Value { get; set; }
        public MyArgs(int value)
        {
            Value = value;
        }
    }

    public class Pub
    {
        public event EventHandler OnChange = delegate { };

        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach(Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch(Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }

    class Program
    {
        public static void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e) => throw new Exception();
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");

            try
            {
                p.Raise();
            }
            catch(AggregateException ae)
            {
                Console.WriteLine(ae.InnerExceptions.Count);
            }
        }

        static void Main(string[] args)
        {
            CreateAndRaise();

            Console.ReadKey();
        }
    }
}
