using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(object o);
    }

    public class MyPlugin : IPlugin
    {
        public string Name
        {
            get { return "MyPlugin"; }
        }

        public string Description
        {
            get { return "MyDescription"; }
        }

        public bool Load(object o)
        {
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 42;
            System.Type thisType = i.GetType();

            Assembly pluginAssembly = Assembly.Load("assemblyname");

            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (Type pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            }

            Console.ReadKey();
        }
    }
}
