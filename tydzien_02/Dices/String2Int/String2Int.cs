using System;

namespace String2Int
{
    public static class String2Int
    {
        public static int Transform(string source)
        {
            int result = 0;
            for (int inputDigits = source.Length, processedDigits = 0; processedDigits < inputDigits; ++processedDigits)
            {
                result *= 10;
                result += source[processedDigits] - '0';
            }
            return result;
        }
    }
}
