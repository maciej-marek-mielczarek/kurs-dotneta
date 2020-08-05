using String2Int;
using System;

namespace D5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestD5 diceTester = new TestD5();
            Console.WriteLine("Roll D5 how many times to test it?");
            string userInput = Console.ReadLine();
            diceTester.Test(String2Int.String2Int.Transform(userInput));
        }
    }
}
