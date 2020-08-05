using D25;
using D6;
using D5;
using String2Int;
using System;

namespace Dices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number N to roll a N-sided dice.");
            int sides = String2Int.String2Int.Transform(Console.ReadLine());
            switch (sides)
            {
                case (25):
                    D25.D25 d25 = new D25.D25();
                    Console.WriteLine($"Rolling a d{sides}: {d25.Roll()}");
                    break;
                case (6):
                    D6.D6 d6 = new D6.D6();
                    Console.WriteLine($"Rolling a d{sides}: {d6.Roll()}");
                    break;
                case (5):
                    D5.D5 d5 = new D5.D5();
                    Console.WriteLine($"Rolling a d{sides}: {d5.Roll()}");
                    break;
                default:
                    UniversalDice universalDice = new UniversalDice();
                    Console.WriteLine($"Sorry, d{sides} dice not implemented (yet?).");
                    break;
            }
        }
    }
}
