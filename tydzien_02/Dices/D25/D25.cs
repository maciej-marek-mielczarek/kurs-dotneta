using D5;
using System;

namespace D25
{
    public class D25
    {
        private static readonly D5.D5 baseDice1 = new D5.D5();
        private static readonly D5.D5 baseDice2 = new D5.D5();
        public int Roll()
        {
            return (baseDice1.Roll() - 1) * 5 + baseDice2.Roll();
        }
    }
}