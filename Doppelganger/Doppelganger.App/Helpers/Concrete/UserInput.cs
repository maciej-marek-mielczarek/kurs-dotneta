using System;
using Doppelganger.App.Helpers.Abstract;

namespace Doppelganger.App.Helpers.Concrete
{
    public class UserInput: IUserInput
    {
        public char GetChar(string possibleChoices)
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

        public int CharDigitToInt(char v)
        {
            if (v >= '0' && v <= '9')
            {
                return v - '0';
            }
            else if (v >= 'a' && v <= 'z')
            {
                return v - 'a' + 10;
            }
            else if (v >= 'A' && v <= 'Z')
            {
                return v - 'A' + 10;
            }
            else
            {
                throw new ArgumentException("Expected a Latin character or a number, got: " + v);
            }
        }
    }
}