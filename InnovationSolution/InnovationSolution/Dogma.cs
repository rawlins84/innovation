using System;
using System.Linq;
using System.Reflection;

namespace Innovation
{
    public class Dogma
    {
        public Dogma()
        {

        }

        public void run(string methodName)
        {
            MethodInfo mi = this.GetType().GetMethod(methodName.ToLower());
            mi.Invoke(this, null);
        }

        public void archery()
        {
            Console.WriteLine("This is the Archery Dogma");
        }
    }
}