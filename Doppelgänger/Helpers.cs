using System;

namespace Doppelgänger
{
    internal static class Helpers
    {
        internal static char GetChar(string possibleChoices)
        {//Not "try to get a correct char", rather "try until you get a correct char".
            char choice;
            bool madeChoice;
            do
            {
                madeChoice = char.TryParse(Console.ReadKey().KeyChar.ToString(), out choice);
                Console.Write("\b \b");
            }
            while (!madeChoice || !possibleChoices.Contains(choice));
            return choice;
        }

        internal static void ClearLine(int lineLength = 80)
        {
            string enoughSpaces = new string(' ', lineLength);
            Console.Write('\r' + enoughSpaces + '\r');
        }
    }
}