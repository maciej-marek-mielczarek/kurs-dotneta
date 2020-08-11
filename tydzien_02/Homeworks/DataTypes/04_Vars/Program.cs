using System;
using System.Drawing;

namespace _04_Vars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            object[] all = new object[5];
            byte wholeNumber;
            decimal fractionalNumber;
            string words;
            Uri joke;
            Image image;

            wholeNumber = 10;
            words = "Szkoła Dotneta";
            joke = new Uri("https://szkoladotneta.pl/");
            fractionalNumber = 12.5M;
            image = Image.FromFile("a.bmp");

            all[0] = wholeNumber;
            all[1] = words;
            all[2] = fractionalNumber;
            all[3] = joke;
            all[4] = image;

            foreach (var item in all)
            {
                Console.WriteLine($"{item} stored in a {item.GetType()}");
            }
        }
    }
}
