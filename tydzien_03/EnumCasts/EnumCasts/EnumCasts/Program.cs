using System;
using System.Collections.Generic;

namespace EnumCasts
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = A.x;
            Enum b = a;//works
            Console.WriteLine(b);

            Dictionary<Enum, string> fff = new Dictionary<Enum, string>() { {A.y, "asd" },{B.r, "wed" },{B.w, "pp" } };
            Console.WriteLine(fff[B.r]);//also works

            Dictionary<A, string> sss = new Dictionary<A, string>() { {A.x, "123" },{ A.y, "456"},{A.z, "789" } };
            //Dictionary<Enum, string> pairs = sss;//doesn't work
            //Console.WriteLine(pairs[A.x]);
        }
    }
    public enum A
    {
        x,
        y,
        z
    }
    public enum B
    {
        q,
        w,
        e,
        r
    }
}
