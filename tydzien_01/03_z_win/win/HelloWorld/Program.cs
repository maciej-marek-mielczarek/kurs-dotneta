using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "abc";
            System.Diagnostics.Debugger.Break();
            Console.WriteLine("ęóąśłżźćńĘÓĄŚŁŻŹĆŃ!");
            string b = a.ToUpper();
            Console.WriteLine(b);
        }
    }
}
