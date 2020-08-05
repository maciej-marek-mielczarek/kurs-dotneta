using System;

namespace TicTacToe
{
    class Program
    {
        private const string welcomeMessage = "This application lets you play Tic-Tac-Toe. What do you want to do?";
        private static readonly string[] menuOptions =
        {
            "1. Start a new game.",
            "2. Load game.",
            "3. Exit."
        };
        static void Main(string[] args)
        {
            int menuChoice;
            do
            {
                Console.WriteLine(welcomeMessage);
                foreach (string option in menuOptions)
                {
                    Console.WriteLine(option);
                }
                menuChoice = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"You have chosen the option number {menuChoice}");
            }
            while (menuChoice != 3);
        }
    }
}
