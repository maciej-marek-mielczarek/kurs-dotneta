using System;

namespace _03_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
		if(args.Length == 2)
		{
			double x = double.Parse(args[0]);
			double y = double.Parse(args[1]);
			double diagonal = 
				Math.Sqrt(
					Math.Pow(x,2)
				       	+ Math.Pow(y,2));
			Console.WriteLine($"The diagonal of a rectangle with sides {x} and {y} is {diagonal}");
		}
		else
		{
			Console.WriteLine("Please supply exactly 2 command line parameters, like so:");
			Console.WriteLine("dotnet run -- 1.5 2");
			Console.WriteLine("The program will then return just the answer without asking any more questions.");
		}
        }
    }
}
