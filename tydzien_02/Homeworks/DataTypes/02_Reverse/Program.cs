using System;

namespace _02_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
		unsafe
		{
		char*[] b = new char*[3];
		{
			char a = 'x';
			Console.WriteLine($"Value: {a}, address: {new IntPtr(&a)} of first 'a'");
			b[0] = &a;
		}
		{
			char a = 'y';
			Console.WriteLine($"Value: {a}, address: {new IntPtr(&a)} of second 'a'");
			b[1] = &a;
		}
		{
			char a = 'z';
			Console.WriteLine($"Value: {a}, address: {new IntPtr(&a)} of third 'a'");
			b[2] = &a;
		}
		Console.WriteLine($"Value: {*(b[2])}, address: {new IntPtr(b[2])} of third 'a'");
		Console.WriteLine($"Value: {*(b[1])}, address: {new IntPtr(b[1])} of second 'a'");
		Console.WriteLine($"Value: {*(b[0])}, address: {new IntPtr(b[0])} of first 'a'");
		Console.WriteLine("If the addresses match, then the exact same variables were written both times (no chars were copied).");
		}
        }
    }
}
