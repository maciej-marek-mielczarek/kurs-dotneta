using System;
using System.Collections.Generic;

namespace _01_EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
	       	Console.Write("Enter employee's name: ");
		string name = Console.ReadLine();

		Console.Write("Enter employee's surname: ");
		string surname = Console.ReadLine();

		Console.Write("Enter employee's age: ");
		byte age = Byte.Parse(Console.ReadLine());

		Console.Write("Enter employee's SSN: ");
		string ssnString = Console.ReadLine();
		List<byte> ssn = new List<byte>();
		foreach(char digit in ssnString)
		{
			ssn.Add( (byte) (digit - '0') );
		}

		Console.Write("Enter employee's number: ");
		string idString = Console.ReadLine();
		List<byte> id = new List<byte>();
		foreach(char digit in idString)
		{
			id.Add( (byte) (digit - '0') );
		}

		Console.Write("Enter employee's sex ('m'/'w'): ");
		char sex = Convert.ToChar(Console.Read());

		Console.WriteLine($"{name} {surname} is age {age}.");
		Console.Write($"{name} {surname}'s ssn is ");
		foreach(byte digit in ssn)
		{
			Console.Write(digit);
		}
		Console.WriteLine(".");
		Console.Write($"{name} {surname}'s employee number is ");
	       	foreach(byte digit in id)
		{
			Console.Write(digit);
		}
		Console.WriteLine(".");
		Console.WriteLine($"{name} {surname} is a {(sex == 'm' || sex == 'M' ? "man" : "woman")}.");

        }
    }
}
