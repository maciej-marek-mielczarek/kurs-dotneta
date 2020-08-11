using System;
namespace Conversion
{
    public class Foo
    {
        public int a{ get; set; }

        public Foo(int A)
        {
            a = A;
        }

        public static implicit operator Bar(Foo f) => new Bar(f.a);
    }
}
