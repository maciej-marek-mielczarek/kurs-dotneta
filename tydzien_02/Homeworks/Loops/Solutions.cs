using System;
namespace Loops
{
    public class Solutions
    {
        internal static readonly int numberOfSolutions = 10;

        public Solutions()
        {
        }

        internal static void Ex01()
        {
            const byte max = 100;
            Console.WriteLine($"I shall check how many prime numbers there are in the interval 0-{max}.");
            byte sqrtOfMax = (byte) Math.Sqrt(max);
            bool[] isComposite = new bool[max+1];//Erathosteneses Sieve
            byte primesInRange = 0;
            for(byte divisor = 2; divisor <= max; ++divisor)
            {
                if (!isComposite[divisor])
                {
                    primesInRange++;
                    if (divisor <= sqrtOfMax)
                    {//every composite number <= n has a prime divisor <= sqrt(n)
                        //so don't check divisors greater than sqrt(n)
                        for (byte multipleOfDivisor = (byte)(divisor * divisor); multipleOfDivisor <= max; multipleOfDivisor += divisor)
                        {//no overflow in squaring, because divisor is at most sqrt(n)
                            isComposite[multipleOfDivisor] = true;
                        }
                    }
                }
            }

            Console.WriteLine("There are " + primesInRange + " primes in range 0-" + max);
        }

        internal static void Ex02()
        {
            Console.WriteLine("I shall write all even numbers from 0 to 1000.");
            ushort n = 0, max = 1000;
            do
            {
                if (n % 2 == 0)
                {
                    Console.Write(n + (n == max ? "" : ", "));
                }
            } while (++n <= max);
            //preincrement: first increase n,
            //then check the condition with the increased n
            Console.WriteLine();
        }

        internal static void Ex03()
        {
            Console.WriteLine("I shall display consecutive Fibonacci numbers, starting with the 1st. Which one should I end with?"); 
            Console.WriteLine("The max I will allow is 92.");
            byte maxIdx = GetByte();//index
            if(maxIdx > 92)
            {
                Console.WriteLine("Let's keep the numbers down to 64 bits.");
                maxIdx = 92;
            }
            ulong next, curr = 1, prev = 0;
            for (byte idx = 1; idx <= maxIdx; idx++)
            {
                Console.WriteLine("F(" + idx + ") = " + curr);
                if(curr > ulong.MaxValue - prev)
                {
                    throw new OverflowException();
                }
                //Calculate next number:
                next = curr + prev;
                //Move up the index
                prev = curr;
                curr = next;
            }
        }

        private static byte GetByte()
        {
            return byte.Parse(Console.ReadLine());
        }

        internal static void Ex04()
        {
            Console.WriteLine("I shall draw a pyramid. What should be its height?");
            Console.WriteLine("Please note that I don't know how much horizontal space you have.");
            byte maxHeight = GetByte();
            const byte reasonableHeightLimit = 20;
            if(maxHeight > reasonableHeightLimit)
            {
                Console.WriteLine("That's unlikely to fit in your console, but whatever you wish.");
            }
            //ints, because calculations on bytes go through ints anyway
            //biggest numer in the pyramid:
            int maxBlock = maxHeight * (maxHeight + 1) / 2;
            //how many digits it has, plus one space between numbers (for alignment)
            int blockSize = (int)Math.Ceiling(Math.Log10(maxBlock)) + 1;
            int currentBlockNumber = 0;
            for(byte currentHeight = 1; currentHeight <= maxHeight; currentHeight++)
            {
                string floor = "";
                for(byte floorWidth = 1; floorWidth <= currentHeight; floorWidth++)
                {//print next block
                    currentBlockNumber++;
                    string block = "" + currentBlockNumber;
                    block = block.PadRight(blockSize);
                    floor += block;
                }
                Console.WriteLine(floor);
            }
        }

        internal static void Ex05()
        {
            const int min = 1, max = 20;
            Console.WriteLine($"I shall display the cubes of numbers from {min} to {max}.");
            for(int n = min; n <= max; ++n)
            {
                Console.WriteLine(Cube(n));
            }
        }

        private static int Cube(int n)
        {
            return n * n * n;
        }

        internal static void Ex06()
        {
            const int min = 0, max = 20;
            Console.WriteLine($"I shall calculate the sum of a series 1/(n+1) for n from {min} to {max}");
            //basically, unless it represents money, it doesn't need to be decimal
            double sum = 0;
            for (int n = min; n <= max; ++n)
            {
                sum += 1 / (n + 1d);//+1d also does the conversion to double
            }
            Console.WriteLine("Result = " + sum);
        }

        internal static void Ex07()
        {
            Console.WriteLine("I shall draw a diamond. What should be its size?");
            Console.WriteLine("Note that if you pick a size greater than 20, it probably won't look pretty in your console.");
            byte size = GetByte();
            for (int floorNumber = 1; floorNumber <= size; floorNumber++)
            {
                DrawFloor(size, floorNumber);
            }
            for (int floorNumber = size - 1; floorNumber >= 1; floorNumber--)
            {
                DrawFloor(size, floorNumber);
            }
        }

        private static void DrawFloor(byte size, int floorNumber)
        {
            string floor = "";
            int numberOfStars = (floorNumber * 2) - 1;
            //from start of the line to one space after the final star
            int floorSize = (size * 2) + (2 * (floorNumber - 1));
            floor = floor
            .PadRight(numberOfStars)//create the correct number of characters
            .Replace(" ", "* ")//now make them the correct type
                .PadLeft(floorSize);//and add the spaces to the front
            Console.WriteLine(floor);
        }

        internal static void Ex08()
        {
            Console.WriteLine("Please write something and I'll write it back in reverse.");
            string input = Console.ReadLine(), output = "";
            if (input.Length < 2)
            {
                output = input;
            }
            else
            {
                //There arre special rules for 1st and last char
                char firstChar = input[0], lastChar = input[input.Length - 1];
                if (char.IsLower(lastChar) && char.IsUpper(firstChar))
                {
                    //if input started with a Capital Letter,
                    //don't let output start with a lowercase letter
                    output += char.ToUpper(lastChar);
                }
                else
                {
                    output += lastChar;
                }
                for (int idx = input.Length - 2; idx > 0; --idx)
                {
                    //skip 1st and last char,
                    //they get special treatment outside the loop
                    output += input[idx];
                }
                if (char.IsUpper(firstChar) && char.IsLower(lastChar))
                {
                    //if input endee with a lowercase letter
                    //don't let output end with a Capital Letter
                    output += char.ToLower(firstChar);
                }
                else
                {
                    output += firstChar;
                }
            }
            Console.WriteLine(output);
        }

        internal static void Ex09()
        {
            Console.WriteLine("Write a positive integer decimal number,\nand I'll return it's binary representation.");
            Console.WriteLine("Please keep your number down to " + ulong.MaxValue);
            ulong input = GetULong();
            string output = "";
            while(input > 0)
            {
                //probably much faster
                //to add new chars on the other side and then reverse
                //but the time of communicating with a human makes that irrelevant
                output = (input % 2) + output;
                input /= 2;
            }
            Console.WriteLine(output);
        }

        private static ulong GetULong()
        {
            return ulong.Parse(Console.ReadLine());
        }

        internal static void Ex10()
        {
            Console.WriteLine("Give me 2 numbers and I'll find their lowest common multiple.");
            Console.WriteLine("Your numbers should be non-negative and no larger than " + uint.MaxValue);
            uint a = GetUInt(), b = GetUInt();
            ulong lcm;
            if (a == 0 && b == 0)
            {
                lcm = 0;
            }
            else
            {
                lcm = (ulong)a * (ulong)b / (ulong)GCD(a, b);
            }
            Console.WriteLine($"LCM of {a} and {b} is " + lcm);
        }

        private static uint GCD(uint a, uint b)
        {
            if (a == 1 || b == 1)
            {
                return 1;
            }
            else if (a == 0 || b == 0)
            {
                return a + b;
            }
            else if (a > b)
            {
                return GCD(b, a % b);
            }
            else
            {
                return GCD(a, b % a);
            }
        }

        private static uint GetUInt()
        {
            return uint.Parse(Console.ReadLine());
        }
    }
}
