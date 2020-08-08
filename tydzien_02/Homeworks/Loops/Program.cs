using System;

namespace Loops
{
    class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Which exercise would you like to check? Type 0 to exit.");
                byte exerciseNumber = byte.Parse(Console.ReadLine());
                switch (exerciseNumber)
                {
                    case 0:
                        Console.WriteLine("Terminating the program...");
                        break;
                    case 1:
                        Solutions.Ex01();
                        break;
                    case 2:
                        Solutions.Ex02();
                        break;
                    case 3:
                        Solutions.Ex03();
                        break;
                    case 4:
                        Solutions.Ex04();
                        break;
                    case 5:
                        Solutions.Ex05();
                        break;
                    case 6:
                        Solutions.Ex06();
                        break;
                    case 7:
                        Solutions.Ex07();
                        break;
                    case 8:
                        Solutions.Ex08();
                        break;
                    case 9:
                        Solutions.Ex09();
                        break;
                    case 10:
                        Solutions.Ex10();
                        break;
                    default:
                        Console.WriteLine("That is not a valid exercise number.");
                        break;
                }
                if(exerciseNumber == 0)
                {
                    break;
                }
            } while (true);
        }
    }
}
