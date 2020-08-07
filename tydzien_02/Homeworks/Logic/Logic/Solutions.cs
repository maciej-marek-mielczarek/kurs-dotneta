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
            Console.WriteLine("Write a year (number) and I'll tell you if it's a leap year.");
            int year = int.Parse(Console.ReadLine());
            if(year <= 1582 )
            {
                Console.WriteLine("I don't know by which Calendar. Gregorian Calendar did not exist until late 1582.");
            }
            else
            {
                int currentYear = DateTime.Today.Year;
                bool isLeapYear;
                if(year % 400 == 0)
                {
                    isLeapYear = true;
                }
                else if(year % 100 == 0)
                {
                    isLeapYear = false;
                }
                else
                {
                    isLeapYear = year % 4 == 0;
                }
                Console.Write($"{year} {(year < currentYear ? "was" : (year > currentYear ? "will" : "is"))} ");
                Console.WriteLine($"{(isLeapYear ? "" : "not ")}{(year > currentYear ? "be " : "")}a leap year");
            }
        }

        public static void Exercise03()
        {
            Console.WriteLine("Write 1 integer number and I'll check if it's positive or negative;");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{n} is {(n > 0 ? "positive" : (n < 0 ? "negative" : "zero"))}");
        }

        public static void Exercise02()
        {
            Console.WriteLine("Write 1 integer number and i'll check if it's odd or even.");
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
