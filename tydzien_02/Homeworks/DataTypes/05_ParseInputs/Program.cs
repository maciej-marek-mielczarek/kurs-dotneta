using System;

namespace _05_ParseInputs
{
    class Program
    {
	    private static readonly string ask = "What is your ";
	    
	    private static readonly string[] questions = 
	    {
		    "name",//string
		    "surname",//string
		    "age",//byte
		    "phone number",//byte[]
		    "email address",//Net.Mail.MailAddress
		    "mood today? It's good, isn't it (true/false)",//bool
		    "height in meters",//single, also known as float
		    "date of birth",//DateTime
		    "favourite galaxy's volume in liters",//double; some 2e51 (give or take an order of magnitude) for the Milky Way
	    };
	    
	    private static object[] answers = new object[9];

        static void Main(string[] args)
        {
		Console.Write($"{ask}{questions[0]}? ");
		answers[0] = Console.ReadLine();

		Console.Write($"{ask}{questions[1]}? ");
                answers[1] = Console.ReadLine();

		Console.Write($"{ask}{questions[2]}? ");
                answers[2] = byte.Parse(Console.ReadLine());

		Console.Write($"{ask}{questions[3]}? ");
		{
			// hide local vars
                	string phoneNumber = Console.ReadLine();
			int parsedDigits = 0;
			answers[3] = new byte[phoneNumber.Length];
			foreach(var digit in phoneNumber)
			{
				( (byte[]) (answers[3]) )[parsedDigits++] = (byte) (digit - '0');
			}
		}

		Console.Write($"{ask}{questions[4]}? ");
                answers[4] = new System.Net.Mail.MailAddress(Console.ReadLine());

		Console.Write($"{ask}{questions[5]}? ");
                answers[5] = bool.Parse(Console.ReadLine());

		Console.Write($"{ask}{questions[6]}? ");
                answers[6] = float.Parse(Console.ReadLine());
	
		Console.WriteLine($"Today is {DateTime.Today}");
		Console.Write($"{ask}{questions[7]}? ");
                answers[7] = DateTime.Parse(Console.ReadLine());
	
		Console.Write($"{ask}{questions[8]}? ");
                answers[8] = double.Parse(Console.ReadLine());

		Console.WriteLine("\nYour answers:");

		for(int index = 0; index < questions.Length; ++index)
		{
			if(index == 3)
			{
				Console.Write("phone number is ");
				foreach(var digit in (byte[])(answers[index]))
				{
					Console.Write(digit);
				}
				Console.Write(". ");
			}
			else
			{
				Console.Write($"{questions[index]} is {answers[index]}. ");
			}
			Console.WriteLine("The answer was stored in a {0}", answers[index].GetType());
		}
        }
    }
}
