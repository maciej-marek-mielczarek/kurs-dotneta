using System;

namespace D25
{
    class Program
    {
        static void Main(string[] args)
        {
            D25 d25 = new D25();
            Console.WriteLine($"Rolling d25: {d25.Roll()}");
        }
    }
}
