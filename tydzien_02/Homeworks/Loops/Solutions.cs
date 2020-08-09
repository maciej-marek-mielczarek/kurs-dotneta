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
            throw new NotImplementedException();
        }

        internal static void Ex03()
        {
            throw new NotImplementedException();
        }

        internal static void Ex04()
        {
            throw new NotImplementedException();
        }

        internal static void Ex05()
        {
            throw new NotImplementedException();
        }

        internal static void Ex06()
        {
            throw new NotImplementedException();
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
