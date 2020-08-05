using System;

namespace D6
{
    public class TestD6
    {
        public TestD6()
        {
        }

        public void Test(int numberOfTests)
        {
            D6 dice = new D6();
            int[] results = new int[6];
            for(int rollNumber = 1; rollNumber <= numberOfTests; ++rollNumber)
            {
                ++(results[dice.Roll() - 1]);
            }
            string[] numberNames = {"ones", "twos", "threes", "fours", "fives", "sixes"};
            Console.WriteLine($"Rolled {numberOfTests} times. Results:");
            int numberOfFaces = 6;
            for (int face = 1; face <= numberOfFaces; ++face)
            {
                Console.WriteLine($"{results[face - 1]} {numberNames[face - 1]}");
            }
        }
    }
}