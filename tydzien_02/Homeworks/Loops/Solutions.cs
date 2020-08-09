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
            Console.WriteLine("I shall check how many prime numbers there are in the interval 0-100.");
            byte max = 100;
            bool[] isComposite = new bool[101];//Erathosteneses Sieve
            byte primesInRange = 0;
            for(byte divisor = 2; divisor <= max; ++divisor)
            {
                if (!isComposite[divisor])
                {
                    primesInRange++;
                    for (byte checkedNumber = (byte)(divisor + 1); checkedNumber <= max; ++checkedNumber)
                    {// if a and b are bytes, then a+b actually means (int)a+(int)b
                        if (!isComposite[checkedNumber] && checkedNumber % divisor == 0)
                        {
                            isComposite[checkedNumber] = true;
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
            throw new NotImplementedException();
        }

        internal static void Ex08()
        {
            throw new NotImplementedException();
        }

        internal static void Ex09()
        {
            throw new NotImplementedException();
        }

        internal static void Ex10()
        {
            throw new NotImplementedException();
        }
    }
}
