using System;
using System.Collections.Generic;

namespace _01_EmployeeData
{
    public class Program
    {
        public static void Main(string[] args)
        {
	    Console.Write("Enter employee's name: ");
		string name = Console.ReadLine();

		Console.Write("Enter employee's surname: ");
		string surname = Console.ReadLine();

		Console.Write("Enter employee's age: ");
		byte age = Byte.Parse(Console.ReadLine());

		Console.Write("Enter employee's Personal Id: ");
		string personalIdString = Console.ReadLine();
		List<byte> personalId = new List<byte>();
		foreach(char digit in personalIdString)
		{
			personalId.Add( (byte) (digit - '0') );
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
		Console.Write($"{name} {surname}'s Personal Id is ");
		foreach(byte digit in personalId)
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
