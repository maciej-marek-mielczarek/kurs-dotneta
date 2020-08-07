using System;

namespace Logic
{
    public static class Solutions
    {
        public static void Exercise13()
        {
            throw new NotImplementedException();
        }

        public static void Exercise12()
        {
            throw new NotImplementedException();
        }

        public static void Exercise11()
        {
            throw new NotImplementedException();
        }

        public static void Exercise10()
        {
            throw new NotImplementedException();
        }

        public static void Exercise09()
        {
            throw new NotImplementedException();
        }

        public static void Exercise08()
        {
            throw new NotImplementedException();
        }

        public static void Exercise07()
        {
            throw new NotImplementedException();
        }

        public static void Exercise06()
        {
            throw new NotImplementedException();
        }

        public static void Exercise05()
        {
            throw new NotImplementedException();
        }

        public static void Exercise04()
        {
            throw new NotImplementedException();
        }

        public static void Exercise03()
        {
            throw new NotImplementedException();
        }

        public static void Exercise02()
        {
            Console.WriteLine("Write 1 intege number and i'll check if it's odd or even.");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"{number} is {((number % 2) == 0 ? "even" : "odd")}");
        }

        public static void Exercise01()
        {
            Console.WriteLine("Write 2 integer numbers and I'll check if they're equal.");
            int a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine());
            Console.Write($"Numbers {a} and {b} are ");
            if (a == b)
            {
                Console.WriteLine("equal.");
            }
            else
            {
                Console.WriteLine("not equal.");
            }
        }
    }
}
