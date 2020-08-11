using System;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo(1);
            Bar bar = foo;
            Console.WriteLine("Nowa zmienna ma typ: " + bar.GetType());
            Console.WriteLine("Nowa zmienna ma pole b: " + bar.b);
        }
    }
}
