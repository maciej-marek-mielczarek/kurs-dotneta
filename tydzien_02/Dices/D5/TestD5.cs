using System;

namespace D5
{
    internal class TestD5
    {
        public TestD5()
        {
        }

        internal void Test(int numberOfTests)
        {
            D5 dice = new D5();
            int[] results = new int[5];
            for (int rollNumber = 1; rollNumber <= numberOfTests; ++rollNumber)
            {
                ++(results[dice.Roll() - 1]);
            }
            string[] numberNames = { "ones", "twos", "threes", "fours", "fives"};
            Console.WriteLine($"Rolled {numberOfTests} times. Results:");
            int numberOfFaces = 5;
            for (int face = 1; face <= numberOfFaces; ++face)
            {
                Console.WriteLine($"{results[face - 1]} {numberNames[face - 1]}");
            }
        }
    }
}