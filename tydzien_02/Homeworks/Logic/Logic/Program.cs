using System;

namespace Logic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Which exercise would you like to check? ");
            int exerciseNumber = Int32.Parse(Console.ReadLine());
            switch (exerciseNumber)
            {
                case 1:
                    Solutions.Exercise01();
                    break;
                case 2:
                    Solutions.Exercise02();
                    break;
                case 3:
                    Solutions.Exercise03();
                    break;
                case 4:
                    Solutions.Exercise04();
                    break;
                case 5:
                    Solutions.Exercise05();
                    break;
                case 6:
                    Solutions.Exercise06();
                    break;
                case 7:
                    Solutions.Exercise07();
                    break;
                case 8:
                    Solutions.Exercise08();
                    break;
                case 9:
                    Solutions.Exercise09();
                    break;
                case 10:
                    Solutions.Exercise10();
                    break;
                case 11:
                    Solutions.Exercise11();
                    break;
                case 12:
                    Solutions.Exercise12();
                    break;
                case 13:
                    Solutions.Exercise13();
                    break;
                default:
                    Console.WriteLine("Number not recognised, this batch has 13 exercises.");
                    break;
            }
        }
    }
}
