using String2Int;
using System;

namespace D6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestD6 diceTester = new TestD6();
            Console.WriteLine("Roll D6 how many times to test it?");
            string userInput = Console.ReadLine();
            diceTester.Test(String2Int.String2Int.Transform(userInput));
        }
    }
}
