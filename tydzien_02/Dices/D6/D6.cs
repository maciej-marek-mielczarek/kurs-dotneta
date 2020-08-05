using System;

namespace D6
{
    public class D6
    {
        private const int lowestFace = 1;
        private const int highestFace = 6;
        private static readonly Random numberGenerator = new Random();
        public int Roll()
        {
            return numberGenerator.Next(lowestFace, highestFace + 1);
        }
    }
}