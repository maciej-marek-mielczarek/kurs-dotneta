using D6;
using System;

namespace D5
{
    public class D5
    {
        private static readonly D6.D6 baseDice = new D6.D6();
        public int Roll()
        {
            int rollResult;
            do
            {
                rollResult = baseDice.Roll();
            }
            while (rollResult == 6);
            return rollResult;
        }
    }
}