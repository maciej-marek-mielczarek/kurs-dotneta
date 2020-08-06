using System;

namespace _04_Vars
{
    class Program
    {
        static void Main(string[] args)
        {
		object[] all = new object[4];
		byte wholeNumber;
		decimal fractionalNumber;
		string words;
		Uri joke;

		wholeNumber = 10;
		words = "Szkoła Dotneta";
		joke = new Uri("https://szkoladotneta.pl/");
		fractionalNumber = 12.5M;

		all[0] = wholeNumber;
		all[1] = words;
		all[2] = fractionalNumber;
		all[3] = joke;

		foreach(var item in all)
		{
			Console.WriteLine($"{item} stored in a {item.GetType()}");
		}
        }
    }
}
