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
            Console.WriteLine("What mark did you get on The Test?");
            byte mark = GetByte();
            string descriptiveMark = mark switch
            {
                1 => "Insufficient",
                2 => "Allowing",
                3 => "Sufficient",
                4 => "Good",
                5 => "Very Good",
                6 => "Excellent",
                _ => "That's not a real mark."
            };
            Console.WriteLine(descriptiveMark);
        }
        public static void Exercise10()
        {
            Console.WriteLine("Give me 3 integer numbers and I'll tell you if you can build a triangle with those sides.");
            int a = GetInt(), b = GetInt(), c = GetInt();
            //max smaller than the other 2 == 2*max smaller than all 3
            Console.WriteLine($"{(2 * Max3(a, b, c) < a + b + c ? "Yes." : "No.")}");
        }

        public static void Exercise09()
        {
            Console.WriteLine("What temperature is it now?");
            sbyte temp = GetSByte();
            string response;
            if(temp < 0)
            {
                response = "Cold as Hell!";
            }
            else if(temp < 10)
            {
                response = "Chill.";
            }
            else if(temp < 20)
            {
                response = "Cool.";
            }
            else if(temp < 30)
            {
                response = "Perfect.";
            }
            else if(temp < 40)
            {
                response = "I wish it wasn't so hot.";
            }
            else
            {
                response = "Screw this, I'm moving to Alaska.";
            }
            Console.WriteLine(response);
        }

        private static sbyte GetSByte()
        {
            return sbyte.Parse(Console.ReadLine());
        }

        public static void Exercise08()
        {
            Console.WriteLine("Tell me your matura results and I'll check if you were admitted to studies.");
            Console.WriteLine("Write 0 if you didn't take an exam.");
            
            Console.Write("Mathematics: ");
            byte math = GetByte();
            Console.Write("Physics: ");
            byte phys = GetByte();
            Console.Write("Chemistry: ");
            byte chem = GetByte();

            if((math > 70 && phys > 55 && chem > 45 && math + phys + chem > 180) || (math + Math.Max(phys, chem) > 150))
            {
                Console.WriteLine("Yes, congratulations!");
            }
            else
            {
                Console.WriteLine("Sorry, not this time.");
            }
        }

        private static byte GetByte()
        {
            return byte.Parse(Console.ReadLine());
        }

        public static void Exercise07()
        {
            Console.WriteLine("Give me 3 integer numbers and 'll check which is heighest.");
            int a = GetInt(), b = GetInt(), c = GetInt();
            Console.WriteLine(Max3(a, b, c) + " is the heighest of them.");
        }

        private static int Max3(int a, int b, int c)
        {
            return (a > b ? (a > c ? a : c) : (b > c ? b : c));
        }

        private static int GetInt()
        {
            return int.Parse(Console.ReadLine());
        }

        public static void Exercise06()
        {
            Console.WriteLine("Tell me your height in centimeters and I'll tell you which height cathegory you're in.");
            ushort height = ushort.Parse(Console.ReadLine());
            string ans = "You're a ";
            int[] limits = {10000, 300, 200, 120, 80, 0 };
            string[] namesIfHeigherThanLimit = {"tower", "tree", "giant", "human", "dwarf", "gnome" };
            for(int conditionNumber = 0; conditionNumber < limits.Length; ++conditionNumber)
            {
                if(height > limits[conditionNumber])
                {
                    ans += namesIfHeigherThanLimit[conditionNumber];
                    break;
                }
            }
            if(height == 0)
            {
                ans += "dot";
            }
            Console.WriteLine(ans + ".");
        }

        public static void Exercise05()
        {
            Console.WriteLine("Tell me your age and I'll tell you if you can become an MP, PM, Senator or President at this age.");
            byte age = byte.Parse(Console.ReadLine());
            string rights = "become a Prime Minister";
            //Common sense says that you should probably be a Member of Parliment,
            //or at the very least be an adult to become a Prime Minister,
            //but the Constitution doesn't specify that.
            //So... I guess the only thing protecting us from a 5-year-old PM is the President's and Parliment's sanity?
            if(age < 18)
            {
                rights += ", but can't vote yet";
            }
            else
            {
                rights += ", can vote in elections and become a City Councilor";
            }
            if (age >= 21)
            {
                rights += " or a Member of Parliment or European Parliment";
            }
            if(age >= 25)
            {
                rights += " or a City Mayor";
            }
            if(age >= 30)
            {
                rights += " or a Senator";
            }
            if(age >= 35)
            {
                rights += " or a President";
            }
            Console.WriteLine("At this age, you can " + rights + ".");
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
